using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace PizzaExercise_Console.Utility
{
    public class JsonHelper
    {
        /// <summary>
        /// Downloads a file from specified url to physical path 
        /// </summary>
        /// <param name="url">url for the downloadable file</param>
        /// <param name="toPath">physical path to store file</param>
        /// <returns>true if download is successfull.</returns>
        public static bool DownloadFromUrl(string url, string toPath)
        {
            bool downloadsuccess = false;
            //download file 
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(url, toPath);
                downloadsuccess = true;
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Message:{ex.Message}:\n1.Make sure your internet is on and url is correct.\n2.Make sure Physical FilePath is correct and have write permission");
            }
            return downloadsuccess;
        }

        /// <summary>
        /// Generates a object from Json data from file
        /// </summary>
        /// <param name="filepath">physical path for json file</param>
        /// <returns>c# object</returns>
        public static IList<Order> GetDataFromJson(string filepath)
        {
            IList<Order> ordersList = new List<Order>();
            try
            {
                using (StreamReader file = File.OpenText(filepath))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    var ordersArray = (JArray)JToken.ReadFrom(reader);
                    ordersList = ordersArray.ToObject<IList<Order>>();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("File read failed: check for read permission on File");
            }
            return ordersList;
        }


    }
}
