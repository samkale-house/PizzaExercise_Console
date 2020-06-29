using System.Collections.Generic;
using System.Text;

namespace PizzaExercise_Console.Model
{
    /// <summary>
    /// This class represents one topping combination,with the it's frequency of order and its rank
    /// </summary>
    public class ToppingsCombination
    {
        public List<string> Toppings { get; set; }
        public int AppearedInOrderCount { get; set; }
        public int Rank { get; set; }

        public override string ToString()
        {
            StringBuilder toppingCombination = new StringBuilder();
            foreach (string t in Toppings)
                toppingCombination.Append(t + " ");
            return ($"Rank:{Rank} Toppings:[{string.Join(",", Toppings)}]  Ordered:{AppearedInOrderCount} times");
        }

    }
}
