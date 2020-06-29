using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace PizzaExercise_Console
{
    /// <summary>
    /// This class represents one order from incoming Json data.
    /// It implements IEquatable to compare two orders based on its topping list
    /// </summary>
    
    public class Order : IEquatable<Order>
    {
        public List<string> Toppings { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Order);
        }

        public bool Equals(Order other)
        {
            return other != null && 
                Enumerable.SequenceEqual(this.Toppings.OrderBy(t => t), other.Toppings.OrderBy(t => t));
        }

        public override int GetHashCode()
        {
            int hc = 0;
            if (Toppings != null)
            {
                foreach (string t in Toppings)
                    hc += t.GetHashCode();
            }
            return hc;
        }

    }
}
