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
    public partial class Chap05_StringSplit : Form
    {
        private string sTitle = "ABCD/EFG/HIJK/LMN";
        public Chap05_StringSplit()
        {
            InitializeComponent();
            label1.Text = sTitle;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Split : 지정된 문자를 기준으로 문자열을 자르고 자른값을 반환한다.

            // Split 명령어(메서드) 반환값은 배열.
            // 배열 : 같은 타입의 변수를 변수명으로 여러개 모아놓은 데이터 타입.

            // 1. 나눈 값을 받아올 배열 변수 지정.
            string sResult_;
            string[] sResult;

            sResult_ = "asdasd";
            // sResult = { "A","B","C"};

            // 2. 문자열을 분할할 기준 문자를 변수에 담는다. ex)/
            string sSplitValue = textBox1.Text;

            // 3. 지정한 문자를 기준으로 나눈 문자열을 Split 배열에 담는다.
            sResult = label1.Text.Split(Convert.ToChar(sSplitValue));
            // sResult = label1.Text.Split('/'); 와 같음

            // 4. 나눈 문자를 표현한다.
            MessageBox.Show(sResult[0]);
            MessageBox.Show(sResult[1]);
            MessageBox.Show(sResult[2]);
            MessageBox.Show(sResult[3]);

            // 배열의 Index가 벗어나게 되면 오류가 발생한다.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Substring : 사용자가 지정한 위치로부터 지정한 갯수만큼 문자를 잘라서 표현
            // 1. 분할된 문자열을 담을 변수지정
            string sValue;

            // 2. 문자열을 자르기 시작할 위치 지정
            int iIndex = Convert.ToInt32(textBox2.Text);

            // 3. 지정한 위치로부터 잘라올 문자의 개수. ex)5
            int iStringCount = Convert.ToInt32(textBox3.Text);

            // 4. 문자를 잘라서 변수에 대입. ex)3
            sValue = label1.Text.Substring(iIndex, iStringCount);

            // 5. 메세지 박스로 표현. ex)EFG
            MessageBox.Show(sValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 문자열 보간
            // 보간 : 비거나 누락된 부분을 채우는 기능
            string sResult = $"알파벳 리스트 : {sTitle}";
            string sResult2 = "알파벳 리스트 : " + sTitle;
            MessageBox.Show(sResult);
        }
    }
}
