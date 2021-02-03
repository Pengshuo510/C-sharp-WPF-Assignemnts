//Cong Liu, Zalak Patel, Jyoti Mittal, Penghsuo Liu
using System.Windows;

namespace PopulationDBMS
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        readonly VM vm;
        readonly Population population = new Population();

        public EditWindow(bool isEdit)
        {
            InitializeComponent();
            vm = VM.Instance;
            if (isEdit)
            {
                population.City = vm.SelectedPopulation.City;
                population.PopulationNum = vm.SelectedPopulation.PopulationNum;

                population.IsNew = false;
                txtCity.IsEnabled = false;
            }
            else
                Title = "Add Population";

            DataContext = population;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            vm.Save(population);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
