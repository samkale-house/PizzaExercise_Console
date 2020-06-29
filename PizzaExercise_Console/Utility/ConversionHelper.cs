using PizzaExercise_Console.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaExercise_Console.Utility
{
    /// <summary>
    /// This class provides method for converting from one custom object to other custom object
    /// </summary>
    static class ConversionHelper
    {
        public static IList<ToppingsCombination> FromOrderListToToppingCombinationList(IEnumerable<KeyValuePair<Order, int>> toppingCombinationWithCount)
        {
            IList<ToppingsCombination> toppingCombinations = new List<ToppingsCombination>();
            if (toppingCombinationWithCount != null)
            {
                int rank = 1;
                foreach (var combination in toppingCombinationWithCount)
                {
                    toppingCombinations.Add(new ToppingsCombination
                    {
                        Toppings = combination.Key.Toppings,
                        AppearedInOrderCount = combination.Value,
                        Rank = rank

                    });
                    rank += 1;
                }


            }
            return toppingCombinations;
        }
    }
}
