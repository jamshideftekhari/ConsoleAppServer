using System;
using System.IO;
using System.Net.Sockets;
using ModelLibrary;
using Newtonsoft.Json;

namespace JsonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World it is client!");
            int counter = 1;
            Car clientCar = new Car{Color = "red",Model = "BMW",RegisterNumber = "BM 1234"};
            Console.WriteLine(clientCar);
            Console.WriteLine(JsonConvert.SerializeObject(clientCar));

            Console.WriteLine("Flushig Car?");
            FlushCar(clientCar, counter);
        }

        private static void FlushCar(Car clientCar, int counter)
        {
            Console.ReadLine();
            TcpClient clientSocket = new TcpClient("localhost", 10001);

            Stream ns = clientSocket.GetStream(); //provides a Stream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            // string message = Console.ReadLine();
           // string message = clientCar.ToString();
           string message = JsonConvert.SerializeObject(clientCar);
           Console.WriteLine("Json Message: " + message);
            while (!string.IsNullOrEmpty(message))
            {
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                while (serverAnswer != "_")
                {
                    Console.WriteLine("Server: " + serverAnswer);
                    serverAnswer = sr.ReadLine();
                }

                message = Console.ReadLine();
                counter++;
            }


            ns.Close();

            clientSocket.Close();
        }
    }
}
