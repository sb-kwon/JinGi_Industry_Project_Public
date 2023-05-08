using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace View
{
    public partial class DefectRegistration : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private List<Quality> _QT;
        private ProcessC _ProcessCtrl;
        List<Quality> InnerData, FairName;
        int RowCheck = 0;
        String[] RegistValue = new string[7];
        String[] RegistSearchValue = new string[4];
        String dp_startTimeText, dp_endTimeText, cb_FarinameText;
        public DefectRegistration(Member member, BasicForm form)
        {
            InitializeComponent();

            _ProcessCtrl = new ProcessC();
            _LoginInfo = member;
            _Mother = form;
            ViewInit();
            GetInnerData();
        }
        public List<Quality> Qualities
        {
            get { return _QT; }
            set { _QT = value; }
        }
        private void GetDefect()
        {
            _ProcessCtrl.GetDefect();
            Qualities = _ProcessCtrl.Qualities;
        }
        #region 검색 DGV
        public void SetDGV()
        {
            dgv_Registration.Rows.Clear();
            GetDefect();

            if (Qualities != null)
            {
                foreach (Quality quality in Qualities)
                {
                    dgv_Registration.Rows.Add(quality.InnerOrder, quality.InnerProductName, quality.InstructionNo, quality.FairName, quality.MemberName,
                                              quality.Machine.MachineName, quality.InnerStartTime, quality.InnerEndTime, quality.WorkProcessNo, quality.InnerCause);
                }
            }

        }
        private void DrawGridView()
        {
            dgv_Registration.Rows.Clear();

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
                        dgv_Registration.Rows.Add(quality.InnerOrder, quality.InnerProductName, quality.InstructionNo, quality.FairName, quality.MemberName,
                                                  quality.Machine.MachineName, quality.InnerStartTime, quality.InnerEndTime, quality.WorkProcessNo);
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
        private void dgv_Registration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowCount = dgv_Registration.RowCount;
            RowCount -= 1;
            if (e.RowIndex != -1)
            {
                if (e.RowIndex <= RowCount)
                {
                    TextboxClear();
                    lbl_Order.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[0].Value;
                    lbl_Product.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[1].Value;
                    lbl_InstructionNo.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[2].Value;
                    lbl_fiarName.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[3].Value;
                    lbl_Member.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[4].Value;
                    lbl_Machine.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[5].Value;
                    lbl_workProcessStartTime.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[6].Value;
                    lbl_workProcessEndTime.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[7].Value;
                    lbl_Numbercheck.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[8].Value;
                    tb_Cause.Text = (string)dgv_Registration.Rows[e.RowIndex].Cells[9].Value;

                    RowCheck = e.RowIndex;
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
        private void GetInnerData()
        {
            dp_startTimeText = dp_startTime.Text;
            dp_endTimeText = dp_endTime.Text;

            cb_FarinameText = (string)cb_Fariname.Text;

            if (cb_FarinameText.Equals("") || cb_FarinameText.Equals("전체"))
            {
                cb_FarinameText = null;
            }
            RegistSearchValue[0] = dp_startTimeText;
            RegistSearchValue[1] = dp_endTimeText;
            RegistSearchValue[2] = cb_FarinameText;
            InnerData = _ProcessCtrl.GetdefectRegistration(RegistSearchValue);
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
            GetFairName();
            SetDGV();
            //불량발생 항목 테이블 
        }
        #region IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            ViewInit();
            TextboxClear();
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
        #region 검색 Button
        private void btn_Registration_Click(object sender, EventArgs e)
        {
            //등록버튼
            RegistValue[0] = tb_Manager.Text;
            RegistValue[1] = tb_Cause.Text;
            RegistValue[2] = dp_Deadline.Value.ToString("yyyy-MM-dd");
            RegistValue[3] = tb_Actions.Text;
            RegistValue[4] = tb_Remark.Text;
            if (lbl_InstructionNo.Text.Equals(""))
            {
                Alarm("데이터를 입력해 주십시오.");
            }
            else
            {
                _ProcessCtrl.UpdateDefectRegistration(lbl_Numbercheck.Text, RegistValue);
                Alarm("불량 항목 등록이 완료 되었습니다.");
                ViewInit();
                TextboxClear();
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //취소버튼 
            TextboxClear();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetInnerData();
            DrawGridView();
        }
        #endregion
        private void TextboxClear()
        {
            tb_Cause.Text = lbl_fiarName.Text = lbl_InstructionNo.Text = lbl_Machine.Text = lbl_Member.Text = lbl_Order.Text = tb_Actions.Text =
            tb_Manager.Text = tb_Remark.Text = lbl_workProcessStartTime.Text = lbl_workProcessEndTime.Text = lbl_Product.Text = "";
            dp_Deadline.Text = DateTime.Now.ToString();
        }
        private void Alarm(String str)
        {
            Alarm Alarm = new Alarm(str);
            Alarm.ShowDialog();
        }
    }
}