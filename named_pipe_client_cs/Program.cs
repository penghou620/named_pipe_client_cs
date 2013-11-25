using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Pipes;
using System.IO;
namespace named_pipe_client_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            NamedPipeClientStream client = new NamedPipeClientStream(".", "my_pipe", PipeDirection.InOut);
            client.Connect();
            if (!client.IsConnected)
            {
                System.Console.Write("Failed to connect.");
                return;
            }
            System.Console.Write("Connected.");
            StreamReader sr = new StreamReader(client);
            char[] c = new char[200];

            while (sr.Peek() >= 0)
            {
                sr.Read(c, 0, c.Length);
            }
            string s = new string(c);
            System.Console.Write(s);
            System.Console.Read();
        }
    }
}
