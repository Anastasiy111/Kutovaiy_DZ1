using System;

namespace DZ1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите последовательность символов (С-с, Ю-ю, З-з, В-в)");
                string way = Console.ReadLine();
                char[] way_mas = way.ToCharArray();

                int x = 0, y = 0;
                bool check_input = true;
                for (int i = 0; i < way_mas.Length; i++)
                {
                    switch (way[i])
                    {
                        case 'С': y = y + 1; break;
                        case 'с': y = y + 1; break;
                        case 'Ю': y = y - 1; break;
                        case 'ю': y = y - 1; break;
                        case 'В': x = x + 1; break;
                        case 'в': x = x + 1; break;
                        case 'З': x = x - 1; break;
                        case 'з': x = x - 1; break;
                        default: check_input = false; break;
                    }

                }

                if (check_input == false)
                {
                    Console.WriteLine("Ошибка. Введен неверный символ(ы)!");
                }
                else if (check_input == true)
                {
                    Console.WriteLine($"x={x}, y={y}");
                    double distance = Math.Sqrt(x * x + y * y);
                    Console.WriteLine($"Растояние между началом и концом составило: {distance}");
                }

                Console.Write("Желаете продолжить? (да - нажмите Enter, нет - нажмите на любую клавишу): ");

            } while (Console.ReadKey().Key == ConsoleKey.Enter);

            Console.WriteLine();
            Console.WriteLine("До свидания!");
        }
    }
}
