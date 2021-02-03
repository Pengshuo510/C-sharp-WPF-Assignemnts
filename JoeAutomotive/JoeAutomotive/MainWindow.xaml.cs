//Zalak Patel, Jyoti Mittal, Pengshuo Liu
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JoeAutomotive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            vm.Total();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            vm.Clear();
        }

        private void TxtPart_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            e.Handled = !decimal.TryParse(tb.Text + e.Text, out _);//try >0?
        }

        private void TxtNoOfHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            e.Handled = !int.TryParse(tb.Text + e.Text, out _);
        }

        /*
        if(decimal.TryParse(Parts.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint,
        CultureInfo.CurrentCulture, out decimal partsVal))
            parts = partsVal;
        */
    }
}
