using System;
using System.Collections.Generic;
using System.Text;

namespace PoCos
{
    class Program
    {

        public static void Main(string[] args)
        {
            //DriverLicenseInfo
            DriverLicense myLicense = new DriverLicense ("Joe", "Somebody", "Male", 09876521);
            Console.WriteLine(myLicense.LicenseInfo());
            Console.ReadKey();
            Console.Clear();

            //Book
            Book harryPotter = new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 309, 0590353403, "Scholastic Press", 11.99);
            Console.WriteLine(harryPotter.BookInfo());
            Console.ReadKey();
            Console.Clear();

            //Airplane
            Airplane boeing747v1 = new Airplane("Boeing", 747, "747SP", 400, "PTWJT9d-7");
            Console.WriteLine(boeing747v1.AirplaneInfo());
            Console.ReadKey();
            Console.Clear();

            Airplane boeingv2 = new Airplane("Boeing", 747, "VC-25", 76, "CF6-80C2B1");
            Console.WriteLine(boeingv2.AirplaneInfo());

        }

    }

}