using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Serializable, CollectionDataContract]
    public class TypeList : List<Type> { }

    [Serializable, DataContract]
    public class Type
    {
            public static int Counter = 0;

            public Type()
            {
                NumbOfCurrency = ++Counter;
            }

            [DisplayName("Номер валюты"), DataMember]
            public int NumbOfCurrency { get; set; }
            [DisplayName("Название валюты"), DataMember]
            public string NameOfCurrency { get; set; } = "";
            [DisplayName("Сокращение"), DataMember]
            public string ShortNameOfCurrency { get; set; } = "";

        }    
}
