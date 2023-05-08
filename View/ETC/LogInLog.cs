using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class LogInLog : Form, IBasicForm
    {
        List<DataVal> myset;
        private Member _LoginInfo;
        private BasicForm _Mother;
        private NoticeCtrl _NoticeCtrl;
        TimeSpan Result, Str;
        DateTime StartTime, EndTime;

        public LogInLog(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _NoticeCtrl = new NoticeCtrl();

            InitializeComponent();
            GetComboBox();
            dgv_Log.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void GetComboBox()
        {
            cb_User.Items.Clear();
            cb_User.Items.Add("전체 조회");

            ProcessC _ProcessCtrl = new ProcessC();
            List<String[]> list = new List<string[]>();
            list = _ProcessCtrl.GetComboMember();

            foreach (string[] str in list)
            {
                cb_User.Items.Add(str[0]);
                cb_User.SelectedIndex = 0;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Str = TimeSpan.Zero;
            Log();
        }
        public void Log()
        {
            string Start = dp_StartTime.Text;
            string End = dp_EndTime.Text;
            string User = cb_User.Text;
            dgv_Log.Rows.Clear();
            myset = _NoticeCtrl.SelectParameter(Start, End, User);
            //int str1, str2, str3, str4, str5, str5_, str6, str6_ = 0;
            string Set = "";
            foreach (DataVal myset_ in myset)
            {
                if (myset_.InOut == "LogIn")
                {
                    StartTime = Convert.ToDateTime(myset_.LogTime);
                    /*                    str1 = Convert.ToInt32(myset_.LogTime.Substring(11, 2));
                                        str2 = Convert.ToInt32(myset_.LogTime.Substring(14, 2));*/
                    Set = "";
                }
                else if (myset_.InOut == "LogOut")
                {
                    EndTime = Convert.ToDateTime(myset_.LogTime);
                    /*str3 = Convert.ToInt32(myset_.LogTime.Substring(11, 2));
                    str4 = Convert.ToInt32(myset_.LogTime.Substring(14, 2));*/
                    Result = EndTime - StartTime;
                    Str = Str + Result;
                    /*str5 = str3 - str1;
                    str6 = str4 - str2; if (str6 < 0) str6 += 60;
*/
                    //set = (str5 + "시간" + str6 + "분").ToString();
                    Set = Result.ToString();
                    /*str5_ += str5;
                    str6_ += str6;*/
                }
                lbl_Result.Text = "총 접속시간" + "  :  " + Str.ToString();
                //label4.Text = str5_.ToString() + "시간 " + str6_.ToString() + "분";
                //label5.Text = str6_.ToString() + "분";
                dgv_Log.Rows.Add(myset_.No, myset_.User, myset_.LogTime, myset_.InOut, myset_.IP, Set);
            }
        }
        #region IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            GetComboBox();
            Str = TimeSpan.Zero;
            dgv_Log.Rows.Clear();
            lbl_Result.Text = null;
            dp_StartTime.Value = dp_EndTime.Value = DateTime.Now;
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
    }
}