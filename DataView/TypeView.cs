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
    public partial class TypeView : UserControl
    {
        public TypeView()
        {
            InitializeComponent();
        }

        public bool AllowCurrentRemove
        {
            get { return typeBindingNavigator.DeleteItem.Enabled; }
            set { typeBindingNavigator.DeleteItem.Enabled = value; }
        }
    }
}
