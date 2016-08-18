using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiceDoctor.Core.SQLite
{
    public class Soil
    {
        private string name;
        private float PH;
        public Soil(string name, float ph)
        {
            this.name = name;
            this.PH = ph;
        }
        public string getname { get; set; }
        public string getph { get; set; }

    }
}
