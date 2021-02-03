using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceSimulator
{
    class Image
    {
        public string ImagePath { get; set; }

        public static implicit operator Image(string v)
        {
            throw new NotImplementedException();
        }

        internal static string FromFile(string v)
        {
            throw new NotImplementedException();
        }
    }
}
