using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class DefectSituation : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessCtrl;

        String[] SituationSearchValue = new string[6];
        List<Quality> FairName, DefectCount, InnerData;
        String dp_startTimeText, dp_endTimeText, cb_FarinameText;
        public DefectSituation(Member member, BasicForm form)
        {
            InitializeComponent();

            _ProcessCtrl = new ProcessC();
            _LoginInfo = member;
            _Mother = form;
            ViewInit();
            GetFairName();
        }
        #region IBasicForm
        public string GetText()
        {
            return this.Text;
        }

        public void RefreshForm()
        {
            ViewInit();
        }
        public Form SetForm()
        {
            return this;
        }

        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        #endregion
        #region 검색 DGV
        private void GetInnerData()
        {
            InnerData = _ProcessCtrl.GetDefectSituation();
            DefectCount = _ProcessCtrl.GetDefectCount();
        }
        private void SetDGV()
        {
            dgv_Situation.Rows.Clear();

            GetInnerData();
            if (InnerData != null)
            {
                foreach (Quality quality in InnerData)
                {
                    dgv_Situation.Rows.Add(quality.WorkProcessNo, quality.InnerOrder, quality.InnerProductName, quality.InstructionNo, quality.FairName,
                                        quality.InnerState, quality.MemberName, quality.Machine.MachineName, quality.InnerStartTime, quality.InnerEndTime,
                                        quality.InnerManager, quality.InnerCause, quality.InnerDeadline, quality.InnerActions, quality.InnerRemark);
                }
                foreach (Quality quality in DefectCount)
                {
                    lbl_Clear.Text = quality.ClearCount + "개";
                    lbl_Defect.Text = quality.DefectCount + "개";
                }
            }

        }
        private void DrawGridView()
        {
            dgv_Situation.Rows.Clear();

            if (InnerData is null)
            {
                Alarm("검색어를 입력해주세요.");
            }
            else
            {
                if (InnerData.Count != 0)
                {
                    foreach (Quality quality in InnerData)
                    {
                        dgv_Situation.Rows.Add(quality.WorkProcessNo, quality.InnerOrder, quality.InnerProductName, quality.InstructionNo, quality.FairName,
                                    quality.InnerState, quality.MemberName, quality.Machine.MachineName, quality.InnerStartTime, quality.InnerEndTime,
                                    quality.InnerManager, quality.InnerCause, quality.InnerDeadline, quality.InnerActions, quality.InnerRemark);
                    }
                    foreach (Quality quality in DefectCount)
                    {
                        lbl_Clear.Text = quality.ClearCount + " " + "개";
                        lbl_Defect.Text = quality.DefectCount + " " + "개";
                    }
                }
                else
                {
                    Alarm("검색 된 내용이 없습니다.");
                    SetDGV();
                    cb_Fariname.Text = string.Empty;
                    dp_endTime.Text = string.Empty;
                    dp_startTime.Text = string.Empty;
                }
            }
        }
        private void dgv_Situation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowCount = dgv_Situation.RowCount;
            RowCount -= 1;
            if (e.RowIndex != -1)
            {
                if (e.RowIndex <= RowCount)
                {
                    TextboxClear();

                    lbl_InstructionNo.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[3].Value;
                    lbl_Order.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[1].Value;
                    lbl_Product.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[2].Value;
                    lbl_fiarName.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[4].Value;
                    if (dgv_Situation.Rows[e.RowIndex].Cells[5].Value.Equals("양호"))
                    {
                        btn_good.BackColor = Color.Lime;
                        btn_Discard.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        btn_good.BackColor = SystemColors.Control;
                        btn_Discard.BackColor = Color.Red;
                    }
                    lbl_Member.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[6].Value;
                    lbl_Machine.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[7].Value;
                    lbl_workProcessStartTime.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[8].Value;
                    lbl_workProcessEndTime.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[9].Value;
                    lbl_Manager.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[10].Value;
                    lbl_Cause.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[11].Value;
                    lbl_Deadline.Text = Convert.ToDateTime(dgv_Situation.Rows[e.RowIndex].Cells[12].Value).ToString("yyyy-MM-dd");
                    lbl_Actions.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[13].Value;
                    lbl_Remark.Text = (string)dgv_Situation.Rows[e.RowIndex].Cells[14].Value;
                }
                else
                {
                    TextboxClear();
                }
            }
            else
            {
                TextboxClear();
            }
        }
        #endregion
        private void SearchData()
        {
            dp_startTimeText = dp_startTime.Text;
            dp_endTimeText = dp_endTime.Text;
            cb_FarinameText = (string)cb_Fariname.Text;

            if (cb_FarinameText.Equals(""))
            {
                cb_FarinameText = null;
            }

            SituationSearchValue[0] = dp_startTimeText;
            SituationSearchValue[1] = dp_endTimeText;
            SituationSearchValue[2] = cb_FarinameText;

            InnerData = _ProcessCtrl.SearchSituationData(SituationSearchValue);
            DefectCount = _ProcessCtrl.GetDefectSearchCount(SituationSearchValue);
        }
        private void GetFairName()
        {
            cb_Fariname.Items.Clear();
            FairName = _ProcessCtrl.GetFairName();
            for (int i = 0; i < FairName.Count(); i++)
            {
                cb_Fariname.Items.Add(FairName[i].FairName);
            }
        }
        private void ViewInit()
        {
            SetDGV();
            GetFairName();
            GetInnerData();
            TextboxClear();
        }
        private void Alarm(String str)
        {
            Alarm Alarm = new Alarm(str);
            Alarm.ShowDialog();
        }
        private void TextboxClear()
        {
            dp_startTime.Text = dp_endTime.Text = DateTime.Now.ToString();
            lbl_InstructionNo.Text = lbl_fiarName.Text = lbl_Member.Text = lbl_Order.Text = lbl_workProcessStartTime.Text = lbl_workProcessEndTime.Text =
            lbl_Machine.Text = lbl_Product.Text = lbl_Cause.Text = lbl_Actions.Text = lbl_Manager.Text = lbl_Deadline.Text = lbl_Remark.Text = cb_Fariname.Text = "";
            btn_good.BackColor = btn_Discard.BackColor = SystemColors.Control;
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchData();
            DrawGridView();
        }
    }
}
