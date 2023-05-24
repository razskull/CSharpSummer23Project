using System;
using App.PracticePanther.Models;
using App.PracticePanther.Helpers;

namespace App.PracticePanther// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientHelper = new ClientHelper();
            Console.WriteLine("Choose an Action:");
            Console.WriteLine("1. Add Client");
            Console.WriteLine("2. Exit");
            var input = Console.ReadLine();
            if(int.TryParse(input, out int result))
            {
                while(result != 2)
                {
                    if (result == 1)
                    {
                        clientHelper.CreateClient();
                    }
                    Console.WriteLine("Choose an Action:");
                    Console.WriteLine("1. Add Client");
                    Console.WriteLine("2. Exit");
                    input = Console.ReadLine();
                    int.TryParse(input, out result);
                }
                
            }
        }
    }
}

