using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTheaterPoster
{
    class Movie
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string NameHall { get; set; }

        public Movie() { }
        public Movie(string Name, double Prise, string NameHall) { }

        public void GetInfo()
        {
            Console.WriteLine($"Фильм: {Name}");
            Console.WriteLine($"Цена билета: {Price}");
            Console.WriteLine($"Зал: {NameHall}");
        }
    }

    class Hall
    {
        public string NameHall { get; set; }
        public int CountPlaces { get; set; }

        public Hall() { }
        public Hall(string NameHall, int CountPlaces) { }

        public void GetInfo()
        {
            Console.WriteLine($"Зал: \t {NameHall}");
            Console.WriteLine($"Количество мест: {CountPlaces}");

        }
    }
}