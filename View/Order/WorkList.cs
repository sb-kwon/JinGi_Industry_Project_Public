using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public partial class WorkList : Form, IBasicForm
    {
        private int Index;
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;
        public WorkList(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;

            _ProcessC = new ProcessC();
            InitializeComponent();

            SetView();
            SetComboBox();
        }
        private String SetProcessState(string state)
        {
            string str = "";

            if (state == "0") str = "작업 전";
            if (state == "1") str = "작업 중";
            if (state == "2") str = "폐기";
            if (state == "3") str = "일시중지";
            if (state == "4") str = "중지";
            if (state == "5") str = "작업완료";

            return str;
        }
        private void SetComboBox()
        {
            comboBox7.Items.Clear();
            comboBox7.Items.Add("모두");

            //맵핑명
            List<String> list4 = _ProcessC.GetDefFairName();

            if (list4 != null)
            {
                foreach (string array in list4)
                    comboBox7.Items.Add(array);

                comboBox7.SelectedIndex = 0;
            }
            flatComboBox1.SelectedIndex = 0;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = null;
            dtp_date.Value = dtp_date_End.Value = DateTime.Now;
        }
        public void SetView()
        {
            dgv_work.Rows.Clear();

            List<string[]> list = _ProcessC.GetWorkProcess();
            if (list != null)
                foreach (string[] str in list)
                    dgv_work.Rows.Add(
                        str[0],
                        str[1],
                        str[2] + " 등 " + str[15] + "개",
                        str[3],
                        str[4],
                        SetProcessState(str[5]),
                        str[6].Substring(0,10),
                        str[7].Substring(0,10),
                        str[8],
                        str[9],
                        str[10],
                        str[11],
                        str[12],
                        str[13],
                        str[14]
                        );
        }
        public void Working()
        {
            dgv_work.Rows.Clear();

            List<string[]> list = _ProcessC.GetWorkProcess();
            if (list != null)
                foreach (string[] str in list)
                    if (comboBox7.SelectedItem.Equals(str[3]) || comboBox7.SelectedItem.Equals("모두"))
                    dgv_work.Rows.Add(
                        str[0],
                        str[1],
                        str[2] + " 등 " + str[15] + "개",
                        str[3],
                        str[4],
                        SetProcessState(str[5]),
                        str[6].Substring(0, 10),
                        str[7].Substring(0, 10),
                        str[8],
                        str[9],
                        str[10],
                        str[11],
                        str[12],
                        str[13],
                        str[14]
                        );
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            WorkList_Start popup = new WorkList_Start(_LoginInfo, _ProcessC);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            popup.ShowDialog();

            Working();
            if (dgv_work.Rows.Count <= Index) Index = Index - 1;
            dgv_work.FirstDisplayedCell = dgv_work.Rows[Index].Cells[0];
            dgv_work.Rows[Index].Cells[0].Selected = true;
        }
        private void btn_end_Click(object sender, EventArgs e)
        {
            WorkList_End popup = new WorkList_End(_ProcessC);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            popup.ShowDialog();

            Working();
            if (dgv_work.Rows.Count <= Index) Index = Index - 1;
            dgv_work.FirstDisplayedCell = dgv_work.Rows[Index].Cells[0];
            dgv_work.Rows[Index].Cells[0].Selected = true;
        }
        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            SetView();
            SetComboBox();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        #endregion
        private void button3_Click(object sender, EventArgs e)
        {
            dgv_work.Rows.Clear();

            List<string[]> list = _ProcessC.GetWorkProcess();
            if (flatComboBox1.Text.Equals("수주 시작일 기준 날짜"))
            {
                if (list != null)
                    foreach (string[] str in list)
                        if ((comboBox7.SelectedItem.Equals("모두") || comboBox7.SelectedItem.Equals(str[3]))
                        && str[0].ToLower().IndexOf(textBox1.Text.ToLower()) != -1
                         && str[1].ToLower().IndexOf(textBox2.Text.ToLower()) != -1
                         && str[2].ToLower().IndexOf(textBox3.Text.ToLower()) != -1
                         && str[8].ToLower().IndexOf(textBox4.Text.ToLower()) != -1
                         && (!dtp_date.Enabled || dtp_date.Value.Date <= Convert.ToDateTime(str[6]).Date && Convert.ToDateTime(str[6]) <= dtp_date_End.Value.Date)
                         && Convert.ToDateTime(str[7]).Date >= dtp_date.Value.Date
                         )
                            dgv_work.Rows.Add(str[0], str[1], str[2] + " 등 " + str[15] + "개", str[3], str[4], SetProcessState(str[5]), str[6].Substring(0, 10), str[7].Substring(0, 10),
                            str[8], str[9], str[10], str[11], str[12], str[13], str[14]);
            }
            else if (flatComboBox1.Text.Equals("작업 시작 시간 기준"))
            {
                if (list != null)
                    foreach (string[] str in list)
                        if ((comboBox7.SelectedItem.Equals("모두") || comboBox7.SelectedItem.Equals(str[3]))
                        && str[0].ToLower().IndexOf(textBox1.Text.ToLower()) != -1
                         && str[1].ToLower().IndexOf(textBox2.Text.ToLower()) != -1
                         && str[2].ToLower().IndexOf(textBox3.Text.ToLower()) != -1
                         && str[8].ToLower().IndexOf(textBox4.Text.ToLower()) != -1
                         && (!dtp_date.Enabled || dtp_date.Value.Date <= Convert.ToDateTime(str[10]).Date && Convert.ToDateTime(str[10]) <= dtp_date_End.Value.Date)
                         && Convert.ToDateTime(str[7]).Date >= dtp_date.Value.Date
                         )
                            dgv_work.Rows.Add(str[0], str[1], str[2] + " 등 " + str[15] + "개", str[3], str[4], SetProcessState(str[5]), str[6].Substring(0, 10), str[7].Substring(0, 10),
                            str[8], str[9], str[10], str[11], str[12], str[13], str[14]);
            }
            else
            {
                if (list != null)
                    foreach (string[] str in list)
                        if ((comboBox7.SelectedItem.Equals("모두") || comboBox7.SelectedItem.Equals(str[3]))
                        && str[0].ToLower().IndexOf(textBox1.Text.ToLower()) != -1
                         && str[1].ToLower().IndexOf(textBox2.Text.ToLower()) != -1
                         && str[2].ToLower().IndexOf(textBox3.Text.ToLower()) != -1
                         && str[8].ToLower().IndexOf(textBox4.Text.ToLower()) != -1
                         )
                            dgv_work.Rows.Add(str[0], str[1], str[2] + " 등 " + str[15] + "개", str[3], str[4], SetProcessState(str[5]), str[6].Substring(0, 10), str[7].Substring(0, 10),
                            str[8], str[9], str[10], str[11], str[12], str[13], str[14]);
            }
        }
        private void btn_all_Click(object sender, EventArgs e)
        {
            SetView();
            SetComboBox();
        }
        private void datagridview1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvr = dgv.Rows[e.RowIndex];
                int wpNo = Convert.ToInt32(dgvr.Cells[14].Value);

                WorkProcessDetailView popup = new WorkProcessDetailView(wpNo, _ProcessC);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                popup.ShowDialog();
            }
        }
        private void flatComboBox1_TextChanged(object sender, EventArgs e)
        {
            dtp_date.Enabled = dtp_date_End.Enabled = ((flatComboBox1.Text.Equals("수주 시작일 기준 날짜")) || flatComboBox1.Text.Equals("작업 시작 시간 기준"));
        }
        private void datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvr = dgv.SelectedRows[0];

                if (!(dgvr.Cells[0].Value is null))
                {
                    Index = dgvr.Index;
                    _ProcessC.WorkProcess.WorkInstructionNo = Convert.ToInt64(dgvr.Cells[1].Value);
                    _ProcessC.WorkProcess.FairName = dgvr.Cells[3].Value.ToString();
                }
            }
        }
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveAsFile = new SaveFileDialog();

            SaveAsFile.InitialDirectory = @"바탕 화면";
            SaveAsFile.Title = "다른 이름으로 저장";
            SaveAsFile.Filter = "엑셀파일(*xlsx)|*xlsx|엑셀파일(*xls)|*xls|모든파일|*.*";
            SaveAsFile.DefaultExt = "xlsx";
            SaveAsFile.AddExtension = true;

            if (SaveAsFile.ShowDialog() == DialogResult.OK)
            {
                ExcelProduct ea = new ExcelProduct(SaveAsFile.FileName);

                List<string[]> list = new List<string[]>();

                foreach (DataGridViewRow dgvr in dgv_work.Rows)
                {
                    string[] strArr = new string[6];
                    strArr[0] = dgvr.Cells[1].Value.ToString();
                    strArr[1] = dgvr.Cells[2].Value.ToString();
                    strArr[2] = dgvr.Cells[3].Value.ToString();
                    strArr[3] = dgvr.Cells[4].Value.ToString();
                    strArr[4] = dgvr.Cells[5].Value.ToString();
                    strArr[5] = dgvr.Cells[6].Value.ToString();

                    list.Add(strArr);
                }
                string str = ea.SaveExcelFile(list);

                if (str.Length != 0) MessageBox.Show(str);
            }
        }
    }
}