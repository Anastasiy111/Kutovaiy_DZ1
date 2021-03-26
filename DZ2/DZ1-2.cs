using System;

namespace DZ1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            float flag = 1;
            do
            {
                Console.WriteLine("Введите последовательность символов (С-с, Ю-ю, З-з, В-в)");
                string way = Console.ReadLine();
                char[] way_mas = way.ToCharArray();

                int x = 0, y = 0, q=1;
                for (int i = 0; i < way_mas.Length; i++)
                {
                    switch (way[i])
                    {
                        case 'С': break;
                        case 'с': break;
                        case 'Ю': break;
                        case 'ю': break;
                        case 'В': break;
                        case 'в': break;
                        case 'З': break;
                        case 'з': break;
                        default: q = 0; break;
                    }
                }

                if (q == 0)
                {
                    Console.WriteLine("Ошибка. Введен неверный символ(ы)!");
                }
                else if (q == 1)
                {
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
                        }

                    }
                    Console.WriteLine($"x={x}, y={y}");
                    double distance = Math.Sqrt(x * x + y * y);
                    Console.WriteLine($"Растояние между началом и концом составило: {distance}");
                }            
                                
                Console.Write("Для прекращения работы программы ввдите 0, иначе любое число: ");
                flag = float.Parse(Console.ReadLine());
                Console.WriteLine();

            } while (flag != 0);
            Console.WriteLine("До свидания!");
        }
    }
}
