using System;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Globalization;

namespace TemHum
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort SP = new SerialPort();
            SP.PortName = "COM5";
            SP.BaudRate = 9600;
            SP.DataBits = 8;
            SP.StopBits = StopBits.One;
            SP.Parity = Parity.None;
            SP.Handshake = Handshake.None;
            SP.RtsEnable = true;
            SP.Close();
            SP.Open();
                                    
            bool open = SP.IsOpen;
            if (open)
            {                   
                while (true)
                {
                    string sendMsg = ":80040004000375\r\n";
                    SP.Write(sendMsg);
                    Thread.Sleep(500);
                    string data = SP.ReadExisting();
                    if (data != string.Empty)
                    {                      
                        PrintTemHum(data);
                    }
                }            
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            SP.Close();
        }

        public static void PrintTemHum(string item)
        {
            string temp = item.Substring(11, 4);
            string humi = item.Substring(7, 4);
            string dewPoint = item.Substring(15, 4);

            var t = short.Parse(temp, NumberStyles.HexNumber, CultureInfo.InvariantCulture) * 0.01f;
            var h = short.Parse(humi, NumberStyles.HexNumber, CultureInfo.InvariantCulture) * 0.01f;
            var d = short.Parse(dewPoint, NumberStyles.HexNumber, CultureInfo.InvariantCulture) * 0.01f;

            Console.WriteLine(string.Format("온도: {0}, 습도: {1}, 이슬점: {2}", t, h, d));
        }
    }
}
