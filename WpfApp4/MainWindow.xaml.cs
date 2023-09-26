using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        private List<Pizza> cart = new List<Pizza>();
        private decimal totalPrice = 0.0m;
        private ToppingsWindow toppingsWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        public class ListToStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is List<string> stringList)
                {
                    return string.Join(", ", stringList);
                }
                return string.Empty;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (PizzaListBox.SelectedItem != null)
            {
                ListBoxItem selectedItem = (ListBoxItem)PizzaListBox.SelectedItem;
                string pizzaName = selectedItem.Content.ToString();
                decimal pizzaPrice = 20.0m;

                // Set prices for different pizzas
                if (pizzaName == "Pizza Margherita")
                {
                    pizzaPrice = 20.0m;
                }
                else if (pizzaName == "Pizza Pepperoni")
                {
                    pizzaPrice = 22.0m;
                }
                else if (pizzaName == "Another Pizza Name")
                {
                    pizzaPrice = 25.0m; 
                }


                toppingsWindow = new ToppingsWindow();
                bool? toppingResult = toppingsWindow.ShowDialog();

                if (toppingResult.HasValue && toppingResult.Value)
                {
                    bool extraCheeseSelected = toppingsWindow.ExtraCheeseSelected;
                    bool extraBaconSelected = toppingsWindow.ExtraBaconSelected;

                    if (extraCheeseSelected)
                    {
                        pizzaName += " + Cheese";
                        pizzaPrice += 8.0m; 
                    }

                    if (extraBaconSelected)
                    {
                        pizzaName += " + Bacon";
                        pizzaPrice += 8.0m;
                    }
                }

                Pizza pizza = new Pizza(pizzaName, pizzaPrice);
                cart.Add(pizza);

                CartListBox.Items.Add(pizzaName);
                totalPrice += pizzaPrice;
                UpdateTotalPrice();
            }
        }



        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderSummaryWindow orderSummaryWindow = new OrderSummaryWindow(cart, totalPrice);
                orderSummaryWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTotalPrice()
        {
            TotalPriceTextBlock.Text = "Total pris: " + totalPrice.ToString("C");
        }
    }
}
