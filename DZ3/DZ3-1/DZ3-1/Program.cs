using System;
using System.Collections.Generic;

namespace DZ3_1
{
    class Program
    {
        static public void Mail()
        {
            Console.WriteLine("Очерьдь в почтовом отделении.");
            Console.WriteLine();

            Console.WriteLine("Введите время работы почты (в минутах): ");
            int workTimeMail = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число посетителей, желающих хабрать посылку: ");
            int visitorsMail = int.Parse(Console.ReadLine());

            if (visitorsMail != 0)
            {
                Queue<int> timeServicesVisitirsMail = new Queue<int>();
                int counterVisitor = 1;
                Console.WriteLine("Время обслудивания каждого посетителя: ");
                for (int counter = 0; counter < visitorsMail; counter++)
                {
                    Console.Write($"{counterVisitor} посетитель: ");
                    counterVisitor++;
                    timeServicesVisitirsMail.Enqueue(int.Parse(Console.ReadLine()));
                    if (workTimeMail > 0)
                    {
                        workTimeMail -= timeServicesVisitirsMail.Dequeue();
                    }
                }
                Console.WriteLine($"{timeServicesVisitirsMail.Count} посетителей уйдут без посылки.");
            }
            else
            {
                Console.WriteLine($"{0} посетителей уйдут без посылки.");
            }
        }

        static void Main(string[] args)
        {
            Mail();
            Console.WriteLine();
            Console.WriteLine("До свидания!");
        }
    }
}
