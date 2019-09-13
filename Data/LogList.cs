using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data
{
    [Serializable, CollectionDataContract]
    public class LogList : List<Log> { }
}
