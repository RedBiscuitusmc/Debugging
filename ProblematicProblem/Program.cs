using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ProblematicProblem
{
    class program
    {
        static Random rng = new Random();
        public static string response;
        public static bool seeList;
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {


            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");

            response = Console.ReadLine().ToLower();
            if (response != "yes" || response == "y")
            {
                Console.WriteLine("Closing Application ...");
                return;
            }


            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");

            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");

            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? yes/no thanks: ");
            response = Console.ReadLine().ToLower();
            if (response == "yes" || response == "y")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                response = Console.ReadLine().ToLower();

                if (response != "yes" || response == "y")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    for (int i = 0; i < activities.Count; i++)
                    {
                        string activity = activities[i];
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    response = Console.ReadLine().ToLower();
                    if (response != "yes" || response == "y")
                    {
                        Console.WriteLine("Closing Application ...");
                        return;
                    }
                }

                do
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();

                    var randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                    if (userAge > 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);

                    }
                    Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    break;
                }
                while (activities.Count > 0);
            }
        }
    }
}