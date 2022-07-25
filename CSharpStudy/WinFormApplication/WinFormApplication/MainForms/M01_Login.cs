using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// SQL Server 에 접속할 수 있는 클래스 라이브러리
using System.Data.SqlClient;
// Assembly 라이브러리 참조
using Assembly;

namespace MainForms
{
    /*********************************************************
     * NAME : M01_LOGIN
     * DESC : 시스템 로그인
     * ------------------------------------------------------
     * DATE        : 2022.06.20
     * AUTHOR      : 김유진
     * DESCRIPTION : 최초 프로그램 작성
     * ------------------------------------------------------*/

    // WinFormApplication 강의의 목표
    // C# .NetFrameWork 기본 도구와 프로그래밍 문법을 사용하여 개발 솔루션의 프레임을 만들어보고
    // 시스템 개발 프레임 소스의 원리를 이해 및 기능을 습득한다.

    public partial class M01_Login : Form
    {
        int iCount = 0;
        // SQL Server 커넥터 객체 생성
        private SqlConnection Connect = null;
        public M01_Login()
        {
            InitializeComponent();
            Commons.sConnectInfo = "Server = localhost; Uid = sa; Pwd = 1234; database = AppDev";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 로그인 버튼 클릭
            DoLogin();
        }
        private void DoLogin()
        {
            try
            {
                // 데이터베이스 접속 경로 설정
                string strConn = Commons.sConnectInfo;

                // 접속 경로 커넥터 객체에 전달
                Connect = new SqlConnection(strConn);

                // 데이터베이스 접속 여부 확인
                Connect.Open();
                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터박스 연결에 실패하였습니다.");
                    return;
                }

                string sLogInID = txtID.Text; // 사용자 ID
                string sPassWord = txtPW.Text; // 사용자 비밀번호

                // ID / PW 찾는 sql 구문
                string sFindUserSQL = " SELECT USERNAME,PW";
                sFindUserSQL       += " ISNULL(PW_FAIL_CNT, 0) AS PWF_CNT";
                sFindUserSQL       += "   FROM TB_USER";
                sFindUserSQL       += $" WHERE USERID = '{sLogInID}'";
                //sFindUserSQL       += $"   AND PW = '{sPassWord}'"; 

                // SqlDataAdapter : 데이터베이스에 연결 후 SELECT SQL 구문 전달. 결과값 리턴받는 클래스
                SqlDataAdapter Adapter = new SqlDataAdapter(sFindUserSQL, Connect);
                // DataTable : 프로그래밍 언어에서 데이터를 DB 의 테이블 형태로 관리하는 데이터 자료 구조 클래스
                // DQL 서버로 SQL 문 전달 후 결과를 DataTable 에 담기
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // ID 와 PW 가 일치하지 않을 경우 (dtTemp 에 데이터가 한 건도 없을 경우)
                // return;
                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("로그인 ID 가 잘못되었습니다.");
                    txtID.Text = "";
                    txtID.Focus();
                    ++iCount;
                    CheckThreeFail();
                    return;
                }
                // dtTemp 테이블에 받아온 데이터 중 PassWord 정보를 변수에 담는다.
                else if (sPassWord != Convert.ToString(dtTemp.Rows[0]["PW"]))
                {
                    MessageBox.Show("PW 가 일치하지 않습니다.");
                    txtPW.Text = "";
                    txtPW.Focus();
                    ++iCount;
                    CheckThreeFail();
                    return;
                }
                // ID 와 PW 가 일치할 경우 log in

                // 공통 변수에 값 대입
                Commons.sLogInUserID = sLogInID;
                Commons.sLogInUserName = Convert.ToString(dtTemp.Rows[0]["USERNAME"]);

                MessageBox.Show($"{Commons.sLogInUserName} 님 반갑습니다.");

                this.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }
        private void CheckThreeFail()
        {
            if (iCount == 3)
            {
                MessageBox.Show("해킹이 감지되었습니다.");
                this.Close();
            }
        }

        private void btnPWChange_Click(object sender, EventArgs e)
        {
            M03_PassWordChange M03 = new M03_PassWordChange();
            this.Visible = false; // 로그인 화면을 숨기기
            M03.ShowDialog();
            this.Visible = true;
        }
    }
}
