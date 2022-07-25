﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DC00_assm;
using DC00_WinForm;
using DC00_PuMan;

/***********************************************************************
 * From ID   : BM_StopListMaster
 * Form Name : 비가동 항목 마스터
 * date      : 2022-06-30
 * Maker     : 김유진
 * 
 * 수정사항  : 
 * *********************************************************************/

namespace KFQS_Form
{
    public partial class BM_StopListMaster : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil(); // 그리드 셋팅 클래스
        private string sPlantCode = LoginInfo.PlantCode; // 로그인한 공장 정보
        #endregion

        public BM_StopListMaster()
        {
            InitializeComponent();
        }

        private void BM_StopListMaster_Load(object sender, EventArgs e)
        {
            // Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE", "비가동 코드", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPNAME", "비가동 명", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);

            // 콤보박스 셋팅.


            #region < 콤보박스 셋팅 설명 >
            // 공장

            // 공장에 대한 시스템 공통 코드 내역을 DB 에서 가져온다. => dtTemp 데이터 테이블에 담는다. 
            dtTemp = Common.StandardCODE("PLANTCODE");

            // 콤보박스 에 받아온 데이터를 밸류멤버와 디스플레이멤버로 표현한다.  
            Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 셋팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");

            #endregion


            // 사용여부
            dtTemp = Common.StandardCODE("USEFLAG");
            Common.FillComboboxMaster(this.cboUseFlag_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", dtTemp, "CODE_ID", "CODE_NAME");

            // 공장 로그인 정보로 자동 셋팅
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
                string sStopCode = Convert.ToString(txtStopCode_H.Text);     // 비가동 코드
                string sStopName = Convert.ToString(txtStopName_H.Text);     // 비가동 명
                string sUseFlag = Convert.ToString(cboUseFlag_H.Value);      // 사용여부


                dtTemp = helper.FillTable("03BM_StopListMaster_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE", sPlantCode_)
                                          , helper.CreateParameter("STOPCODE", sStopCode)
                                          , helper.CreateParameter("STOPNAME", sStopName)
                                          , helper.CreateParameter("USEFLAG", sUseFlag)
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
            base.DoNew();

            // 그리드에 새로운 행을 하나 생성한다. 
            this.grid1.InsertRow();

            // 생성된 행에 디폴트 데이터를 입력한다. 
            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
            this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
        }


        public override void DoDelete()
        {
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
                        // 삭제 된 상태 이면.
                        case DataRowState.Deleted:
                            dr.RejectChanges();


                            helper.ExecuteNoneQuery("03BM_StopListMaster_D", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("STOPCODE", Convert.ToString(dr["STOPCODE"])));


                            break;
                        // 추가 된 상태 이면.
                        case DataRowState.Added:

                            if (Convert.ToString(dr["STOPCODE"]) == "")
                            {
                                throw new Exception("비가동 코드를 입력하지 않았습니다.");
                            }

                            helper.ExecuteNoneQuery("03BM_StopListMaster_I", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("STOPCODE", Convert.ToString(dr["STOPCODE"]))
                                                    , helper.CreateParameter("STOPNAME", Convert.ToString(dr["STOPNAME"]))
                                                    , helper.CreateParameter("REMARK", Convert.ToString(dr["REMARK"]))
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(dr["USEFLAG"]))
                                                    , helper.CreateParameter("MAKER", LoginInfo.UserID));
                            break;
                        // 수정 된 상태이면
                        case DataRowState.Modified:
                            helper.ExecuteNoneQuery("03BM_StopListMaster_U", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("STOPCODE", Convert.ToString(dr["STOPCODE"]))
                                                    , helper.CreateParameter("STOPNAME", Convert.ToString(dr["STOPNAME"]))
                                                    , helper.CreateParameter("REMARK", Convert.ToString(dr["REMARK"]))
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(dr["USEFLAG"]))
                                                    , helper.CreateParameter("EDITOR", LoginInfo.UserID));
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
