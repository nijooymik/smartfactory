using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class
{
    public partial class M_Stop : Form
    {
        public M_Stop()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(M_RunStopFlag.sRunStopFlag);
            M_RunStopFlag.sRunStopFlag = "정지";
            MessageBox.Show(M_RunStopFlag.sRunStopFlag);
        }
    }
}
