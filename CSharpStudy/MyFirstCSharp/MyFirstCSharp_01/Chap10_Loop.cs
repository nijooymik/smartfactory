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
    public partial class Chap10_Loop : Form
    {
        public Chap10_Loop()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1 부터 100 까지 누적 합산 결과를 표현하세요.
            int iResult = 0; // 누적 계산 결과가 들어갈 변수.

            //  ( i가 1부터 ;100될때까지;i를 1씩 증가시켜서 반복하라 )
            for ( int i = 1 ; i <= 100 ; i++ )
            {
                iResult+= i; // iResult = iResult + i; // 현재 수를 누적시켜 합산한다.
            }
            MessageBox.Show(Convert.ToString(iResult));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 배열의 수만큼 for 반복 후 값 더하기

            // 1. 임의의 배열 값 등록
            int[] iValue = new int[] { 1, 12, 18, 20, 13 }; // 인티저 배열 iValue
            //                   index 0   1   2   3   4

            // 2. 배열 값의 합을 더할 변수 생성
            int iResult = 0;

            // 3. for 문을 시작할 변수 데이터 생성
            //int NowIndex = 0;

            for (int NowIndex = 0; NowIndex < iValue.Length; NowIndex++) // 배열 개수보다 적을 때까지
            {
                iResult = iResult + iValue[NowIndex];
                // 왜 Length 보다 미만인 수만큼 반복해야 하나?
                // 배열의 Length 는 5개, Indext는 0, 1, 2, 3, 4 이므로
                // iValue[NowIndex] 에서 NowIndex 는 4가 가장 마지막 주소 정수가 되어야 한다.
            }
            MessageBox.Show(Convert.ToString(iResult));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 구구단 만들기 (For In For)

            // 1. base 가 되는 단수 문자열 변수
            string sBase = string.Empty;

            // 2. 곱해지는 수와 결과 값 문자열 변수
            string sSub = string.Empty;

            // 3. Base 단수 2 ~ 9 단 반복
            for (int i = 2; i <= 9; i++)
            {
                // 4. sBase 에 현재 i 단수 문자열 대입
                sBase = $"{Convert.ToString(i)} * "; // 첫번째 반복일 때 (2 * )

                // 5. 곱해지는 수 1 ~ 9 반복문
                for (int k = 1; k <= 9; k++)
                {
                    // 6. sSub 문자변수에 곱해지는 수와 결과 값을 베이스 문자열과 합
                    sSub = $"{Convert.ToString(k)} = {Convert.ToString(i * k)}";
                    textBox1.Text += $"{sBase}{sSub}\r\n"; // == 이면 81만 나옴. \r\n 줄바꿈

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1 부터 100 까지 누적 합산 계산 For 문
            int iSumValue = 0; // 누적값 변수

            for (int i = 1; i <= 100; i++)
            {
                //iSumValue = iSumValue + i;
                iSumValue += i;
                if (i >= 50 && i <= 60)
                {
                    continue; // 스킵
                }
                

                if (iSumValue > 1000) break; // 종료
            }
            MessageBox.Show(Convert.ToString(iSumValue));
        }
    }
}
