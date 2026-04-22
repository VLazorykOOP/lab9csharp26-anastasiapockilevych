using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab9CSharp
{
    class Task1_4
    {
        public void Run()
        {
            Console.WriteLine("\n=== ЗАВДАННЯ 1.4: Перевірка зворотного рядка (Stack) ===");

            Console.Write("Введіть рядок s1: ");
            string s1 = Console.ReadLine() ?? "";

            Console.Write("Введіть рядок s2: ");
            string s2 = Console.ReadLine() ?? "";

            Stack stack = new Stack();
            for (int i = 0; i < s1.Length; i++)
                stack.Push(s1[i]);

            if (s1.Length != s2.Length)
            {
                Console.WriteLine("Результат: рядок s2 НЕ є зворотним рядку s1 (різна довжина).");
                return;
            }

            bool isReverse = true;
            for (int i = 0; i < s2.Length; i++)
            {
                char top = (char)stack.Pop();
                if (top != s2[i])
                {
                    isReverse = false;
                    break;
                }
            }

            if (isReverse)
                Console.WriteLine($"Результат: рядок \"{s2}\" є зворотним рядку \"{s1}\".");
            else
                Console.WriteLine($"Результат: рядок \"{s2}\" НЕ є зворотним рядку \"{s1}\".");
        }
    }

    class Task2_4
    {
        private readonly string _basePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Lab9CSharp");

        public void Run()
        {
            Console.WriteLine("\n=== ЗАВДАННЯ 2.4: Позитивні та негативні числа (Queue) ===");
            Directory.CreateDirectory(_basePath);

            string inputFile = Path.Combine(_basePath, "input2_4.txt");

            if (!File.Exists(inputFile))
                File.WriteAllText(inputFile,
                    "5 -3 8 -1 0 12 -7 4 -9 2",
                    Encoding.UTF8);

            Console.WriteLine($"Читаємо файл: {inputFile}");

            Queue positive = new Queue(); 
            Queue negative = new Queue(); 

            string text = File.ReadAllText(inputFile, Encoding.UTF8);
            string[] parts = text.Split(new char[] { ' ', '\t', '\n', '\r' },
                                        StringSplitOptions.RemoveEmptyEntries);

            Console.Write("Вихідні числа: ");
            foreach (string part in parts)
            {
                if (double.TryParse(part, out double num))
                {
                    Console.Write($"{num} ");
                    if (num >= 0)
                        positive.Enqueue(num);
                    else
                        negative.Enqueue(num);
                }
            }
            Console.WriteLine();

            Console.Write("\nПозитивні числа (>= 0): ");
            while (positive.Count != 0)
                Console.Write($"{positive.Dequeue()} ");

            Console.Write("\nНегативні числа (< 0):  ");
            while (negative.Count != 0)
                Console.Write($"{negative.Dequeue()} ");

            Console.WriteLine();
        }
    }

    class Task3
    {
        private readonly string _basePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Lab9CSharp");

        public void Run()
        {
            Console.WriteLine("\n=== ЗАВДАННЯ 3: Позитивні та негативні числа (ArrayList) ===");
            Directory.CreateDirectory(_basePath);

            string inputFile = Path.Combine(_basePath, "input2_4.txt");

            if (!File.Exists(inputFile))
                File.WriteAllText(inputFile,
                    "5 -3 8 -1 0 12 -7 4 -9 2",
                    Encoding.UTF8);

            Console.WriteLine($"Читаємо файл: {inputFile}");

            ArrayList positive = new ArrayList(); 
            ArrayList negative = new ArrayList(); 

            string text = File.ReadAllText(inputFile, Encoding.UTF8);
            string[] parts = text.Split(new char[] { ' ', '\t', '\n', '\r' },
                                        StringSplitOptions.RemoveEmptyEntries);

            Console.Write("Вихідні числа: ");
            foreach (string part in parts)
            {
                if (double.TryParse(part, out double num))
                {
                    Console.Write($"{num} ");
                    if (num >= 0)
                        positive.Add(num);
                    else
                        negative.Add(num);
                }
            }
            Console.WriteLine();

            Console.Write("\nПозитивні числа (>= 0): ");
            foreach (double n in positive)
                Console.Write($"{n} ");

            Console.Write("\nНегативні числа (< 0):  ");
            foreach (double n in negative)
                Console.Write($"{n} ");

            Console.WriteLine();

            positive.Sort();
            Console.Write("\nВідсортовані позитивні: ");
            foreach (double n in positive)
                Console.Write($"{n} ");
            Console.WriteLine();
        }
    }

    class Task4
    {
        private Hashtable catalog = new Hashtable();

        public void Run()
        {
            Console.WriteLine("\n=== ЗАВДАННЯ 4: Каталог музичних дисків (Hashtable) ===");

            InitSampleData();

            bool running = true;
            while (running)
            {
                PrintMenu();
                Console.Write("Оберіть дію: ");
                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1": AddDisk(); break;
                    case "2": RemoveDisk(); break;
                    case "3": AddSong(); break;
                    case "4": RemoveSong(); break;
                    case "5": ViewAllCatalog(); break;
                    case "6": ViewDisk(); break;
                    case "7": SearchByArtist(); break;
                    case "0": running = false; break;
                    default:
                        Console.WriteLine("✗ Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }

        private void InitSampleData()
        {
            ArrayList songs1 = new ArrayList
            {
                "Queen - Bohemian Rhapsody",
                "Queen - We Will Rock You",
                "Queen - Don't Stop Me Now"
            };
            ArrayList songs2 = new ArrayList
            {
                "The Beatles - Hey Jude",
                "The Beatles - Let It Be",
                "David Bowie - Heroes"
            };
            catalog.Add("Rock Classics Vol.1", songs1);
            catalog.Add("Rock Classics Vol.2", songs2);
            Console.WriteLine("✓ Завантажено тестові дані (2 диски).");
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n--- Меню каталогу ---");
            Console.WriteLine("1 - Додати диск");
            Console.WriteLine("2 - Видалити диск");
            Console.WriteLine("3 - Додати пісню до диску");
            Console.WriteLine("4 - Видалити пісню з диску");
            Console.WriteLine("5 - Переглянути весь каталог");
            Console.WriteLine("6 - Переглянути вміст одного диску");
            Console.WriteLine("7 - Пошук за виконавцем");
            Console.WriteLine("0 - Вихід");
        }

        private void AddDisk()
        {
            Console.Write("Введіть назву нового диску: ");
            string name = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(name))
            { Console.WriteLine("✗ Назва не може бути порожньою."); return; }

            if (catalog.ContainsKey(name))
            { Console.WriteLine($"✗ Диск \"{name}\" вже існує в каталозі."); return; }

            catalog.Add(name, new ArrayList());
            Console.WriteLine($"✓ Диск \"{name}\" додано.");
        }

        private void RemoveDisk()
        {
            if (catalog.Count == 0)
            { Console.WriteLine("✗ Каталог порожній."); return; }

            Console.Write("Введіть назву диску для видалення: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            if (!catalog.ContainsKey(name))
            { Console.WriteLine($"✗ Диск \"{name}\" не знайдено."); return; }

            catalog.Remove(name);
            Console.WriteLine($"✓ Диск \"{name}\" видалено з каталогу.");
        }

        private void AddSong()
        {
            if (catalog.Count == 0)
            { Console.WriteLine("✗ Каталог порожній. Спочатку додайте диск."); return; }

            Console.Write("Введіть назву диску: ");
            string diskName = Console.ReadLine()?.Trim() ?? "";

            if (!catalog.ContainsKey(diskName))
            { Console.WriteLine($"✗ Диск \"{diskName}\" не знайдено."); return; }

            Console.Write("Введіть виконавця: ");
            string artist = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Введіть назву пісні: ");
            string song = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(song))
            { Console.WriteLine("✗ Виконавець і пісня не можуть бути порожніми."); return; }

            string entry = $"{artist} - {song}";
            ArrayList songs = (ArrayList)catalog[diskName];
            songs.Add(entry);
            Console.WriteLine($"✓ Додано: \"{entry}\" → диск \"{diskName}\".");
        }

        private void RemoveSong()
        {
            Console.Write("Введіть назву диску: ");
            string diskName = Console.ReadLine()?.Trim() ?? "";

            if (!catalog.ContainsKey(diskName))
            { Console.WriteLine($"✗ Диск \"{diskName}\" не знайдено."); return; }

            ArrayList songs = (ArrayList)catalog[diskName];
            if (songs.Count == 0)
            { Console.WriteLine("✗ На диску немає пісень."); return; }

            Console.WriteLine($"Пісні на диску \"{diskName}\":");
            for (int i = 0; i < songs.Count; i++)
                Console.WriteLine($"  {i + 1}. {songs[i]}");

            Console.Write("Введіть номер пісні для видалення: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= songs.Count)
            {
                string removed = (string)songs[idx - 1];
                songs.RemoveAt(idx - 1);
                Console.WriteLine($"✓ Пісню \"{removed}\" видалено.");
            }
            else
                Console.WriteLine("✗ Невірний номер.");
        }

        private void ViewAllCatalog()
        {
            if (catalog.Count == 0)
            { Console.WriteLine("Каталог порожній."); return; }

            Console.WriteLine("\n========== ВЕСЬ КАТАЛОГ ==========");
            ICollection keys = catalog.Keys;
            foreach (string disk in keys)
            {
                Console.WriteLine($"\n💿 {disk}");
                ArrayList songs = (ArrayList)catalog[disk];
                if (songs.Count == 0)
                    Console.WriteLine("   (пісень немає)");
                else
                    for (int i = 0; i < songs.Count; i++)
                        Console.WriteLine($"   {i + 1}. {songs[i]}");
            }
            Console.WriteLine("===================================");
            Console.WriteLine($"Всього дисків: {catalog.Count}");
        }

        private void ViewDisk()
        {
            Console.Write("Введіть назву диску: ");
            string diskName = Console.ReadLine()?.Trim() ?? "";

            if (!catalog.ContainsKey(diskName))
            { Console.WriteLine($"✗ Диск \"{diskName}\" не знайдено."); return; }

            ArrayList songs = (ArrayList)catalog[diskName];
            Console.WriteLine($"\n💿 {diskName} ({songs.Count} пісень):");
            if (songs.Count == 0)
                Console.WriteLine("   (пісень немає)");
            else
                for (int i = 0; i < songs.Count; i++)
                    Console.WriteLine($"   {i + 1}. {songs[i]}");
        }

        private void SearchByArtist()
        {
            Console.Write("Введіть ім'я виконавця для пошуку: ");
            string artist = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(artist))
            { Console.WriteLine("✗ Введіть виконавця."); return; }

            Console.WriteLine($"\n🔍 Результати пошуку виконавця \"{artist}\":");
            bool found = false;

            ICollection keys = catalog.Keys;
            foreach (string disk in keys)
            {
                ArrayList songs = (ArrayList)catalog[disk];
                foreach (string song in songs)
                {
                    if (song.IndexOf(artist, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine($"   💿 {disk}  →  {song}");
                        found = true;
                    }
                }
            }

            if (!found)
                Console.WriteLine($"   Записів виконавця \"{artist}\" не знайдено.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА №9: Колекції ===");
            Console.WriteLine("1 - Завдання 1.4 (Stack:  перевірка зворотного рядка)");
            Console.WriteLine("2 - Завдання 2.4 (Queue:  позитивні та негативні числа)");
            Console.WriteLine("3 - Завдання 3   (ArrayList: позитивні та негативні числа)");
            Console.WriteLine("4 - Завдання 4   (Hashtable: каталог музичних дисків)");
            Console.Write("\nОберіть завдання (1-4): ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1": new Task1_4().Run(); break;
                case "2": new Task2_4().Run(); break;
                case "3": new Task3().Run(); break;
                case "4": new Task4().Run(); break;
                default: Console.WriteLine("✗ Невірний вибір!"); break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}
