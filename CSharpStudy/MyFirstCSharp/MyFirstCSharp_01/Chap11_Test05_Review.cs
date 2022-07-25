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
    public partial class Chap11_Test05_Review : Form
    {
        public Chap11_Test05_Review()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 타이틀에 나열된 문자를 숫자 형식으로 바꿀 수 있도록 문자 변경
            string sTitle = label3.Text.Replace("{", "").Replace("}", "").Replace(" ", "");

            // , 로 구분할 수 있는 정수 문자를 배열에 담기
            string[] sArray = sTitle.Split(',');

            // 문자 배열을 정수 배열로 담기
            int[] iArray = new int[sArray.Length];

            int iArrayCount = 0; // int[] 에 담길 index 주소
            foreach(string sValue in sArray)
            {
                iArray[iArrayCount] = Convert.ToInt32(sValue);
                ++iArrayCount;
            }


            // 첫번재 중복되는 수, 세번째 중복되는 수 찾기

            // iArray[] 값 정렬
            Array.Sort(iArray);
            // 1 2 3 8 8 8 13 13 15 15 17 19 23

            string sResult = string.Empty; // 결과가 누적될 문자
            int iFindCount = 0; // 중복 숫자를 찾은 횟수
            // 중복되는 값 찾기
            for (int i = 0; i < iArray.Length; i++)
            {
                if (i + 1 == iArray.Length) break;
                if (iArray[i] == iArray[i+1])
                {
                    if (sResult.Contains(Convert.ToString(iArray[i]))) continue;
                    iFindCount++;
                    if (iFindCount == 2) continue;
                    sResult += Convert.ToString(iArray[i]) + " ";
                    if (iFindCount == 3) break;
                }
            }
            MessageBox.Show(sResult);
        }
    }
}
