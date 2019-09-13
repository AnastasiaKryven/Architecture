using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    [Serializable, DataContract]
    public class Log
    {
#pragma warning disable CS0169 // Поле "Log.mFO" никогда не используется.
        private int mFO;
#pragma warning restore CS0169 // Поле "Log.mFO" никогда не используется.
        private double buyCurrency;
        private double saleCurrency;

        [DisplayName("Дата"), XmlAttribute, DataMember]
        public DateTime Date { get; set; }


        [DisplayName("МФО банка"), XmlAttribute, DataMember]
        public int MFO { get; set; }

        [DisplayName("Номер валюты"), XmlAttribute, DataMember]
        public int NumbOfCurrency { get; set; }

        [DisplayName("Курс покупки валюты, грн"), XmlAttribute, DataMember]
        public double BuyCurrency
        {
            get
            {
                return buyCurrency;
            }
            set
            {
                buyCurrency = Math.Round(value, 3);
            }
        }


        [DisplayName("Курс продажи валюты, грн"), XmlAttribute, DataMember]
        public double SaleCurrency
        {
            get
            {
                return saleCurrency;
            }

            set
            {
                saleCurrency = Math.Round(value, 3);
            }
        }
    }
}
