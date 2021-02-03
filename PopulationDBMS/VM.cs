//Cong Liu, Zalak Patel, Jyoti Mittal, Penghsuo Liu
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PopulationDBMS
{
    internal class VM : INotifyPropertyChanged
    {
        readonly DB db = DB.Instance;
        List<Population> populations;

        #region singleton
        private static VM vm;
        public static VM Instance { get { vm ??= new VM(); return vm; } }

        private VM()
        {
            populations = db.Get();
            UpdatePopulations();
        }
        #endregion

        #region properties
        public BindingList<Population> Populations { get; set; } = new BindingList<Population>();

        private Population selectedPopulation;
        public Population SelectedPopulation
        {
            get { return selectedPopulation; }
            set { selectedPopulation = value; propertyChanged(); }
        }

        public int MaxPopulation { get; set; } = 0;
        public string MaxCity { get; set; } = string.Empty;
        public int MinPopulation { get; set; }
        public string MinCity { get; set; } = string.Empty;
        public int SumPopulation { get; set; } = 0;
        public double AvePopulation { get; set; } = 0;

        private int selectedSort;//enum
        public int SelectedSort
        {
            get { return selectedSort; }
            set { selectedSort = value; propertyChanged(); }
        }
        #endregion

        #region methods
        public void Save(Population population)
        {
            bool success;

            if (population.IsNew)
            {
                success = db.Insert(population); //return true if the new population is inserted
                population.IsNew = false;
            }
            else
            {
                success = db.Update(population); //return true if the population is updated
                if (success)
                {
                    populations.Remove(SelectedPopulation);
                    SelectedPopulation = null;
                }
            }

            if (success) //refresh the ListItems if the insert or update works
            {
                populations.Add(population);
                UpdatePopulations();
            }
        }

        public void Delete()
        {
            bool success = db.Delete(SelectedPopulation);

            if (success) //refresh the ListItems if the delete works
            {
                populations.Remove(SelectedPopulation);
                SelectedPopulation = null;
                UpdatePopulations();
            }
        }

        public void UpdatePopulations()
        {
            if (SelectedSort == 0)//enum
                populations = populations.OrderBy(p => p.City).ToList();
            else
                populations = populations.OrderByDescending(p => p.PopulationNum).ToList();

            Populations.Clear();
            foreach (Population p in populations)
                Populations.Add(p);
        }

        public void CalcReport()
        {
            // find max population and its city
            foreach (Population p in populations)// max + min
            {
                MaxPopulation = p.PopulationNum > MaxPopulation ? p.PopulationNum : MaxPopulation;//+ p.City
            }
            foreach (Population p in populations)
            {
                MaxCity = p.PopulationNum == MaxPopulation ? p.City : MaxCity;
            }

            // find min population and its city
            foreach (Population p in populations)
            {
                MinPopulation = p.PopulationNum < MaxPopulation ? p.PopulationNum : MinPopulation;
            }
            foreach (Population p in populations)
            {
                MinCity = p.PopulationNum == MinPopulation ? p.City : MinCity;
            }

            // calc total population and average population
            SumPopulation = populations.Sum(p => p.PopulationNum);// avg = sum / num
            AvePopulation = populations.Average(p => p.PopulationNum);
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
