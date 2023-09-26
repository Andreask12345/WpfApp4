using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp4
{
    public class Pizza
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string> SelectedToppings { get; set; }

        public Pizza(string name, decimal price)
        {
            Name = name;
            Price = price;
            SelectedToppings = new List<string>();
        }

        public string GetFormattedToppings()
        {
            return string.Join(", ", SelectedToppings);
        }
    }
}
