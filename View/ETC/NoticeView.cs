using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model.Material;

namespace View
{
	public partial class NoticeView : Form, IBasicForm
	{
		public Member _LoginInfo;
		private BasicForm _Mother;
		public NoticeCtrl _NoticeCtrl;
		public NoticeView(Member member, BasicForm form)
		{
			InitializeComponent();

			_Mother = form;
			_LoginInfo = member;
			_NoticeCtrl = new NoticeCtrl();
			SetView();

		}


		public void SetView()
		{
			dgv_notice.Rows.Clear();
			List<Notice> list = _NoticeCtrl.GetNotices();
			if (list != null)
				foreach (Notice n in list)
					dgv_notice.Rows.Add(n.NoticeNo, n.NoticeTime.Substring(0,11), n.NoticeTitle, n.memberName, n.NoticeContent);

			dgv_notice_sys.Rows.Clear();
			List<string[]> list2 = _NoticeCtrl.GetNoticesSys();
			if (list2 != null)
				foreach (string[] str in list2)
					dgv_notice_sys.Rows.Add(str[0], str[1].Substring(0,10), str[2], str[3], str[4]);

			comboBox1.Items.Clear();


			
			if(_NoticeCtrl.NoticeSysTitleList() != null)
			{
				foreach (string str in _NoticeCtrl.NoticeSysTitleList())
				{
					comboBox1.Items.Add(str);
				}
				if (comboBox1.Items.Count != 0) comboBox1.SelectedIndex = 0;
			}
			
		}
		#region Ibasic
		public string GetText()
		{
			return this.Text;
		}

		public void RefreshForm()
		{
			SetView();
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


		private void button2_Click(object sender, EventArgs e)
		{
			dgv_notice.Rows.Clear();
			List<Notice> list = _NoticeCtrl.GetNotices();
			if (list != null)
				foreach (Notice n in list)
					if (!dateTimePicker1.Enabled || dateTimePicker1.Value.ToString("yyyy-MM-dd").Equals(n.NoticeTime.Substring(0, 10)))
						if(n.NoticeTitle.IndexOf(textBox1.Text) != -1)
							dgv_notice.Rows.Add(n.NoticeNo, n.NoticeTime.Substring(0, 11), n.NoticeTitle, n.memberName, n.NoticeContent);
		}


		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = checkBox1.Checked;
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker2.Enabled = checkBox2.Checked;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			
			if (btn.Tag.ToString().Equals("f"))
			{
				btn.BackColor = Color.FromArgb(255, 128, 0);
				btn.Tag = "t";

				dgv_notice.Rows.Clear();
				List<Notice> list = _NoticeCtrl.GetNotices();
				if (list != null)
					foreach (Notice n in list)
						if(n.memberName.Equals(_LoginInfo.Membername))
							dgv_notice.Rows.Add(n.NoticeNo, n.NoticeTime.Substring(0, 11), n.NoticeTitle, n.memberName, n.NoticeContent);
			}
			else
			{
				btn.BackColor = Color.FromArgb(48, 103, 162);
				btn.Tag = "f";
				SetView();
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			NoticeInsert ni = new NoticeInsert(this, _LoginInfo.Memberid, "Add", null) ;
			ni.ShowDialog();
			btn.BackColor = Color.FromArgb(48, 103, 162);
			SetView();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			dgv_notice_sys.Rows.Clear();
			List<string[]> list2 = _NoticeCtrl.GetNoticesSys();
			if (list2 != null)
				foreach (string[] str in list2)
					if (!dateTimePicker1.Enabled || dateTimePicker1.Value.ToString("yyyy-MM-dd").Equals(str[1].Substring(0, 10)))
						if (str[3].IndexOf(textBox1.Text) != -1)
							if(comboBox1.SelectedItem.Equals(str[2]))
								dgv_notice_sys.Rows.Add(str[0], str[1].Substring(0, 10), str[2], str[3], str[4]);
		}

		private void dgv_notice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				DataGridView senderGrid = (DataGridView)sender;

				Notice n = new Notice();

				n.NoticeNo = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
				n.NoticeTime = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
				n.NoticeTitle = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
				n.memberId = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
				n.NoticeContent = senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString();

				NoticeInsert ni = new NoticeInsert(this, _LoginInfo.Memberid, "View", n);
				ni.ShowDialog();

				SetView();
			}
		}

		private void dgv_notice_sys_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				DataGridView senderGrid = (DataGridView)sender;



				Notice n = new Notice();

				n.NoticeNo = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
				n.NoticeTime = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
				n.NoticeTitle = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
				n.memberId = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
				n.NoticeContent = senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString();

				NoticeInsert ni = new NoticeInsert(this, _LoginInfo.Memberid, "Sys", n);
				ni.ShowDialog();

				SetView();
			}
		}
	}
}