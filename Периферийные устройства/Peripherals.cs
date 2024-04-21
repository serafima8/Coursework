using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Периферийные_устройства
{
    abstract class Peripherals
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public Peripherals() { }
        public Peripherals(string name, string type, string country, int year)
        {
            this.Name = name;
            this.Type = type;
            this.Country = country;
            this.Year = year;
        }
        public abstract void Show();
    }
}
