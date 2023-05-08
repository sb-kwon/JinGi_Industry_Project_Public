using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace View.UserController
{
	public partial class DefBoardSize : UserControl
	{
		private Def _Def;

		[Description("MakeEvent"), Category("MakeEvent")]
		public event EventHandler GetData;
		[Description("MakeEvent"), Category("MakeEvent")]
		public event EventHandler GetSelect;

		public DefBoardSize()
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
					dgv.Rows.Add(str);
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
			dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);


			Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			Column1.Resizable = DataGridViewTriState.False;
			Column1.ReadOnly = true;
			Column1.Width = dgv.Width;
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
	}
}
