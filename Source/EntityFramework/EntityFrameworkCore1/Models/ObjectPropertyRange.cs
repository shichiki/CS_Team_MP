using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1.Models
{
    public partial class ObjectPropertyRange
    {
        public long Id { get; set; }
        public long ObjectPropertyId { get; set; }
        public long ClassId { get; set; }

        public virtual Declaration Class { get; set; }
        public virtual Declaration ObjectProperty { get; set; }
    }
}
