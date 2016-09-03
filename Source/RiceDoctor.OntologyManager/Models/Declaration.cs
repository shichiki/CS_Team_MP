using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.Models
{
    public partial class Declaration
    {
        public Declaration()
        {
            AnnotationAssertion = new HashSet<AnnotationAssertion>();
            ClassAssertionClass = new HashSet<ClassAssertion>();
            DataPropertyAssertionDataProperty = new HashSet<DataPropertyAssertion>();
            DataPropertyAssertionNamedIndividual = new HashSet<DataPropertyAssertion>();
            DataPropertyDomainClass = new HashSet<DataPropertyDomain>();
            DataPropertyDomainDataProperty = new HashSet<DataPropertyDomain>();
            ObjectPropertyAssertionNamedIndividualId1Navigation = new HashSet<ObjectPropertyAssertion>();
            ObjectPropertyAssertionNamedIndividualId2Navigation = new HashSet<ObjectPropertyAssertion>();
            ObjectPropertyAssertionObjectProperty = new HashSet<ObjectPropertyAssertion>();
            ObjectPropertyDomainClass = new HashSet<ObjectPropertyDomain>();
            ObjectPropertyDomainObjectProperty = new HashSet<ObjectPropertyDomain>();
            ObjectPropertyRangeClass = new HashSet<ObjectPropertyRange>();
            ObjectPropertyRangeObjectProperty = new HashSet<ObjectPropertyRange>();
        }

        public long Id { get; set; }
        public string Type { get; set; }
        public string Iri { get; set; }

        public virtual ICollection<AnnotationAssertion> AnnotationAssertion { get; set; }
        public virtual ICollection<ClassAssertion> ClassAssertionClass { get; set; }
        public virtual ClassAssertion ClassAssertionNamedIndividual { get; set; }
        public virtual ICollection<DataPropertyAssertion> DataPropertyAssertionDataProperty { get; set; }
        public virtual ICollection<DataPropertyAssertion> DataPropertyAssertionNamedIndividual { get; set; }
        public virtual ICollection<DataPropertyDomain> DataPropertyDomainClass { get; set; }
        public virtual ICollection<DataPropertyDomain> DataPropertyDomainDataProperty { get; set; }
        public virtual DataPropertyRange DataPropertyRange { get; set; }

        public virtual ICollection<ObjectPropertyAssertion> ObjectPropertyAssertionNamedIndividualId1Navigation { get;
            set; }

        public virtual ICollection<ObjectPropertyAssertion> ObjectPropertyAssertionNamedIndividualId2Navigation { get;
            set; }

        public virtual ICollection<ObjectPropertyAssertion> ObjectPropertyAssertionObjectProperty { get; set; }
        public virtual ICollection<ObjectPropertyDomain> ObjectPropertyDomainClass { get; set; }
        public virtual ICollection<ObjectPropertyDomain> ObjectPropertyDomainObjectProperty { get; set; }
        public virtual ICollection<ObjectPropertyRange> ObjectPropertyRangeClass { get; set; }
        public virtual ICollection<ObjectPropertyRange> ObjectPropertyRangeObjectProperty { get; set; }
    }
}