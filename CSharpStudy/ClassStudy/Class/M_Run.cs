using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class
{
    public partial class M_Run : Form
    {
        public M_Run()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// M_RunStopFlag.CS 에 있는 데이터를 M_RSflag 이름의 객체로 복사하라.
            //M_RunStopFlag M_RSflag = new M_RunStopFlag();

            //// 복사 해온 M_RSflag 에 있는 sRunStopFlag 의 값을 표현해 주세요. 
            //MessageBox.Show(M_RSflag.sRunStopFlag);

            //// 복사 해온 M_RSflag 객체에 있는 sRunStopFlag 변수에 "가동"이라는 
            //// 데이터를 넣어 주세요 제발 컴퓨터님.
            //M_RSflag.sRunStopFlag = "가동";

            //// 복사해온 M_RSflag 객체에 있는 sRunStopFlag 값이 바뀐 최신의 상태를
            //// 보여주세요.
            //MessageBox.Show(M_RSflag.sRunStopFlag);

            MessageBox.Show(M_RunStopFlag.sRunStopFlag);
            M_RunStopFlag.sRunStopFlag = "가동";
            MessageBox.Show(M_RunStopFlag.sRunStopFlag);
        }
    }
}
