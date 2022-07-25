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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // RunStopFlag RS_Flag = new RunStopFlag(); // 지워도 됨
            // MessageBox.Show(RS_Flag.sRunStopValue);
            MessageBox.Show(RunStopFlag.sRunStopValue); // 정적 한정자로 원본 데이터가 묶여 있는 상태
        }

        private void button2_Click(object sender, EventArgs e)
        {
            M_Run Run = new M_Run();
            Run.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            M_Stop Stop = new M_Stop();
            Stop.Show();
        }
    }
}
