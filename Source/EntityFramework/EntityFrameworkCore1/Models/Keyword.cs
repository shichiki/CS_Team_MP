using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1.Models
{
    public partial class Keyword
    {
        public long Id { get; set; }
        public string VietnameseName { get; set; }
        public string Definition { get; set; }
        public long DeclarationId { get; set; }

        public virtual Declaration Declaration { get; set; }
    }
}
