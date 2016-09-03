using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class Entity
    {
        internal long? DeclarationId { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Instances { get; internal set; }

        // TODO: Working with disjointness based on http://ontogenesis.knowledgeblog.org/1260.
        public IEnumerable<string> DisjoinClasses { get; internal set; }

        public DeclarationType DeclarationType => DeclarationType.Class;

        public IEnumerable<Annotation> Annotations { get; internal set; }
    }
}