using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 스레드를 사용하기 위한 라이브러리 참조
using System.Threading;
using Assembly;

namespace MainForms
{
    public partial class M04_MainForm : Form
    {
        private Thread thNowTime; // 현재 시각 스레드 객체
        public M04_MainForm()
        {
            InitializeComponent();
            M01_Login_N M01 = new M01_Login_N();
            M01.ShowDialog();
            // 호출했던 로그인 화면의 결과 Tag 값이 성공이 아니면 프로그램 종료
            if (Convert.ToBoolean(M01.Tag) != true)
            {
                Environment.Exit(0);
            }
        }
        // 신규 스레드를 통한 현재시간 체크
        // Thread : 프로세스 내부에서 생성되는 작업을 하는 주체
        //          스레드를 생성함으로서 하나의 프로세스 외에 여러 가지 일을 동시에 수행 가능
        private void M04_MainForm_Load(object sender, EventArgs e)
        {
            // 현재 시각 Thread 시작
            thNowTime = new Thread(new ThreadStart(GetNowTime));
            if (thNowTime.IsAlive == false) thNowTime.Start();
        }

        private void GetNowTime()
        {
            // 5초 뒤 스레드를 종료하기 위한 임시 변수
            int iThBreak = 0;
            while(true)
            {
                // 1초마다 갱신
                Thread.Sleep(1000);
                stsNowTime.Text = String.Format("{0:yyyy-M-dd HH:mm:ss}", DateTime.Now);
                iThBreak++;
                if (iThBreak == 5)
                    break;
            }
            MessageBox.Show("현재시각 표시 스레드를 종료합니다.");

            // 스레드의 종료
            thNowTime.Abort();
        }
        #region < 프로그램 종료 >
        private void tsExit_Click(object sender, EventArgs e)
        {
            // 프로그램 종료 버튼 클릭
            ApplicationExit();

        }

        private void M04_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 메인화면 폼 종료 시
            ApplicationExit();
        }

        private void ApplicationExit()
        {
            // 확인메세지 표현 후 프로그램 종료
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.No) return;

            // 구동되고 있는 스레드 종료
            if (thNowTime.IsAlive) thNowTime.Abort();

            // 어플리케이션 종료
            Environment.Exit(0);
        }

        private void M_TEST_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // 메뉴 클릭
            // 1. CS 파일을 직접 호출
        }
        #endregion


        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    // 1틱이 발생될 때마다 (1초) 현재 일시를 라벨에 나타낸다.
        //    stsNowTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
        //}
    }
}
