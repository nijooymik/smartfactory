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
    public partial class Chap11_Middle_Exam_TestCode_2 : Form
    {
        public Chap11_Middle_Exam_TestCode_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] Array = { 1, 4, 6, 9, 10, 12, 16 };
            foreach (int a in Array)
            {
                foreach (int b in Array)
                {
                    if ((a < b) && (a + b == 16))
                    {
                        MessageBox.Show($"{a}, {b}");
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
