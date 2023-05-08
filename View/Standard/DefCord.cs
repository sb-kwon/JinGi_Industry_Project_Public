using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.UserController;

namespace View
{
	public partial class DefCord : Form, IBasicForm
	{
		private Member _LoginInfo;
		private BasicForm _Mother;
		private BaseC _BaseCtrl;
		private List<Def> _DefList;
		public DefCord(Member member, BasicForm form)
		{
			InitializeComponent();
			_Mother = form;
			_LoginInfo = member;
			_BaseCtrl = new BaseC();
			SetTables();
		}
		//--------------------------------------------------------------
		//Getter And Setter
		//--------------------------------------------------------------
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
		//--------------------------------------------------------------
		//InterFace
		//--------------------------------------------------------------

		public string GetText()
		{
			return this.Text;
		}
		public void RefreshForm()
		{
			SetTables();
			Reset();
		}
		public Form SetForm()
		{
			return this;
		}

		public void SetInterval(string seletedPageName, bool check)
		{
			;
		}
		//--------------------------------------------------------------
		//Method 
		//--------------------------------------------------------------
		private void Reset()
		{
			lbl_Table.Text = "";
			lbl_Value.Text = "";
		}
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
		//--------------------------------------------------------------
		//UI
		//--------------------------------------------------------------
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
				Reset();
			}
			else if (lbl_Table.Text.Length == 0 && lbl_Value.Text.Length == 0)
			{
				MessageBox.Show("추가할 항목을 선택해 주십시오.");
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
				Reset();
			}
			else if (lbl_Table.Text.Length == 0 && lbl_Value.Text.Length == 0)
            {
				MessageBox.Show("수정할 항목을 선택해 주십시오.");
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
				Reset();
			}
			else if (lbl_Table.Text.Length == 0 && lbl_Value.Text.Length == 0)
			{
				MessageBox.Show("삭제할 항목을 선택해 주십시오.");
			}
			else if (!_BaseCtrl.DefCheck(Def))
			{
				MessageBox.Show("해당 항목은 변경 불가 합니다.");
			}
		}
	}
}
