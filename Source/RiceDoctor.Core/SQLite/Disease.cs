using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiceDoctor.Core.SQLite
{
    public class Disease
    {
        private string name;
        private string scientificName;
        public Disease(string name, string scientificname)
        {
            this.name = name;
            this.scientificName = scientificname;
        }
        public string getname { get; set; }
        public string getscientificName { get; set; }

        

    }
}
