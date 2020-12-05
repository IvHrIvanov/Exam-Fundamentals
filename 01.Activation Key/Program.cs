using System;
using System.Text;
using System.Linq;
namespace _01.Activation_Key
{
    class Program
    {
        static void Main(string[] args)
        {

            string key = Console.ReadLine();

            string[] command = Console.ReadLine().Split(">>>");

            while (command[0] != "Generate")
            {
                StringBuilder sb = new StringBuilder();
                switch (command[0])
                {
                    case "Contains":

                        if (key.Contains(command[1]))
                        {
                            sb.Append($"{key} contains {command[1]}");
                        }
                        else
                        {
                            sb.Append($"Substring not found!");
                        }

                        break;
                    case "Flip":
                        int startIndex = int.Parse(command[2]);
                        int endIndex = int.Parse(command[3]);
                        if (command[1] == "Upper")
                        {
                            key = key.Substring(0, startIndex) + key.Substring(startIndex, endIndex - startIndex).ToUpper() + key.Substring(endIndex);
                            sb.Append(key);
                        }
                        else if (command[1] == "Lower")
                        {

                            key = key.Substring(0, startIndex) + key.Substring(startIndex, endIndex - startIndex).ToLower() + key.Substring(endIndex);
                            sb.Append(key);
                        }
                        break;
                    case "Slice":
                        startIndex = int.Parse(command[1]);
                        endIndex = int.Parse(command[2]);
                        key = key.Remove(startIndex, endIndex-startIndex);
                        sb.Append(key);
                        break;
                }
                Console.WriteLine(sb);
                command = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}