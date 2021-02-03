// Pengshuo Liu
using System.Windows;

namespace ExamScores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            vm.Import();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            vm.Calculate();
        }
    }
}
