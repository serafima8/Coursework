using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Периферийные_устройства
{
    /// <summary>
    /// класс для добавления нового периферийного устройства 
    /// </summary>
    class Supplement : Peripherals
    {
        public Supplement() { }
        public Supplement(string name, string type, string country, int year): base(name, type, country, year) { }
        public override void Show()
        {
            Console.WriteLine($"Название компании: {Name}, Тип: {Type}, Страна производства: {Country}, Год производства: {Year}");
        }
    }
}
