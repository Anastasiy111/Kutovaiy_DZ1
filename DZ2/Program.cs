using System;

namespace DZ2_1
{
    class Program
    {
        static void diferentNumbers() // Сложность алгоритма: O(n)
        {
            do
            {
                Console.Write("Введите размер массива: ");
                int arraySize = int.Parse(Console.ReadLine());
                bool growthCheck = true;

                double[] array = new double[arraySize];
                Console.WriteLine("Введите упорядоченный по возрастанию массив: ");

                Console.Write($"array[{0}] = ");
                array[0] = int.Parse(Console.ReadLine());

                int digitCounter = 1;
                for (int counter = 1; counter < arraySize; counter++)
                {
                    Console.Write($"array[{counter}] = ");
                    array[counter] = int.Parse(Console.ReadLine());
                    if (array[counter - 1] != array[counter])
                    {
                        if (array[counter] < array[counter - 1])
                        {
                            Console.WriteLine("Ошибка! Элементы массива введены не по возрастанию!");
                            growthCheck = false;
                            break;
                        }
                        digitCounter += 1;
                    }
                }

                if (growthCheck == true)
                {
                    Console.WriteLine($"{digitCounter} различных чисел в массиве.");
                    Console.Write("Желаете продолжить? (да - нажмите Enter, нет - нажмите на любую клавишу): ");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Желаете продолжить? (да - нажмите Enter, нет - нажмите на любую клавишу): ");
                    Console.WriteLine();
                    Console.WriteLine();
                }

            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }





        static void symmetricArray() // Сложность алгоритма: O(n2)+O(n2)=O(n2)
        {
            do
            {
                Console.Write("Введите размер квадратной матрицы: ");
                int arraySize = int.Parse(Console.ReadLine());

                bool checkSymmetry = true;
                double[,] array = new double[arraySize, arraySize];

                for (int counterI = 0; counterI < arraySize; counterI++)
                {
                    for (int counterJ = 0; counterJ < arraySize; counterJ++)
                    {
                        Console.Write($"array[{counterI},{counterJ}] = ");
                        array[counterI, counterJ] = double.Parse(Console.ReadLine());
                    }
                    Console.WriteLine();
                }

                for (int counterI = 0; counterI < arraySize; counterI++)
                {
                    for (int counterJ = counterI+1; counterJ < arraySize; counterJ++)
                    {
                        if (array[counterI, counterJ] != array[counterJ, counterI])
                        {
                            checkSymmetry = false;
                            break;
                        }
                    }

                    if (checkSymmetry == false)
                    {
                        break;
                    }
                }

                if (checkSymmetry == true)
                {
                    Console.WriteLine("Да, матрица симметричная!");
                }
                else
                {
                    Console.WriteLine("Нет, матрица не симметричная!");
                }

                Console.Write("Желаете продолжить? (да - нажмите Enter, нет - нажмите на любую клавишу): ");
                Console.WriteLine();
                Console.WriteLine();

            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }





        static void Main(string[] args)
        {
            Program.diferentNumbers();
            Program.symmetricArray();

            Console.WriteLine("До свидания!");

        }
    }
}
