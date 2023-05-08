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
    public partial class OrderShipmentInput : Form, IBasicForm
    {
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {
            //진행중인 수주
            dgv_order.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[0].Width = 60;
            dgv_order.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_order.Columns[1].Width = 300;
            dgv_order.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[2].Width = 100;
            dgv_order.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[3].Width = 150;
            dgv_order.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[4].Width = 150;
            dgv_order.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[5].Width = 150;
            dgv_order.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[6].Width = 150;
            dgv_order.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[7].Width = 150;
            dgv_order.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[8].Width = 100;

            //수주 상세보기
            dgv_order_detail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[1].Width = 70;
            dgv_order_detail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[3].Width = 150;
            dgv_order_detail.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[4].Width = 150;
            dgv_order_detail.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[5].Width = 150;
            dgv_order_detail.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[6].Width = 150;
            dgv_order_detail.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[7].Width = 100;

            dgv.Font = new Font("맑은 고딕", 11, FontStyle.Regular);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 72, 81);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.SeaGreen;

            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.CurrentCell = null;

            dgv.BackgroundColor = SystemColors.GradientInactiveCaption;

            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f =>
            {
                f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            });
            dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion

        #region 검색 basicform
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            GetShipmentOrderData();
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
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;
        private AuthorityC _AuthorityCtrl;
        private List<WorkOrder> OrderName;
        private List<String[]> ViewList;
        private List<String[]> ViewList2;
        public OrderShipmentInput(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;

            _ProcessC = new ProcessC();
            _AuthorityCtrl = new AuthorityC();

            ViewList = new List<string[]>();
            ViewList2 = new List<string[]>();
            InitializeComponent();

            //SetDataGridView(dgv_order);
            //SetDataGridView(dgv_order_detail);
            GetShipmentOrderData();
            GetOrderState();
        }
        public void GetShipmentOrderData()
        {
            ViewList = _ProcessC.GetShipmentOrderDataList();
            SetShipmentOrderListView();
        }
        private void SetShipmentOrderListView()
        {
            dgv_order.Rows.Clear();
            dgv_order_detail.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    if (!(SetOrderState(array[2]).Equals("완료")))
                    dgv_order.Rows.Add(array[0], array[1], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[7], array[8] + "/" + array[9], "수주 출하", array[10], array[8], array[9], array[11]);
                }
            SumPrice();
        }
        private void dgv_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);

                SetOrderDetailListView();
            }
        }
        private void SetOrderDetailListView()
        {
            dgv_order_detail.Rows.Clear();
            ViewList2 = _ProcessC.GetShipmentProductData();
            if (ViewList2 != null)
                foreach (string[] array in ViewList2)
                {
                    dgv_order_detail.Rows.Add(array[0], array[1], array[2], array[3], SetInstructionState(array[4]), SetQualityState(array[5]), SetCnt(array[6], array[7], array[4]), "품목 출하", array[8]);
                }
        }
        private void dgv_order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Rows[e.RowIndex].Cells[2].Value.Equals("완료"))
            {
                SetAlarm("출고 완료된 수주는 수정할 수 없습니다.");
            }
            else
            {
                OrderShipmentUpdate popup = new OrderShipmentUpdate(_ProcessC.WorkOrder, this);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                popup.ShowDialog();
            }
        }
        private string SetCnt(string str1, string str2, string str3)
        {
            string str = "";

            if ((str1 == str2) && (str3 == "3")) str = "출고 가능";
            else if ((str1 != str2) && (str3 != "3")) str = "출고 불가";
            else if ((str1 == str2) && (str3 == "6")) str = "출고 완료";

            return str;
        }
        private String SetOrderState(string state)
        {
            string str = "";

            if (state == "0") str = "대기";
            if (state == "1") str = "등록";
            if (state == "2") str = "진행중";
            if (state == "3") str = "출하 대기";
            if (state == "4") str = "출하 진행중";
            if (state == "5") str = "완료";
            if (state == "6") str = "폐기";

            return str;
        }
        private String SetInstructionState(string state)
        {
            string str = "";

            if (state == "0") str = "대기";
            if (state == "1") str = "등록";
            if (state == "2") str = "진행중";
            if (state == "3") str = "완료";
            if (state == "4") str = "폐기";
            if (state == "5") str = "취소";
            if (state == "6") str = "출고 완료";

            return str;
        }
        private void SumPrice()
        {
            int Sum = 0;
            for (int k = 0; k < dgv_order.Rows.Count; k++)
            {
                Sum += Convert.ToInt32(dgv_order.Rows[k].Cells[7].Value.ToString().Replace(",", ""));
            }
            if (dgv_order.Rows.Count == 0) lbl_Price.Text = "0원";
            else lbl_Price.Text = string.Format("{0:#,###}", Sum) + "원";
        }
        private String SetQualityState(string state)
        {
            string str = "";

            if (state == "0") str = "양호";
            if (state == "1") str = "불량";
            //if (state == "") str = "검사 전";

            return str;
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            WorkOrder _wor = new WorkOrder();

            _wor.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _wor.OrderName = dgvr.Cells[1].Value.ToString();
            _wor.OrderStateName = dgvr.Cells[2].Value.ToString();
            if (!(dgvr.Cells[3].Value.ToString() == "")) _wor.OrderStartSchedule = dgvr.Cells[3].Value.ToString();
            if (!(dgvr.Cells[4].Value.ToString() == "")) _wor.OrderEndSchedule = dgvr.Cells[4].Value.ToString();
            _wor.OrderPrice = Convert.ToInt64(dgvr.Cells[7].Value.ToString().Replace(",",""));
            _wor.OrderMemo = dgvr.Cells[10].Value.ToString();
            _wor.CustomerMemberName = dgvr.Cells[13].Value.ToString();

            _ProcessC.WorkOrder = _wor;
        }
        private void dgv_order_detail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            _ProcessC.WorkProcess.WorkInstructionNo = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells[8].Value);

            if (_AuthorityCtrl.GetAuthority(_LoginInfo.MemberAccess.Authorityname, "버튼 누르기"))
            {
                if (dgv.Columns[e.ColumnIndex].Index == 7 && dgv.Rows[e.RowIndex].Cells[4].Value.ToString() == "완료" && dgv.Rows[e.RowIndex].Cells[6].Value.ToString() == "출고 가능")
                {
                    _ProcessC.UpdateShipmentState();
                    SetAlarm("품목이 출고 되었습니다.");
                    GetShipmentOrderData();
                }
                else if (dgv.Columns[e.ColumnIndex].Index == 7 && dgv.Rows[e.RowIndex].Cells[4].Value.ToString() == "출고 완료")
                    SetAlarm("이미 출고 된 품목입니다.");
                else if (dgv.Columns[e.ColumnIndex].Index == 7 && dgv.Rows[e.RowIndex].Cells[4].Value.ToString() != "완료" || dgv.Rows[e.RowIndex].Cells[6].Value.ToString() != "출고 가능")
                    SetAlarm("공정이 모두 완료 되어야 품목 출하가 가능합니다.");
            }
            else
            {
                SetAlarm("권한이 없습니다.");
            }
        }
        private void dgv_order_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            _ProcessC.WorkOrder.OrderNo = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);

            if (_AuthorityCtrl.GetAuthority(_LoginInfo.MemberAccess.Authorityname, "버튼 누르기"))
            {
                if (dgv.Columns[e.ColumnIndex].Index == 9)
                {
                    foreach (DataGridViewRow dgvr in dgv_order_detail.Rows)
                    {
                        if (dgv.Rows[e.RowIndex].Cells[11].Value.ToString() != dgv.Rows[e.RowIndex].Cells[12].Value.ToString())
                        {
                            SetAlarm("품목이 모두 출고가 되어야 합니다.");
                            break;
                        }
                        else if (dgv.Rows[e.RowIndex].Cells[11].Value.ToString() == dgv.Rows[e.RowIndex].Cells[12].Value.ToString() && dgv.Rows[e.RowIndex].Cells[2].Value.ToString() != "완료")
                        {
                            DialogResult result = MessageBox.Show("실제 수주 출하일을 변경하시겠습니까?", "수주 출하 알림", MessageBoxButtons.YesNoCancel);
                            if (result == DialogResult.Yes)
                            {
                                OutDateForm ODF = new OutDateForm(_ProcessC);
                                ODF.StartPosition = FormStartPosition.CenterParent;
                                ODF.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                                ODF.ShowDialog();
                            }
                            else if (result == DialogResult.No) _ProcessC.WorkOrder.RealEndDate = DateTime.Now.ToString("yyyy-MM-dd");
                            else if (result == DialogResult.Cancel) break;

                            if (_ProcessC.WorkOrder.OrderMemo.Equals("1")) _ProcessC.UpdateOrderState();
                            else { _ProcessC.UpdateOrderState(); SetAlarm("수주가 출하 되었습니다."); }
                            break;
                        }
                        else if (dgv.Rows[e.RowIndex].Cells[2].Value.ToString() == "완료")
                            SetAlarm("완료 된 수주 입니다.");
                            break;
                    }
                    GetShipmentOrderData();
                }
            }
            else
            {
                SetAlarm("권한이 없습니다.");
            }
        }
        private void GetOrderState()
        {
            cb_OrderState.Items.Clear();
            cb_OrderState.Items.Add("모두");
            OrderName = _ProcessC.GetOrderState();
            for (int i = 0; i < OrderName.Count(); i++)
            {
                cb_OrderState.Items.Add(SetOrderState(OrderName[i].OrderStateName));
                cb_OrderState.SelectedIndex = 0;
            }
        }
        private void btn_Search_Click_1(object sender, EventArgs e)
        {
            dgv_order.Rows.Clear();
            dgv_order_detail.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetShipmentOrderDataList();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    if ((array[1].IndexOf(tb_OrderName.Text) != -1)
                        && (cb_OrderState.SelectedItem.Equals("모두") || cb_OrderState.SelectedItem.Equals(SetOrderState(array[2])))
                        && (!dtp_date.Enabled || dtp_date.Value.Date <= Convert.ToDateTime(array[3]).Date && Convert.ToDateTime(array[3]) <= dtp_date_End.Value.Date)
                        //&& (!dtp_date.Enabled || Convert.ToDateTime(array[4]).Date >= dtp_date.Value.Date)
                        && (!dateTimePicker1.Enabled || dateTimePicker1.Value.Date <= Convert.ToDateTime(array[5]).Date && Convert.ToDateTime(array[5]).Date <= dateTimePicker2.Value.Date))
                        //&& (!dateTimePicker1.Enabled || Convert.ToDateTime(array[6]).Date >= dateTimePicker1.Value.Date))
                    {
                        if (!(SetOrderState(array[2]).Equals("완료")))
                            dgv_order.Rows.Add(array[0], array[1], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[7], array[8] + "/" + array[9], "수주 출하", array[10], array[8], array[9], array[11]);
                    }
                }
            SumPrice();
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            dtp_date.Enabled = dtp_date_End.Enabled = checkBox2.Checked;
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = checkBox1.Checked;
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(_ProcessC.WorkOrder.OrderName + "의 수주를 삭제하시겠습니까?", "수주 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (MessageBox.Show("정말 삭제하시겠습니까?", "수주 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (_ProcessC.WorkOrder.OrderNo.ToString() == "0" || _ProcessC.WorkOrder.OrderNo.ToString() == "")
                        SetAlarm("삭제할 수주를 선택 해주세요.");
                    else if (_ProcessC.WorkOrder.OrderStateName == "폐기")
                        SetAlarm("이미 폐기된 수주입니다.");
                    else
                    {
                        _ProcessC.DeleteWorkOrder();
                        SetAlarm("수주명 : " + _ProcessC.WorkOrder.OrderName.ToString() + "이(가) \n 삭제 처리 되었습니다.");
                        RefreshForm();
                    }
        }
    }
}