using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiceDoctor.Core.Ontology
{
    public class Attribute
    {
        public string Name { get; set; }
        public string OwlType { get; set; }
        public string SqlType { get; set; }
    }
}
