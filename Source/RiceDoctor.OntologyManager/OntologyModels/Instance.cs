using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class Instance
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public DeclarationType DeclarationType => DeclarationType.NamedIndividual;

        public IEnumerable<Annotation> Annotations { get; set; }
    }
}