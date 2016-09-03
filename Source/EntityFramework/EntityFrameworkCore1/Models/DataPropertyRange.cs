using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1.Models
{
    public partial class DataPropertyRange
    {
        public long Id { get; set; }
        public long DataPropertyId { get; set; }
        public string DatatypeAbbreviatedIri { get; set; }

        public virtual Declaration DataProperty { get; set; }
    }
}
