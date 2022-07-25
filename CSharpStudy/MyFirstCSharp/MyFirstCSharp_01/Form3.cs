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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnRanMake_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            GetPrice(ran.Next(100, 3000), ran.Next(1, 20), ran.Next(10000, 500000));
        }

        private void GetPrice(int iPrice, int iCount, int iCash)
        {
            // 내가 지불해야 할 금액
            int iResult = 0; // 지불해야 할 누적 금액
            for (int i = 1; i <= iCount; i++)
            {
                iResult += iPrice * i;
            }
            // 내가 지불하고 남는 금액
            int iRemain = 0;
            iRemain = iCash - iResult;

            string sMessage = "남습니다.";
            if (iRemain < 0) sMessage = "모자랍니다.";

            MessageBox.Show($"{iCash} 이 있을 때 이용요금 {iPrice} 인 놀이기구 {iCount} 번 타면 {iRemain} 이 {sMessage}");
        }
    }
}
