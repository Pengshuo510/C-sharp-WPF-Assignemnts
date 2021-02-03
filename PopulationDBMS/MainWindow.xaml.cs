//Cong Liu, Zalak Patel, Jyoti Mittal, Penghsuo Liu
using System.Windows;

namespace PopulationDBMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = VM.Instance;
            DataContext = vm;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EditWindow ew = new EditWindow(false) { Owner = this };
            ew.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedPopulation == null)
                MessageBox.Show("Please select a city to edit");
            else
            {
                EditWindow ew = new EditWindow(true) { Owner = this };
                ew.ShowDialog();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedPopulation == null)
                MessageBox.Show("Please select a city to delete");
            else
                vm.Delete();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Report ew = new Report() { Owner = this };
            ew.ShowDialog();
        }
    }
}
