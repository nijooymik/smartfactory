using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_Test_01
{
    public partial class M_Run : Form
    {
        public M_Run()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RunStopFlag R_S = new RunStopFlag();
            //MessageBox.Show(R_S.sRunStopValue); // 대기
            //R_S RunStopValue = "가동";
            //MessageBox.Show(R_S.sRunStopValue); // 가동
            MessageBox.Show(RunStopFlag.sRunStopValue);
        }
    }
}
