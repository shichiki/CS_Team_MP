using System.Collections.Generic;

namespace RiceDoctor.Core.Ontology
{
    public class Concept
    {
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
    }
}