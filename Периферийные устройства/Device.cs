using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Периферийные_устройства
{
    //Объявление класса Device для управления периферийными устройствами
    class Device 
    {
        //Приватное поле для хранения списка периферийных устройств
        private List<Peripherals> peripherals = new List<Peripherals>();
        //Метод для добавления нового периферийного устройства в список
        public void AddPeripheral()
        {
            //Запрашиваем данные о новом устройстве от пользователя
            do
            {
                Console.Write("Введите название компании: ");
                string name = Console.ReadLine();
                Console.Write("Введите тип устройства: ");
                string type = Console.ReadLine();
                Console.Write("Введите страну производства: ");
                string country = Console.ReadLine();
                Console.Write("Введите год производства: ");
                int year = Convert.ToInt32(Console.ReadLine());
                // Создаем новый объект периферийного устройства на основе введенных данных
                Peripherals newPeripheral = new Supplement(name, type, country, year);
                peripherals.Add(newPeripheral);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Периферийное устройство успешно добавлено в список.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nХотите добавить еще устройство? (да/нет)");
            }
            while (Console.ReadLine().ToLower() == "да");
            Console.WriteLine("\nНажмите Enter для выхода в главное меню...");
            Console.ReadLine(); 
            Console.Clear();
        }
        //Метод для отображения всех устройств в списке и предоставления пользователю опций для управления списком
        public void DisplayAllDevices()
        {
            //Вывод информации о каждом устройстве в списке
            foreach (var device in peripherals)
            {
                device.Show();
            }
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить устройство в начало списка");
            Console.WriteLine("2. Добавить устройство в конец списка");
            Console.WriteLine("3. Добавить устройство после определенного устройства");
            Console.WriteLine("4. Добавить устройство перед определенным устройством");
            Console.WriteLine("5. Удалить устройство из списка");
            Console.WriteLine("6. Показать устройства определенного типа");
            Console.WriteLine("7. Показать устройства отсортированные по годам производства");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. Вернуться в главное меню");
            Console.ForegroundColor = ConsoleColor.White;
            //Чтение выбора пользователя и вызов соответствующего метода
            int choice = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddDeviceToBeginning();
                    break;
                case 2:
                    Console.Clear();
                    AddDeviceToEnd();
                    break;
                case 3:
                    Console.Clear();
                    AddDeviceAfter();
                    break;
                case 4:
                    Console.Clear();
                    AddDeviceBefore();
                    break;
                case 5:
                    Console.Clear();
                    RemoveDevice();
                    break;
                case 6:
                    Console.Clear();
                    ShowDevicesByType();
                    break;
                case 7:
                    Console.Clear();
                    DisplayDevicesSortedByYear();
                    break;
                case 8:
                    Console.Clear();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
        // метод для добавления устройства в начало списка
        public void AddDeviceToBeginning()
        {
            Console.WriteLine("Введите данные для нового устройства:");
            Console.Write("Введите название компании: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип устройства: ");
            string type = Console.ReadLine();
            Console.Write("Введите страну производства: ");
            string country = Console.ReadLine();
            Console.Write("Введите год производства: ");
            int year = Convert.ToInt32(Console.ReadLine());
            //Создаем новый объект устройства и добавляем его в начало списка
            Peripherals newPeripheral = new Supplement(name, type, country, year);
            peripherals.Insert(0, newPeripheral); // Вставляем устройство в начало списка
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Устройство успешно добавлено в начало списка.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DisplayAllDevices();
        }
        // метод для добавления устройства в конец списка
        public void AddDeviceToEnd()
        {
            Console.WriteLine("Введите данные для нового устройства:");
            Console.Write("Введите название компании: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип устройства: ");
            string type = Console.ReadLine();
            Console.Write("Введите страну производства: ");
            string country = Console.ReadLine();
            Console.Write("Введите год производства: ");
            int year = Convert.ToInt32(Console.ReadLine());
            //Создаем новый объект устройства и добавляем его в конец списка
            Peripherals newPeripheral = new Supplement(name, type, country, year);
            peripherals.Add(newPeripheral);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Устройство успешно добавлено в конец списка.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DisplayAllDevices();
        }
        // метод для добавления устройства после определенного типа 
        public void AddDeviceAfter()
        {
            Console.Write("Введите тип устройства, после которого нужно добавить новое устройство: ");
            string deviceTypeToInsertAfter = Console.ReadLine();
            Console.WriteLine("Введите данные для нового устройства:");
            Console.Write("Введите название компании: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип устройства: ");
            string type = Console.ReadLine();
            Console.Write("Введите страну производства: ");
            string country = Console.ReadLine();
            Console.Write("Введите год производства: ");
            int year = Convert.ToInt32(Console.ReadLine());
            //Создаем новый объект устройства и добавляем его после определенного типа
            Peripherals newPeripheral = new Supplement(name, type, country, year);
            //Определение переменной index, которая будет содержать индекс первого вхождения элемента в списке, удовлетворяющего условию, заданному в лямбда-выражении
            int index = peripherals.FindIndex(device => device.Type == deviceTypeToInsertAfter);
            // Проверка, найдено ли устройство с заданным типом в списке
            if (index != -1)
            {
                //Вставка нового устройства в список после устройства с заданным типом
                peripherals.Insert(index + 1, newPeripheral);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Устройство успешно добавлено после устройства типа '{deviceTypeToInsertAfter}'.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Устройство с типом '{deviceTypeToInsertAfter}' не найдено в списке.");
            }
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DisplayAllDevices();
        }
        // метод для добавления устройства перед определенным типом
        public void AddDeviceBefore()
        {
            Console.Write("Введите тип устройства, перед которым нужно добавить новое устройство: ");
            string deviceTypeToInsertBefore = Console.ReadLine();
            Console.WriteLine("Введите данные для нового устройства:");
            Console.Write("Введите название компании: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип устройства: ");
            string type = Console.ReadLine();
            Console.Write("Введите страну производства: ");
            string country = Console.ReadLine();
            Console.Write("Введите год производства: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Peripherals newPeripheral = new Supplement(name, type, country, year);
            //Определение переменной index, которая будет содержать индекс первого вхождения элемента в списке, удовлетворяющего условию, заданному в лямбда-выражении
            int index = peripherals.FindIndex(device => device.Type == deviceTypeToInsertBefore);
            //Проверка, найдено ли устройство с заданным типом в списке
            if (index != -1)
            {
                //Вставка нового устройства в список перед устройством с заданным типом
                peripherals.Insert(index, newPeripheral);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Устройство успешно добавлено перед устройством типа '{deviceTypeToInsertBefore}'.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Устройство типа '{deviceTypeToInsertBefore}' не найдено в списке.");
            }
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DisplayAllDevices();
        }
        // метод для удаления устройства из списка
        public void RemoveDevice()
        {
            Console.WriteLine("Список устройств:");
            //Цикл для перебора всех элементов в списке устройств
            for (int i = 0; i < peripherals.Count; i++)
            {
                //Вывод информации о каждом устройстве в формате "номер. Название, Тип, Страна, Год"
                Console.WriteLine($"{i + 1}. {peripherals[i].Name}, {peripherals[i].Type}, {peripherals[i].Country}, {peripherals[i].Year}");
            }

            Console.Write("\nВведите номер устройства для удаления: ");
            //Переменная для хранения номера устройства, введенного пользователем
            int deviceNumber;
            //Проверка, успешно ли удалось преобразовать введенное значение в целое число, и находится ли введенный номер в допустимом диапазоне (от 1 до количества устройств в списке)
            if (int.TryParse(Console.ReadLine(), out deviceNumber) && deviceNumber >= 1 && deviceNumber <= peripherals.Count)
            {
                // Индекс устройства в списке (с учетом того, что пользователи нумеруют устройства с 1)
                int index = deviceNumber - 1;

                // Удаляем устройство из списка по найденному индексу
                peripherals.RemoveAt(index);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Устройство номер {deviceNumber} успешно удалено из списка.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный номер устройства.");
            }

            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DisplayAllDevices();
        }
        //метод для поиска устройств определенного типа
        public void ShowDevicesByType()
        {
            Console.Write("Введите тип устройства для вывода: ");
            string deviceType = Console.ReadLine();
            //Фильтрация списка устройств, чтобы получить только те устройства, у которых тип соответствует введенному типу
            List<Peripherals> devicesOfType = peripherals.Where(device => device.Type.Equals(deviceType, StringComparison.OrdinalIgnoreCase)).ToList();
            //Проверка, найдены ли устройства заданного типа
            if (devicesOfType.Count > 0)
            {
                //Если найдены, выводим заголовок и информацию об устройствах заданного типа
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Устройства типа '{deviceType}':");
                Console.ForegroundColor = ConsoleColor.White;
                //Вывод информации о каждом устройстве заданного типа
                foreach (var device in devicesOfType)
                {
                    device.Show();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Устройства типа '{deviceType}' не найдены.");
            }
            // Ожидание нажатия клавиши Enter для продолжения
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            //Повторное отображение списка устройств и доступных операций
            DisplayAllDevices();

        }
        //метод для вывода устройств, отсортированных по годам производства
        public void DisplayDevicesSortedByYear()
        {
            //Проверка, содержит ли список устройств хотя бы одно устройство
            if (peripherals.Count > 0)
            {
                //Если список не пуст, сортируем устройства по году производства
                var sortedDevices = peripherals.OrderBy(device => device.Year);
                Console.WriteLine("Устройства, отсортированные по годам производства:");
                foreach (var device in sortedDevices)
                {
                    device.Show();
                }
            }
            else
            {
                Console.WriteLine("Список устройств пуст.");
            }
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DisplayAllDevices();
           
        }
        //метод для вывода из списка устройств только мониторы 
        public void SaveMonitorsToFile()
        {
            string file = @"E:\Периферийные устройства\monitor.bin";
            try
            {
                //Фильтрация списка устройств, чтобы получить только мониторы
                List<Peripherals> monitors = peripherals.Where(device => device.Type.Equals("Монитор", StringComparison.OrdinalIgnoreCase)).ToList();
                if (monitors.Count > 0)
                {
                    Console.WriteLine("Список мониторов:");
                    foreach (var monitor in monitors)
                    {
                        Console.WriteLine($"Название: {monitor.Name}, Тип: {monitor.Type}, Страна производства: {monitor.Country}, Год производства: {monitor.Year}");
                    }
                }
                else
                {
                    Console.WriteLine("Мониторы не найдены.");
                }
                // Запись данных о мониторах в бинарный файл
                using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Create)))
                {
                    //Проход по всем устройствам в списке
                    foreach (Peripherals peripheral in peripherals)
                    {
                        //Проверка, является ли устройство монитором
                        if (peripheral.Type.Equals("Монитор", StringComparison.OrdinalIgnoreCase))
                        {
                            //Если устройство монитор, записываем его данные в файл
                            if (peripheral is Supplement supplement)
                            {
                                // Записываем данные в бинарный файл
                                writer.Write(supplement.Name);
                                writer.Write(supplement.Type);
                                writer.Write(supplement.Country);
                                writer.Write(supplement.Year);
                            }
                        }
                    }
                }
                Console.WriteLine("Данные о мониторах успешно сохранены в файл.");
            }
            catch (Exception error)
            {
                //  Обработка и вывод сообщения об ошибке при сохранении данных в файл
                Console.WriteLine($"Ошибка при сохранении данных в файл: {error.Message}");
            }
            Console.ReadLine();
            Console.Clear();
        }
        // Метод для загрузки данных из файла
        public void LoadDataFromFile(Device device)
        {
            string file = @"E:\Периферийные устройства\device.bin";
            try
            {
                //Проверка, существует ли файл с данными
                if (File.Exists(file))
                {
                    // Если файл существует, открываем его для чтения
                    using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
                    {
                        // Читаем данные из бинарного файла и создаем объекты
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            string name = reader.ReadString();
                            string type = reader.ReadString();
                            string country = reader.ReadString();
                            int year = reader.ReadInt32();
                            //Создание нового объекта периферийного устройства на основе прочитанных данных
                            Supplement supplement = new Supplement(name, type, country, year);
                            //Добавление созданного устройства в список периферийных устройств устройства
                            device.peripherals.Add(supplement);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файл с данными не найден. Создан новый файл.");
                    File.Create(file).Close();
                }
            }
            catch (Exception error)
            {
                //Обработка и вывод сообщения об ошибке при загрузке данных из файла
                Console.WriteLine($"Ошибка при загрузке данных из файла: {error.Message}");
            }
        }
        // Метод для сохранения данных в файл
        public void SaveDataToFile(Device device)
        {
            string file = @"E:\Периферийные устройства\device.bin";
            try
            {
                //Открытие файла для записи данных в бинарном формате
                using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Create)))
                {
                    //Проход по всем периферийным устройствам в списке устройств
                    foreach (Peripherals peripheral in device.peripherals)
                    {
                        //Проверка, является ли устройство экземпляром класса Supplement (подклассом Peripherals)
                        if (peripheral is Supplement supplement)
                        {
                            // Записываем данные в бинарный файл
                            writer.Write(supplement.Name);
                            writer.Write(supplement.Type);
                            writer.Write(supplement.Country);
                            writer.Write(supplement.Year);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Ошибка при сохранении данных в файл: {error.Message}");
            }
        }
    }
}
