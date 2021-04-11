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
            "7 - Отфильтровать по залу",
            "8 - Сортировать по цене (убывание, возрастание)",
            "9 - Чек",
            "0 - Выход"
        };

        static public void Chek(List<Movie> movieList, List<Hall> hallList) //9 - Чек
        {
            Console.Clear();
            Dictionary<int, string > chek = new Dictionary<int, string>();
            string nameMovie = "";
            do
            {
                Console.WriteLine("Введите название фильма, билет на который хотите приобрести: ");
                bool checkFlag = true;
                while (checkFlag)
                {
                    try
                    {
                        nameMovie = FirstUpper(Console.ReadLine());
                        checkFlag = false;
                    }
                    catch (Exception)
                    {
                        Console.Write("Введено недопустимое значение, попробуйте еще раз: ");
                    }
                }

                foreach (Movie element in movieList)
                {
                    if (element.Name == nameMovie)
                    {
                        checkFlag = true;
                        break;
                    }
                }

                if (checkFlag == false)
                {
                    Console.Write("Такого фильма нет. Хотите ввести заново? (да - нажмите Enter, нет - нажмите на любую клавишу):");
                }
                else
                {
                    int countTickets;
                    Console.Write("Введите количество белетов: ");
                    while (!int.TryParse(Console.ReadLine(), out countTickets))
                    {
                        Console.Write("Ошибка! Введите заново количество белетов: ");
                    }
                    chek.Add(countTickets, nameMovie);
                    Console.Write("Добавить еще фильм? (да - нажмите Enter, нет - нажмите на любую клавишу): ");
                }
                Console.WriteLine();
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

            double sum = 0;

            foreach (Movie element in movieList)
            {
                foreach (KeyValuePair<int, string> key in chek)
                {
                    if (element.Name == key.Value)
                    {
                        sum += element.Price * key.Key;
                    }
                }
                
            }

            int chekCountTickets = chek.Aggregate(0, (x,y) => y.Key >= 0 ? x+y.Key : x);

            Console.Clear();
            Console.WriteLine("Чек: ");
            Console.WriteLine();
            foreach (KeyValuePair<int, string> element in chek)
            {
                Console.WriteLine($"Фильм: \t {element.Key}");
                Console.WriteLine($"Количество билетов: {element.Value}");
                Console.WriteLine();
            }
            Console.WriteLine("Итог: ");
            Console.WriteLine($"Количество билетов: {chekCountTickets}");
            Console.WriteLine($"Сумма: \t {sum}");
            Console.WriteLine();
            Console.WriteLine("Спасибо! Приходите к нам еще!");

            Console.WriteLine();
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public void FilterHall(List<Movie> movieList, List<Hall> hallList) //7 - Отфильтровать по залу
        {
            Console.Clear();
            string nameHall = "";
            Console.Write("Введите название зала: ");
            bool checkFlag = true;
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

            foreach (Hall element in hallList)
            {
                if (element.NameHall == nameHall)
                {
                    checkFlag = true;
                    break;
                }
            }

            if (checkFlag == false)
            {
                Console.WriteLine("Ошибка! Такого зала не существуте.");
            }
            else 
            {
                var s = movieList.GroupBy(x => x.NameHall);

                foreach (IGrouping<string, Movie> element in s)
                {
                    if (element.Key == nameHall)
                    {
                        Console.WriteLine();
                        foreach (var t in element)
                        {
                            Console.WriteLine($"Фильм: {t.Name} - {t.Price} руб.");
                        }
                    }          
                }
            }
            Console.WriteLine();
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }


        static public string[] listMenuSortPrice =
        {
            "Меню:",
            "1 - Сортировка по цене (убывание)",
            "2 - Сортировка по цене (возрастание)",
            "0 - Вернуться в основаное меню"
        };

        public static void MenuSortPrice(string[] listMenuSortPrice)
        {
            Console.Clear();

            foreach (string element in listMenuSortPrice)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
            Console.Write("Нажмите цифру, соответствующую пункту меню: ");
        }

        public static void SortPrice(List<Movie> movieList) //8 - Сортировать по цене (убывание, возрастание)
        {
            Console.Clear();
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                MenuSortPrice(listMenuSortPrice);
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        SortPriceDescending(movieList);
                        break;
                    case ConsoleKey.D2:
                        SortPriceAscending(movieList);
                        break;
                    default: continue;
                }

            } while (key != ConsoleKey.D0);
        }

        public static void SortPriceDescending(List<Movie> movieList)
        {
            Console.Clear();

            var movieListSortPrice = movieList.OrderByDescending(x => x.Price);

            foreach (Movie element in movieListSortPrice)
            {
                element.GetInfo();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static void SortPriceAscending(List<Movie> movieList)
        {
            Console.Clear();

            var movieListSortPrice = movieList.OrderBy(x => x.Price);

            foreach (Movie element in movieListSortPrice)
            {
                element.GetInfo();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }


        public static void FilterByPrice(List<Movie> movieList) //6 - Отфильтровать по стоимости
        {
            Console.Clear();

            double priceMin = 0;
            double priceMax = 0;
            do
            {
                Console.Clear();
                Console.Write("Введите минимальную стоимость: ");

                while (!double.TryParse(Console.ReadLine(), out priceMin))
                {
                    Console.Write("Ошибка! Введите заново: ");
                }
                Console.Write("Введите максимальную стоимость: ");

                while (!double.TryParse(Console.ReadLine(), out priceMax))
                {
                    Console.Write("Ошибка! Введите заново: ");
                }

                if (priceMin > priceMax)
                {
                    Console.WriteLine("Ошибка! Минимальная стоимость меньше максильной. Попробуйте заново.");
                    Console.ReadKey();
                }


            } while (priceMin > priceMax);

            var movieListPriceMinMax = movieList.Where(x => x.Price <= priceMax && x.Price >= priceMin);

            Console.WriteLine();
            if (movieListPriceMinMax.Count() == 0)
            {
                Console.WriteLine("Фильмы не найдены!");
            }
            else
            {
                foreach (Movie element in movieListPriceMinMax)
                {
                    element.GetInfo();
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }


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


        static public void Menu(string[] listMenu) // Вывод меню
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



        static public void AddMovie(List<Movie> movieList, List<Hall> hallList) //2 - Добавить новый фильм
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
                Console.WriteLine("Выберите зал: ");
                ConsoleKey key = ConsoleKey.Enter;
                int count = 1;
                foreach (Hall element in hallList)
                {
                    Console.WriteLine($"{count} - {element.NameHall}");
                    count++;
                }
                do
                {
                    Console.Write("Номер зала: ");
                    key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            nameHall = hallList[0].NameHall;
                            break;
                        case ConsoleKey.D2:
                            nameHall = hallList[1].NameHall;
                            break;
                        default: continue;
                    }
                    Console.WriteLine();
                } while ((key != ConsoleKey.D1) && (key != ConsoleKey.D2));

                Console.Write("Введите стоимость билета (в руб.): ");
                while (!double.TryParse(Console.ReadLine(), out ticketPrice))
                {
                    Console.Write("Ошибка! Введите заново: ");
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

            List<Hall> hallList = new List<Hall>();
            hallList.Add(new Hall() { NameHall = "Синий", CountPlaces = 120});
            hallList.Add(new Hall() { NameHall = "Красный", CountPlaces = 150});
            
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
                        AddMovie(movieList, hallList);
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
                        FilterByPrice(movieList);
                        break;
                    case ConsoleKey.D7:
                        FilterHall(movieList, hallList);
                        break;
                    case ConsoleKey.D8:
                        SortPrice(movieList);
                        break;
                    case ConsoleKey.D9:
                        Chek(movieList, hallList);
                        break;
                    default: continue;
                }


            } while (key != ConsoleKey.D0);

        }
    }
}
