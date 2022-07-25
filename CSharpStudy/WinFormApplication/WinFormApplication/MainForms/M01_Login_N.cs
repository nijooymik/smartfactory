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

    public partial class M01_Login_N : Form
    {
        int iCount = 0;
        // SQL Server 커넥터 객체 생성
        private SqlConnection Connect;
        public M01_Login_N()
        {
            InitializeComponent();
            Commons.sConnectInfo = "Server = localhost; Uid = sa; Pwd = 1234; database = AppDev";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 로그인 버튼 클릭
            DoLogin();

            if (iCount == 3)
            {
                MessageBox.Show("해킹이 감지되었습니다");
                this.Close();
            }
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
                string sFindUserSQL = " SELECT USERNAME,PW,ISNULL(PW_F_CNT,0) AS PW_F_CNT";
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
                } // dtTemp 테이블에 받아온 데이터 중 PassWord 정보를 변수에 담는다.

                if (Convert.ToInt32(dtTemp.Rows[0]["PW_F_CNT"]) == 3)
                {
                    MessageBox.Show("3회 이상 비밀번호를 잘못입력하였습니다.\r\n 관리자와 문의 하세요.");
                    return;
                }

                // dtTemp 테이블에 받아온 데이터 중 PassWord 정보를 변수에 담는다.
                else if (sPassWord != Convert.ToString(dtTemp.Rows[0]["PW"]))
                {
                    MessageBox.Show("비밀번호를 잘못 입력하셨습니다.");
                    // 비밀번호 실패 횟수 증가
                    SqlTransaction Transaction = Connect.BeginTransaction("MyTran");
                    try
                    {
                        // 비밀번호 실패 횟수 변경
                        SqlCommand cmd = new SqlCommand();

                        // 비밀번호 누적 오류 횟수 tran
                        cmd.Transaction = Transaction;
                        cmd.Connection = Connect;
                        // 실행할 SQL 구문 등록 
                        string sUpdateSql;
                        sUpdateSql = " UPDATE TB_USER                          ";
                        sUpdateSql += $" SET PW_F_CNT = ISNULL(PW_F_CNT,0) + 1 ";
                        sUpdateSql += $" WHERE USERID = '{sLogInID}'           ";

                        // 커맨드에 실행할 SQL 구문 등록
                        cmd.CommandText = sUpdateSql;
                        // 커맨드 실행
                        cmd.ExecuteNonQuery();
                        // 정상 완료 시 COMMIT
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("누적 횟수 증가 오류 발생");
                        Transaction.Rollback();
                    }

                    // 비밀번호 누적 실패 횟수 확인 및 메세지
                    sFindUserSQL = " SELECT ISNULL(PW_F_CNT, 0) AS PWF_CNT";
                    sFindUserSQL += " FROM TB_USER ";
                    sFindUserSQL += $" WHERE USERID = '{sLogInID}'";

                    Adapter = new SqlDataAdapter(sFindUserSQL, Connect);

                    dtTemp = new DataTable();
                    Adapter.Fill(dtTemp);

                    if (Convert.ToInt32(dtTemp.Rows[0]["PW_F_CNT"]) == 3)
                    {
                        MessageBox.Show("3회 이상 비밀번호를 잘못 입력하셨습니다.");
                    }
                    return;
                }
                // ID 와 PW 가 일치할 경우 log in

                // 공통 변수에 값 대입
                Commons.sLogInUserID = sLogInID;
                Commons.sLogInUserName = Convert.ToString(dtTemp.Rows[0]["USERNAME"]);

                MessageBox.Show($"{Commons.sLogInUserName} 님 반갑습니다.");
                
                // 로그인이 성공했다는 값을 클래스의 Tag 에 등록
                this.Tag = true;

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

        }

        private void btnPWChange_Click(object sender, EventArgs e)
        {
            M03_PassWordChange M03 = new M03_PassWordChange();
            this.Visible = false; // 로그인 화면을 숨기기
            M03.ShowDialog();
            this.Visible = true;
        }

        private void txtPW_KeyDown(object sender, KeyEventArgs e)
        {
            // 로그인 정보 작성 후 엔터 입력 시 비밀번호 변경 클릭 메서드 실행
            if (e.KeyCode == Keys.Enter)
            {
                DoLogin();
            }
        }
    }
}
