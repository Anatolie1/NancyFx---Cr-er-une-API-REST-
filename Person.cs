using System;
using System.Collections.Generic;
using System.Text;

namespace EcoConception
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Password}";
        }
    }
}
