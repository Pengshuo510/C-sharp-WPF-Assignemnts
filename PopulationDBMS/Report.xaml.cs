//Cong Liu, Zalak Patel, Jyoti Mittal, Penghsuo Liu
using System.Windows;

namespace PopulationDBMS
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        readonly VM vm;

        public Report()
        {
            InitializeComponent();
            vm = VM.Instance; 
            DataContext = vm;
            vm.CalcReport();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            vm.UpdatePopulations();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
