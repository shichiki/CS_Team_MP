using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class Entity : Keyword
    {
        public IEnumerable<string> Instances { get; set; }

        // TODO: Working with disjointness based on http://ontogenesis.knowledgeblog.org/1260.
        public IEnumerable<string> DisjoinClasses { get; set; }

        public Entity() : base(DeclarationType.Class)
        {
        }
    }
}