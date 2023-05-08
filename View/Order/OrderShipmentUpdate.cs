using System;
using Controller;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public partial class OrderShipmentUpdate : Form
    {
        private Point mousePoint;
        private WorkOrder _WorkOrder;
        private ProcessC _ProcessCtrl;
        private OrderShipmentInput _View;
        public OrderShipmentUpdate(WorkOrder wo, OrderShipmentInput OrderView)
        {
            InitializeComponent();

            _WorkOrder = wo;
            _View = OrderView;
            _ProcessCtrl = new ProcessC();
            FormStart();
        }
        private void FormStart()
        {
            tb_OrderName.Text  = _WorkOrder.OrderName;
            tb_OrderMemo.Text  = _WorkOrder.OrderMemo;
            lbl_OrderNo.Text   = _WorkOrder.OrderNo.ToString();
            lbl_OrderDateEnd.Text = _WorkOrder.OrderEndSchedule;
            lbl_CustomerMemberName.Text = _WorkOrder.CustomerMemberName;
            tb_OrderPrice.Text = string.Format("{0:#,###}", _WorkOrder.OrderPrice);
        }
        private void OrderShipmentUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void OrderShipmentUpdate_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            WorkOrder wo = new WorkOrder();

            wo.OrderNo = Convert.ToInt32(lbl_OrderNo.Text);
            wo.OrderName = tb_OrderName.Text;
            wo.OrderMemo = tb_OrderMemo.Text;
            wo.OrderPrice = Convert.ToInt64(tb_OrderPrice.Text.Replace(",",""));
            wo.OrderDateEnd = Convert.ToDateTime(lbl_OrderDateEnd.Text).ToString("yyyy-MM-dd");
            wo.CustomerMemberName = lbl_CustomerMemberName.Text;

           _ProcessCtrl.UpdateOrder(wo);

            SetAlarm("수주 금액, 메모가 수정 되었습니다.");
            _View.GetShipmentOrderData();
            this.Close();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        private void tb_OrderPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void tb_OrderPrice_TextChanged(object sender, EventArgs e)
        {
            long longPrice;
            longPrice = Convert.ToInt64(tb_OrderPrice.Text.Replace(",", ""));
            tb_OrderPrice.Text = String.Format("{0:#,###}", longPrice);
            tb_OrderPrice.SelectionStart = tb_OrderPrice.TextLength;
            tb_OrderPrice.SelectionLength = 0;
        }
    }
}