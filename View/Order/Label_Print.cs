using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Controller;
using System.IO;
using System.Diagnostics;

namespace View
{
    public partial class Label_Print : Form
    {
        private String OrderNo, ProductName;
        private ProcessC _ProcessCtrl;
        private List<String[]> OrderName, ProductList;
        public Label_Print()
        {
            InitializeComponent();

            _ProcessCtrl = new ProcessC();
            GetOrderName();
        }
        private void GetOrderName()
        {
            Cb_PJT.Items.Clear();
            OrderName = _ProcessCtrl.GetOrderName();

            if (!(OrderName is null))
            {
                foreach (String[] str in OrderName)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = str[0];
                    cbi.Value = str[1];
                    Cb_PJT.Items.Add(cbi);
                }
            }
            OrderName.Clear();
        }
        private void Cb_PJT_TextChanged(object sender, EventArgs e)
        {
            foreach (ComboboxItem ci in Cb_PJT.Items)
            {
                if (ci.Text.Equals(Cb_PJT.Text))
                {
                    OrderNo = ci.Value.ToString();
                }
            }
            Cb_Product.Items.Clear();
            ProductList = _ProcessCtrl.GetProductList(OrderNo);

            if (!(ProductList is null))
            {
                foreach (String[] str in ProductList)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = str[0];
                    //lbl_Drawing.Text = str[1];
                    lbl_Start.Text = str[2];
                    lbl_End.Text = str[3];
                    //lbl_Count.Text = str[4] + "개";

                    Cb_Product.Items.Add(cbi);
                    Cb_Product.SelectedIndex = 0;
                }
            }
            ProductList.Clear();
        }
        private void Cb_Product_TextChanged(object sender, EventArgs e)
        {
            foreach (ComboboxItem ci in Cb_PJT.Items)
            {
                if (ci.Text.Equals(Cb_PJT.Text))
                {
                    OrderNo = ci.Value.ToString();
                }
            }
            foreach (ComboboxItem ci in Cb_Product.Items)
            {
                if (ci.Text.Equals(Cb_Product.Text))
                {
                    ProductName = ci.Text;
                }
            }
            ProductList = _ProcessCtrl.ProductData(ProductName, OrderNo);

            if (!(ProductList is null))
            {
                foreach (String[] str in ProductList)
                {
                    lbl_Drawing.Text = str[1];
                    lbl_Count.Text = str[2] + "개";
                }
            }
            ProductList.Clear();
        }
        private void pic_Print_Click(object sender, EventArgs e)
        {
            File.Delete(@"C:/PrintImage/print.jpg");

            using (Bitmap bitmap = GetBitmap(panel14))
            {
                bitmap.Save(@"C:/PrintImage/print.jpg");
            }
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = @"C:/PrintImage/print.jpg", //put the correct path here
            };
            p.Start();
        }
        private void DTP_RealEnd_ValueChanged(object sender, EventArgs e)
        {
            DTP_RealEnd.Visible = false;
            lbl_RealEnd.Text = DTP_RealEnd.Value.ToString("yyyy년 MM월 dd일");
        }
        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            DTP_RealEnd.Visible = true;
            lbl_RealEnd.Text = "납품일";
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Bitmap GetBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));

            return bitmap;
        }
    }
}