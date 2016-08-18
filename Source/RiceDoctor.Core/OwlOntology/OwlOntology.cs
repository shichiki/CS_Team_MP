using System.Collections.Generic;

namespace RiceDoctor.Core.OwlOntology
{
    public class OwlOntology
    {
        public List<Declaration> Declarations { get; set; }
        public List<string> DisjointClasses { get; set; }
        public List<ClassAssertion> ClassAssertions { get; set; }
        public List<DataPropertyAssertion> DataPropertyAssertions { get; set; }
        public List<ObjectPropertyDomain> ObjectPropertyDomains { get; set; }
        public List<ObjectPropertyRange> ObjectPropertyRanges { get; set; }
        public List<DataPropertyRange> DataPropertyRanges { get; set; }
    }
}