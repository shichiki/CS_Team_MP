using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class DataProperty
    {
        internal long? DeclarationId { get; set; }

        public string Name { get; set; }

        public DataType Range { get; set; }

        public IEnumerable<string> Domains { get; internal set; }

        public DeclarationType DeclarationType => DeclarationType.DataProperty;

        public IEnumerable<Annotation> Annotations { get; internal set; }
    }
}