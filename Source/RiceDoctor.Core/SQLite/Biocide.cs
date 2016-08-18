using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiceDoctor.Core.SQLite
{
    public class Biocide
    {
        private string name;
        private string scientificName;
        public string expirationDate;
        public string producer;
        public Biocide()
        {

        }
        public string getname { get; set; }
        public string scientificName { get; set; }
        public string expirationDate { get; set; }
        public string proceducer { get; set; }
    }

}
