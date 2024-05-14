using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Периферийные_устройства
{
    class Program
    {
        // Создание экземпляра класса Device для работы с периферийными устройствами
        static Device device = new Device();

        static void Main(string[] args)
        {
            //Загрузка данных о периферийных устройствах из файла при запуске программы
            device.LoadDataFromFile(device);
            //Бесконечный цикл для отображения меню и выполнения действий пользователя
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Добро пожаловать в информационную систему периферийных устройств");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Добавить в список периферийное устройство");
                Console.WriteLine("2. Посмотреть все устройства");
                Console.WriteLine("3. Посмотреть список, содержащий только мониторы");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("4. Выход");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Выберите действие: ");
                //Считывание выбора пользователя
                int choice = int.Parse(Console.ReadLine());
                // Обработка выбора пользователя
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
                        // Обработка выбора пользователя
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

