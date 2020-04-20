using System;
using System.Collections.Generic;
using System.Linq;

namespace Gradebook
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name = string.Empty;
            Dictionary<string, string> gradebook = new Dictionary<string, string>();
            do
            {
                Console.WriteLine("Enter a student name.");
                name = Console.ReadLine();
                Console.WriteLine("Enter student's grades.");
                string grades = Console.ReadLine();

                gradebook.Add(name, grades);



            } while (!name.Equals("quit"));

                do
                {
                    int lowestGrade = 0;
                    int highestGrade = 0;
                    double average = 0.00;
                    foreach (var item in gradebook)
                    {
                        Console.WriteLine($"\n{item.Key}\n");


                        int[] singleGrades = Array.ConvertAll(gradebook[item.Key].Split(), Convert.ToInt32);

                        lowestGrade = singleGrades.Min();
                        highestGrade = singleGrades.Max();
                        average = singleGrades.Average();

                        Console.Write($"Highest grade = {highestGrade} Lowest grade = {lowestGrade} Average = {average}\n");
                    } 
                } while (name.Equals("quit"));
        }
               
               /* int lowestGrade = 0;
                int highestGrade = 0;
                double average = 0.00;
                foreach (var item in gradebook)
                {
                    Console.WriteLine($"\n{item.Key}\n");


                    int[] singleGrades = Array.ConvertAll<string, int>(gradebook[item.Key].Split(), Convert.ToInt32);

                    lowestGrade = singleGrades.Min();
                    highestGrade = singleGrades.Max();
                    average = singleGrades.Average();

                    Console.Write($"Highest grade = {highestGrade} Lowest grade = {lowestGrade} Average = {average}\n");
                }*/
            
        
    }
}