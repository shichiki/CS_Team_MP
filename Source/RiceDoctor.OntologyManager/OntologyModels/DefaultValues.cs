using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.OntologyModels
{
    public enum DeclarationType
    {
        Undefined,
        Class,
        DataProperty,
        NamedIndividual,
        ObjectProperty
    }

    public enum DataType
    {
        Undefined,
        Boolean,
        Date,
        Float,
        Int,
        PlainLiteral,
        String
    }

    public enum AnnotationType
    {
        Undefined,
        Label,
        Comment
    }

    public enum LanguageType
    {
        Undefined,
        English,
        Vietnamese
    }

    public static class DefaultValue
    {
        public static Dictionary<DeclarationType, string> DeclarationTypes = new Dictionary<DeclarationType, string>
        {
            {DeclarationType.Class, "Class"},
            {DeclarationType.DataProperty, "DataProperty"},
            {DeclarationType.NamedIndividual, "NamedIndividual"},
            {DeclarationType.ObjectProperty, "ObjectProperty"}
        };

        // References:
        // - http://www.xml.dvint.com/docs/SchemaDataTypesQR-2.pdf
        // - https://www.w3.org/2001/XMLSchema-datatypes
        public static Dictionary<DataType, string> DataTypes = new Dictionary<DataType, string>
        {
            {DataType.Boolean, "http://www.w3.org/2001/XMLSchema#boolean"},
            {DataType.Date, "http://www.w3.org/2001/XMLSchema#date"},
            {DataType.Float, "http://www.w3.org/2001/XMLSchema#float"},
            {DataType.Int, "http://www.w3.org/2001/XMLSchema#int"},
            {DataType.PlainLiteral, "http://www.w3.org/1999/02/22-rdf-syntax-ns#PlainLiteral"},
            {DataType.String, "http://www.w3.org/2001/XMLSchema#string"}
        };

        public static Dictionary<AnnotationType, string> AnnotationTypes = new Dictionary<AnnotationType, string>
        {
            {AnnotationType.Comment, "rdfs:comment"},
            {AnnotationType.Label, "rdfs:label"}
        };

        // http://www.w3schools.com/tags/ref_language_codes.asp
        public static Dictionary<LanguageType, string> LanguageTypes = new Dictionary<LanguageType, string>
        {
            {LanguageType.English, "en"},
            {LanguageType.Vietnamese, "vi"}
        };

        //public static Dictionary<DataTypeIri, DataType> DataTypes = new Dictionary<DataTypeIri, DataType>
        //{
        //    {
        //        DataTypeIri.Boolean, new DataType
        //        {
        //            Iri = "http://www.w3.org/2001/XMLSchema#boolean",
        //            AbbreviatedIri = "xsd:boolean",
        //            Definition = "Binary-valued logic legal literals {true, false, 1, 0}.",
        //            Kind = "Atomic"
        //        }
        //    },
        //    {
        //        DataTypeIri.Date, new DataType
        //        {
        //            Iri = "http://www.w3.org/2001/XMLSchema#date",
        //            AbbreviatedIri = "xsd:date",
        //            Definition = "Calendar date.Format CCYY-MM-DD. Example, May the 31st, 1999 is: 1999-05-31.",
        //            Kind = "Atomic"
        //        }
        //    },
        //    {
        //        DataTypeIri.Float, new DataType
        //        {
        //            Iri = "http://www.w3.org/2001/XMLSchema#float",
        //            AbbreviatedIri = "xsd:float",
        //            Definition =
        //                "32-bit floating point type - legal literals {0, -0, INF, -INF and NaN}. Example, -1E4, 1267.43233E12, 12.78e-2, 12 and INF.",
        //            Kind = "Atomic"
        //        }
        //    },
        //    {
        //        DataTypeIri.Int, new DataType
        //        {
        //            Iri = "http://www.w3.org/2001/XMLSchema#int",
        //            AbbreviatedIri = "xsd:int",
        //            Definition =
        //                "2147483647 to -2147483648. Sign omitted, \"+\" is assumed. Example, -1, 0, 126789675, +100000.",
        //            Kind = "Derived long"
        //        }
        //    },
        //    {
        //      DataTypeIri.PlainLiteral, new DataType
        //        {
        //            Iri = "http://www.w3.org/1999/02/22-rdf-syntax-ns#PlainLiteral",
        //            AbbreviatedIri = null,
        //            Definition = null,
        //            Kind = null
        //        }
        //    },
        //    {
        //        DataTypeIri.String, new DataType
        //        {
        //            Iri = "http://www.w3.org/2001/XMLSchema#string",
        //            AbbreviatedIri = "xsd:string",
        //            Definition = "Character strings.",
        //            Kind = "Atomic"
        //        }
        //    }
        //};
    }
}