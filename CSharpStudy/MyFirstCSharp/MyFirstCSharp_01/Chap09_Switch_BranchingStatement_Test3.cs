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
    public partial class Chap09_Switch_BranchingStatement_Test3 : Form
    {
        private int iOrderPrice = 0; // 총 누적 금액
        private int iAppleLeftCount = 10; // 사과의 남은 수량
        private int iMelonLeftCount = 10; // 참외의 남은 수량
        private int iW_MelonLeftCount = 10; // 수박의 남은 수량

        public Chap09_Switch_BranchingStatement_Test3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"총 결제 금액은 : {Convert.ToString(iOrderPrice)} 입니다.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FruitOperate("사과");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FruitOperate("참외");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FruitOperate("수박");
        }
        private void FruitOperate(string sFruitName)
        {
            switch (sFruitName)
            {
                case "사과":
                    // 수량 차감
                    FruitLeftCountCheck(ref iAppleLeftCount, "사과");
                    label3.Text = Convert.ToString(iAppleLeftCount);
                    iOrderPrice += 2000;
                    break;

                case "참외":
                    // 수량 차감
                    FruitLeftCountCheck(ref iMelonLeftCount, "참외");
                    label4.Text = Convert.ToString(iMelonLeftCount);
                    iOrderPrice += 2500;
                    break;

                case "수박":
                    FruitLeftCountCheck(ref iW_MelonLeftCount, "수박");
                    label7.Text = Convert.ToString(iW_MelonLeftCount);
                    iOrderPrice += 18000;
                    break;
            }
        }

        private void FruitLeftCountCheck(ref int FruitLeftCount, string FruitName)
        {
            if (FruitLeftCount == 0)
            {
                MessageBox.Show($"{FruitName} 의 수량이 {FruitLeftCount} 개 입니다.");
                return;
            }
            --FruitLeftCount;
        }
        
    }
}
