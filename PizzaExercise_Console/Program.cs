using NLog;
using PizzaExercise_Console.Data;
using PizzaExercise_Console.Model;
using PizzaExercise_Console.Utility;
using System;
using System.Collections.Generic;
using System.IO;

namespace PizzaExercise_Console
{
    class Program
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        static string filepath = Directory.GetCurrentDirectory() + "/pizzas.json";
        static string downloadFromPath = "https://www.olo.com/pizzass.json";
        static void Main(string[] args)
        {

            PizzaRepo repo = new PizzaRepo();

            //1. Download Json file from url
            bool isDownloadSuccessfull = JsonHelper.DownloadFromUrl(downloadFromPath, filepath);


            //2.GetTop20ToppingFromJsonData
            try
            {
                IList<ToppingsCombination> result = repo.GetTopTwentyToppingCombination(filepath);
                //3.Print the results
                if(result!=null &&result.Count>0)
                foreach (ToppingsCombination item in result)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch(Exception e)
            {
                logger.Fatal($"url:{downloadFromPath} isDownloadSuccessfull:{isDownloadSuccessfull}");
                Console.WriteLine("Download fail for Json file");
            }

            //3.exit
            logger.Info("Application terminated. Press <enter> to exit...");
            Console.ReadLine();

        }
    }
}
