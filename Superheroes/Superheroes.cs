using System;
using System.Collections.Generic;

namespace Superheroes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            people.Add(new Hero("Cyclops", string.Empty, "Scott Summers", "Energy Blast"));
            people.Add(new Hero("Phoenix", string.Empty, "Jean Grey", "Telepathy"));
            people.Add(new Hero("Professor X", string.Empty, "Charles Xavier", "Telekenisis"));
            people.Add(new Villain("Black King", string.Empty, "Cyclops"));
            people.Add(new Villain("White Queen", string.Empty, "Phoenix"));
            people.Add(new Villain("Apocalypse", string.Empty, "Professor X"));
            people.Add(new Person("Bobby Drake", "Iceman"));
            people.Add(new Person("John Allerdyce", "Pyro"));
            people.Add(new Person("Jubilation Lee", "Jubilee"));

            foreach (var person in people)
            {

                Console.WriteLine($"{person.Name}: {person.Introduction()}");

            }
            Console.ReadKey();
        }

        class Person
        {
      
            public string Name { get; set; }

            public string Nickname { get; set; }

            public Person(string name, string nickname)
            {
                Name = name;
                Nickname = nickname;
            }

            public virtual string Introduction()
            {
                return ($"Hey, I'm {Name}, but you can call me {Nickname}!");
            }
            
            
        }

        class Hero : Person
        {

            public string Powers { get; set; }
            public string Identity { get; set; }
            public Hero(string name, string nickname, string identity, string powers) : base(name, nickname)
            {
                Identity = identity;
                Powers = powers;
            }
            public override string Introduction()
            {
                return $"I am {Identity}, but you can call me {Name}.\nI use {Powers} to fight crime in the city.";
            }
        }

        class Villain : Person
        {
            public string Enemy { get; set; }
            public Villain(string name, string nickname, string enemy) : base(name, nickname)
            {
                Enemy = enemy;
            }
            public override string Introduction()
            {
                return $"You will call me {Name}, where is {Enemy}?";
            }
        }
    }
}
