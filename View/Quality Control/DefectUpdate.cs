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

    public partial class DefectUpdate : Form, IBasicForm
    {
        private BasicForm _Mother;
        private Member _LoginInfo;
        private ProcessC _ProcessCtrl;
        List<Quality> InnerData, FairName;
        int RowCheck = 0;
        String ItemCheck;
        String[] UpdateValue = new string[5];
        String[] RegistSearchValue = new string[4];
        String dp_startTimeText, dp_endTimeText, cb_FarinameText;

        public DefectUpdate(Member member, BasicForm form)
        {
            InitializeComponent();

            _Mother = form;
            _LoginInfo = member;
            _ProcessCtrl = new ProcessC();
            ViewInit();
        }
        #region 검색 DGV
        private void GetInnerData()
        {
            InnerData = _ProcessCtrl.GetDefectUpdate();
        }
        public void SetDGV()
        {
            dgv_Update.Rows.Clear();
            GetInnerData();

            if (InnerData != null)
            {
                foreach (Quality quality in InnerData)
                {
                    dgv_Update.Rows.Add(quality.WorkProcessNo, quality.InnerOrder, quality.InnerProductName, quality.InstructionNo, quality.FairName,
                                        quality.InnerState, quality.MemberName, quality.Machine.MachineName, quality.InnerStartTime, quality.InnerEndTime,
                                        quality.InnerManager, quality.InnerCause, quality.InnerDeadline, quality.InnerActions, quality.InnerRemark);
                }
            }

        }
        private void DrawGridView()
        {
            dgv_Update.Rows.Clear();

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
                        dgv_Update.Rows.Add(quality.WorkProcessNo, quality.InnerOrder, quality.InnerProductName, quality.InstructionNo, quality.FairName,
                                    quality.InnerState, quality.MemberName, quality.Machine.MachineName, quality.InnerStartTime, quality.InnerEndTime,
                                    quality.InnerManager, quality.InnerCause, quality.InnerDeadline, quality.InnerActions, quality.InnerRemark);
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
        private void dgv_Update_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckZero();

            int RowCount = dgv_Update.RowCount;
            RowCount -= 1;
            if (e.RowIndex != -1)
            {
                if (e.RowIndex <= RowCount)
                {
                    TextboxClear();

                    lbl_Numbercheck.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[0].Value;
                    lbl_Order.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[1].Value;
                    lbl_Product.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[2].Value;
                    lbl_InstructionNo.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[3].Value;
                    lbl_fiarName.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[4].Value;
                    lbl_State.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[5].Value;
                    lbl_Member.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[6].Value;
                    lbl_Machine.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[7].Value;
                    lbl_workProcessStartTime.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[8].Value;
                    lbl_workProcessEndTime.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[9].Value;
                    tb_Manager.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[10].Value;
                    tb_Cause.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[11].Value;
                    dp_Deadline.Text = Convert.ToDateTime(dgv_Update.Rows[e.RowIndex].Cells[12].Value).ToString("yyyy-MM-dd");
                    tb_Actions.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[13].Value;
                    tb_Remark.Text = (string)dgv_Update.Rows[e.RowIndex].Cells[14].Value;
                }
                else
                {
                    ZeroClear();
                }
            }
            else
            {
                ZeroClear();
            }
        }
        #endregion
        private void GetFairName()
        {
            cb_Fariname.Items.Clear();
            FairName = _ProcessCtrl.GetFairName();
            for (int i = 0; i < FairName.Count(); i++)
            {
                cb_Fariname.Items.Add(FairName[i].FairName);
            }
        }
        private void ZeroClear()
        {
            CheckZero();
            TextboxClear();
        }
        #region IBasicForm
        private void ViewInit()
        {
            GetInnerData();
            SetDGV();
            ZeroClear();
            GetFairName();
        }
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
        private void TextboxClear()
        {
            tb_Cause.Text = lbl_fiarName.Text = lbl_InstructionNo.Text = lbl_Machine.Text = lbl_Member.Text = lbl_Order.Text = tb_Actions.Text =
            tb_Manager.Text = tb_Remark.Text = lbl_workProcessStartTime.Text = lbl_workProcessEndTime.Text = lbl_Product.Text = lbl_State.Text = "";
            dp_Deadline.Text = dp_startTime.Text = dp_endTime.Text = DateTime.Now.ToString();
        }
        private void CheckZero()
        {
            btn_good.BackColor = SystemColors.ControlLight;
            btn_Discard.BackColor = SystemColors.ControlLight;
            ItemCheck = "초기화";
        }
        private void Alarm(String str)
        {
            Alarm Alarm = new Alarm(str);
            Alarm.ShowDialog();
        }
        private void SearchData()
        {
            dp_startTimeText = dp_startTime.Text;
            dp_endTimeText = dp_endTime.Text;

            cb_FarinameText = (string)cb_Fariname.Text;

            if (cb_FarinameText.Equals(""))
            {
                cb_FarinameText = null;
            }
            RegistSearchValue[0] = dp_startTimeText;
            RegistSearchValue[1] = dp_endTimeText;
            RegistSearchValue[2] = cb_FarinameText;
            InnerData = _ProcessCtrl.SearchData(RegistSearchValue);
        }
        #region 검색 Button
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ViewInit();
        }
        private void btn_good_Click(object sender, EventArgs e)
        {
            btn_good.BackColor = Color.Lime;
            btn_Discard.BackColor = SystemColors.ControlLight;
            ItemCheck = "양호";
        }
        private void btn_Discard_Click(object sender, EventArgs e)
        {
            btn_Discard.BackColor = Color.Red;
            btn_good.BackColor = SystemColors.ControlLight;
            ItemCheck = "폐기";
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchData();
            DrawGridView();
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (ItemCheck.Equals("초기화"))
            {
                Alarm("상태 선택을 완료해 주세요.");
            }
            else if (ItemCheck.Equals("양호"))
            {
                //등록버튼
                //quality에 양호

                UpdateValue[0] = tb_Cause.Text;
                UpdateValue[1] = tb_Actions.Text;
                UpdateValue[2] = tb_Manager.Text;
                UpdateValue[3] = dp_Deadline.Value.ToString("yyyy-MM-dd");
                UpdateValue[4] = tb_Remark.Text;

                _ProcessCtrl.DefectUpdate(InnerData[RowCheck], lbl_Numbercheck.Text, UpdateValue, ItemCheck);
                Alarm("등록이 완료되었습니다.");
                ViewInit();
            }
            else if (ItemCheck.Equals("폐기"))
            {
                // 폐기띠
                UpdateValue[0] = tb_Cause.Text;
                UpdateValue[1] = tb_Actions.Text;
                UpdateValue[2] = tb_Manager.Text;
                UpdateValue[3] = dp_Deadline.Value.ToString("yyyy-MM-dd");
                UpdateValue[4] = tb_Remark.Text;

                _ProcessCtrl.DefectUpdate(InnerData[RowCheck], lbl_Numbercheck.Text, UpdateValue, ItemCheck);
                Alarm("등록이 완료되었습니다.");
                ViewInit();
            }
        }
        #endregion
    }
}