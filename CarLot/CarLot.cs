using System;
using System.Collections.Generic;

namespace CarLot
{
    class Program
    {
        public static void Main(string[] args)
        {
            CarLot carlotBrance = new CarLot("Scott Motors", "Scott's Inventory:");
            CarLot carlotBrooke = new CarLot("Brooke's Cars","Brooke's Inventory:");

            carlotBrance.AddVehicle(new Truck(1991, "Ford", "F-350", 9999, "FYS1942", "4WD", "Long"));
            carlotBrance.AddVehicle(new Truck(2008, "Jeep", "Wrangler", 15999, "PLJ5621", "2WD", "Short"));
            carlotBrance.AddVehicle(new Car(1997, "Chevy", "Impala", 6999, "JKF9012", "Coupe", 4));

            carlotBrooke.AddVehicle(new Car(1994, "Ford", "Taurus", 4999, "HGR0986", "Sedan", 2));
            carlotBrooke.AddVehicle(new Car(2009, "Nissan", "Altima", 14999, "GQS4371", "Sedan", 4));
            carlotBrooke.AddVehicle(new Truck(2016, "Chevrolet", "Yukon", 32999, "TYL6541", "4WD", "Short"));

            carlotBrance.Info();
            Console.WriteLine($"There are {carlotBrance.vehicles.Count} cars on our lot");


            foreach (var automobile in carlotBrance.GetVehicles())
            {
                automobile.VehicleDescription();
            }

           
            Console.WriteLine("Press any key to see the inventory at our sister location:\n");
            Console.ReadKey();

            carlotBrooke.Info();
            Console.WriteLine($"There are {carlotBrooke.vehicles.Count} vehicles on our lot");

            foreach (var automobile in carlotBrooke.GetVehicles())
            {
                automobile.VehicleDescription();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        abstract class Vehicle
        {
            public int Year { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Price { get; set; }
            public string LicensePlate { get; set; }

            public Vehicle(int year, string make, string model, int price, string licensePlate)
            {
                Year = year;
                LicensePlate = licensePlate;
                Make = make;
                Model = model;
                Price = price;
            }

            public virtual void VehicleDescription()
            {
                Console.WriteLine($"Vehicle Description: {Year} {Make} {Model} ${Price} {LicensePlate}");
            }
        }

        class Car : Vehicle
        {
            public int Doors{ get; set; }

            public string Type { get; set; }

            public Car(int year, string make, string model, int price, string licensePlate, string type, int doors) : base(year, make, model, price, licensePlate)
            {

                Doors = doors;
                Type = type;
            }

            public override void VehicleDescription()
            {
                Console.WriteLine($"\tCar Description:\n\t Year: {Year}\n\t Make: {Make}\n\t Model: {Model}\n\t Type: {Type}\n\t Doors: {Doors}\n\t Price: ${Price}\n\t License Plate: {LicensePlate}\n");
            }
        }

        class Truck : Vehicle
        {
            public string Bed { get; set; }
            public string Drive { get; set; }

            public Truck(int year, string make, string model, int price, string licenseNumber, string drive, string bed) : base(year, make, model, price, licenseNumber)
            {
                Bed = bed;
                Drive = drive;
            }

            public override void VehicleDescription()
            {
                Console.WriteLine($"\tTruck Description:\n\t Year: {Year}\n\t Make: {Make}\n\t Model: {Model}\n\t Drive: {Drive}\n\t Bed: {Bed}\n\t Price: ${Price}\n\t License Plate: {LicensePlate}\n");
            }

        }

        class CarLot
        {
            public string Name { get; set; }
            public string Intro{ get; set; }



            public CarLot(string name, string intro)
            {
                Name = name;
                Intro = intro;
            }

            public CarLot(string v)
            {
                this.v = v; //not 100% sure what this does but intellisense recommended it and it made the red lines go away until I can actually figure out what I did wrong
            }

            public List<Vehicle> vehicles = new List<Vehicle>();
            private string v;

            public void AddVehicle(Vehicle vehicle)
            {
                vehicles.Add(vehicle);
            }

            public List<Vehicle> GetVehicles()
            {
                return vehicles;
            }

            public void Info()
            {
                Console.Write($"{Name}, {Intro} ");
            }

        }
    }
}