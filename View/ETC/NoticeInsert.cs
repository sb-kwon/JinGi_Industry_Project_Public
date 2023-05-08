using Controller;
using Model.Material;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class NoticeInsert : Form
    {
        private NoticeView _form1;
        private String _UserId;
        private String _Type;
        private Notice _Notice;

        public NoticeInsert(NoticeView form, string str, string type, Notice n)
        {
            InitializeComponent();

            _form1 = form;
            _UserId = str;
            _Notice = n;
            _Type = type;
            ViewInit();
        }

        private void ViewInit()
        {
            switch (_Type)
            {
                case "Add":
                    label2.Text = "※공지 추가";
                    button1.Text = "+ 신규 공지 등록";
                    break;

                case "Update":
                    label2.Text = "※공지 수정";
                    button1.Text = "+ 기존 공지 수정";

                    textBox1.Text = _Notice.NoticeTitle;
                    textBox3.Text = _Notice.NoticeContent;

                    textBox1.Enabled = true;
                    textBox3.Enabled = true;
                    break;

                case "Delete":
                    label2.Text = "※공지 삭제";
                    button1.Text = "+ 기존 공지 삭제";
                    textBox1.Text = _Notice.NoticeTitle;
                    textBox3.Text = _Notice.NoticeContent;

                    textBox1.Enabled = false;
                    textBox3.Enabled = false;
                    break;

                case "View":
                    label2.Text = "※공지";
                    button1.Visible = false;
                    textBox1.Text = _Notice.NoticeTitle;
                    textBox3.Text = _Notice.NoticeContent;

                    textBox1.Enabled = false;
                    textBox3.Enabled = false;

                    if (_form1._LoginInfo.Membername.Equals(_Notice.memberId))
                    {
                        button2.Visible = true;
                        button3.Visible = true;
                    }
                    break;

                case "Sys":
                    label2.Text = "※시스템 이력 : " + _Notice.memberId;
                    button1.Visible = false;

                    textBox1.Text = _Notice.NoticeTitle;
                    textBox3.Text = _Notice.NoticeContent;

                    textBox1.Enabled = false;
                    textBox3.Enabled = false;

                    if (_form1._LoginInfo.Membername.Equals(_Notice.memberId))
                    {
                        button2.Visible = true;
                        button3.Visible = true;
                    }
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_Type.Equals("Add"))
            {
                Notice n = new Notice();
                n.memberId = _UserId;
                n.NoticeTitle = textBox1.Text;
                n.NoticeContent = textBox3.Text;

                _form1._NoticeCtrl.AddNotice(n);
            }
            else if (_Type.Equals("Update"))
            {
                Notice n = _Notice;

                n.NoticeTitle = textBox1.Text;
                n.NoticeContent = textBox3.Text;

                _form1._NoticeCtrl.ModifyNotice(n);
            }
            else if (_Type.Equals("Delete"))
            {
                Notice n = _Notice;

                _form1._NoticeCtrl.DelNotice(n);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            _Type = "Update";
            ViewInit();


            button2.BackColor = Color.FromArgb(255, 128, 0);
            button3.BackColor = Color.FromArgb(48, 103, 162);

            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _Type = "Delete";
            ViewInit();

            button3.BackColor = Color.FromArgb(255, 128, 0);
            button2.BackColor = Color.FromArgb(48, 103, 162);

            button1.Visible = true;

        }
    }
}
