using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class DataProperty
    {
        public string Name { get; set; }

        public DataType Range { get; set; }

        public DeclarationType DeclarationType => DeclarationType.DataProperty;

        public IEnumerable<Annotation> Annotations { get; set; }
    }
}