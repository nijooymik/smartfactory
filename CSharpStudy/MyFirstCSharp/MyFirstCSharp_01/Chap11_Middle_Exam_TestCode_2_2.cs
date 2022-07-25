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
    public partial class Chap11_Middle_Exam_TestCode_2_2 : Form
    {
        public Chap11_Middle_Exam_TestCode_2_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] Array = { 1, 4, 6, 9, 10, 12, 16 };
            for (int i = 0; i < 7; i++)
            {
                if ( (Array.Contains<int>(16 - Array[i])) && (Array[i] < (16 - Array[i])) )
                {
                    MessageBox.Show($"{Array[i]}, {16 - Array[i]}");
                }
            }

        }

    }
}
