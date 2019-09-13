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

    public partial class LogListView : UserControl
    {

        public LogListView()
        {
            InitializeComponent();
        }

        private void LogListView_Load(object sender, EventArgs e)
        {
           // logListBindingSource.DataSource = new LogList();
        }

        public bool AllowAddLog
        {
            get { return logListBindingSource.AllowNew; }
            set { logListBindingSource.AllowNew = value; }
        }

        public BindingSource bsMFO
        {
            set
            {
                cbMFO.DataSource = value;
                cbMFO.ValueMember = "MFO";
                cbMFO.DisplayMember = "MFO";
            }
        }

        public BindingSource bsNumb
        {
            set
            {
                cbNumb.DataSource = value;
                cbNumb.ValueMember = "NumbOfCurrency";
                cbNumb.DisplayMember = "NumbOfCurrency";
            }
        }


    }
}
