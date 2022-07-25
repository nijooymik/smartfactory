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
    public partial class Chap09_Switch_BranchingStatement_Test : Form
    {
        string sFruitName = "";
        int iA = 0;
        int iB = 0;
        int iC = 0;
        int iSum = 0;

        public Chap09_Switch_BranchingStatement_Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { //사과
            sFruitName = "사과";
            if (iA >= 10)
            {
                MessageBox.Show($"{sFruitName}의 남은 수량이 0 개 입니다. 주문할 수 없습니다.");
                return;
            }
            else
            {
                iA++;
                label3.Text = $"{10 - iA} 개"; //남은수량 //Convert.ToString(10 - iA) + " 개"
                SwitchMethod(sFruitName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //비트
            sFruitName = "참외";
            if (iB >= 10)
            {
                MessageBox.Show($"{sFruitName}의 남은 수량이 0 개 입니다. 주문할 수 없습니다.");
                return;
            }
            else
            {
                iB++;
                label4.Text = $"{10 - iB} 개"; //남은수량
                SwitchMethod(sFruitName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { //수박
            sFruitName = "수박";
            if (iC >= 10)
            {
                MessageBox.Show($"{sFruitName}의 남은 수량이 0 개 입니다. 주문할 수 없습니다.");
                return;
            }
            else
            {
                iC++;
                label7.Text = $"{10 - iC} 개"; //남은수량
                SwitchMethod(sFruitName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        { //총결제
            MessageBox.Show("총 결제 금액은 " + Convert.ToString(iSum) + " 원 입니다.");
        }

        private void SwitchMethod(string sFruitName)
        {
            int iPrice = 0;
            switch (sFruitName)
            {
                case "사과":
                    iPrice = 2000;
                    iSum += iPrice;
                    break;

                case "참외":
                    iPrice = 2500;
                    iSum += iPrice;
                    break;

                case "수박":
                    iPrice = 18000;
                    iSum += iPrice;
                    break;
            }
        }
    }
}
