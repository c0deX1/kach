using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace Boss
{
    class Processor
    {
        List<IPAddress> m_ipAddresses = new List<IPAddress>();
        string m_exePath;
        string m_dataPath;
        const string m_outputPath = "C:\\output\\processor.txt";
        const string m_fullDataPath = "C:\\processor\\fullDataToSend.txt";
        const int m_port = 50000;
        const int bufferSize = 1024;

        public Processor(List<string> ipStrings, string exePath, string dataPath)
        {
            for (int i = 0; i < ipStrings.Count; i++)
                m_ipAddresses.Add(IPAddress.Parse(ipStrings[i]));
            m_exePath = exePath;
            m_dataPath = dataPath;
        }

        public string Start()
        {
            int workersAmm = m_ipAddresses.Count;
            if (workersAmm == 0)
            {
                string fullData = workersAmm.ToString() + Environment.NewLine + (workersAmm + 1).ToString()
                                    +Environment.NewLine + File.ReadAllText(m_dataPath);
                File.WriteAllText(m_fullDataPath, fullData);
                var process = Process.Start(m_exePath, "\"" + m_fullDataPath + "\" \"" + m_outputPath + "\"");
                process.WaitForExit();
                return File.ReadAllText(m_outputPath);
            }
            else
            {
                List<TcpClient> workersConnections = new List<TcpClient>();
                List<string> outputs = new List<string>();

                for (int i = 0; i < workersAmm; i++)
                {
                    TcpClient client = connectClient(m_ipAddresses[i], 50000);
                    workersConnections.Add(client);
                }

                for (int i = 0; i < workersAmm; i++)
                {
                    SendTask(workersConnections[i], i, workersAmm + 1);
                }

                string fullData = workersAmm.ToString() + Environment.NewLine + (workersAmm + 1).ToString()
                    + Environment.NewLine + File.ReadAllText(m_dataPath);
                File.WriteAllText(m_fullDataPath, fullData);
                var process = Process.Start(m_exePath, "\"" + m_fullDataPath + "\" \"" + m_outputPath + "\"");
                process.WaitForExit();
                outputs.Add(File.ReadAllText(m_outputPath));

                for (int i = 0; i < workersAmm; i++)
                {
                    byte[] output = ReadFile(workersConnections[i]);
                    File.WriteAllBytes(m_outputPath, output);
                    outputs.Add(File.ReadAllText(m_outputPath));
                }

                for (int i = 0; i < workersAmm; i++)
                {
                    workersConnections[i].GetStream().Close();
                    workersConnections[i].Close();
                }

                return ProcessWorkersOutput(outputs);
            }
        }

        private TcpClient connectClient(IPAddress ip, int port)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(new IPEndPoint(ip, port));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return client;
        }

        private void SendTask(TcpClient client, int myId, int clientsAmm)
        {
            NetworkStream netStream = client.GetStream();
            WriteFile(client, File.ReadAllBytes(m_exePath));
            string fullData = myId.ToString() + Environment.NewLine + clientsAmm.ToString() +
                Environment.NewLine + File.ReadAllText(m_dataPath);
            File.WriteAllText(m_fullDataPath, fullData);
            WriteFile(client, File.ReadAllBytes(m_fullDataPath));
        }

        private void WriteFile(TcpClient client, byte[] data)
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

        private byte[] ReadFile(TcpClient client)
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

        string ProcessWorkersOutput(List<string> workersOutputs)
        {
            int sum = 0;
            for (int i = 0; i < workersOutputs.Count; i++)
            {
                sum += Int32.Parse(workersOutputs[i]);
            }
                return sum.ToString();
        }
    }
}
