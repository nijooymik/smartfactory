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
    public partial class Chap11_Middel_Test_T2 : Form
    {
        Dictionary<string, int> MyDicMargin = new Dictionary<string, int>();

        int iOrderPrice = 0; // 총 결제 금액

        int iAppleLeftCount = 10; // 현재 사과 잔량
        int iMelonLeftCount = 10; // 현재 참외 잔량
        int iW_MLeftCount   = 10; // 현재 수박 잔량

        int iALeftC = 10; // 결제 후 이전 사과 잔량
        int iMLeftC = 10; // 결제 후 이전 참외 잔량
        int iWLeftC = 10; // 결제 후 이전 수박 잔량

        public Chap11_Middel_Test_T2()
        {
            InitializeComponent();
            MyDicMargin["사과"] = 0;
            MyDicMargin["참외"] = 0;
            MyDicMargin["수박"] = 0;
        }

        private void btnAppleOrder_Click(object sender, EventArgs e)
        {
            FruitOperator("사과");
        }

        private void btnMelonOrder_Click(object sender, EventArgs e)
        {
            FruitOperator("참외");
        }

        private void btnW_MOrder_Click(object sender, EventArgs e)
        {
            FruitOperator("수박");
        }

        private void btnShowOrderPrice_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"총 결제 금액은 {iOrderPrice}원입니다.");
        }

        private void btnOrderCancle_Click(object sender, EventArgs e)
        {
            // 주문 취소하기
            // 1. 취소할 내역이 없으면 메세지
            //if (iALeftC - iAppleLeftCount == 0 && iMLeftC - iMelonLeftCount == 0 && iWLeftC - iW_MLeftCount == 0)
            //{
            //    MessageBox.Show("사과의 주문 수량이 없습니다.");
            //    return;
            //}
            if (iOrderPrice == 0)
            {
                MessageBox.Show("주문 내역이 없습니다.");
                return;
            }

            // 마지막 결제 이전 재고 수량 표현하기
            lblAppleLeftCount.Text = Convert.ToString(iALeftC);
            lblMelonLeftCount.Text = Convert.ToString(iMLeftC);
            lblW_MLeftCount.Text   = Convert.ToString(iWLeftC);

            iAppleLeftCount = iALeftC;
            iMelonLeftCount = iMLeftC;
            iW_MLeftCount   = iWLeftC;

            // 결제 주문 금액 초기화
            iOrderPrice = 0;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            // 결제하기 버튼 클릭

            // 고객 잔액 // 결제할 금액이 잔액보다 많은 경우
            if (iOrderPrice > Convert.ToInt32(lblCustomerCash.Text))
            {
                MessageBox.Show("주문 금액이 잔액보다 많습니다.");
                return;
            }

            // 관리자 금액에 주문 금액을 증가시킨다. // 결제 금액 차감 가게 잔액 증가
            lblCustomerCash.Text = Convert.ToString(Convert.ToInt32(lblCustomerCash.Text) - iOrderPrice);
            lblManCash.Text = Convert.ToString(Convert.ToInt32(lblManCash.Text) + iOrderPrice);

            // 주문 수량, 금액 Text Box에 표현
            //int inowAppleLeftCount = Convert.ToInt32(lblAppleLeftCount.Text);

            // 주문한 수량 // 사과의 판매 개수
            int iAOrderCount = iALeftC - iAppleLeftCount; // 이전 잔량 - 현재 잔량 = 주문 수량
            // 참외의 판매 개수
            int iMOrderCount = iMLeftC - iMelonLeftCount;
            // 수박의 판매 개수
            int iWOrderCount = iWLeftC - iW_MLeftCount;

            // 과일의 각 판매 금액
            int iASalePrice = iAOrderCount * 2000;
            int iMSalePrice = iMOrderCount * 2500;
            int iWSalePrice = iWOrderCount * 18000;

            // 마진 금액 더하기
            MyDicMargin["사과"] += iASalePrice;
            MyDicMargin["참외"] += iMSalePrice;
            MyDicMargin["수박"] += iWSalePrice;

            // 거래 내역있는 내역만 TextBox에 표현
            string sOrderList = "--------------- 판매 내역 ------------------ \r\n";
            if (iAOrderCount != 0) sOrderList += $"사과의 판매 개수 : {iAOrderCount}, 판매 금액 : {iASalePrice}\r\n";
            if (iAOrderCount != 0) sOrderList += $"참외의 판매 개수 : {iMOrderCount}, 판매 금액 : {iMSalePrice}\r\n";
            if (iAOrderCount != 0) sOrderList += $"수박의 판매 개수 : {iWOrderCount}, 판매 금액 : {iWSalePrice}\r\n";

            txtOrderList.Text += sOrderList;

            // 결제 후 재고 기억하기
            iALeftC = iAppleLeftCount;
            iMLeftC = iMelonLeftCount;
            iWLeftC = iW_MLeftCount;

            // 결제 금액 초기화
            iOrderPrice = 0;

            // 결제 완료 메세지 표현
            MessageBox.Show("결제가 완료되었습니다.");
        }

        private void btnFruitInvoice_Click(object sender, EventArgs e)
        {
            // 발주 입고 버튼 클릭

            // 발주 수량 가져오기
            int iAInvCount = 0;
            int iMInvCount = 0;
            int iWInvCount = 0;

            int.TryParse(txtAppleInvoice.Text, out iAInvCount); // 사과의 발주 수량
            int.TryParse(txtMelonInvoice.Text, out iMInvCount); // 참외의 발주 수량
            int.TryParse(txtW_MInvoice.Text,   out iWInvCount); // 수박의 발주 수량

            if (iAInvCount == 0 && iMInvCount == 0 && iWInvCount == 0)
            {
                MessageBox.Show("발주 수량을 입력하지 않았습니다.");
                return;
            }

            // 발주 금액 산출하기
            int iAInvPrice = Convert.ToInt32(iAInvCount * 0.6 * 2000);
            int iMInvPrice = Convert.ToInt32(iMInvCount * 0.6 * 2500);
            int iWInvPrice = Convert.ToInt32(iWInvCount * 0.6 * 18000);

            // 마진 금액 차감
            MyDicMargin["사과"] -= iAInvPrice;
            MyDicMargin["참외"] -= iMInvPrice;
            MyDicMargin["수박"] -= iWInvPrice;

            // 차감 총액 변수에 담기
            int iTotalInvPrice = iAInvPrice + iMInvPrice + iWInvPrice;

            // 관리자 금액에서 총 발주 금액 차감하기
            int iManLeftCash = Convert.ToInt32(lblManCash.Text);

            if (iManLeftCash < iTotalInvPrice)
            {
                MessageBox.Show("잔액이 부족하여 발주를 진행할 수 없습니다.ㅠㅠ");
                return;
            }

            lblManCash.Text = Convert.ToString(iManLeftCash - iTotalInvPrice);

            // 주문 가능 수량 증가하기
            iAppleLeftCount = iALeftC += iAInvCount;
            iMelonLeftCount = iMLeftC += iMInvCount;
            iW_MLeftCount   = iWLeftC += iWInvCount;

            lblAppleLeftCount.Text = Convert.ToString(iAppleLeftCount);
            lblMelonLeftCount.Text = Convert.ToString(iMelonLeftCount);
            lblW_MLeftCount.Text   = Convert.ToString(iW_MLeftCount);

            // 발주 내역 있는 내역만 TextBox List 에 표현하기
            string sInvList = "------------- 발주내역 -------------\r\n";
            if (iAInvCount != 0) sInvList += $"사과 구매 개수 : {iAInvCount} , 구매 금액 : {iAInvPrice}\r\n";
            if (iMInvCount != 0) sInvList += $"참외 구매 개수 : {iMInvCount} , 구매 금액 : {iMInvPrice}\r\n";
            if (iWInvCount != 0) sInvList += $"수박 구매 개수 : {iWInvCount} , 구매 금액 : {iWInvPrice}\r\n";

            txtOrderList.Text += sInvList;

            // 수량 입력한 텍스트 내용 지우기
            InvoiceCountClear();

            // 메세지
            MessageBox.Show("발주/입고를 완료하였습니다.");
        }

        private void btnInvoiceClear_Click(object sender, EventArgs e)
        {
            InvoiceCountClear();
        }

        private void btnShowUnitMargin_Click(object sender, EventArgs e)
        {
            // 개별 마진 보기
            if (rdoAppleMargin.Checked)
            {
                MessageBox.Show(Convert.ToString(MyDicMargin["사과"]));
            }
            else if (rdoMelonMargin.Checked)
            {
                MessageBox.Show(Convert.ToString(MyDicMargin["참외"]));
            }
            else if (rdoW_MMargin.Checked)
            {
                MessageBox.Show(Convert.ToString(MyDicMargin["수박"]));
            }
        }

        private void btnShowTotalMargin_Click(object sender, EventArgs e)
        {
            // 총 마진 보기
            int iTotalSaleMargin = 0;
            foreach (int iFruitMargin in MyDicMargin.Values)
            {
                iTotalSaleMargin += iFruitMargin;
            }
            MessageBox.Show($"금일 발생한 총 마진은 {iTotalSaleMargin} 입니다.");
        }

        private void FruitOperator(string sFruitName)
        {
            switch (sFruitName)
            {
                case "사과":
                    iAppleLeftCount = Convert.ToInt32(lblAppleLeftCount.Text);
                    if (!CheckFruitCount("사과", ref iAppleLeftCount)) return;
                    lblAppleLeftCount.Text = Convert.ToString(iAppleLeftCount);
                    iOrderPrice += 2000;
                    break;
                case "참외":
                    iMelonLeftCount = Convert.ToInt32(lblMelonLeftCount.Text);
                    if (!CheckFruitCount("참외", ref iMelonLeftCount)) return;
                    lblMelonLeftCount.Text = Convert.ToString(iMelonLeftCount);
                    iOrderPrice += 2500;
                    break;
                case "수박":
                    iW_MLeftCount = Convert.ToInt32(lblW_MLeftCount.Text);
                    if (!CheckFruitCount("수박", ref iW_MLeftCount)) return;
                    lblW_MLeftCount.Text = Convert.ToString(iW_MLeftCount);
                    iOrderPrice += 18000;
                    break;
            }
        }

        private bool CheckFruitCount(string sFruitName, ref int iFruitCount)
        {
            if (iFruitCount == 0)
            {
                MessageBox.Show($"{sFruitName}의 잔량이 0개입니다.");
                return false;
            }
            --iFruitCount;
            return true;
        }

        
        private void InvoiceCountClear()
        {
            // 발주 수량 초기화 메서드☆
            foreach(Control txt in groupBox6.Controls)
            {
                if (txt is TextBox)
                {
                    txt.Text = "";
                }
            }
        } 
    }
}
