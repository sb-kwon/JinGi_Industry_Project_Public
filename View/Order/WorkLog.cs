using Model;
using System;
using System.IO;
using Controller;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace View
{
    public partial class WorkLog : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;
        private List<String[]> ViewList;
        private List<String[]> ViewList2;
        private bool PopupType;
        private string SearchText, SearchName;
        public WorkLog(Member member, BasicForm form)
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
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = null;
            dtp_date.Value = DateTime.Now;
        }
        public void SetView()
        {
            dgv_WorkLog.Rows.Clear();

            List<string[]> list = _ProcessC.GetWorkProcessLog();
            if (list != null)
                foreach (string[] str in list)
                    dgv_WorkLog.Rows.Add(
                        str[0],
                        str[1],
                        str[2] + " 등 " + str[16] + "개",
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
                        str[14],
                        str[15],
                        str[17]
                        );
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
           // WorkList_Start popup = new WorkList_Start(_LoginInfo);
           // popup.StartPosition = FormStartPosition.CenterParent;
           // popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
           // popup.ShowDialog();
        }
        private void btn_end_Click(object sender, EventArgs e)
        {
            //WorkList_End popup = new WorkList_End();
            //popup.StartPosition = FormStartPosition.CenterParent;
            //popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            //popup.ShowDialog();
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
            dgv_WorkLog.Rows.Clear();

            List<string[]> list = _ProcessC.GetWorkProcessLog();
            if (list != null)
                foreach (string[] str in list)
                    if ((comboBox7.SelectedItem.Equals("모두") || comboBox7.SelectedItem.Equals(str[3]) && (!(str[10].Equals(""))
                    && str[0].ToLower().IndexOf(textBox1.Text.ToLower()) != -1
                     && str[1].ToLower().IndexOf(textBox2.Text.ToLower()) != -1
                     && str[2].ToLower().IndexOf(textBox3.Text.ToLower()) != -1
                     && str[8].ToLower().IndexOf(textBox4.Text.ToLower()) != -1
                     && (!dtp_date.Enabled || dtp_date.Value.Date <= Convert.ToDateTime(str[6]).Date && Convert.ToDateTime(str[6]) <= dtp_date_End.Value.Date)
                     && (!dateTimePicker2.Enabled || dateTimePicker2.Value.Date <= Convert.ToDateTime(str[10]).Date && Convert.ToDateTime(str[10]) <= dateTimePicker1.Value.Date)
                    //&& Convert.ToDateTime(str[6]).Date <= dtp_date.Value.Date
                    //&& Convert.ToDateTime(str[7]).Date >= dtp_date.Value.Date
                     )))
                        dgv_WorkLog.Rows.Add(
                    str[0],
                    str[1],
                    str[2] + " 등 " + str[16] + "개",
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
        private void btn_all_Click(object sender, EventArgs e)
        {
            SetView();
            SetComboBox();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.ForeColor == Color.Gray) label1.ForeColor = Color.Black;
            else label1.ForeColor = Color.Gray;

            dateTimePicker1.Enabled = dateTimePicker2.Enabled = (label1.ForeColor == Color.Black);
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (label4.ForeColor == Color.Gray) label4.ForeColor = Color.Black;
            else label4.ForeColor = Color.Gray;

            dtp_date.Enabled = dtp_date_End.Enabled = (label4.ForeColor == Color.Black);
        }
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SaveFileDialog SaveAsFile = new SaveFileDialog();

            if (btn.BackColor.Equals(Color.FromArgb(32, 118, 71)))
            { 
                SaveAsFile.InitialDirectory = @"바탕 화면";
                SaveAsFile.Title = "다른 이름으로 저장";
                SaveAsFile.Filter = "엑셀파일(*xlsx)|*xlsx|엑셀파일(*xls)|*xls|모든파일|*.*";
                SaveAsFile.DefaultExt = "xlsx";
                SaveAsFile.AddExtension = true;

                if (SaveAsFile.ShowDialog() == DialogResult.OK)
                {
                    ExcelProduct ea = new ExcelProduct(SaveAsFile.FileName);

                    List<string[]> list = new List<string[]>();

                    foreach (DataGridViewRow dgvr in dgv_WorkLog.Rows)
                    {
                        string[] strArr = new string[14];
                        strArr[0] = dgvr.Cells[0].Value.ToString();
                        strArr[1] = dgvr.Cells[13].Value.ToString();
                        strArr[2] = dgvr.Cells[2].Value.ToString();
                        strArr[3] = dgvr.Cells[3].Value.ToString();
                        strArr[4] = dgvr.Cells[4].Value.ToString();
                        strArr[5] = dgvr.Cells[5].Value.ToString();
                        strArr[6] = dgvr.Cells[6].Value.ToString();
                        strArr[7] = dgvr.Cells[7].Value.ToString();
                        strArr[8] = dgvr.Cells[8].Value.ToString();
                        strArr[9] = dgvr.Cells[9].Value.ToString();
                        strArr[10] = dgvr.Cells[10].Value.ToString();
                        strArr[11] = dgvr.Cells[16].Value.ToString();
                        strArr[12] = dgvr.Cells[12].Value.ToString();
                        strArr[13] = dgvr.Cells[15].Value.ToString();

                        list.Add(strArr);
                    }
                    string str = ea.SaveExcelFile(list);
                    
                    if (str.Length != 0) MessageBox.Show(str);
                }
            }
            bool FileExist = File.Exists(SaveAsFile.FileName);

            if (FileExist)
            {
                btn.Text = "데이터 전체 삭제";
                btn.BackColor = btn.FlatAppearance.BorderColor = btn.FlatAppearance.MouseDownBackColor = Color.Red;
                if (btn.BackColor.Equals(Color.Red))
                    if (MessageBox.Show("이 달의 모든 데이터가 삭제됩니다.", "데이터 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        _ProcessC.AllDataTruncate();

                btn.Text = "Excel 내려받기";
                btn.BackColor = btn.FlatAppearance.BorderColor = btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 118, 71);
                MessageBox.Show("데이터 삭제가 완료되었습니다.");
            }
            else MessageBox.Show("해당 파일을 찾을 수 없으므로 데이터 삭제가 불가능합니다.");
        }
    }
}