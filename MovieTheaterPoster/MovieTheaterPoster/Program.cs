using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTheaterPoster
{
    class Program
    {
        static public string[] listMenu =
        {
            "Меню:",
            "1 - Вывести список фильмов",
            "2 - Добавить новый фильм",
            "3 - Удалить фильм",
            "4 - Информация о фильме",
            "5 - Стоимость билетов в $",
            "6 - Отфильтровать по стоимости",
            "7 - Чек",
            "8 - Сортировать по цене (убывание, возрастание)",
            "0 - Выход"
        };


        public static void PriceDolars(List<Movie> movieList) //5 - Стоимость билетов в $
        {
            Console.Clear();
            Console.WriteLine("Стоимость билетов в $");
            Console.WriteLine();

            List<double> listPrise = new List<double>();
            List<Movie> movieListDolars = new List<Movie>();

            foreach (Movie element in movieList)
            {
                listPrise.Add(element.Price);
                movieListDolars.Add(new Movie() { Name = element.Name, NameHall = element.NameHall});
            }

            IEnumerable<double> listDolars = listPrise.Select(x => Math.Round(x / 77, 2));

            int count = 0;
            foreach (double element in listDolars)
            {
                movieListDolars.Add(new Movie() { Name = movieList[count].Name, NameHall = movieList[count].NameHall });
                movieListDolars[count].Price = element;
                movieListDolars[count].GetInfo();
                Console.WriteLine();
                count++;
            }
            
            Console.WriteLine();
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static string FirstUpper(string str)
        {
            return str.Substring(0, 1).ToUpper() + (str.Length > 1 ? str.Substring(1).ToLower() : "");
        }

        static public void Menu(string[] listMenu)
        {
            Console.Clear();

            foreach (string menuItem in listMenu)
            {
                Console.WriteLine(menuItem);
            }

            Console.WriteLine();
            Console.Write("Нажмите цифру, соответствующую пункту меню: ");
        }



        static public void OutputListMovie(List<Movie> movieList) //1 - Вывести список фильмов
        {
            Console.Clear();

            foreach (Movie movie in movieList)
            {
                movie.GetInfo();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }



        static public void AddMovie(List<Movie> movieList) //2 - Добавить новый фильм
        {
            Console.Clear();

            string movie = "", nameHall = "";
            double ticketPrice;

            Console.Write("Введите название фильма: ");
            bool checkFlag = true;
            while (checkFlag)
            {
                try
                {
                    movie = FirstUpper(Console.ReadLine());
                    checkFlag = false;
                }
                catch (Exception)
                {
                    Console.Write("Введено недопустимое значение, попробуйте еще раз: ");
                }
            }

            Console.Write("Введите название зала: ");
            checkFlag = true;
            while (checkFlag)
            {
                try
                {
                    nameHall = FirstUpper(Console.ReadLine());
                    checkFlag = false;
                }
                catch (Exception)
                {
                    Console.Write("Введено недопустимое значение, попробуйте еще раз: ");
                }
            }

            checkFlag = false;
            foreach (Movie name in movieList)
            {
                if (movie == name.Name)
                {
                    checkFlag = true;
                }
            }

            if (checkFlag == true)
            {
                Console.WriteLine("Фильм уже добавлен.");
            }
            else
            {
                Console.Write("Введите стоимость билета (в руб.): ");
                while (!double.TryParse(Console.ReadLine(), out ticketPrice))
                {
                    Console.WriteLine("Ошибка! Введите заново: ");
                }


                movieList.Add(new Movie() { Name = movie, Price = ticketPrice, NameHall = nameHall });

                Console.WriteLine("Фильм добавлен.");
            }

            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public void DeleteMovie(List<Movie> movieList) //3 - Удалить фильм
        {
            Console.Clear();

            Console.Write("Введите название фильма, который нужно удалить: ");
            bool checkFlag = true;
            string movie = "";

            while (checkFlag)
            {
                try
                {
                    movie = FirstUpper(Console.ReadLine());
                    checkFlag = false;
                }
                catch (Exception)
                {
                    Console.Write("Введено недопустимое значение, попробуйте еще раз: ");
                }
            }

            checkFlag = Error(movie, movieList);

            if (checkFlag == true)
            {
                movieList.Remove(movieList.Find(x => x.Name.Contains(movie)));
                Console.WriteLine("Фильм удален.");
            }

            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }


        static public bool Error(string name, List<Movie> movieList) //Проверка на существование фильма в списке
        {
            bool checkFlag = false;

            foreach (Movie nameMovie in movieList)
            {
                if (name == nameMovie.Name)
                {
                    checkFlag = true;
                }
            }

            if (checkFlag == false)
            {
                Console.WriteLine("Ошибка! Фильм не найден.");
            }

            return checkFlag;
        }

        static public void TicketPriceOutput(List<Movie> movieList) //4 - Информация о фильме
        {
            Console.Clear();

            Console.Write("Введите название фильма: ");
            bool checkFlag = true;
            string movie = "";

            while (checkFlag)
            {
                try
                {
                    movie = FirstUpper(Console.ReadLine());
                    checkFlag = false;
                }
                catch (Exception)
                {
                    Console.Write("Введено недопустимое значение, попробуйте еще раз: ");
                }
            }

            checkFlag = Error(movie, movieList);

            if (checkFlag == true)
            {
                foreach (Movie element in movieList)
                {
                    if (element.Name == movie)
                    {
                        element.GetInfo();
                    }
                }
            }

            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();

            movieList.Add(new Movie() { Name = "Затура", Price = 120, NameHall = "Синий" });
            movieList.Add(new Movie() { Name = "Аватар", Price = 150, NameHall = "Синий" });
            movieList.Add(new Movie() { Name = "Люди в черном", Price = 120, NameHall = "Красный" });

            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                Menu(listMenu);
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        OutputListMovie(movieList);
                        break;
                    case ConsoleKey.D2:
                        AddMovie(movieList);
                        break;
                    case ConsoleKey.D3:
                        DeleteMovie(movieList);
                        break;
                    case ConsoleKey.D4:
                        TicketPriceOutput(movieList);
                        break;
                    case ConsoleKey.D5:
                        PriceDolars(movieList);
                        break;
                    case ConsoleKey.D6:
                        break;
                    case ConsoleKey.D7:
                        break;
                    case ConsoleKey.D8:
                        break;
                    default: continue;
                }


            } while (key != ConsoleKey.D0);

        }
    }
}
