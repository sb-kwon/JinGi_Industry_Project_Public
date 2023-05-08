using Controller;
using System;
using System.Windows.Forms;

namespace View
{
	public partial class OrderChildOrder : Form
	{
		private Form _form;
		private Product _Pro;
		private ProcessC _ProcessCtrl;
		public OrderChildOrder(ProcessC processCtrl, Form form)
		{
			InitializeComponent();
			_form = form;
			_Pro = new Product();
			_ProcessCtrl = processCtrl;
		}
		public void DetailTextSave(ProcessC wp)
		{
			tb_OrderName.Text = wp.WorkOrder.OrderName;
			tb_Order_State.Text = wp.WorkOrder.OrderStateName;
			tb_ProductName.Text = wp.Product.ProductName;
			tb_ProductType.Text = wp.Product.ProductType;
			tb_Work_No.Text = wp.WorkInstruction.WorkinstructionNo.ToString();
			tb_Work_State.Text = SetInstructionState(wp.WorkInstruction.WorkinstructionState.ToString());
			tb_Memo.Text = wp.WorkInstruction.WorkinstructionMemo;
		}
		private String SetInstructionState(string state)
		{
			string str = "";

			if (state == "0") str = "대기";
			if (state == "1") str = "등록";
			if (state == "2") str = "진행중";
			if (state == "3") str = "공정 완료";
			if (state == "4") str = "폐기";
			if (state == "5") str = "취소";
			if (state == "6") str = "품목 출고";
			if (state == "7") str = "출하";

			return str;
		}
	}
}