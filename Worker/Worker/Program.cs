using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Worker
{
    class Server
    {
        TcpListener listener;
 
        public Server(int Port)
        {
            listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();
 
            while (true)
            {
                new Client(listener.AcceptTcpClient());
            }
        }
 
        ~Server()
        {
            if (listener != null)
                listener.Stop();
        }
 
        static void Main(string[] args)
        {
            new Server(50000);
        }
    }

    class Client
    {
        int bufferSize = 1024;
        TcpClient client;
        string exeFile = "C:\\1.exe";
        string dataFile = "C:\\data.txt";
        string outputFile = "C:\\output.txt";

        private void WriteFile(byte[] data)
        {
            byte[] dataLength = BitConverter.GetBytes(data.Length);
            byte[] package = new byte[4 + data.Length];
            NetworkStream netStream = client.GetStream();
            dataLength.CopyTo(package, 0);
            data.CopyTo(package, 4);

            int bytesSent = 0;
            int bytesLeft = package.Length;

            while (bytesLeft > 0)
            {
                int nextPacketSize = (bytesLeft > bufferSize) ? bufferSize : bytesLeft;

                netStream.Write(package, bytesSent, nextPacketSize);
                bytesSent += nextPacketSize;
                bytesLeft -= nextPacketSize;
            }
        }

        private byte[] ReadFile()
        {
            NetworkStream netStream = client.GetStream();
            int allBytesRead = 0;

            byte[] length = new byte[4];
            int bytesRead = netStream.Read(length, 0, 4);
            int dataLength = BitConverter.ToInt32(length, 0);

            int bytesLeft = dataLength;
            byte[] data = new byte[dataLength];

            while (bytesLeft > 0)
            {

                int nextPacketSize = (bytesLeft > bufferSize) ? bufferSize : bytesLeft;

                bytesRead = netStream.Read(data, allBytesRead, nextPacketSize);
                allBytesRead += bytesRead;
                bytesLeft -= bytesRead;
            }
            return data;
        }

        public Client(TcpClient client)
        {
            this.client = client;
            byte[] exe = ReadFile();
            byte[] data = ReadFile();

            File.WriteAllBytes(exeFile, exe);
            File.WriteAllBytes(dataFile, data);

            var process = Process.Start(exeFile, dataFile + " " + outputFile);
            process.WaitForExit();
            WriteFile(File.ReadAllBytes(outputFile));

            Console.WriteLine("Sent");

            client.GetStream().Close();
            client.Close();
        }
    }
}
