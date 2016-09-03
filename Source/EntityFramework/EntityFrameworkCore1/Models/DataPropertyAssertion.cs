using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1.Models
{
    public partial class DataPropertyAssertion
    {
        public long Id { get; set; }
        public long DataPropertyId { get; set; }
        public long NamedIndividualId { get; set; }
        public string LiteralDatatypeIri { get; set; }
        public string LiteralValue { get; set; }

        public virtual Declaration DataProperty { get; set; }
        public virtual Declaration NamedIndividual { get; set; }
    }
}
