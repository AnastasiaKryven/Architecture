using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace DataView
{
    public partial class Views: UserControl
    {
        public Views()
        {
            InitializeComponent();
        }

        public BindingSource bsTypes
        {
            get
            {
                return typeListView1.typeListBindingSource;
            }
        }

        public BindingSource bsBank
        {
            get
            {
                return bankListView1.bankListBindingSource;
            }
        }

        public BindingSource bsLog
        {
            get
            {
                return logListView1.logListBindingSource;
            }
        }

        private void Views_Load(object sender, EventArgs e)
        {
            bsTypes.PositionChanged += TypePositionChanged;
            bsBank.PositionChanged += BankPositionChanged;
            bsLog.ListChanged += LogListChanged;

            bsTypes.ListChanged += TypeListChanged;
            bsBank.ListChanged += BankListChanged;

            bsLog.AddingNew += AddingNewLog;

            logListView1.bsMFO = bsBank;
            logListView1.bsNumb = bsTypes;
        }

        private void TypePositionChanged(object sender, EventArgs e)
        {
            CheckTypeRemove();
        }

        private void CheckTypeRemove()
        {
            if (bsTypes.Current == null) return;

            var idCheck = (bsTypes.Current as Data.Type).NumbOfCurrency;
            typeListView1.AllowCurrentRemove = !(bsLog.DataSource as Data.LogList).Exists(item => item.NumbOfCurrency == idCheck);            
        }

        private void BankPositionChanged(object sender, EventArgs e)
        {
            CheckBankRemove();
        }

        private void CheckBankRemove()
        {
            if (bsBank.Current == null) return;

            var idCheck = (bsBank.Current as Data.Bank).MFO;
            bankListView1.AllowCurrentRemove = !(bsLog.DataSource as Data.LogList).Exists(item => item.MFO == idCheck);
        }

        private void LogListChanged(object sender, ListChangedEventArgs e)
        {
            CheckTypeRemove();
            CheckBankRemove();
        }

        private void TypeListChanged(object sender, ListChangedEventArgs e)
        {
            CheckTypeRemove();
            logListView1.AllowAddLog = AllowCreateLog();
        }

        private bool AllowCreateLog()
        {
            return (bsTypes.Count > 0) && (bsBank.Count > 0);
        }

        private void BankListChanged(object sender, ListChangedEventArgs e)
        {
            CheckBankRemove();
            logListView1.AllowAddLog = AllowCreateLog();
        }

        private void AddingNewLog(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Log()
            {
                NumbOfCurrency = (bsTypes.Current as Data.Type).NumbOfCurrency,
                MFO = (bsBank.Current as Bank).MFO,
                Date = DateTime.Now
            };
        }

    }
}
