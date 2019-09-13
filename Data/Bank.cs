using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data
{
    [Serializable, CollectionDataContract]
    public class BankList : ObservableCollection<Bank> { }

    [Serializable, DataContract]
    public class Bank
    {
#pragma warning disable CS0169 // Поле "Bank.mFO" никогда не используется.
        private int mFO;
#pragma warning restore CS0169 // Поле "Bank.mFO" никогда не используется.
        private string bankType;
        private string numberPhone;

        Random random = new Random();

        public Bank()
        {
            MFO = random.Next(100000, 999999);
        }

        public enum TypeOfBank
        { national, international  }

        [DisplayName("МФО банка"), DataMember] public int MFO { get; set; }

        [DisplayName("Название банка"), DataMember] public string BankName { get; set; }

        [DisplayName("Тип"), DataMember]
        public string BankType
        {
            get
            {
                return bankType;
            }
            set
            {
                if (value == "Национальный" || value == "Интернациональный")
                {
                    bankType = value;
                }
            }
        }

        [DisplayName("Адрес главного филиала"), DataMember] public string Adress { get; set; }

        [DisplayName("Телефон"), DataMember]
        public string NumberPhone
        {
            get
            {
                return numberPhone;
            }
            set
            {
                string patt = @"(\d{3})\d{7}";
                if (Regex.IsMatch(value, patt))
                {
                    numberPhone = value;
                }
            }
        }
    }
}
