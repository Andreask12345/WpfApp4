using System;
using System.Windows;

namespace WpfApp4
{
    public partial class ToppingsWindow : Window
    {
        public bool ExtraCheeseSelected { get; private set; }
        public bool ExtraBaconSelected { get; private set; }
        public bool ExtraSelected { get; private set; }
        public bool ExtraMozzarellaCheeseSelected { get; private set; }
        public bool ExtraPepperoniSelected { get; private set; }
        public bool ExtraMushroomsSelected { get; private set; }
        public bool ExtraOnionsSelected { get; private set; }
        public bool ExtraOliveSelected { get; private set; }
        public bool ExtraSausageSelected { get; private set; }
        public bool ExtraHamSelected { get; private set; }
        public bool ExtraPineappleSelected { get; private set; }
        public bool ExtraSpinachSelected { get; private set; }
        public bool ExtraJalapenosSelected { get; private set; }
        public bool ExtraAnchoviesSelected { get; private set; }
        public bool ExtraOlivesSelected { get; internal set; }

        public ToppingsWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ExtraCheeseSelected = ExtraCheeseCheckBox.IsChecked ?? false;
            ExtraBaconSelected = ExtraBaconCheckBox.IsChecked ?? false;
            ExtraMozzarellaCheeseSelected = ExtraMozzarellaCheeseCheckBox.IsChecked ?? false;
            ExtraPepperoniSelected = ExtraPepperoniCheckBox.IsChecked ?? false;
            ExtraMushroomsSelected = ExtraMushroomsCheckBox.IsChecked ?? false;
            ExtraOnionsSelected = ExtraOnionsCheckBox.IsChecked ?? false;
            ExtraOliveSelected = ExtraOliveCheckBox.IsChecked ?? false;
            ExtraSausageSelected = ExtraSausageCheckBox.IsChecked ?? false;
            ExtraHamSelected = ExtraHamCheckBox.IsChecked ?? false;
            ExtraPineappleSelected = ExtraPineappleCheckBox.IsChecked ?? false;
            ExtraSpinachSelected = ExtraSpinachCheckBox.IsChecked ?? false;
            ExtraJalapenosSelected = ExtraJalapenosCheckBox.IsChecked ?? false;
            ExtraAnchoviesSelected = ExtraAnchoviesCheckBox.IsChecked ?? false;
            ExtraOlivesSelected = ExtraOlivesCheckBox.IsChecked ?? false;

            DialogResult = true;
        }
    }
}
