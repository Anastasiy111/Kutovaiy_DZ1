using System;
using System.Collections.Generic;

namespace DZ3
{
    class Program
    {
        static public string[] menuItems =
        {
            "Меню:",
            "1 - Вывести список форматов",
            "2 - Добавить новый формат",
            "3 - Удалить формат",
            "4 - Вывод полного наименования формата по короткому наименованию",
            "5 - Выход"
        };


        static public void Menu()
        {
            Console.Clear();

            foreach (string menuItem in menuItems)
            {
                Console.WriteLine(menuItem);
            }

            Console.WriteLine();
            Console.Write("Нажмите цифру, соответствующую пункту меню: ");
        }

        static public void AddFormat(Dictionary<string, string> formatDictionary) //2 - Добавить новый формат
        {
            Console.Clear();
            string nameFormat, nameFormatFull;

            Console.Write("Введите короткое наименования формата: ");
            nameFormat = Console.ReadLine().ToUpper();

            bool checkFlag = false;
            foreach (KeyValuePair<string, string> name in formatDictionary)
            {
                if (nameFormat == name.Key)
                {
                    checkFlag = true;
                }
            }

            if (checkFlag == true)
            {
                Console.WriteLine("Формат уже существует.");
            }
            else
            {
                Console.Write("Введите полное наименования формата: ");
                nameFormatFull = Console.ReadLine();

                formatDictionary.Add(nameFormat, nameFormatFull);

                Console.WriteLine("Формат добавлен.");
            }

            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public void DeleteFormat(Dictionary<string, string> formatDictionary) //3 - Удалить формат
        {
            Console.Clear();
            Console.Write("Введите короткое наименование формата, который нужно удалить: ");
            string format = Console.ReadLine().ToUpper();

            bool checkFlag;
            checkFlag = Error(format, formatDictionary);

            if (checkFlag == true)
            {
                formatDictionary.Remove(format);
                Console.WriteLine("Формат удален.");
            }

            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public void OutputList(Dictionary<string, string> formatDictionary) //1 - Вывести список форматов
        {
            Console.Clear();

            foreach (KeyValuePair<string, string> nameFormat in formatDictionary)
            {
                Console.WriteLine($"Name: \t\t {nameFormat.Key}");
                Console.WriteLine($"Full name: \t { nameFormat.Value}.");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public void FullNameOutput(Dictionary<string, string> formatDictionary) //4 - Вывод полного наименования формата по короткому наименованию
        {
            Console.Clear();
            Console.Write("Введите короткое наименование формата: ");
            string format = Console.ReadLine().ToUpper();

            bool checkFlag;
            checkFlag = Error(format, formatDictionary);

            if (checkFlag == true)
            {
                Console.WriteLine($"Полное наименование: {formatDictionary[format]}");
                Console.WriteLine();
            }

            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public bool Error(string name, Dictionary<string, string> formatDictionary)
        {
            bool checkFlag = false;

            foreach (KeyValuePair<string, string> nameFormat in formatDictionary)
            {
                if (name == nameFormat.Key)
                {
                    checkFlag = true;
                }
            }

            if (checkFlag == false)
            {
                Console.Clear();
                Console.WriteLine("Ошибка! Введен неверный формат.");
            }

            return checkFlag;
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> formatDictionary = new Dictionary<string, string>();
            formatDictionary.Add("GIF", "Graphics Interchange Format");
            formatDictionary.Add("TIFF", "Tagged Image File Format");
            formatDictionary.Add("PNG", "Portable Network Graphics");
            formatDictionary.Add("SWF", "Small Web Format");
            formatDictionary.Add("EPS", "Encapsulated PostScript");

            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                Menu();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        OutputList(formatDictionary);
                        break;
                    case ConsoleKey.D2:
                        AddFormat(formatDictionary);
                        break;
                    case ConsoleKey.D3:
                        DeleteFormat(formatDictionary);
                        break;
                    case ConsoleKey.D4:
                        FullNameOutput(formatDictionary);
                        break;
                    default: continue;
                }
            } while (key != ConsoleKey.D5);

            Console.WriteLine();
            Console.WriteLine("До свидания!");

        }
    }
}
