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
    public partial class Chap09_IF_BranchingStatement_Test2 : Form
    {
        private int clickCnt = 0;
        public Chap09_IF_BranchingStatement_Test2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            clickCnt++;
            // 공백일 경우
            if (textBox1.Text == "")
            {
                MessageBox.Show("값을 입력하세요.");
            }
            // 숫자가 아닐 경우
            if ((int.TryParse((textBox1.Text), out i)) == false)
            {
                MessageBox.Show("숫자를 입력하세요.");
            }
            else
            {
                int iValue = Convert.ToInt32(textBox1.Text);
            // 범위 외 숫자일 경우
                if (iValue < 1 || iValue > 100)
                {
                    MessageBox.Show("1부터 100까지의 수를 입력하세요.");
                }
                // 잘 입력한 경우
                else if (iValue >= 1 && iValue <= 100)
                {
                    if (iValue % 10 == 0)
                    {
                        MessageBox.Show("2, 5 공배수 입니다");
                    }
                    else
                    {
                        MessageBox.Show("2, 5 공배수가 아닙니다");
                    }
                    if (iValue % 8 == 0)
                    {
                        textBox2.Text = Convert.ToString(iValue * 8);
                    }
                }
            }
            textBox3.Text = Convert.ToString(clickCnt);
        }
    }
}
