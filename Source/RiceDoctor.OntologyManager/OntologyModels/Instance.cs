using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class Instance
    {
        internal long? DeclarationId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DeclarationType DeclarationType => DeclarationType.NamedIndividual;

        public IEnumerable<Annotation> Annotations { get; internal set; }
    }
}