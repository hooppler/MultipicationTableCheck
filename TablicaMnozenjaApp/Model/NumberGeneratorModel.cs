using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablicaMnozenjaApp.Model
{
    public class NumberGeneratorModel
    {
        Random rnd = new Random();
        public NumberGeneratorModel()
        {
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }


        public void GenerateNumbers()
        {
            FirstNumber = rnd.Next(1, 10);
            SecondNumber = rnd.Next(1, 10);
        }
    }
}
