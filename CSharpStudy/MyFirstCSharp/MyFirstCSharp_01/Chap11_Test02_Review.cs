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
    public partial class Chap11_Test02_Review : Form
    {
        public Chap11_Test02_Review()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 중복되지 않는 문자열 찾기 (Dictionary Foreach)

            // 딕셔너리 선언
            Dictionary<char, int> dMydic = new Dictionary<char, int>();

            foreach (char BaseString in label2.Text)
            {
                if (dMydic.ContainsKey(BaseString))
                {
                    dMydic[BaseString] = dMydic[BaseString] + 1;
                }
                else
                {
                    dMydic[BaseString] = 1;
                }
            }

            // 딕셔너리에 넣은 키와 값 중 값이 1인 가장 첫 데이터를 찾기
            bool bCheck = false;
            string sValueString = string.Empty;
            foreach (char sValue in dMydic.Keys)
            {
                if (dMydic[sValue] == 1)
                {
                    bCheck = true;
                    sValueString = Convert.ToString(sValue);
                    break;
                }
            }
            if (bCheck) MessageBox.Show($"중복되지 않는 가장 첫 문자는 {sValueString} 입니다.");
            else MessageBox.Show($"중복되지 않는 문자가 없습니다.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 중복되지 않는 문자열 찾기 (LastIndexOf)
            string sTitle = label2.Text;
            string sBaseString = string.Empty; // 비교할 문자
            int iLastIndex = 0;

            bool bCheckFind = false; // 문자열을 찾았는지 못 찾았는지
            for (int i = 0; i < sTitle.Length; i++)
            {
                sBaseString = sTitle.Substring(i, 1);
                iLastIndex = sTitle.LastIndexOf(sBaseString); // 기준 문자가 포함되어 있는 마지막 Index
                if (i == iLastIndex)
                {
                    bCheckFind = true;
                    break;
                }  
            }
            if (bCheckFind) MessageBox.Show($"중복되지 않는 첫 문자는 {sBaseString} 입니다.");
            else MessageBox.Show($"중복되지 않는 문자가 없습니다.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 중복되지 않는 문자열 찾기 (For in For)

            // 비교하여야 할 문자열 변수에 등록
            string sTitle = label2.Text;
            string sBaseString = string.Empty; // 기준 문자
            string sCheckString = string.Empty; // 비교할 문자

            bool bFind = false;
            // 기준 문자열 찾기
            for (int i = 0; i < sTitle.Length; i++)
            {
                sBaseString = sTitle.Substring(i, 1);
                for (int k = sTitle.Length - 1; k >= 0; k--)
                {
                    sCheckString = sTitle.Substring(k, 1);
                    if (i == k)
                    {
                        bFind = true;
                        break;
                    }
                    if (sBaseString == sCheckString)
                    {
                        break;
                    }
                }
                if (bFind) break;
            }
            MessageBox.Show($"중복되지 않는 첫 문자는 {sBaseString} 입니다.");
        }
    }
}
