using System;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Globalization;
using System.Linq;

namespace TemHum
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort SP = new SerialPort();
            var isOpen = SerialSetting(SP);

            SP.Close();
            SP.Open();

            isOpen = SP.IsOpen;
            if (isOpen)
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

        public static bool SerialSetting(SerialPort serialPort)
        {
            var portNum = 0;
            Console.Write("포트 번호를 입력하세요: COM");          
            int.TryParse(Console.ReadLine(), out portNum);

            serialPort.PortName = "COM" + portNum;
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.Handshake = Handshake.None;
            serialPort.RtsEnable = true;

            var portCheck = SerialPort.GetPortNames();           
            var checkPort = portCheck.Contains(serialPort.PortName);
            return checkPort;
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
