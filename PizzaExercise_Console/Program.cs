using PizzaExercise_Console.Data;
using PizzaExercise_Console.Model;
using PizzaExercise_Console.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PizzaExercise_Console
{
    class Program
    {
        static string filepath = Directory.GetCurrentDirectory() + "/pizzas.json";
        static string downloadFromPath = "https://www.olo.com/pizzas.json";
        static void Main(string[] args)
        {
            
            PizzaRepo repo = new PizzaRepo();

            //1. Download Json file from url
            bool isDownloadSuccessfull = JsonHelper.DownloadFromUrl(downloadFromPath, filepath);


            //2.GetTop20ToppingFromJsonData
            if (isDownloadSuccessfull)
            {
                IList<ToppingsCombination> result = repo.GetTopTwentyToppingsCombination(filepath);
                //3.Print the results
                foreach (ToppingsCombination item in result)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Download fail for Json file");
            }

            //3.exit
            Console.ReadKey();

        }
    }
}
