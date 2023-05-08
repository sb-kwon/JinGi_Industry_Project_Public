using Controller;
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
    public partial class NumberKey : Form
    {
        Form _Form;
        public NumberKey(Form Mother, String RetunText)
        {
            InitializeComponent();

            _Form = Mother;
            tb_Result.Text = RetunText;
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            tb_Result.Text = tb_Result.Text + btn.Text;
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            tb_Result.Text = "";
        }
        private void Btn_Min_Click(object sender, EventArgs e)
        {
            Double result = Double.Parse(tb_Result.Text);
            result = result * -1;
            tb_Result.Text = result.ToString();
        }

        private void Btn_Insert_Click(object sender, EventArgs e)
        {
            if (tb_Result.Text.Length > 0)
            {
                _Form.Tag = tb_Result.Text;
            }
            this.Close();
        }
    }
}
