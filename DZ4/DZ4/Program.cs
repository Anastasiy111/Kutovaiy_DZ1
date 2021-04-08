using System;
using System.Collections.Generic;
using System.Linq;

namespace DZ4
{
    class Program
    {
        static public string[] listVarMenu =
        {
                "Меню:",
                "1 - Задание 3. Минимальное и Максимальное значения.",
                "2 - Заданее 4. Количество различных элементов в списке.",
                "3 - Задание 5. Список различных чисел на отрезке [10, 25] (в порядке убывания).",
                "4 - Выход"
            };

        static public string[] listVarMiniMenu =
            {
                "1 - Задать список с помощью рандома",
                "2 - Задать список вручную",
                "3 - Выход"
            };

        static public void Menu(string[] listVar)
        {
            Console.Clear();
            foreach (string point in listVar)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine();
            Console.Write("Нажмите цифру, соответствующую Вашему выбору: ");
        }

        static public void MiniMenu(string[] listVar)
        {
            foreach (string point in listVar)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine();
            Console.Write("Нажмите цифру, соответствующую Вашему выбору: ");
        }

        static public void MinMaxRandom()
        {
            Console.Clear();

            Random rand = new Random();
            List<int> listNumber = new List<int>();

            Console.Write("Введите колличество чисел в списке: ");
            int countElements;
            while (!int.TryParse(Console.ReadLine(), out countElements))
            {
                Console.Write("Ошибка! Введите колличество чисел в списке: ");
            }

            Console.WriteLine("Элменты списка: ");
            for (int i = 0; i < countElements; i++)
            {
                listNumber.Add(rand.Next(0, 101));
                Console.Write($"{listNumber[i]} ");
            }

            var listNumberOrderBy = listNumber.OrderBy(nember => nember);

            Console.WriteLine();
            Console.WriteLine($"Минимальное значение: {listNumberOrderBy.First()}.");
            Console.WriteLine($"Максимальное значение: {listNumberOrderBy.Last()}.");

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();

        }

        static public void MinMaxManualInput()
        {
            Console.Clear();

            List<int> listNumber = new List<int>();

            Console.Write("Введите колличество чисел в списке: ");
            int countElements;
            while (!int.TryParse(Console.ReadLine(), out countElements))
            {
                Console.WriteLine("Ошибка! Введите колличество чисел в списке: ");
            }

            Console.WriteLine("Ввдите элменты списка: ");
            int element;
            for (int i = 0; i < countElements; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out element))
                {
                    Console.WriteLine("Ошибка! Введите элемент списка: ");
                }
                listNumber.Add(element);
            }

            var listNumberOrderBy = listNumber.OrderBy(nember => nember);

            Console.WriteLine();
            Console.WriteLine($"Минимальное значение: {listNumberOrderBy.First()}.");
            Console.WriteLine($"Максимальное значение: {listNumberOrderBy.Last()}.");

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();

        }

        static public void MinMax()
        {
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                Console.Clear();
                Console.WriteLine("Минимальное и Максимальное значения.");
                Console.WriteLine();
                MiniMenu(listVarMiniMenu);
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        MinMaxRandom();
                        break;
                    case ConsoleKey.D2:
                        MinMaxManualInput();
                        break;
                    default: continue;
                }

            } while (key != ConsoleKey.D3);
        }


        static public void CountDifferentNumbersRandom()
        {
            Console.Clear();

            Random rand = new Random();
            List<int> listNumber = new List<int>();

            Console.Write("Введите количество элементво в списке: ");
            int countElements;
            while (!int.TryParse(Console.ReadLine(), out countElements))
            {
                Console.Write("Ошибка! Введите количество элементво в списке: ");
            }

            for (int i = 0; i < countElements; i++)
            {

                listNumber.Add(rand.Next(0, 101));
            }

            var listNumberDistinct = listNumber.Distinct();

            Console.WriteLine("Список различных чисел в сгенерированном списке: ");
            foreach (int element in listNumberDistinct)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Количество различных элементов в списке: {listNumberDistinct.Count()}");

            Console.WriteLine("Для продолжения наждимите любую клавишу...");
            Console.ReadKey();
        }

        static public void CountDifferentNumbersManualInput()
        {
            Console.Clear();

            List<int> listNumber = new List<int>();

            Console.Write("Введите количество элементво в списке: ");
            int countElements;
            while (!int.TryParse(Console.ReadLine(), out countElements))
            {
                Console.Write("Ошибка! Введите количество элементво в списке: ");
            }

            Console.WriteLine("Введите элементы списка: ");
            int element;
            for (int i = 0; i < countElements; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out element))
                {
                    Console.Write("Ошибка! Введите элемент списка: ");
                }

                listNumber.Add(element);
            }

            var listNumberDistinct = listNumber.Distinct();

            Console.WriteLine();
            Console.WriteLine($"Количество различных элементов в списке: {listNumberDistinct.Count()}");

            Console.WriteLine("Для продолжения наждимите любую клавишу...");
            Console.ReadKey();
        }

        static public void CountDifferentNumbers()
        {
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                Console.Clear();
                Console.WriteLine("Количество различных элементов в списке.");
                Console.WriteLine();
                MiniMenu(listVarMiniMenu);
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        CountDifferentNumbersRandom();
                        break;
                    case ConsoleKey.D2:
                        CountDifferentNumbersManualInput();
                        break;
                    default: continue;
                }

            } while (key != ConsoleKey.D3);

        }

        static public void ListRandom()
        {
            Console.Clear();
            Console.WriteLine("Список различных чисел на отрезке [10, 25] (в порядке убывания).");
            Console.WriteLine();

            Random rand = new Random();
            List<int> listNumber = new List<int>();

            for (int i = 0; i < 50; i++)
            {
                listNumber.Add(rand.Next(0, 26));
            }

            var listNemberSegment = listNumber.Where(x => (x>=10) & (x<=25));
            var listNemberSegmentDistinct = listNemberSegment.Distinct();
            var listNemberSegmentDistinctOrderBy = listNemberSegmentDistinct.OrderByDescending(x => x);

            foreach (int element in listNemberSegmentDistinctOrderBy)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();

            Console.WriteLine("Для продолжения наждимите любую клавишу...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {

            ConsoleKey keyBos = ConsoleKey.Enter;
            do
            {
                Menu(listVarMenu);
                keyBos = Console.ReadKey().Key;

                switch (keyBos)
                {
                    case ConsoleKey.D1:
                        MinMax();
                        break;
                    case ConsoleKey.D2:
                        CountDifferentNumbers();
                        break;
                    case ConsoleKey.D3:
                        ListRandom();
                        break;
                    default: continue;
                }

            } while (keyBos != ConsoleKey.D4);

            Console.WriteLine();
            Console.WriteLine("До свидания!");

        }
    }
}
