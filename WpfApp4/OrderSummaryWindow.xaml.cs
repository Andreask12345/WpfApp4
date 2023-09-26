using System.Collections.Generic;
using System.Windows;

namespace WpfApp4

{
    public partial class OrderSummaryWindow : Window
    {

        public OrderSummaryWindow(List<Pizza> cart, decimal totalPrice)
        {
            InitializeComponent();

            foreach (Pizza pizza in cart)
            {
                OrderListView.Items.Add(pizza);
            }

            TotalPriceTextBlock.Text = "Total price: " + totalPrice.ToString("C");
        }
    }
}
