using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp_01
{
    public partial class Chap03_Class_Test : Form
    {
        Chap02_DataType CHP_02 = new Chap02_DataType();
        public Chap03_Class_Test()
        {
            InitializeComponent();
            Chap02_DataType CHP_02 = new Chap02_DataType();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show (CHP_02.sMessage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show (CHP_02.sMessage2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show (CHP_02.sMessage3);
        }
    }
}
