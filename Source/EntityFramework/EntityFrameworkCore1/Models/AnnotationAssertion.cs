using System;
using System.Collections.Generic;

namespace EntityFrameworkCore1.Models
{
    public partial class AnnotationAssertion
    {
        public long Id { get; set; }
        public string AnnotationPropertyAbbreviatedIri { get; set; }
        public long LiteralId { get; set; }
        public string LiteralXmlLang { get; set; }
        public string LiteralDatatypeIri { get; set; }
        public string LiteralValue { get; set; }

        public virtual Declaration Literal { get; set; }
    }
}
