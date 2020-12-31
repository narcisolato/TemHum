﻿using System;
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
            var temHum = new TemHum();
            temHum.OpenSerial();
            temHum.ReadData();
        }
    }

    class TemHum
    {
        private static SerialPort SerialPort;
        public bool isOpen { get; private set; }
        
        public void OpenSerial()
        {
            SerialPort = new SerialPort();
            isOpen = SetSerialPort();

            if (isOpen)
            {
                SerialPort.Close();
                SerialPort.Open();
            }
            else
            {
                Console.WriteLine("해당 포트가 없습니다. 아무 키나 누르세요.");
                Console.ReadKey();
            }
        }

        public void ReadData()
        {
            isOpen = SerialPort.IsOpen;
            if (isOpen)
            {
                while (true)
                {
                    string sendMsg = ":80040004000375\r\n";
                    SerialPort.Write(sendMsg);
                    Thread.Sleep(500);
                    string data = SerialPort.ReadExisting();
                    if (data != string.Empty)
                    {
                        PrintTemHum(data);
                    }
                }
            }
            else
            {
                Console.WriteLine("포트가 열리지 않았습니다. 아무 키나 누르세요.");
                Console.ReadKey();
            }
            SerialPort.Close();
        }
        
        private bool SetSerialPort()
        {
            Console.Write("포트 번호를 입력하세요: COM");
            int.TryParse(Console.ReadLine(), out int portNum);

            SerialPort.PortName = "COM" + portNum;
            SerialPort.BaudRate = 9600;
            SerialPort.DataBits = 8;
            SerialPort.StopBits = StopBits.One;
            SerialPort.Parity = Parity.None;
            SerialPort.Handshake = Handshake.None;
            SerialPort.RtsEnable = true;

            var portCheck = SerialPort.GetPortNames();
            var checkPort = portCheck.Contains(SerialPort.PortName);
            return checkPort;
        }

        private void PrintTemHum(string item)
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
