using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Периферийные_устройства
{
    class Program
    {
        static Device device = new Device();

        static void Main(string[] args)
        {
            device.LoadDataFromFile(device);
            while (true)
            {
                Console.WriteLine("Добро пожаловать в информационную систему периферийных устройств");
                Console.WriteLine("1. Добавить в список периферийное устройство");
                Console.WriteLine("2. Посмотреть все устройства");
                Console.WriteLine("3. Посмотреть список, содержащий только мониторы");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        device.AddPeripheral();
                        device.SaveDataToFile(device);
                        break;
                    case 2:
                        Console.Clear();
                        device.DisplayAllDevices();
                        device.SaveDataToFile(device);
                        break;
                    case 3:
                        Console.Clear();
                        device.SaveMonitorsToFile();
                        break;
                    case 4:
                        device.SaveDataToFile(device);
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
                }
            }
        }
    }
}

