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
    public partial class Chap11_Middel_Test_T : Form
    {

        int iOrderPrice = 0; // 총 누적 금액
        int iAppleLeftCount = 10; // 사과의 남은 수량
        int iMelonLeftCount = 10; // 참외의 남은 수량
        int iW_MLeftCount = 10; // 수박의 남은 수량

        int iAppleSellCount = 0;
        int iMelonSellCount = 0;
        int iW_MSellCount = 0;
        
        int iAppleICount = 0;
        int iMelonICount = 0;
        int iW_MICount = 0;
        int iInvoicePrice = 0;

        int iAppleMargin = 0;
        int iMelonMargin = 0;
        int iW_MMargin = 0;
        int iTotalMargin = 0;

        public Chap11_Middel_Test_T()
        {
            InitializeComponent();
        }

        

        private void btnAppleOrder_Click(object sender, EventArgs e)
        {
            FruitOperate("사과");
        }

        private void FruitOperate(string sFruitName)
        {
            switch (sFruitName)
            {
                case "사과":
                    // 수량 차감
                    FruitLeftCountCheck(ref iAppleLeftCount, "사과");
                    lblAppleLeftCount.Text = Convert.ToString(iAppleLeftCount);
                    iOrderPrice += 2000;
                    iAppleSellCount += 1;
                    break;

                case "참외":
                    // 수량 차감
                    FruitLeftCountCheck(ref iMelonLeftCount, "참외");
                    lblMelonLeftCount.Text = Convert.ToString(iMelonLeftCount);
                    iOrderPrice += 2500;
                    iMelonSellCount += 1;
                    break;

                case "수박":
                    FruitLeftCountCheck(ref iW_MLeftCount, "수박");
                    lblW_MLeftCount.Text = Convert.ToString(iW_MLeftCount);
                    iOrderPrice += 18000;
                    iW_MSellCount += 1;
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

        private void btnMelonOrder_Click(object sender, EventArgs e)
        {
            FruitOperate("참외");
        }

        private void btnW_MOrder_Click(object sender, EventArgs e)
        {
            FruitOperate("수박");
        }

        private void btnShowOrderPrice_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"총 결제 금액은 : {Convert.ToString(iOrderPrice)} 입니다.");
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            int iCustomerCash = Convert.ToInt32(lblCustomerCash.Text);
            int iManCash = Convert.ToInt32(lblManCash.Text);

            if ((iCustomerCash < iOrderPrice) || (iOrderPrice == 0))
            {
                MessageBox.Show("결제를 할 수 없습니다.");
            }
            else
            {
                iCustomerCash -= iOrderPrice;
                iManCash += iOrderPrice;

                iOrderPrice = 0;
                
                lblCustomerCash.Text = Convert.ToString(iCustomerCash);
                lblManCash.Text = Convert.ToString(iManCash);

                textBox1.Text += $"--------- 판매 내역 -----------\r\n";

                if (iAppleSellCount > 0)
                {
                    textBox1.Text += $"사과 판매 개수 : {iAppleSellCount}, 판매 금액 : {iAppleSellCount * 2000}\r\n";
                    iAppleMargin += Convert.ToInt32(iAppleSellCount * 0.6 * 2000);
                }
                if (iMelonSellCount > 0)
                {
                    textBox1.Text += $"참외 판매 개수 : {iMelonSellCount}, 판매 금액 : {iMelonSellCount * 2500}\r\n";
                    iMelonMargin += Convert.ToInt32(iMelonSellCount * 0.6 * 2500);
                }
                if (iW_MSellCount > 0)
                {
                    textBox1.Text += $"수박 판매 개수 : {iW_MSellCount}, 판매 금액 : {iW_MSellCount * 18000}\r\n";
                    iW_MMargin += Convert.ToInt32(iW_MSellCount * 0.6 * 18000);
                }
                
                iAppleSellCount = 0;
                iMelonSellCount = 0;
                iW_MSellCount = 0;
                MessageBox.Show("결제가 완료되었습니다.");
            }
        }

        private void btnOrderCancle_Click(object sender, EventArgs e)
        {
            int iCustomerCash = Convert.ToInt32(lblCustomerCash.Text);
            int iManCash = Convert.ToInt32(lblManCash.Text);

            if (iOrderPrice == 0)
            {
                MessageBox.Show("취소할 내역이 없습니다.");
            }
            else
            {
                
                iOrderPrice = 0;

                lblAppleLeftCount.Text = Convert.ToString(Convert.ToInt32(lblAppleLeftCount.Text) + iAppleSellCount);
                iAppleSellCount = 0;

                lblMelonLeftCount.Text = Convert.ToString(Convert.ToInt32(lblMelonLeftCount.Text) + iMelonSellCount);
                iMelonSellCount = 0;

                lblW_MLeftCount.Text = Convert.ToString(Convert.ToInt32(lblW_MLeftCount.Text) + iW_MSellCount);
                iW_MSellCount = 0;
                
                
            }
        }

        private void btnFruitInvoice_Click(object sender, EventArgs e)
        {
            int.TryParse(txtAppleInvoice.Text, out iAppleICount);
            int.TryParse(txtMelonInvoice.Text, out iMelonICount);
            int.TryParse(txtW_MInvoice.Text, out iW_MICount);

            if (iAppleICount == 0 && iMelonICount == 0 && iW_MICount == 0)
            {
                MessageBox.Show("발주 내역이 없습니다.");
                return;
            }



            if (txtAppleInvoice.Text == "")
            {
                txtAppleInvoice.Text = "0";
            }
            if (txtMelonInvoice.Text == "")
            {
                txtMelonInvoice.Text = "0";
            }
            if (txtW_MInvoice.Text == "")
            {
                txtW_MInvoice.Text = "0";
            }

            int ia = Convert.ToInt32(iAppleICount * 0.6 * 2000);
            int im = Convert.ToInt32(iMelonICount * 0.6 * 2500);
            int iW = Convert.ToInt32(iW_MICount * 0.6 * 18000);
            iInvoicePrice = ia + im + iW;

            if (Convert.ToInt32(lblManCash.Text) < iInvoicePrice)
            {
                txtAppleInvoice.Text = "";
                txtMelonInvoice.Text = "";
                txtW_MInvoice.Text = "";
                MessageBox.Show("발주할 잔액이 부족합니다.");
                return;
            }

            lblAppleLeftCount.Text = Convert.ToString(Convert.ToInt32(lblAppleLeftCount.Text) + iAppleICount);
            iAppleMargin -= ia;

            lblMelonLeftCount.Text = Convert.ToString(Convert.ToInt32(lblMelonLeftCount.Text) + iMelonICount);
            iMelonMargin -= im;

            lblW_MLeftCount.Text = Convert.ToString(Convert.ToInt32(lblW_MLeftCount.Text) + iW_MICount);
            iW_MMargin -= iW;

            lblManCash.Text = Convert.ToString(Convert.ToInt32(lblManCash.Text) - (ia + im + iW));
            //if (!String.IsNullOrEmpty(txtAppleInvoice.Text))
            //{
            //    lblAppleLeftCount.Text = Convert.ToString(Convert.ToInt32(lblAppleLeftCount.Text) + iAppleICount);
            //    lblManCash.Text = Convert.ToString(Convert.ToInt32(lblManCash.Text) - 0.6 * 2000 * iAppleICount);
            //    iAppleMargin -= Convert.ToInt32(iAppleICount * 0.6 * 2000);
            //}
            //if (!String.IsNullOrEmpty(txtMelonInvoice.Text))
            //{
            //    lblMelonLeftCount.Text = Convert.ToString(Convert.ToInt32(lblMelonLeftCount.Text) + iMelonICount);
            //    lblManCash.Text = Convert.ToString(Convert.ToInt32(lblManCash.Text) - 0.6 * 2500 * iMelonICount);
            //    iMelonMargin -= Convert.ToInt32(iMelonICount * 0.6 * 2500);
            //}
            //if (!String.IsNullOrEmpty(txtW_MInvoice.Text))
            //{
            //    lblW_MLeftCount.Text = Convert.ToString(Convert.ToInt32(lblW_MLeftCount.Text) + iW_MICount);
            //    lblManCash.Text = Convert.ToString(Convert.ToInt32(lblManCash.Text) - 0.6 * 18000 * iW_MICount);
            //    iW_MMargin -= Convert.ToInt32(iW_MICount * 0.6 * 18000);
            //}

            textBox1.Text += "--------- 발주 내역 -----------\r\n";
            if (iAppleICount > 0)
            {
                textBox1.Text += $"사과 발주 개수 : {iAppleICount}, 구매 금액 : {ia}\r\n";
            }
            if (iMelonICount > 0)
            {
                textBox1.Text += $"참외 발주 개수 : {iMelonICount}, 구매 금액 : {im}\r\n";
            }
            if (iW_MICount > 0)
            {
                textBox1.Text += $"수박 발주 개수 : {iW_MICount}, 구매 금액 : {iW}\r\n";
            }

            txtAppleInvoice.Text = "";
            txtMelonInvoice.Text = "";
            txtW_MInvoice.Text = "";
            MessageBox.Show("발주가 완료되었습니다.");
        }


        private void btnInvoiceClear_Click(object sender, EventArgs e)
        {
            txtAppleInvoice.Text = "";
            txtMelonInvoice.Text = "";
            txtW_MInvoice.Text = "";
        }
        private void btnShowUnitMargin_Click(object sender, EventArgs e)
        {
            // 개별 마진 보기
            if (rdoAppleMargin.Checked == true)
            {
                MessageBox.Show($"사과의 마진은 {Convert.ToString(iAppleMargin)} 원입니다.");
            }
            else if (rdoMelonMargin.Checked == true)
            {
                MessageBox.Show($"참외의 마진은 {Convert.ToString(iMelonMargin)} 원입니다.");
            }
            else if (rdoW_MMargin.Checked == true)
            {
                MessageBox.Show($"수박의 마진은 {Convert.ToString(iW_MMargin)} 원입니다.");
            }
        }


        private void btnShowTotalMargin_Click(object sender, EventArgs e)
        {
            iTotalMargin = iAppleMargin + iMelonMargin + iW_MMargin;
            MessageBox.Show($"총 마진은 {Convert.ToString(iTotalMargin)} 원입니다.");
        }
    }
}
