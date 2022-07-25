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
    public partial class For_문_실습_메소드_간추리기 : Form
    {
        public For_문_실습_메소드_간추리기()
        {
            InitializeComponent();
        }

        int iSum = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            TimesSum(2, textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimesSum(5, textBox1.Text, textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimesSum(10, textBox1.Text, textBox2.Text);
        }

        private void TimesSum(int times, string sStart, string sEnd)
        {
            string sValue1 = sStart;
            string sValue2 = sEnd;
            int iValue;

            bool bCheck1 = int.TryParse(sValue1, out iValue);
            bool bCheck2 = int.TryParse(sValue2, out iValue);

            if (!bCheck1)
            {
                MessageBox.Show("숫자로 변환할 수 없는 값입니다.");
                return;
            }
            
            else if (!bCheck2)
            {
                MessageBox.Show("숫자로 변환할 수 없는 값입니다.");
                return;
            }

            else if ((Convert.ToInt32(sStart) < 0) || (Convert.ToInt32(sEnd) < 0))
            {
                MessageBox.Show("음수를 입력할 수 없습니다.");
                return;
            }

            int iStart = Convert.ToInt32(sStart);
            int iEnd = Convert.ToInt32(sEnd);
            for (int i = iStart; i <= iEnd; i++)
            {
                if (i % times == 0)
                {
                    iSum += i;
                }
            }
            MessageBox.Show($"범위 내 {times}의 배수의 합은 {iSum} 입니다.");
            return;
        }
    }
}
