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
using static Data.Bank;

namespace DataView
{
    public partial class BankListView : UserControl
    {
        public BankListView()
        {
            InitializeComponent();
        }

        private void BankListView_Load(object sender, EventArgs e)
        {
         //   bankListDataGridView.DataSource = Enum.GetValues(typeof(TypeOfBank));
        }

        public bool AllowCurrentRemove
        {
            get { return bankListBindingNavigator.DeleteItem.Enabled; }
            set { bankListBindingNavigator.DeleteItem.Enabled = value; }
        }
    }
}
