//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework6
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataPropertyAssertion
    {
        public long Id { get; set; }
        public long DataPropertyId { get; set; }
        public long NamedIndividualId { get; set; }
        public string LiteralDatatypeIri { get; set; }
        public string LiteralValue { get; set; }
    
        public virtual Declaration Declaration { get; set; }
        public virtual Declaration Declaration1 { get; set; }
    }
}
