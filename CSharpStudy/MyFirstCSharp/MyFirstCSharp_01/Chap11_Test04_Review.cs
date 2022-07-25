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
    public partial class Chap11_Test04_Review : Form
    {
        int[] iArray = new int[3];
        int iCount = 0;

        public Chap11_Test04_Review()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 난수를 생성
            Random rnd = new Random();
            int iValue = rnd.Next(0, 100);
            if (iCount == 0)      txtRan1.Text = Convert.ToString(iValue);
            else if (iCount == 1) txtRan2.Text = Convert.ToString(iValue);
            else if (iCount == 2) txtRan3.Text = Convert.ToString(iValue);
            iArray[iCount] = iValue;
            ++iCount;
            if (iCount == 3)
            {
                iCount = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 결과 버튼 클릭
            Array.Sort(iArray); // int[] 배열에 있는 값을 정렬 0 : 최소값, 2 : 최대값
            int iResult = 0; // 합을 누적시킬 결과 변수
            for (int i = 0; i < iArray.Length; i++)
            {
                iResult += iArray[i];
            }
            
            if (iResult < 100)
            {
                MessageBox.Show($"3 수의 합이 100 미만, 최소값 {iArray[0]}, 최대값 {iArray[2]}의 곱은 {iArray[0] * iArray[2]}");
            }
            else if (iResult >= 100 && iResult < 200)
            {
                MessageBox.Show($"3 수의 합이 100 이상 200 미만, 최소값 {iArray[0]}, 최대값 {iArray[2]}의 합은 {iArray[0] + iArray[2]}");
            }
            else if (iResult >= 200)
            {
                MessageBox.Show($"3 수의 합이 200이 넘습니다.");
            }
        }
    }
}
