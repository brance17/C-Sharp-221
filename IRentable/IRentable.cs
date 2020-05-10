using System;
using System.Collections.Generic;


namespace IRentable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRentable> rentals = new List<IRentable>();
            rentals.Add(new Boat("10ft Canoe", 79));
            rentals.Add(new Car("2001 Camry", 99));
            rentals.Add(new House("2 bed 2 bath Townhouse", 400));

            Console.WriteLine("Hello. Here are the rentals we have available in our inventory for your stay:");

            foreach (var item in rentals)
            {
                Console.WriteLine($"{item.GetDescription()} {item.GetRate()}");
            }
            Console.ReadKey();
        }
    }

    interface IRentable
    {
        string GetRate();
        string GetDescription();
    }

    class Boat : IRentable
    {
        private string desc;
        private decimal hourlyRate;


        public Boat(string desc, decimal hourlyRate)
        {
            this.desc = desc;
            this.hourlyRate = hourlyRate;

        }

        public string GetDescription()
        {
            return $"This boat is a {desc},";
        }

        public string GetRate()
        {

            return $"it is {hourlyRate} per hour to rent";
        }
    }

    class Car : IRentable
    {
        private string desc;
        private decimal dailyRate;

        public Car(string desc, decimal dailyRate)
        {
            this.desc = desc;
            this.dailyRate = dailyRate;
        }

        public string GetDescription()
        {
            return $"This car is a {desc},";
        }

        public string GetRate()
        {
            return $"it costs {dailyRate} per day to rent.";
        }
    }

    class House : IRentable
    {
        private string desc;
        private decimal weeklyRate;

        public House(string desc, decimal weeklyRate)
        {
            this.desc = desc;
            this.weeklyRate = weeklyRate;
        }

        public string GetDescription()
        {
            return $"This is a {desc} home,";
        }

        public string GetRate()
        {
            return $"it costs {weeklyRate} a week to rent.";
        }
    }
}