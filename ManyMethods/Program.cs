using System;

namespace ManyMethods
{
    class Program
    {
        public static void Main(string[] args)
        {
            Hello();
            Addition();
            CatDog();
            OddEven();
            Inches();
            Echo();
            killGrams();
            Date();
            Age();
            Guess();

        }

        public static void Hello()
        {
            Console.WriteLine("Hello");
        }

        public static void Addition()
        {
            Console.WriteLine("Enter your first number");
            string answer = Console.ReadLine();
            Console.WriteLine("enter your second number");
            string secondAnswer = Console.ReadLine();

            int first = Convert.ToInt32(answer);
            int second = Convert.ToInt32(secondAnswer);
            int total = Convert.ToInt32(answer) + Convert.ToInt32(secondAnswer);
            Console.WriteLine("The sum is " + total);

        }

        public static void CatDog()
        {
            string dogs = "dogs";
            string cats = "cats";

            Console.WriteLine("Do you like cats or dogs?");
            string fav = Console.ReadLine();
            

            if (fav == dogs)
                {
                Console.WriteLine("Bark!");
            }
            else if (fav == cats)
            {
                Console.WriteLine("Meow!");
            }
            else{
                Console.WriteLine("Invalid answer");
            }
        }

       


        public static void OddEven()
        {
            int i;
            Console.WriteLine("Enter a number:");
            i = int.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                Console.WriteLine("This is an even number");
                
            }
            else
            {
                Console.WriteLine("This is an odd number");
                
            }

        }

        public static void Inches()
        {
            Console.WriteLine("How many feet?");
            string feet = Console.ReadLine();
            int inches = (Convert.ToInt32(feet) * 12);
            Console.WriteLine("Your feet in inches " + inches);
        }

        public static void Echo()
        {
            Console.WriteLine("What would you like to yell?");
            string yell = Console.ReadLine();
            string allcaps = yell.ToUpper();
            string lowercase = yell.ToLower();
            Console.WriteLine(allcaps);
            Console.WriteLine(lowercase);
            Console.WriteLine(lowercase);
        }

        public static void killGrams()
        {
            Console.WriteLine("How many pounds?");
            string pounds = Console.ReadLine();
            double kilos = (Convert.ToInt32(pounds) / 2.2);
            Console.WriteLine("Weight in kilograms " + kilos);
           
        }

        public static void Date()
        {
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            Console.WriteLine("Today's Date is {0}", date);
        }

        public static void Age()
        {
            int bday;
            var today = DateTime.Now;
            Console.WriteLine("What year were you born?");
            bday = int.Parse(Console.ReadLine());

            var age = today.Year - bday;
            var year = today.Year - bday - 1;

            Console.WriteLine("If your birthday has passed, you are " + age + " years old!" + "If your birthday has not passed you are " +year+ " years old!");

        }


        public static void Guess()
        {
            string myword = "Csharp";
            Console.WriteLine("Can you guess the word I'm thinking of?");
            string guess = Console.ReadLine();

            if (guess == myword)
            {
                Console.WriteLine("CORRECT!");
            }
            else if (guess != myword)
            {
                Console.WriteLine("WRONG!");
            }

        }
     
        }
    }
