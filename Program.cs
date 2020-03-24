using System;
using Nancy.Hosting.Self;
using Nancy.Configuration;

namespace EcoConception
{
    class Program
    {
        private string _url = "http://localhost";
        private int _port = 1234;
        private NancyHost _nancy;

        public Program()
        {
            var uri = new Uri($"{_url}:{_port}/");
            _nancy = new NancyHost(uri);
        }
        private void Start()
        {
            _nancy.Start();
            Console.WriteLine($"Started listennig port {_port}");
            Console.ReadKey();
            _nancy.Stop();
        }
        static void Main(string[] args)
        {
            var p = new Program();
            p.Start();
        }
    }
}
