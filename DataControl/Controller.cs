using Data;
using DataView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataControl
{
    [Serializable, DataContract]
    public class Controller
    {
        [DataMember]
        public TypeList Types { get; private set; }

        [DataMember]
        public LogList Logs { get; set; }

        [DataMember]
        public BankList Banks { get; private set; }

        public Controller(Views view)
        {
            Logs = new LogList();
            Types = new TypeList();
            Banks = new BankList();

            Binding(view);
        }

        public Controller()
        {
            Types = new TypeList();
            Banks = new BankList();
            Logs = new LogList();
        }

        public void Binding(Views views)
        {
            views.bsTypes.DataSource = Types;
            views.bsBank.DataSource = Banks;
            views.bsLog.DataSource = Logs;
        }

    }
}
