using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace View.UserController
{
	public partial class DefBoard : UserControl
	{
		private Def _Def;

		[Description("MakeEvent"), Category("MakeEvent")]
		public event EventHandler GetData;
		[Description("MakeEvent"), Category("MakeEvent")]
		public event EventHandler GetSelect;

		public DefBoard()
		{
			InitializeComponent();
			Def = new Def();
		}
		public Def Def
		{
			get { return _Def; }
			set
			{
				_Def = value;
				lbl_Name.Text = Def.TableName;
				SetGridView();
			}
		}
		private void SetGridView()
		{
			dgv.Rows.Clear();
			if (Def.Columns != null)
			{
				foreach (String str in Def.Columns)
				{
					int returnVal = 0;
					bool result = int.TryParse(str, out returnVal);
					if (result)
					{
						dgv.Rows.Add(SetProcessState(str));
					}
					else
					{
						dgv.Rows.Add(str);
					}
				}
			}

			dgv.ReadOnly = true;
			dgv.RowHeadersVisible = false;
			dgv.MultiSelect = false;
			dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f =>
			{
				f.SortMode = DataGridViewColumnSortMode.NotSortable;
				f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
			});
			dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.WhiteSmoke);


			Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			Column1.Resizable = DataGridViewTriState.False;
			Column1.ReadOnly = true;
			Column1.Width = dgv.Width;
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
			else
            {
                ;
            }

            return str;
		}
		private void DefBoard_Resize(object sender, EventArgs e)
		{
			pnl.Dock = DockStyle.Fill;
		}

		public void OnClick(object sender, EventArgs args)
		{
			if (GetData != null)
			{
				Invoke(GetData, null);
			}
		}
		public void OnClick2(object sender, EventArgs args)
		{
			if (GetSelect != null)
			{
				Invoke(GetSelect, null);
			}
		}
		private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			Def.SelectValue = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
			OnClick2(sender, e);
		}

		private void lbl_Name_Click(object sender, EventArgs e)
		{
			OnClick(sender, e);
		}

		private void DefBoard_Load(object sender, EventArgs e)
		{
			dgv.ClearSelection();
		}
	}
}
