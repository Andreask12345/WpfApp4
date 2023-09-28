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
        private List<Drink> drinkCart = new List<Drink>();
        private decimal totalPrice = 0.0m;
        private ToppingsWindow? toppingsWindow;

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
                string pizzaName = selectedItem?.Content?.ToString() ?? "Default Pizza Name";
                decimal pizzaPrice = 55.0m;

                toppingsWindow = new ToppingsWindow();
                bool? toppingResult = toppingsWindow.ShowDialog();

                if (toppingResult.HasValue && toppingResult.Value)
                {
                    bool extraCheeseSelected = toppingsWindow.ExtraCheeseSelected;
                    bool extraBaconSelected = toppingsWindow.ExtraBaconSelected;
                    bool extraMozzarellaCheeseSelected = toppingsWindow.ExtraMozzarellaCheeseSelected;
                    bool extraPepperoniSelected = toppingsWindow.ExtraPepperoniSelected;
                    bool extraMushroomsSelected = toppingsWindow.ExtraMushroomsSelected;
                    bool extraOnionsSelected = toppingsWindow.ExtraOnionsSelected;
                    bool extraOlivesSelected = toppingsWindow.ExtraOlivesSelected;
                    bool extraSausageSelected = toppingsWindow.ExtraSausageSelected;
                    bool extraHamSelected = toppingsWindow.ExtraHamSelected;
                    bool extraPineappleSelected = toppingsWindow.ExtraPineappleSelected;
                    bool extraSpinachSelected = toppingsWindow.ExtraSpinachSelected;
                    bool extraJalapenosSelected = toppingsWindow.ExtraJalapenosSelected;
                    bool extraAnchoviesSelected = toppingsWindow.ExtraAnchoviesSelected;

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

                    if (extraMozzarellaCheeseSelected)
                    {
                        pizzaName += " + MozzarellaCheese";
                        pizzaPrice += 8.0m;
                    }
                    if (extraPepperoniSelected)
                    {
                        pizzaName += " + Pepperoni";
                        pizzaPrice += 8.0m;
                    }
                    if (extraMushroomsSelected)
                    {
                        pizzaName += " + Mushrooms";
                        pizzaPrice += 8.0m;
                    }
                    if (extraOnionsSelected)
                    {
                        pizzaName += " + Onions";
                        pizzaPrice += 8.0m;
                    }
                    if (extraOlivesSelected)
                    {
                        pizzaName += " + Olives";
                        pizzaPrice += 8.0m;
                    }
                    if (extraSausageSelected)
                    {
                        pizzaName += " + Sausage";
                        pizzaPrice += 8.0m;
                    }
                    if (extraHamSelected)
                    {
                        pizzaName += " + Ham";
                        pizzaPrice += 8.0m;
                    }
                    if (extraPineappleSelected)
                    {
                        pizzaName += " + Pineapple";
                        pizzaPrice += 8.0m;
                    }
                    if (extraSpinachSelected)
                    {
                        pizzaName += " + Spinach";
                        pizzaPrice += 8.0m;
                    }
                    if (extraJalapenosSelected)
                    {
                        pizzaName += " + Jalapenos";
                        pizzaPrice += 8.0m;
                    }
                    if (extraAnchoviesSelected)
                    {
                        pizzaName += " + Anchovies";
                        pizzaPrice += 8.0m;
                    }
                }

                Pizza pizza = new Pizza(pizzaName, pizzaPrice);
                cart.Add(pizza);

                CartListBox.Items.Add(pizzaName);
                totalPrice += pizzaPrice;
                UpdateTotalPrice();

                PizzaListBox.SelectedIndex = -1;
            }
        }


        private void AddDrinkToCart(string drinkName, decimal drinkPrice)
        {
            Drink drink = new Drink(drinkName, drinkPrice);
            drinkCart.Add(drink);
            CartListBox.Items.Add(drinkName);
            totalPrice += drinkPrice;
            UpdateTotalPrice();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderSummaryWindow orderSummaryWindow = new OrderSummaryWindow(cart, drinkCart, totalPrice);
                orderSummaryWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTotalPrice()
        {
            TotalPriceTextBlock.Text = "Total price: " + totalPrice.ToString("C");
        }

        private void AddDrink_Click(object sender, RoutedEventArgs e)
        {
            if (DrinksListBox.SelectedItem != null)
            {
                ListBoxItem selectedDrinkItem = (ListBoxItem)DrinksListBox.SelectedItem;
                string? drinkName = selectedDrinkItem?.Content?.ToString();
                decimal drinkPrice = (decimal)(selectedDrinkItem?.Tag ?? 0.0m);

                if (!string.IsNullOrEmpty(drinkName))
                {
                    AddDrinkToCart(drinkName, drinkPrice);
                }
            }
        }

    }
}

// Resten af din kode for Drink, ToppingsWindow, OrderSummaryWindow og Pizza klasser følger her...
