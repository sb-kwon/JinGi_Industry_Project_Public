using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class SearchBox : Form
    {
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {
            dgv.Font = new Font("맑은 고딕", 11, FontStyle.Regular);


            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 72, 81);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.SeaGreen;

            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.CurrentCell = null;

            dgv.BackgroundColor = SystemColors.GradientInactiveCaption;

            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f =>
            {
                f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            });
            dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion
        private ProcessC _ProcessC;
        private string tablename, tablecolumn, _type;
        private List<String[]> ViewList;
        public SearchBox(ProcessC processC, string type)
        {
            _ProcessC = processC;
            InitializeComponent();

            SetDataGridView(dgv_process);
            _type = type;
            SetSearchView();
        }
        private void dddd()
        {
            switch (_type)
            {
                case "작업자":
                    tablename = "member";
                    tablecolumn = "MemberId, MemberName";
                    break;
                case "장비명":
                    tablename = "machine";
                    tablecolumn = "MachineNo, MachineName";
                    break;
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            dddd();

            ViewList = _ProcessC.GetSearchView(tablename, tablecolumn);
            dgv_process.Rows.Clear();
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((str[1].IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) != -1)
                        && (str[0].IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) != -1))
                    {
                        dgv_process.Rows.Add(str[0], str[1]);
                    }
                }
        }
        private void dgv_process_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (_type)
            {
                case "작업자":
                    _ProcessC.WorkProcess.MemberName = dgv_process.Rows[e.RowIndex].Cells[1].Value.ToString();
                    _ProcessC.WorkProcess.MemberId = dgv_process.Rows[e.RowIndex].Cells[0].Value.ToString();
                    break;

                case "장비명":
                    _ProcessC.WorkProcess.MachineNo = Convert.ToInt32(dgv_process.Rows[e.RowIndex].Cells[0].Value.ToString());
                    _ProcessC.WorkProcess.MachineName = dgv_process.Rows[e.RowIndex].Cells[1].Value.ToString();
                    break;
            }
        }
        private void btn_instruction_save_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetSearchView()
        {
            dddd();

            ViewList = _ProcessC.GetSearchView(tablename, tablecolumn);
            dgv_process.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_process.Rows.Add(array[0], array[1]);
                }
        } 
    }
}
