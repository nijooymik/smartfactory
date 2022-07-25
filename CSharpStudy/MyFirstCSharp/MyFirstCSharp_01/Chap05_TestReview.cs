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
    public partial class Chap05_TestReview : Form
    {
        private string sTitle = "안녕하세요 2022 스마트 팩토리 S/W 개발 교육 과정을 이수 하게된 OOO 입니다. 즐겁고 보람찬 SMARTFACTORY  교육 이 되었으면 합니다.";
        public Chap05_TestReview()
        {
            InitializeComponent();
            label1.Text = sTitle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 이름 변경
            label1.Text = label1.Text.Replace("OOO", "땡땡땡");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // S/W 위치찾기
            int iIndex = label1.Text.IndexOf("S/W");
            MessageBox.Show(Convert.ToString(iIndex));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // -품질재단- 입력
            label1.Text = $"-품질재단- {label1.Text} -품질재단-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // . 두번째 문장
            string[] sValue = label1.Text.Split('.');
            MessageBox.Show(sValue[1]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 문자열 중 본인 이름만 참아서 메세지박스로 표현
            int iIndex = label1.Text.IndexOf("땡땡땡");
            string sResult = label1.Text.Substring(iIndex, 3);
            MessageBox.Show(sResult);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // SMARTFACTORY 만 소문자로 변경

            // 처리할 문자열
            string sValue = "SMARTFACTORY";

            // SMARTFACTORY 위치 찾기
            int iIndex = label1.Text.IndexOf(sValue);

            // 위치에서 글자 수만큼 원본 문자열에서 삭제.
            //string sResult = label1.Text.Remove(iIndex, 12);
            string sResult = label1.Text.Remove(iIndex, sValue.Length);

            // 위치에 소문자로 변경된 문구 입력
            string sResult2 = sValue.ToLower();

            label1.Text = sResult.Insert(iIndex, sResult2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // . 첫번째 문장 삭제
            string sTitle = label1.Text;
            label1.Text = "즐겁고 보람찬 SMARTFACTORY  교육 이 되었으면 합니다.";
            // 라벨에 . 기준 두번째문장을 삭제후 표시
            // = 첫번째 문장만 표현하세요
            string[] sValue = label1.Text.Split('.');
            label1.Text = sValue[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 모든 공백 없애기
            label1.Text = label1.Text.Replace(" ", ""); // 메모리적으로 가장 효율적인 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 되돌리기
            label1.Text = sTitle;
        }
    } // 클래스 묶음 단위 안에 들어가 있음
}
