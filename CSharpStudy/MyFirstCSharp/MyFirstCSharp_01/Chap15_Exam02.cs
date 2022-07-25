﻿using System;
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
    public partial class Chap15_Exam02 : Form
    {
        public Chap15_Exam02()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 기본적인 로직으로 구하는 방법

            string sBaseString = string.Empty; // 앞자리부터 비교할 문자 가져올 변수
            int     iFirstIndex = 0;            // 첫번째 ? 를 찾은 문자열의 Index
            int     iThirdIndex = 0;            // 세번째 ? 를 찾은 문자열의 Index
            int     iFindCount  = 0;            // ? 를 찾은 횟수 (1번째, 3번째 '?' 인지 확인)
            for (int i = 0; i < label1.Text.Length; i++)
            {
                // 앞자리부터 비교할 문자 가져오기
                sBaseString = label1.Text.Substring(i, 1);
                if (sBaseString == "?")
                {
                    // ? 를 찾은 횟수가 0 또는 2 일 때 Index 변수에 인덱스 정보 담기
                    if (iFindCount == 0) iFirstIndex = i; // 첫번째 ? 인덱스 정보
                    else if (iFindCount == 2)
                    {
                        iThirdIndex = i; // 세번째 ? 인덱스 정보
                        break;
                    }
                    // ? 를 찾은 횟수의 증가
                    ++iFindCount;
                }
            }
            // 첫번째와 세번째 인덱스를 합친 인덱스에서 3자리 문자열 가져오기
            string sFindstring = label1.Text.Substring(iFirstIndex + iThirdIndex, 3);
            // 텍스트박스에 xxx 로 변경할 데이터 출력하기
            textBox1.Text = label1.Text.Replace(sFindstring, "XXX");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 제공되는 함수 기능을 이용하여 간단하게 표현
            string sTitle       = label1.Text;         // 비교할 문자열 변수에 담기
            int    iFirstIndex  = sTitle.IndexOf("?"); // 문자열 중에 왼쪽에서 가장 첫번째 ? 인덱스를 찾는다.
            int    iSecondIndex = sTitle.IndexOf("?", iFirstIndex + 1); // 첫번째 ? 를 찾은 Index 다음부터 두번째 ? 의 Index 를 찾는다.
            int    iThirdIndex  = sTitle.IndexOf("?", iSecondIndex + 1); // 세번째 ? 인덱스 찾기
            //첫번째와 세번째 인덱스를 합친 인덱스에서 3자리 문자열 가져오기
            string sFindstring = label1.Text.Substring(iFirstIndex + iThirdIndex, 3);
            textBox1.Text = label1.Text.Replace(sFindstring, "XXX");
        }
    }
}
