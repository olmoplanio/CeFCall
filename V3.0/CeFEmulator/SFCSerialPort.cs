using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public class SFCSerialPort: IServer
    {
        SerialPort serialPort;
        public string LastMessage { get; private set; }

        public SFCSerialPort(string portName = "COM1", int baudRate = 9600)
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.DataReceived += SerialPort_DataReceived;
        }
        
        public void Close()
        {
            serialPort.Close();
        }

        public void Listen()
        {

            try
            {
                serialPort.Open();
                Console.WriteLine("Serial port opened. Press any key to exit.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                serialPort.Close();
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (serialPort.BytesToRead > 0)
                {
                    int data = serialPort.ReadByte();
                    char receivedChar = (char)data;

                    if (receivedChar == 0x11) // XON character (ASCII code 17)
                    {
                        // XON received, resume data transmission
                        serialPort.Write(new byte[] { 0x11 }, 0, 1); // Send XON back to the sender
                        Console.WriteLine("Received XON, data transmission resumed.");
                    }
                    else if (receivedChar == 0x13) // XOFF character (ASCII code 19)
                    {
                        // XOFF received, pause data transmission
                        serialPort.Write(new byte[] { 0x13 }, 0, 1); // Send XOFF back to the sender
                        Console.WriteLine("Received XOFF, data transmission paused.");
                    }
                    else
                    {
                        // Handle received data as needed
                        Console.Write(receivedChar);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}