using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayOfExamScores
{
    class VM : INotifyPropertyChanged
    {
        // public ObservableCollection<Scores> Scores { get; set; } = new ObservableCollection<Scores>();
        public BindingList<int> Scores { get; set; } = new BindingList<int>();
        readonly int[][] scorelist = new int[3][];

        public void SectionRead(string fileName, int fileId)
        {
            string text = File.ReadAllText(fileName);
            string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                scorelist[fileId] = new int[lines.Length];
                scorelist[fileId][i] = int.Parse(lines[i]);
                Scores.Add(scorelist[fileId][i]);
            }
        }
        public void Import()
        {
            SectionRead("section1.txt", 0);
            SectionRead("section2.txt", 1);
            SectionRead("section3.txt", 2);

            /*
            string section1 = File.ReadAllText("Section1.txt");
            string[] s1_lines = section1.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string line in s1_lines)
            {
                Scores score = new Scores
                {
                    Section1 = int.Parse(line)
                };
                Scores.Add(score);
            }

            string section2 = File.ReadAllText("Section2.txt");
            string[] s2_lines = section2.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in s2_lines)
            {
                Scores score = new Scores
                {
                    Section2 = int.Parse(line)
                };
                Scores.Add(score);
            }

            string section3 = File.ReadAllText("Section3.txt");
            string[] s3_lines = section3.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in s3_lines)
            {
                Scores score = new Scores
                {
                    Section3 = int.Parse(line)
                };
                Scores.Add(score);
            }
            */
        }

        public void Calculate()
        {

        }

        #region propertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void propChange([CallerMemberName] string propertyName = "")
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
