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
    public partial class Chap15_Exam01 : Form
    {
        public Chap15_Exam01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iResultD = 0;
            int iResultS = 0;
            // 1 부터 100 까지 반복하여 합할 반복문 작성
            for (int i = 0; i <= 100; i++)
            {
                // 짝수의 합 구하기
                if (i % 2 == 0) iResultD += i;
                else iResultS += i; // 짝수가 아니면 무조건 홀수이다.
            }

            MessageBox.Show($"1 부터 100 까지 수 중 짝수의 합은 {iResultD} 이고 홀수의 합은 {iResultS} 입니다.");
        }
    }
}
