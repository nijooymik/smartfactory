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
    public partial class Chap09_Switch_BranchingStatement_Test_2 : Form //클래스
    {
        private int iOrderPrice       = 0; // 총 누적 금액
        private int iAppleLeftCount   = 10; // 사과의 남은 수량
        private int iK_MelonLeftCount   = 10; // 참외의 남은 수량
        private int iW_MelonLeftCount = 10; // 수박의 남은 수량
        public Chap09_Switch_BranchingStatement_Test_2() //클래스생성자
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 사과
            if (iAppleLeftCount <= 0)
            {
                MessageBox.Show($"사과의 남은 수량이 0 개입니다. 주문할 수 없습니다.");
                return;
            }
            else
            {
                label3.Text = $"{--iAppleLeftCount} 개";
                FruitOperate("사과");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 참외
            if (iK_MelonLeftCount <= 0)
            {
                MessageBox.Show($"참외의 남은 수량이 0 개입니다. 주문할 수 없습니다.");
                return;
            }
            else
            {
                label4.Text = $"{--iK_MelonLeftCount} 개";
                FruitOperate("참외");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 수박
            if (iW_MelonLeftCount <= 0)
            {
                MessageBox.Show($"수박의 남은 수량이 0 개입니다. 주문할 수 없습니다.");
                return;
            }
            else
            {
                label7.Text = $"{--iW_MelonLeftCount} 개";
                FruitOperate("수박");
            }
        }

        private void FruitOperate(string sFruitName)
        {
            switch (sFruitName)
            {
                case "사과":
                    iOrderPrice += 2000;
                    break;
                case "참외":
                    iOrderPrice += 2500;
                    break;
                case "수박":
                    iOrderPrice += 18000;
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"총 결제 금액은 {iOrderPrice} 원 입니다.");
        }
    }
}

/* 과일 가격, 과일 종류 불변
 */