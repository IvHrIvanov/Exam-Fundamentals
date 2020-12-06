using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Pirates
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Town> targets = new List<Town>();
            string[] citiyes = Console.ReadLine().Split("||");
            while (citiyes[0] != "Sail")
            {
                string currentTown = citiyes[0];
                int population = int.Parse(citiyes[1]);

                int gold = int.Parse(citiyes[2]);

                Town newTown = new Town(currentTown, population, gold);
                if (!targets.Any(x => x.City == currentTown))
                {

                    targets.Add(newTown);
                }
                else
                {
                    int indexPopulation = targets.FindIndex(t => t.City == currentTown);
                    targets[indexPopulation].Population += population;
                    targets[indexPopulation].Gold += gold;
                }
                citiyes = Console.ReadLine().Split("||");
            }

            string[] commands = Console.ReadLine().Split("=>");
            while (commands[0] != "End")
            {

                if (commands[0] == "Plunder")
                {
                    string townAtacked = commands[1];
                    int killPpl = int.Parse(commands[2]);
                    int stealGold = int.Parse(commands[3]);
                    int index = targets.FindIndex(t => t.City == townAtacked);

                    if (targets.Any(x => x.City == townAtacked) &&
                        targets[index].Gold >= stealGold &&
                        targets[index].Population >= killPpl)
                    {
                        int gold = targets[index].Gold - stealGold;
                        int people = targets[index].Population - killPpl;
                        Console.WriteLine($"{townAtacked} plundered! {stealGold} gold stolen, {killPpl} citizens killed.");
                        targets[index].Population -= killPpl;
                        targets[index].Gold -= stealGold;

                        if (targets[index].Gold == 0 ||
                           targets[index].Population == 0)
                        {
                            Console.WriteLine($"{townAtacked} has been wiped off the map!");
                            targets.RemoveAt(index);
                        }

                    }
                    
                }
                else if(commands[0]=="Prosper")
                {
                    string townHelped = commands[1];
                    int goldAdd = int.Parse(commands[2]);

                    if(goldAdd>=0)
                    {
                        int index = targets.FindIndex(t => t.City == townHelped);
                        targets[index].Gold += goldAdd;
                        
                        Console.WriteLine($"{goldAdd} gold added to the city treasury. {townHelped} now has {targets[index].Gold} gold.");

                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");

                    }
                }

                commands = Console.ReadLine().Split("=>");
            }

            Console.WriteLine($"Ahoy, Captain! There are {targets.Count} wealthy settlements to go to:");

            foreach (var item in targets.OrderByDescending(x=>x.Gold).ThenBy(t=>t.City))
            {
                Console.WriteLine($"{item.City} -> Population: {item.Population} citizens, Gold: {item.Gold} kg");
            }
        }
    }
    class Town
    {
        public Town(string city, int population, int gold)
        {
            City = city;
            Population = population;
            Gold = gold;
        }

        public string City { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

    }
}
