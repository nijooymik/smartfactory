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
    public partial class Chap09_Switch_BranchingStatement : Form
    {
        public Chap09_Switch_BranchingStatement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 텍스트 박스에 입력한 과일 이름 변수에 담기.
            string sFruitName = textBox1.Text;

            // 2. 과일의 가격 int 변수
            int iResult = 0;

            switch(sFruitName)
            {
                case "사과" :
                    iResult = 3000;
                    //MessageBox.Show($"{sFruitName} 의 값은 {Convert.ToString(iResult)} 입니다"); //빼냄
                    break;
                case "참외" :
                    iResult = 1500;
                    //MessageBox.Show($"{sFruitName} 의 값은 {Convert.ToString(iResult)} 입니다");
                    break;
                case "수박" :
                    iResult = 13000;
                    //MessageBox.Show($"{sFruitName} 의 값은 {Convert.ToString(iResult)} 입니다");
                    break;
                default :
                    iResult = 0;
                    MessageBox.Show($"{sFruitName} 는 취급하지 않습니다");
                    break;
            }
            MessageShow(sFruitName, iResult);
        }

        private void MessageShow(string sFruitName, int iFruitPrice)
        {
            MessageBox.Show($"{sFruitName} 의 값은 {Convert.ToString(iFruitPrice)} 입니다.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
