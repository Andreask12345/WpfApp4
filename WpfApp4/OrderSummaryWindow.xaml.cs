using System.Collections.Generic;
using System.Windows;

namespace WpfApp4
{
    public partial class OrderSummaryWindow : Window
    {
        public OrderSummaryWindow(List<Pizza> cart, List<Drink> drinkCart, decimal totalPrice)
        {
            InitializeComponent();

            foreach (Pizza pizza in cart)
            {
                OrderListView.Items.Add(pizza);
            }

            foreach (Drink drink in drinkCart)
            {
                OrderListView.Items.Add(drink);
            }

            TotalPriceTextBlock.Text = "Total price: " + totalPrice.ToString("C");
        }
    }
}
