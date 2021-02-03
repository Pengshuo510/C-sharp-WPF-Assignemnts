// Pengshuo Liu
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ExamScores
{
    public class VM : INotifyPropertyChanged
    {
        #region properties
        private List<int> Scores { get; set; } = new List<int>();
        public BindingList<int> ScoreList1 { get; set; } = new BindingList<int>();
        public BindingList<int> ScoreList2 { get; set; } = new BindingList<int>();
        public BindingList<int> ScoreList3 { get; set; } = new BindingList<int>();

        private double avgSec1 = 0;
        public double AvgSec1
        {
            get { return avgSec1; }
            set { avgSec1 = value; propChange(); }
        }
        private double avgSec2 = 0;
        public double AvgSec2
        {
            get { return avgSec2; }
            set { avgSec2 = value; propChange(); }
        }
        private double avgSec3 = 0;
        public double AvgSec3
        {
            get { return avgSec3; }
            set { avgSec3 = value; propChange(); }
        }
        private double avgAll = 0;
        public double AvgAll
        {
            get { return avgAll; }
            set { avgAll = value; propChange(); }
        }
        private int highest = 0;
        public int Highest
        {
            get { return highest; }
            set { highest = value; propChange(); }
        }
        private List<int> highestSec = new List<int>();
        public List<int> HighestSec
        {
            get { return highestSec; }
            set { highestSec = value; propChange(); }
        }
        private int lowest = 0;
        public int Lowest
        {
            get { return lowest; }
            set { lowest = value; propChange(); }
        }
        private List<int> lowestSec = new List<int>();
        public List<int> LowestSec
        {
            get { return lowestSec; }
            set { lowestSec = value; propChange(); }
        }
        #endregion

        int[][] scorelist = new int[3][];

        public void SectionRead(string fileName, int fileId, BindingList<int> listName)
        {
            string text = File.ReadAllText(fileName);
            string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            scorelist[fileId] = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                scorelist[fileId][i] = int.Parse(lines[i]);
                listName.Add(scorelist[fileId][i]);
            }
            Scores.AddRange(scorelist[fileId]);
        }

        public void Import()
        {
            SectionRead("section1.txt", 0, ScoreList1);
            SectionRead("section2.txt", 1, ScoreList2);
            SectionRead("section3.txt", 2, ScoreList3);
        }

        public (int, List<int>) HighestSearch()
        {
            int highest = scorelist[0][0];
            List<int> section = new List<int>();
            for (int i = 0; i < scorelist.Length; i++)
            {
                for (int j = 0; j < scorelist[i].Length; j++)
                {
                    if (scorelist[i][j] >= highest)
                    {
                        highest = scorelist[i][j];
                        section.Append(i + 1);//Why is this section list still empty?
                    }
                }
            }
            return (highest, section);
        }

        public (int, List<int>) LowestSearch()
        {
            int lowest = scorelist[0][0];
            List<int> section = new List<int>();
            for (int i = 0; i < scorelist.Length; i++)
            {
                for (int j = 0; j < scorelist[i].Length; j++)
                {
                    if (scorelist[i][j] <= lowest)
                    {
                        lowest = scorelist[i][j];
                        section.Append(i + 1);//Why is this section list still empty?
                    }
                }
            }
            return (lowest, section);
        }

        //Why do two functions below not work? The only difference between these and functions above
        //are not having section list.

        /*
        public (int, int) HighestSearch()
        {
            int highest = scorelist[0][0];
            int section = 0;
            for (int i = 0; i < scorelist.Length; i++)
            {
                for (int j = 0; j < scorelist[i].Length; j++)
                {
                    if (scorelist[i][j] >= highest)
                    {
                        highest = scorelist[i][j];
                        section = i + 1;
                    }
                }
            }
            return (highest, section);
        }

        public (int, int) LowestSearch()
        {
            int lowest = scorelist[0][0];
            int section = 0;
            for (int i = 0; i < scorelist.Length; i++)
            {
                for (int j = 0; j < scorelist[i].Length; j++)
                {
                    if (scorelist[i][j] <= lowest)
                    {
                        lowest = scorelist[i][j];
                        section = i + 1;
                    }
                }
            }
            return (lowest, section);
        }
         */

        // Why these doesn't work either?

        /*
        public (int, int) HighestSearch() 
        {
            int highest = scorelist[0].Max();
            int position = 1;
            for(int i = 0; i < 3; i++)
            {
                if (scorelist[i].Max() >= highest)
                {
                    highest = scorelist[i].Max();
                    position = i + 1;
                }
            }
            return (highest, position);
        }

        public (int, int) LowestSearch()
        {
            int lowest = scorelist[0].Min();
            int position = 1;
            for (int i = 0; i < 3; i++)
            {
                if (scorelist[i].Min() <= lowest)
                {
                    lowest = scorelist[i].Min();
                    position = i + 1;
                }
            }
            return (lowest, position);
        }
        */

        public void Calculate()
        {
            AvgSec1 = ScoreList1.Average();
            AvgSec2 = ScoreList2.Average();
            AvgSec3 = ScoreList3.Average();
            AvgAll = Scores.Average();
            (Highest, HighestSec) = HighestSearch();
            (Lowest, LowestSec) = LowestSearch();
        }

        #region prop change
        public event PropertyChangedEventHandler PropertyChanged;

        private void propChange([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
