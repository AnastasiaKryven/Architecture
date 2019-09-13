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
    public delegate void RemoveRow(int index);

    public partial class LogView : UserControl
    {
        public RemoveRow RemovedIndex;

        public LogView()
        {
            InitializeComponent();
        }

        private void LogView_Load(object sender, EventArgs e)
        {
            logBindingSource.DataSource = new LogList();
        }
    }
}
