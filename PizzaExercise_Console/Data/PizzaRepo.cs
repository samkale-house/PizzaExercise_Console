﻿using PizzaExercise_Console.Model;
using PizzaExercise_Console.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaExercise_Console.Data
{
    public class PizzaRepo
    {
        public IList<Order> GetAllDataFromJson(string filepath)
        {
            IList<Order> toppingDetailsForAllOrder = new List<Order>();

            if (!string.IsNullOrEmpty(filepath))
            {
                toppingDetailsForAllOrder = JsonHelper.GetDataFromJson(filepath);
            }

            return toppingDetailsForAllOrder;
        }

        //Find different Topping combinations and it's frequency 
        //Dictionary:key is ToppingCombination, value is frequency
        public Dictionary<Order,int> GetDifferentToppingCombinations(IList<Order> toppingDetailsForAllOrder)
        {           
           
            
            Dictionary<Order, int> dictToppingPerOrder = new Dictionary<Order, int>();
            foreach (var obj in toppingDetailsForAllOrder)
            {
                if (!dictToppingPerOrder.TryAdd(obj, 1))
                {
                    //edit the topping combinations' frequency
                    dictToppingPerOrder[obj] += 1;
                }

            }
            return dictToppingPerOrder;

        }
        public IList<ToppingsCombination> GetTopTwentyToppingsCombination(string filepath)
        {
            

            //save data from json file into collection
            var toppingDetailsForAllOrder = GetAllDataFromJson(filepath);
            var differentToppingCombinations = GetDifferentToppingCombinations(toppingDetailsForAllOrder);

            //create top20 list and returnlist or print
            IList<ToppingsCombination> top20ToppingCombinations = new List<ToppingsCombination>();

            var top20ToppingsDict = differentToppingCombinations.OrderByDescending(x => x.Value).Take(20);
            top20ToppingCombinations = ConversionHelper.FromOrderListToToppingCombinationList(top20ToppingsDict);


            return top20ToppingCombinations;
        }
    }
}
