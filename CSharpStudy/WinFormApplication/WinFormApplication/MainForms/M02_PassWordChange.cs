using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// SQL SERVER 접속 클래스 라이브러리
using System.Data.SqlClient;
using Assembly;

namespace MainForms
{
    public partial class M02_PassWordChange : Form
    {
        private SqlConnection Connect;           // 데이터베이스 접속 정보 관리 클래스
        private SqlTransaction Tran;             // 데이터베이스 데이터 관리 권한 부여 클래스
        private SqlCommand Cmd = new SqlCommand(); // 데이터베이스 트랜잭션 명령 전달 클래스
        public M02_PassWordChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 비밀번호 변경 클릭
            DoChangePassWord();

        }
        private void DoChangePassWord()
        {
            // 기본값 입력 여부 확인
            string sMessage = string.Empty;
            if (txtUserID.Text == "")
            {
                sMessage = "사용자 ID";
            }
            else if (txtOldPW.Text == "")
            {
                sMessage = "이전 비밀번호";
            }
            else if (txtNewPW.Text == "")
            {
                sMessage = "신규 비밀번호";
            }
            if (sMessage != "")
            {
                MessageBox.Show(sMessage + "를 입력하지 않았습니다.");
                return;
            }

            // 비밀번호 변경을 위한 로직 시작

            // 데이터베이스 접속 경로 설정
            string sConnect = Commons.sConnectInfo;

            // 접속 경로 커넥터 객체에 전달
            Connect = new SqlConnection(sConnect);

            // 데이터베이스 연결 상태 확인
            Connect.Open();
            if (Connect.State != ConnectionState.Open)
            {
                MessageBox.Show("데이터베이스 접속에 실패하였습니다.");
                return;
            }

            string sLogInID = txtUserID.Text;    // 사용자 ID
            string sOldPassWord = txtOldPW.Text; // 이전 비밀번호
            string sNewPassWord = txtNewPW.Text; // 신규 비밀번호

            string sFindUserInfo = string.Empty;
            sFindUserInfo = "  SELECT PW                       ";
            sFindUserInfo += "   FROM TB_USER                  ";
            sFindUserInfo += $" WHERE USERID = '{sLogInID}'    ";
            sFindUserInfo += $"   AND PW     = '{sOldPassWord}'";

            SqlDataAdapter Adapter = new SqlDataAdapter(sFindUserInfo, Connect);
            DataTable dtTemp = new DataTable();
            Adapter.Fill(dtTemp);

            // ID 와 PW 동시에 일치 여부 확인
            if (dtTemp.Rows.Count == 0)
            {
                // ID 와 PW 가 일치하는 데이터가 없다.
                MessageBox.Show("ID 또는 비밀번호가 일치하지 않습니다.");
                txtUserID.Text = "";
                txtOldPW.Text  = "";
                txtNewPW.Text  = "";
                txtUserID.Focus();
                return;
            }

            // ID 와 비밀번호가 동일할 경우 비밀번호 변경 여부
            // 메세지 및 결과에 따른 진행여부 결정
            if (MessageBox.Show("해당 비밀번호를 변경하시겠습니까?", "비밀번호 변경", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // 트랜잭션 선언
            Tran = Connect.BeginTransaction("MyTran");

            // 데이터 베이스 트랜잭션 명령 전달 클래스 객체에 설정한 트랜잭션 등록
            Cmd.Transaction = Tran;   // 생성한 트랜잭션 등록
            Cmd.Connection = Connect; // 접속 정보 등록
            // 트랜잭션 SQL 구문 등록
            string sUpdateSql = " UPDATE TB_USER ";
            sUpdateSql       += $"   SET PW     = '{sNewPassWord}'";
            sUpdateSql       += $" WHERE USERID = '{sLogInID}'";
            Cmd.CommandText = sUpdateSql;

            // SQL 문 실행
            Cmd.ExecuteNonQuery();

            // 정상 완료 시 commit
            Tran.Commit();
            MessageBox.Show("비밀번호가 정상적으로 변경되었습니다.");
        }
    }
}
