using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.ETC
{
    public partial class KeyBoard : Form
    {
        private String mTbName = "";
        private Label _TB;
        private Form _form;
        Boolean mTransferKey;
        String mBildStr;

        public KeyBoard(Form from, Label tb)
        {
            InitializeComponent();

            _form = from;
            mTransferKey = false;
            _TB = tb;
            mTbName = tb.Name;
            mBildStr = tb.Text;
            tb_resultText.Text = mBildStr;
        }

        private void Button55_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Click_Char(object sender, EventArgs e)
        {
            Button btn_Send = sender as Button;
            mBildStr = mBildStr + btn_Send.Text;
            tb_resultText.Text = mBildStr;

            if (mTransferKey)
            {
                SetEnableBtnByName();
                mTransferKey = false;
            }

        }

        public void SetEnableBtnByName()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Tag != null && this.Controls[i].Tag.ToString() != "0")
                {
                    String trans = "";
                    trans = this.Controls[i].Tag.ToString();
                    this.Controls[i].Tag = this.Controls[i].Text;
                    this.Controls[i].Text = trans;
                }
            }
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            SetEnableBtnByName();
        }

        private void Click_Shift(object sender, EventArgs e)
        {
            mTransferKey = !mTransferKey;
            SetEnableBtnByName();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            mBildStr = "";
            tb_resultText.Text = mBildStr;
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            mBildStr = mBildStr.Substring(0, mBildStr.Length - 1);
            tb_resultText.Text = mBildStr;
        }

        private void Button41_Click(object sender, EventArgs e)
        {
            _TB.Text = mBildStr;
            _form.Tag = _TB;
            this.Close();
        }

        private void Button54_Click(object sender, EventArgs e)
        {
            mBildStr = mBildStr + " ";
        }

        private void Button56_Click(object sender, EventArgs e)
        {
            //mBildStr = mBildStr + System.Environment.NewLine;
            //      mainform.SetData(mTbName, tb_resultText.Text);
            _TB.Text = mBildStr;
            _form.Tag = _TB;
            this.Close();
        }
    }
}
