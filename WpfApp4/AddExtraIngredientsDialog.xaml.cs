using System.Windows;

namespace WpfApp4
{
    public partial class ToppingsWindow : Window
    {
        public bool ExtraCheeseSelected { get; private set; }
        public bool ExtraBaconSelected { get; private set; }

        public ToppingsWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ExtraCheeseSelected = ExtraCheeseCheckBox.IsChecked ?? false;
            ExtraBaconSelected = ExtraBaconCheckBox.IsChecked ?? false;

            DialogResult = true;
        }
    }
}
