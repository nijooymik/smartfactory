using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 데이터베이스 접속 라이브러리
using System.Data.SqlClient;

namespace MainForms
{
    /**********************************************************
     * NAME : M03_PassWordChange
     * DESC : 사용자 비밀번호 변경
     * --------------------------------------------------------
     * DATE        : 2022-06-21
     * AUTHOR      : 김유진
     * DESCRIPTION : 최초 프로그램 작성
     * ********************************************************/

    public partial class M03_PassWordChange : Form
    {
        // 1. 공통 클래스 (SELECT 와 Insert, Update, Delete 명령 전달 시 공통으로 사용)
        private SqlConnection Connect; // 데이터베이스 접속 정보 관리 클래스

        // 2. SELECT (조회) 를 실행 후 데이터를 받아오는 클래스
        private SqlDataAdapter Adapter;

        // 3. Insert, Delete, Update 를 실행할 명령 전달 클래스
        private SqlTransaction Transaction; // 데이터 관리 권한 부여 클래스
        private SqlCommand cmd;             // SQL 명령 전달 클래스

        public M03_PassWordChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoChangePassWord();
        }
        private void DoChangePassWord()
        {
            /**************************************************
             *               비밀번호 변경 클릭
             **************************************************/

            try
            {
                // 텍스트박스에 필수 입력값 등록 여부 확인
                string sMessage = string.Empty; // 메세지 변수
                if (txtUserID.Text == "")     sMessage = "사용자 ID";
                else if (txtOldPW.Text == "") sMessage = "이전 비밀번호";
                else if (txtNewPW.Text == "") sMessage = "변경 비밀번호";

                if (sMessage != "")
                {
                    MessageBox.Show(sMessage + "를 입력하지 않았습니다.");
                    return;
                }

                /*** 밸리데이션 체크 후 데이터 베이스 접속 ***/
                // 1. 데이터 베이스 접속 경로 설정
                string strConn = "Server = localhost ; Uid = sa ; Pwd = 1234 ; database = AppDev ;";

                // 2. 접속 경로 커넥터 객체에 전달
                Connect = new SqlConnection(strConn);

                // 3. 데이터베이스 연결 상태 확인
                Connect.Open(); // 데이터베이스 접속 시도
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("데이터베이스 연결에 실패하였습니다.");
                    return;
                }

                // 입력 내용 변수에 저장
                string sLogInID = txtUserID.Text; // 사용자 ID
                string sPerPassWord = txtOldPW.Text; // 현재 비밀번호
                string sNewPassWord = txtNewPW.Text; // 변경할 비밀번호

                #region < 기존 비밀번호와 비교하여 변경 가능한 상태인지 체크 >
                // 1. 기존 비밀번호 찾기 SQL 구문 작성
                string sFindUserInfo;
                sFindUserInfo  = " SELECT PW                   ";
                sFindUserInfo += "   FROM TB_USER              ";
                sFindUserInfo += $"  WHERE USERID = '{sLogInID}'";

                // 2. Adapter(SELECT 구문을 실행하고 결과를 받아오는 클래스)에 SQL 구문과 접속정보 등록
                Adapter = new SqlDataAdapter(sFindUserInfo, Connect);

                // 3. DataBase 로부터 결과 값을 받을 빈 DataTable 객체 생성
                DataTable dtTemp = new DataTable(); 

                // 4. Adapter 실행 및 결과 값 Datatable 에 등록
                Adapter.Fill(dtTemp);

                // 5. ID 존재 여부 확인
                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("로그인 ID가 잘못되었습니다.");
                    return;
                }

                // 6. 현재 비밀번호 비교
                else if (sPerPassWord != Convert.ToString(dtTemp.Rows[0]["PW"]))
                {
                    MessageBox.Show("현재 비밀번호를 잘못 입력하였습니다.");
                    return;
                }

                if (MessageBox.Show("해당 비밀번호로 변경을 진행하시겠습니까?", "비밀번호 변경", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                #endregion

                #region < 데이터베이스 명령 전달 클래스 객체에 설정한 SQL 문 등록 및 실행 > 
                // 1. 트랜잭션 선언 (데이터 관리 권한 부여)
                Transaction = Connect.BeginTransaction("MyTran");

                // 2. Insert, Update, Delete 명령을 전달할 SqlCommand 클래스 객체 생성
                cmd = new SqlCommand();

                // 3. 생성한 Command 에 트랜잭션 설정 정보 등록
                cmd.Transaction = Transaction;

                // 4. 접속 정보 등록
                cmd.Connection = Connect;

                // 5. 실행할 SQL 구문 등록
                string sUpdateSql;
                sUpdateSql  = " UPDATE TB_USER "                 ;
                sUpdateSql += $"   SET PW     = '{sNewPassWord}'";
                sUpdateSql += $" WHERE USERID = '{sLogInID}'"    ;

                // 6. 커맨드에 실행할 SQL 구문 등록
                cmd.CommandText = sUpdateSql;

                // 7. 커맨드 실행
                cmd.ExecuteNonQuery();

                // 8. 정상 완료 시 COMMIT
                Transaction.Commit();

                MessageBox.Show("비밀번호를 정상적으로 등록하였습니다.");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("비밀번호 등록 중 오류가 발생하였습니다. \r\n" + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            // 변경될 비밀번호 입력 후 엔터 입력 시 변경 버튼 클릭
            if (e.KeyCode == Keys.Enter)
            {
                DoChangePassWord();
            }
        }
    }
}
