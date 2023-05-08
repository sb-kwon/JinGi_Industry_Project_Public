using Controller;
using Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
	public partial class DefAddUpdate : Form
	{
		private Def _Def;
		private bool? _check;
		private String _Content;
		private BaseC _BaseCtrl;
		private Point mousePoint;

        public DefAddUpdate(String content, Def def, bool? type, BaseC basectrl)  //0이면 추가, 1이면 수정
		{
			InitializeComponent();
			Content = content;
			_Def = def;
			_BaseCtrl = basectrl;
			_check = type;

			if (type is null)
			{
				panel1.Visible = false;
				panel2.Visible = false;
				label2.Visible = false;
				textBox1.Visible = false;
				this.Size = new Size(303, 114);
				btn_Apply.Location = new Point(216, 76);
			}
		}
		public String Content
		{
			get { return _Content; }
			set
			{
				_Content = value;

				label1.Text = Content;
			}
		}

		private void btn_Apply_Click(object sender, EventArgs e)
		{
			//겹치는 값이 있는지 확인
			if (_BaseCtrl.FindDefData(_Def.TableLogical, _Def.ValueLogical, textBox1.Text))
			{
				//안된다는 알림 알리기
				MessageBox.Show("이미 사용중인 코드 입니다.");
			}
			else
			{
				if (_check is true)  //update
				{
					_BaseCtrl.UpdateDefData(_Def, textBox1.Text);

				}
				else if (_check is false)  //add
				{
					_BaseCtrl.InsertDefData(_Def, textBox1.Text);
				}
				else  //delete
				{
					_BaseCtrl.DeleteDefData(_Def);
				}

				this.Close();
			}
		}
        private void DefAddUpdate_MouseDown(object sender, MouseEventArgs e)
        {
			mousePoint = new Point(e.X, e.Y);
		}
        private void DefAddUpdate_MouseMove(object sender, MouseEventArgs e)
        {
			if (e.Button == MouseButtons.Left)
			{
				int x = mousePoint.X - e.X;
				int y = mousePoint.Y - e.Y;
				Location = new Point(this.Left - x, this.Top - y);
			}
		}

        private void btn_Close_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}
