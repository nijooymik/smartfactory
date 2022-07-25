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
    public partial class Chap10_MiddleTestCode : Form
    {
        //string sTitle = "ABCLD/EML/BAMDC";
        public Chap10_MiddleTestCode()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ////dictionary, foreach
            string sTitle = label2.Text;
            //Dictionary<string, int> MyTable = new Dictionary<string, int>(); //<키, 값>
            //MyTable.Add("A", 1);
            //MyTable.Add("B", 2);
            //MyTable.Add("C", 3);
            //MyTable["D"] = 4;
            ////MyTable[5] = "ABC"; 키 값 데이터 타입 오류

            //// 1. 딕셔너리 복사
            //// 값형 복사
            //Dictionary<string, int> MyTable2 = new Dictionary<string, int>(MyTable);
            //MyTable2["A"] = 10;
            //MessageBox.Show(Convert.ToString(MyTable2["A"]));

            //// 참조형 복사
            //Dictionary<string, int> MyTable3 = MyTable;
            //MyTable3["A"] = 10;
            //MessageBox.Show(Convert.ToString(MyTable["A"]));

            //// key 의 사용여부 확인
            //if (MyTable.ContainsKey("A")) //bool
            //{
            //    MessageBox.Show("A 키가 있습니다.");
            //}

            //// Value 의 사용여부 확인
            //if (MyTable.ContainsValue(3))
            //{
            //    MessageBox.Show("3 번 값을 가지고 있는 데이터가 있습니다.");
            //}

            //// 키와 값의 삭제
            //MyTable.Remove("A");
            //if (!MyTable.ContainsKey("A"))
            //{
            //    MessageBox.Show("A 키를 가지고 있지 않습니다.");
            //}

            //string sTitle = label2.Text;

            //// 추출 시작
            //bool sCheck = false;
            //foreach (char ch in sTitle)
            //{
            //    if ()
            //    {
            //        MessageBox.Show($"{ch} 문자가 있습니다.");
            //        sCheck = true;
            //        break;
            //    }
            //}
            //if (!sCheck) MessageBox.Show("문자가 없습니다.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //lastindexof
            string sTitle = label2.Text;
            foreach (char ch in sTitle)
            {
                if (sTitle.IndexOf(ch) == sTitle.LastIndexOf(ch))
                {
                    MessageBox.Show($"{ch}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
