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
    public partial class Chap11_Test07_Review : Form
    {
        public Chap11_Test07_Review()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] iArray = new int[] { 1, 11, 6, 20, 11, 8, 12, 6, 16, 13, 22 };

            // 비교 기준 값의 Index : 배열의 마지막 Index까지 반복
            for (int i = 0; i < iArray.Length; i++)
            {
                // 비교할 대상이 시작되는 위치부터 배열의 마지막까지 반복
                for (int k = i + 1; k < iArray.Length; k++)
                {
                    if (iArray[k] > iArray[i])
                    {
                        int iValue = 0;         // 값을 담을 임시 변수
                        iValue     = iArray[i]; // 임시 변수에 작은 값을 보관
                        iArray[i]  = iArray[k]; // 큰 값을 작은 값 위치에 복사
                        iArray[k]  = iValue;    // 임시 변수에 보관된 값을
                                                // 큰 값이 있던 위치에 등록
                    }
                }
            }

            string sMessage = string.Empty;
            foreach (int iResult in iArray)
            {
                sMessage += Convert.ToString(iResult) + " ";
            }

            textBox1.Text = sMessage;
        }
    }
}
