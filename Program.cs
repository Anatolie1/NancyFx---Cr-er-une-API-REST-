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
            
            List<Person> users = new List<Person>() 
            {
                new Person() { Id = 1, Name = "Vasea", Password = "2345"},
                new Person() { Id = 2, Name = "Iura", Password = "2345"},
                new Person() { Id = 3, Name = "Gulea", Password = "2345"},
                new Person() { Id = 4, Name = "Hui", Password = "2345"},
                new Person() { Id = 5, Name = "Vitea", Password = "2345"},
                new Person() { Id = 6, Name = "Coren", Password = "2345"},
            };
            
            SimpleModule.people.AddRange(users);
            p.Start();
        }
    }
}
