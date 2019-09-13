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
    public partial class TypeListView : UserControl
    {
        public TypeListView()
        {
            InitializeComponent();
        }

        public bool AllowCurrentRemove
        {
            get { return typeListBindingNavigator.DeleteItem.Enabled; }
            set { typeListBindingNavigator.DeleteItem.Enabled = value; }
        }
    }
}
