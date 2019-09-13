using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DataView
{
    public partial class BankView : UserControl
    {
        public BankView()
        {
            InitializeComponent();
        }

        public bool AllowCurrentRemove
        {
            get { return bankBindingNavigator.DeleteItem.Enabled; }
            set { bankBindingNavigator.DeleteItem.Enabled = value; }
        }

        private void BankView_Load(object sender, EventArgs e)
        {
            bankDataGridView.DataSource = Enum.GetValues(typeof(Data.Bank.TypeOfBank));
        }
    }
}
