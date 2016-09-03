using System.Collections.Generic;

namespace RiceDoctor.OntologyManager.OntologyModels
{
    public enum DeclarationType
    {
        Class,
        DataProperty,
        NamedIndividual,
        ObjectProperty
    }

    public enum DataTypeKind
    {
        Boolean,
        Date,
        Float,
        Int,
        String
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

        public static Dictionary<DataTypeKind, DataType> DataTypes = new Dictionary<DataTypeKind, DataType>
        {
            {
                DataTypeKind.Boolean, new DataType
                {
                    Iri = "http://www.w3.org/2001/XMLSchema#boolean",
                    AbbreviatedIri = "xsd:boolean",
                    Definition = "Binary-valued logic legal literals {true, false, 1, 0}.",
                    Kind = "Atomic"
                }
            },
            {
                DataTypeKind.Date, new DataType
                {
                    Iri = "http://www.w3.org/2001/XMLSchema#date",
                    AbbreviatedIri = "xsd:date",
                    Definition = "Calendar date.Format CCYY-MM-DD. Example, May the 31st, 1999 is: 1999-05-31.",
                    Kind = "Atomic"
                }
            },
            {
                DataTypeKind.Float, new DataType
                {
                    Iri = "http://www.w3.org/2001/XMLSchema#float",
                    AbbreviatedIri = "xsd:float",
                    Definition =
                        "32-bit floating point type - legal literals {0, -0, INF, -INF and NaN}. Example, -1E4, 1267.43233E12, 12.78e-2, 12 and INF.",
                    Kind = "Atomic"
                }
            },
            {
                DataTypeKind.Int, new DataType
                {
                    Iri = "http://www.w3.org/2001/XMLSchema#int",
                    AbbreviatedIri = "xsd:int",
                    Definition =
                        "2147483647 to -2147483648. Sign omitted, \"+\" is assumed. Example, -1, 0, 126789675, +100000.",
                    Kind = "Derived long"
                }
            },
            {
                DataTypeKind.String, new DataType
                {
                    Iri = "http://www.w3.org/2001/XMLSchema#string",
                    AbbreviatedIri = "xsd:string",
                    Definition = "Character strings.",
                    Kind = "Atomic"
                }
            }
        };
    }
}