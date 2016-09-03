using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1.Models
{
    public partial class ObjectPropertyAssertion
    {
        public long Id { get; set; }
        public long ObjectPropertyId { get; set; }
        public long NamedIndividualId1 { get; set; }
        public long NamedIndividualId2 { get; set; }

        public virtual Declaration NamedIndividualId1Navigation { get; set; }
        public virtual Declaration NamedIndividualId2Navigation { get; set; }
        public virtual Declaration ObjectProperty { get; set; }
    }
}
