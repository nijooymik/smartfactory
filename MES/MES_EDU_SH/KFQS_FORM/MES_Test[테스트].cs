using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DC00_assm;
using DC00_WinForm;
using DC00_PuMan;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

/***********************************************************************
 * From ID   : MES_Test
 * Form Name : 자재 발주 및 입고
 * date      : 2022-07-04
 * Maker     : 김유진
 * 
 * 수정사항  : 
 * *********************************************************************/

namespace KFQS_Form
{

    public partial class MES_Test : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil(); // 그리드 셋팅 클래스
        private string sPlantCode = LoginInfo.PlantCode; // 로그인한 공장 정보
        #endregion

        public MES_Test()
        {
            InitializeComponent();
        }

        private void MES_Test_Load(object sender, EventArgs e)
        {
            // Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // 자재 발주 부분
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "발주번호", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PODATE", "발주일자", true, GridColDataType_emu.YearMonthDay, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "POQTY", "발주수량", true, GridColDataType_emu.Double, 130, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처(협력)", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);

            // 원자재 입고 부분
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "입고", true, GridColDataType_emu.CheckBox, 130, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고수량", true, GridColDataType_emu.Double, 130, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT번호", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일자", true, GridColDataType_emu.YearMonthDay, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INWORKER", "입고자", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일시", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);

            // 콤보박스 셋팅.


            #region < 콤보박스 셋팅 설명 >
            // 공장

            // 공장에 대한 시스템 공통 코드 내역을 DB 에서 가져온다. => dtTemp 데이터 테이블에 담는다. 
            dtTemp = Common.StandardCODE("PLANTCODE");

            // 콤보박스 에 받아온 데이터를 밸류멤버와 디스플레이멤버로 표현한다.  
            Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp);

            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 셋팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            // 단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);

            // 품목 타입
            // FERT :  완제품,    ROH : 원자재,    HALB : 반제품,   OM : 외주가공품.
            dtTemp = Common.Get_ItemCode(new string[] { "ROH" });
            Common.FillComboboxMaster(cboItemCode_H, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "ITEMCODE", dtTemp);


            // 공장 로그인 정보로 자동 셋팅.
            cboPlantCode_H.Value = sPlantCode;

        }

        #region < ToolBar Area >
        public override void DoInquire()
        {
            // 툴바의 조회 버튼 클릭.
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_ = Convert.ToString(cboPlantCode_H.Value); // 공장
                string sItemCode = Convert.ToString(cboItemCode_H.Value); // 품목코드
                string sLOTNO = Convert.ToString(txtLOTNO_H.Text); // 발주 번호

                dtTemp = helper.FillTable("03MES_Test_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE", sPlantCode_)
                                          , helper.CreateParameter("@LOTNO", sLOTNO)
                                          , helper.CreateParameter("@ITEMCODE", sItemCode)
                                          );

                // 받아온 데이터 그리드 매핑
                if (dtTemp.Rows.Count == 0)
                {
                    // 그리드 초기화.
                    _GridUtil.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다.", DialogForm.DialogType.OK);
                    return;
                }

                grid1.DataSource = dtTemp;

                grid1.DataBinds(dtTemp);

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }



        public override void DoNew()
        {
            // 자재 발주 내역 등록 행 추가
            base.DoNew();

            // 그리드에 새로운 행을 하나 생성한다. 
            this.grid1.InsertRow();

            // 생성된 행에 디폴트 데이터를 입력한다. 
            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
            this.grid1.ActiveRow.Cells["PODATE"].Value = string.Format("{0:yyyy-MM-dd}",DateTime.Now);

            // 수정을 하지 못하도록 컬럼 제어
            // 신규 추가 시에는 생산 계획 편성 데이터만 등록할 수 있도록 함
            grid1.ActiveRow.Cells["LOTNO"].Activation = Activation.Disabled; // 자재 발주번호

            // 입고 관련 부분
            grid1.ActiveRow.Cells["CHK"].Activation = Activation.Disabled; // 입고등록 체크박스
            grid1.ActiveRow.Cells["LOTNO"].Activation = Activation.Disabled; // LOTNO
            grid1.ActiveRow.Cells["INDATE"].Activation = Activation.Disabled; // 입고일자
            grid1.ActiveRow.Cells["INWORKER"].Activation = Activation.Disabled; // 입고자
            grid1.ActiveRow.Cells["INQTY"].Activation = Activation.Disabled; // 입고수량

            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.Disabled;
            grid1.ActiveRow.Cells["MAKER"].Activation = Activation.Disabled;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.Disabled;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.Disabled;
        }


        public override void DoDelete()
        {
            if (Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value) != "")
            {
                ShowDialog("작업지시 확정 내역을 취소 후 진행하세요.");
                return;
            }

            base.DoDelete();
            this.grid1.DeleteRow();
        }


        public override void DoSave()
        {
            // 1. 그리드에 있는 갱신 이력이 있는 행들만 추출.
            DataTable dt = grid1.chkChange();
            if (dt == null) return;


            // 데이터베이스 오픈 및 트랜잭션 설정.
            DBHelper helper = new DBHelper("", true);

            try
            {
                // 해당 내역을 저장 하시겠습니까 ? 
                if (ShowDialog("해당 내역을 저장 하시겠습니까?") == DialogResult.Cancel)
                {
                    return;
                }

                // 갱신 이력이 담긴 데이터테이블 에서 한 행씩 뽑아와서 처리한다. 
                foreach (DataRow dr in dt.Rows)
                {
                    // 추출한 행의 상태가
                    switch (dr.RowState)
                    {
                        // 삭제된 상태 이면.
                        case DataRowState.Deleted:
                            dr.RejectChanges();

                            helper.ExecuteNoneQuery("03MES_Test_D", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", dr["PLANTCODE"])
                                                    , helper.CreateParameter("@PLANNO", dr["PLANNO"]));

                            break;
                        // 추가된 상태 이면.
                        case DataRowState.Added:
                            // 품목과 수량을 입력하였는지 확인
                            string sMessage = string.Empty;
                            if (Convert.ToString(dr["ITEMCODE"]) == "") sMessage += "품목";
                            if (Convert.ToString(dr["POQTY"]) == "") sMessage += "발주수량";
                            if (Convert.ToString(dr["CUSTCODE"]) == "") sMessage += "협력업체";
                            if (Convert.ToString(dr["PODATE"]) == "") sMessage += "발주일자";
                            if (sMessage != "") throw new Exception($"{sMessage}을(를) 입력하지 않았습니다.");

                            helper.ExecuteNoneQuery("03MES_Test_I", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("@ITEMCODE", Convert.ToString(dr["ITEMCODE"]))
                                                    , helper.CreateParameter("@PODATE", Convert.ToString(dr["PODATE"]))
                                                    , helper.CreateParameter("@POQTY", Convert.ToString(dr["POQTY"]).Replace(",",""))
                                                    , helper.CreateParameter("@UNITCODE", Convert.ToString(dr["UNITCODE"]))
                                                    , helper.CreateParameter("@CUSTCODE", Convert.ToString(dr["CUSTCODE"]))
                                                    , helper.CreateParameter("@MAKER", LoginInfo.UserID));
                            break;
                        // 수정된 상태이면
                        case DataRowState.Modified:

                            // 원자재 입고 등록
                            if (Convert.ToString(dr["CHK"]).ToString() == "1")
                            {
                                if (Convert.ToString(dr["INQTY"]) == "") throw new Exception("입고수량을 입력하지 않았습니다.");
                            }

                            helper.ExecuteNoneQuery("03MES_Test_U", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("@LOTNO", Convert.ToString(dr["LOTNO"]))
                                                    , helper.CreateParameter("@ITEMCODE", Convert.ToString(dr["ITEMCODE"]))
                                                    , helper.CreateParameter("@INQTY", Convert.ToString(dr["INQTY"]).Replace(",",""))                                                                                                                                                                                                                                                                                                                                                                                                                                            
                                                    , helper.CreateParameter("@EDITOR", LoginInfo.UserID)
                                                    );

                            break;
                    }
                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                // 데이터 베이스 등록 완료.
                helper.Commit();
                // 
                ShowDialog("정상적으로 등록 하였습니다.");
            }
            catch (Exception ex)
            {
                // 데이터 등록 복구
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                // 데이터 베이스 닫기
                helper.Close();
            }
        }
        #endregion

    }
}
