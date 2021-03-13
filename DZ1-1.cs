using System;

namespace DZ1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number_manth; 
            float flag;
            do
            {
                Console.Write("Введите номер месяца: ");
                number_manth = int.Parse(Console.ReadLine());
                if ((number_manth >= 1) & (number_manth <= 12))
                {
                    switch (number_manth)
                    {
                        case 1:
                            Console.WriteLine("Январь");
                            break;
                        case 2:
                            Console.WriteLine("Февраль");
                            break;
                        case 3:
                            Console.WriteLine("Март");
                            break;
                        case 4:
                            Console.WriteLine("Апрель");
                            break;
                        case 5:
                            Console.WriteLine("Май");
                            break;
                        case 6:
                            Console.WriteLine("Июнь");
                            break;
                        case 7:
                            Console.WriteLine("Июль");
                            break;
                        case 8:
                            Console.WriteLine("Август");
                            break;
                        case 9:
                            Console.WriteLine("Сентябрь");
                            break;
                        case 10:
                            Console.WriteLine("Октябрь");
                            break;
                        case 11:
                            Console.WriteLine("Ноябрь");
                            break;
                        case 12:
                            Console.WriteLine("Декабрь");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка. Введено не верное число!");
                }
                Console.Write("Для прекращения работы программы введите 0, иначе любое число: ");
                flag = float.Parse(Console.ReadLine());
                Console.WriteLine();
            } while (flag != 0);
            Console.WriteLine("До свидания!");
        }
    }
}
