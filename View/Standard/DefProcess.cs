using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


using View.UserController;

namespace View
{
	public partial class DefProcess : Form, IBasicForm
	{
		private BaseC _BaseCtrl;
		private BasicForm _Mother;
		private Member _LoginInfo;
		private Boolean _FairCheck;
		private List<Def> _DefList;
		private DefFair _SelectedFair;
		private List<DefFair> _FairList;

		public DefProcess(Member member, BasicForm form)
		{
			InitializeComponent();
			_Mother = form;
			_LoginInfo = member;
			_BaseCtrl = new BaseC();
			SetTables();
			GetFariList();
			ComboBoxSet();
		}
        #region Getter And Setter
        public List<DefFair> FairList
		{
			get
			{
				return _FairList;
			}
			set
			{
				_FairList = value;
				if (FairList != null)
				{
					SetDefProcessView();
				}
			}
		}
		public DefFair SeletedFair
		{
			get
			{
				return _SelectedFair;
			}
			set
			{
				_SelectedFair = value;
				SetTextbox();
			}
		}
		public List<Def> DefList
		{
			get
			{
				return _DefList;
			}
			set
			{
				_DefList = value;
				SetViewTable();
			}
		}
		public Def Def { get; set; }
        #endregion
        #region IBasicForm
        public string GetText()
		{
			return this.Text;
		}
		public void RefreshForm()
		{
			SetTables();
			GetFariList();
			ComboBoxSet();
			Reset();
		}
		public Form SetForm()
		{
			return this;
		}

		public void SetInterval(string seletedPageName, bool check)
		{
			//	SetTables();
			//	GetFariList();
			//	ComboBoxSet();
		}
        #endregion
        #region 검색 DGV        
        //--------------------------------------------------------------
        //Method 
        //--------------------------------------------------------------
        private void SetTables()
		{
			DefList = _BaseCtrl.GetDefList(FindDefBoard());
		}
		private List<String> FindDefBoard()
		{
			List<String> list = new List<string>();
			foreach (Object ob in this.Controls)
			{
				if (ob.GetType().Name.ToString().Equals("DefBoard"))
				{
					DefBoard defBoard = (DefBoard)ob;
					list.Add(defBoard.Name);
				}
			}
			return list;
		}
		private void SetViewTable()
		{
			foreach (Object ob in this.Controls)
			{
				if (ob.GetType().Name.ToString().Equals("DefBoard"))
				{
					DefBoard defBoard = (DefBoard)ob;

					foreach (Def def in DefList)
					{
						if (def.TableLogical != null)
						{
							if (def.TableLogical.Equals(defBoard.Name))
							{
								defBoard.Def = def;
							}
						}
					}
				}
			}
		}
		//선택 버튼 클릭
		private void def_continence_location_GetData(object sender, EventArgs e)
		{
			DefBoard db = (DefBoard)sender;
			Def = db.Def;

			lbl_Table.Text = db.Def.TableName;
			lbl_Value.Text = "";
		}
		//cell click
		private void def_continence_location_GetSelect(object sender, EventArgs e)
		{
			DefBoard db = (DefBoard)sender;
			Def = db.Def;

			lbl_Table.Text = Def.TableName;
			lbl_Value.Text = Def.SelectValue;
		}
		private void GetFariList()
		{
			FairList = _BaseCtrl.GetFariList();
		}
		private void dgv_DefProcess_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			SetSelectedData(dgv.SelectedRows[0]);
		}
		//--------------------------------------------------------------
		//UI
		//--------------------------------------------------------------
		private void SetDefProcessView()
		{
			dgv_Process.Rows.Clear();
			foreach (DefFair df in FairList)
				dgv_Process.Rows.Add(df.fairname, df.fairsort, "", df.fairgroup, df.fairreal, df.fairno);
			//	foreach (DefFair df in FairList)
			//		foreach (DataGridViewRow dgvr in dgv_Process.Rows)
			//			if (dgvr.Cells[0].Value.Equals(df.fairname) && dgvr.Cells[1].Value.Equals(df.fairsort) && dgvr.Cells[3].Value.Equals(df.fairgroup))
			//			{
			//				dgvr.Cells[2].Style.BackColor = Color.FromArgb(Convert.ToInt32(df.faircolor));
			//				dgvr.Cells[2].Style.SelectionBackColor = Color.FromArgb(Convert.ToInt32(df.faircolor));
			//			}
		}
		private void SetTextbox()
		{
			tb_FairNo.Text = SeletedFair.fairno;
			tb_FairName.Text = SeletedFair.fairname;
			tb_FairSort.Text = SeletedFair.fairsort.ToString();
			btn_FairColor.BackColor = Color.FromArgb(SeletedFair.faircolor);
			if (SeletedFair.fairgroup.Length == 0) cb_SelectGroup.SelectedIndex = -1;
			else cb_SelectGroup.SelectedItem = SeletedFair.fairgroup;
			if (SeletedFair.fairgroup.Length == 0) cb_SelectMapping.SelectedIndex = -1;
			else cb_SelectMapping.SelectedItem = SeletedFair.fairreal;
		}
		private DefFair GetTextBox()
		{
			DefFair df = new DefFair();
			df.fairno = tb_FairNo.Text;
			df.fairname = tb_FairName.Text;
			df.fairsort = Convert.ToInt32(tb_FairSort.Text);
			df.faircolor = Convert.ToInt32(btn_FairColor.BackColor.ToArgb());
			df.fairgroup = cb_SelectGroup.SelectedItem.ToString();
			df.fairreal = cb_SelectMapping.SelectedItem.ToString();

			return df;
		}
		private void SetSelectedData(DataGridViewRow dgvr)
		{
			DefFair df = new DefFair();
			df.fairname = dgvr.Cells[0].Value.ToString();
			df.fairsort = (int)dgvr.Cells[1].Value;
			df.faircolor = dgvr.Cells[2].Style.BackColor.ToArgb();
			df.fairgroup = dgvr.Cells[3].Value.ToString();
			df.fairreal = dgvr.Cells[4].Value.ToString();
			df.fairno = dgvr.Cells[5].Value.ToString();

			SeletedFair = df;
		}
#endregion
        #region 검색 ComboBox
        private void cb_FindGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetFariList();
			ComboBox cb = (ComboBox)sender;

			foreach (DataGridViewRow dgvr in dgv_Process.Rows)
			{
				if (dgvr.Cells[3].Value.Equals(cb.SelectedItem.ToString())) dgvr.Visible = true;
				else dgvr.Visible = false;
			}
		}
		private void ComboBoxSet()
		{
			cb_Add_Fair.Items.Clear();
			cb_FindGroup.Items.Clear();
			cb_Add_Group.Items.Clear();
			cb_SelectGroup.Items.Clear();
			cb_Add_Mapping.Items.Clear();
			cb_SelectMapping.Items.Clear();

			List<String> list = new List<string>();

			list = _BaseCtrl.GetDefFairGroup();
			if (!(list is null))
			{
				foreach (string str in list)
				{
					cb_SelectGroup.Items.Add(str);
					cb_Add_Group.Items.Add(str);
					cb_FindGroup.Items.Add(str);
				}
				list.Clear();
			}
			list = _BaseCtrl.GetDefProcessMapping();
			if (!(list is null))
			{
				foreach (string str in list)
				{
					cb_Add_Mapping.Items.Add(str);
					cb_SelectMapping.Items.Add(str);
				}
				list.Clear();
			}
			list = _BaseCtrl.GetDefFair();
			if (!(list is null))
			{
				foreach (string str in list)
				{
					cb_Add_Fair.Items.Add(str);
				}
				list.Clear();
			}
		}
        #endregion
        #region 검색 Button
        private void btn_Add_Click(object sender, EventArgs e)
		{
			if (lbl_Table.Text.Length != 0)
			{
				DefAddUpdate DAU = new DefAddUpdate(Def.TableName + " 테이블 항목추가 ", Def, false, _BaseCtrl);

				DAU.StartPosition = FormStartPosition.Manual;
				DAU.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150);
				DAU.ShowDialog();

				SetTables();
				SetViewTable();

				ComboBoxSet();
				GetFariList();
				ReSetTextBox();
			}
		}
		private void btn_Update_Click(object sender, EventArgs e)
		{
			if (lbl_Table.Text.Length != 0 && lbl_Value.Text.Length != 0 && _BaseCtrl.DefCheck(Def))
			{
				DefAddUpdate DAU = new DefAddUpdate(Def.TableName + " 테이블 항목수정 \n 기존값 : " + Def.SelectValue, Def, true, _BaseCtrl);

				DAU.StartPosition = FormStartPosition.Manual;
				DAU.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150);
				DAU.ShowDialog();

				SetTables();
				SetViewTable();

				ComboBoxSet();
				GetFariList();
				ReSetTextBox();
			}
			else if (!_BaseCtrl.DefCheck(Def))
			{
				MessageBox.Show("해당 항목은 변경 불가 합니다.");
			}
		}
		private void btn_Delete_Click(object sender, EventArgs e)
		{
			if (lbl_Table.Text.Length != 0 && lbl_Value.Text.Length != 0 && _BaseCtrl.DefCheck(Def))
			{
				DefAddUpdate DAU = new DefAddUpdate(Def.TableName + " 테이블 항목삭제 \n 기존값 : " + Def.SelectValue, Def, null, _BaseCtrl);

				DAU.StartPosition = FormStartPosition.Manual;
				DAU.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150);
				DAU.ShowDialog();

				SetTables();
				SetViewTable();

				ComboBoxSet();
				GetFariList();
				ReSetTextBox();
			}
			else if (!_BaseCtrl.DefCheck(Def))
			{
				MessageBox.Show("해당 항목은 변경 불가 합니다.");
			}
		}
		private void btn_FairColor_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;

			ColorDialog cd = new ColorDialog();

			if (cd.ShowDialog() == DialogResult.OK)
				btn.BackColor = cd.Color;
		}
		private void btn_Fair_Delete_Click(object sender, EventArgs e)
		{
			if (cb_SelectGroup.SelectedIndex != -1 && tb_FairName.TextLength != 0)
			{
				DefFair df = new DefFair();
				df = GetTextBox();
				if (MessageBox.Show("선택하신 정보가 삭제됩니다", "공정 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					_BaseCtrl.DeleteFair(df.fairno);

					ReSetTextBox();
					GetFariList();
				}
				else
                {
					ReSetTextBox();
					GetFariList();
				}
			}
		}
		private void btn_Fair_Update_Click(object sender, EventArgs e)
		{
			if (cb_SelectGroup.SelectedIndex != -1 && cb_SelectMapping.SelectedIndex != -1 && tb_FairName.TextLength != 0)
			{
				DefFair df = new DefFair();
				df = GetTextBox();
				
				if (_BaseCtrl.CheckFair(df))
				{
					_BaseCtrl.UpdateFair(df);
					MessageBox.Show("공정 수정이 완료 되었습니다.");
					ReSetTextBox();
					GetFariList();
				}
				else
				{
					MessageBox.Show("해당 공정은 이미 그룹에 속해있습니다.");
				}

			}
			else MessageBox.Show("공정그룹이 선택되지 않았습니다.");
		}
		private void btn_Add_Fair_Click(object sender, EventArgs e)
		{
			DefFair DF = new DefFair();

			DF.fairname = cb_Add_Fair.Text;
			DF.fairgroup = cb_Add_Group.Text;
			DF.fairsort = Convert.ToInt32(tb_Add_Sort.Text);
			DF.fairreal = cb_Add_Mapping.Text;
			DF.faircolor = Convert.ToInt32(btn_FairColor.BackColor.ToArgb());

			_FairCheck = _BaseCtrl.CheckFair(DF);
			if (_FairCheck == true)
			{
				_BaseCtrl.InsertFairGroup(DF);
				MessageBox.Show("공정 그룹 추가가 완료 되었습니다.");
				pnl_Add.Visible = false;
			}
			else
			{
				MessageBox.Show("공정명과 공정 그룹이 중복입니다.");
			}
			GetFariList();
			ReSetTextBox();
		}
		private void button4_Click(object sender, EventArgs e)
		{
			ComboBoxSet();
			pnl_Add.Visible = true;
			pnl_Add.BringToFront();
		}
		private void btn_Close_Click(object sender, EventArgs e)
		{
			pnl_Add.Visible = false;
		}
		private void btn_All_Click(object sender, EventArgs e)
		{
			GetFariList();
			ReSetTextBox();
		}
        #endregion
        #region Reset
        private void ReSetTextBox()
		{
			tb_FairName.Text = "";
			tb_FairSort.Text = "";
			btn_FairColor.BackColor = SystemColors.Window;

			cb_SelectMapping.Text = null;
			cb_SelectGroup.Text = null;
		}
		private void Reset()
		{
			lbl_Table.Text = string.Empty;
			lbl_Value.Text = string.Empty;
			tb_FairName.Text = string.Empty;
			tb_FairSort.Text = string.Empty;
		}
        #endregion
    }
}