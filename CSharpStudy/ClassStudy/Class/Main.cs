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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // M_RunStopFlag M_RSFlag = new M_RunStopFlag(); 지우고
           MessageBox.Show(M_RunStopFlag.sRunStopFlag);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            M_Run RunScreen = new M_Run(); // RunScreen이라는 이름으로 객체(M_Run 클래스) 복사
            RunScreen.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            M_Stop StopScreen = new M_Stop();
            StopScreen.Show();
        }
    }
}
