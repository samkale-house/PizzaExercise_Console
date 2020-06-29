using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace PizzaExercise_Console.Utility
{
    public class JsonHelper
    {
        public static bool DownloadFromUrl(string fromUrl,string toPath)
        {
            bool downloadsuccess = false;
            //download file 
            try
            {                
                WebClient webClient = new WebClient();
                webClient.DownloadFile(fromUrl, toPath);
                downloadsuccess = true;
            }
            catch(WebException ex) 
             {                
                Console.WriteLine($"Message:{ex.Message}:\n1.Make sure your internet is on and url is correct.\n2.Make sure Physical FilePath is correct and have write permission");
            }
            return downloadsuccess;
        }

        public static IList<Order> GetDataFromJson(string filepath)
        {
            IList<Order> ordersList;
            // read JSON from a file
            using (StreamReader file = File.OpenText(filepath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var ordersArray = (JArray)JToken.ReadFrom(reader);
                ordersList = ordersArray.ToObject<IList<Order>>();
            }
            return ordersList;
        }


    }
}
