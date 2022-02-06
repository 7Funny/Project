using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            foreach (string line in File.ReadAllLines("persons.txt"))
            {
                persons.Add(Person.Parse(line));
            }

            bool trueNumber = true;

            while (trueNumber)
            {
                Console.WriteLine("Enter command number:");
                Console.WriteLine("1. Sort ascending?");
                Console.WriteLine("2. Sort descending?");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        persons.Sort((x, y) => x.Birthday.CompareTo(y.Birthday));
                        trueNumber = false;
                        break;
                    case 2:
                        persons.Sort((x, y) => y.Birthday.CompareTo(x.Birthday));
                        trueNumber = false;
                        break;
                    default:
                        Console.WriteLine(">> Wrong command number!");
                        break;
                }
            }
            foreach(var person in persons)
                File.AppendAllText("out.txt", $"{person.ToString() +"\n"}");
        }       
    }
}
