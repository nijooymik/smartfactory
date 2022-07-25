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
    public partial class Chap07_Operator : Form
    {
        public Chap07_Operator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 대입연산자 = 오른쪽의 수를 왼쪽 변수에 대입한다.
            int iValue = 10;
            MessageBox.Show(Convert.ToString(iValue));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // += 오른쪽에 있는 수를 왼쪽의 수와 합하여 변수에 저장한다.

            int iValue = 10;
            iValue += 20; // iValue = iValue + 20;
            MessageBox.Show(Convert.ToString(iValue)); // 30


        }

        private void button3_Click(object sender, EventArgs e)
        {
            // -= 오른쪽 수에 왼쪽 수를 뺀 결과를 왼쪽 변수에 저장한다.
            int iValue = 100;
            iValue -= 11; // iValue = iValue - 11;
            MessageBox.Show(Convert.ToString(iValue)); // 89
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // *= 왼쪽 수와 오른쪽 수를 곱하여 왼쪽 변수에 저장한다.
            int iValue = 10;
            iValue *= 10;
            MessageBox.Show(Convert.ToString(iValue)); // 100
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // /= 왼쪽 수와 오른쪽 수를 나누어 몫을 왼쪽 변수에 저장한다.
            int iValue = 10;
            iValue /= 3; // iValue = iValue / 3;
            MessageBox.Show(Convert.ToString(iValue)); // 3
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // %= 왼쪽 수와 오른쪽 수를 나누어 나머지를 왼쪽 변수에 저장한다.
            int iValue = 10;
            iValue %= 3; // iValue = iValue % 3; // 나머지 1
            MessageBox.Show(Convert.ToString(iValue)); // 1
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 전위 증가 연산자와 후위 증가 연산자.

            int iValue = 10;

            // ++ 변수에 1을 더한다.

            // 전위 증가 연산자.
            ++iValue;
            MessageBox.Show(Convert.ToString(iValue));

            // 후위 증가 연산자.
            iValue++;
            MessageBox.Show(Convert.ToString(iValue));

            // 전위 증가 연산자와 후위 증가 연산자의 결과가 다르게 나오는 예
            MessageBox.Show(Convert.ToString(++iValue));
            MessageBox.Show(Convert.ToString(iValue++));

            // 전위 증가 연산자는 코드가 실행(메세지박스)되기 전에 연산 내용이 자신에게 대입
            // 후위 증가 연산자는 코드가 실행(메세지박스)되고 난 다음 연산 내용이 자신에게 대입

            // 일반적으로 연산에 대한 결과를 실시간으로 판단하고 싶을 때는
            // 전위 증가 연산자를 많이 사용합니다.
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int iValue = 10;
            
            --iValue; // 전위 감소 연산자는 코드가 실행되기 전에 1을 차감한다.
            MessageBox.Show(Convert.ToString(iValue));

            iValue--; // 후위 감소 연산자는 코드가 실행되고 난 다음에 1을 차감한다.
            MessageBox.Show(Convert.ToString(iValue));

            MessageBox.Show(Convert.ToString(--iValue));
            MessageBox.Show(Convert.ToString(iValue--));
        }
    }
}
