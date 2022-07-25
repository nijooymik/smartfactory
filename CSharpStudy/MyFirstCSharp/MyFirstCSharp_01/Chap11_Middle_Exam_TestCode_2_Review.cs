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
    public partial class Chap11_Middle_Exam_TestCode_2_Review : Form
    {
        public Chap11_Middle_Exam_TestCode_2_Review()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // int 배열 등록
            int[] iArray = { 1, 4, 6, 9, 10, 12, 16 };

            // 찾은 값을 등록할 변수
            string sFindValue = string.Empty;

            // 결과의 Index
            int iResult = 0;

            for (int i = 0; i < iArray.Length; i++)
            {
                // 찾을 수? 
                int iFindValue = 16 - iArray[i];

                // 찾을 배열의 수가 있는 위치(index)를 찾기
                iResult = Array.IndexOf(iArray, iFindValue, i + 1);

                // 결과가 없으면 -1을 반환
                if (iResult == -1) continue;

                sFindValue += $"{iArray[i]}, {iArray[iResult]} \r\n";
            }
            MessageBox.Show(sFindValue);
        }
    }
}
