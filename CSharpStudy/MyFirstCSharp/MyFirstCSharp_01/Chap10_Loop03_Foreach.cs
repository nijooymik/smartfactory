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
    public partial class Chap10_Loop03_Foreach : Form
    {
        // Foreach
        // 끝을 지정해서 Fale 값으로 종료하는 다른 반복문과는 달리
        // 인자로 들어온 Object의 내부 인덱스의 끝까지 자동으로 순환을 해주는 반복문
        // 인자가 포함하는 내용의 수에 따라 반복하므로
        // 종료 조건이 없어도 반드시 종료가 되는 반복문.

        public Chap10_Loop03_Foreach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 문자열에서 한글자씩 추출된 변수의 데이터 표현하기

            // 문자 1개만 입력받도록
            if (textBox1.Text.Length != 1) //
            {
                MessageBox.Show("하나의 문자를 입력하세요.");
                return;
            }

            // 문자열 데이터 변수에 담기
            string sTitle = label1.Text;

            // 추출 시작
            bool sCheck = false;
            foreach(char ch in sTitle)
            {
                if (ch == Convert.ToChar(textBox1.Text))
                {
                    MessageBox.Show($"{ch} 문자가 있습니다.");
                    sCheck = true;
                    break;
                }
            }
            if (!sCheck) MessageBox.Show("문자가 없습니다.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 배열에서 데이터를 추출하는 Foreach
            int[] Array = new int[] { 11, 12, 13, 14, 15, 16, 17 };
            
            // 현재 배열의 Index 를 담을 변수
            int iIndex = 0;
            
            //
            foreach(int elem in Array)
            {
                MessageBox.Show($"배열 Array[{iIndex} ] : {elem}");
                ++iIndex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 그룹 박스에 있는 컨트롤의 모든 속성을 변경하는 Foreach
            foreach(Control MyControl in groupBox1.Controls)
            {
                // MyControl이 TextBox 클래스와 호환이 되느냐?
                if ((MyControl is TextBox) == true)
                {
                    MyControl.Text = "안녕하세요?";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control MyControl in groupBox1.Controls)
            {
                if ((MyControl is TextBox) == true)
                {
                    MyControl.Text = "";
                }
            }
        }
    }
}
