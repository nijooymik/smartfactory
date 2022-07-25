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
    public partial class Chap09_IF_BranchingStatement_Test3 : Form
    { // 클릭 횟수는 클래스의 필드에 넣어야 함
        private int iClickCount = 0;
        public Chap09_IF_BranchingStatement_Test3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 클릭한 횟수
            ++iClickCount;
            textBox3.Text = Convert.ToString(iClickCount);

            // 1. 입력받은 값이 숫자인지 판단.
            string sValue1 = textBox1.Text;
            int iValue; // 입력한 문자열을 숫자로 담을 변수.

            bool bCheck = int.TryParse(sValue1, out iValue);
            if (!bCheck) // if (bCheck == false)
            {
                MessageBox.Show("숫자로 변환할 수 없는 값입니다.");
                return;
            }

            // 2. 1~100 사이의 수인지 체크
            if (iValue < 1 || iValue > 100)
            {
                MessageBox.Show("1~100 사이의 수만 입력 가능합니다.");
                return;
            }
            
            // 모든 조건을 만족시켰을 로직
            // 2, 5 공배수
            if (iValue % 2 == 0 && iValue % 5 == 0)
            {
                MessageBox.Show("2, 5의 공배수 입니다.");
            }
            else
            {
                MessageBox.Show("2, 5의 공배수가 아닙니다.");
            }

            // 8의 배수인지 찾는다. //메소드
            SeteM(iValue);
        }

        private void SeteM(int iValue)
        {
            if (iValue % 8 == 0)
            {
                textBox3.Text = Convert.ToString(iValue * 8);
            }
        }
    }
}
