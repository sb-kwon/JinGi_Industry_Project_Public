using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using Controller;
using Model;
using System.Diagnostics;
using System.IO;

namespace View
{
    public partial class OrderDraftPrint : Form
    {
        private Image printImage;
        private List<String[]> ViewList;
        private OrderDraft _SeletedOrderDraft;
        public OrderDraftPrint(OrderDraft SeletedOrderDraft)
        {
            InitializeComponent();

            _SeletedOrderDraft = SeletedOrderDraft;
            SetWorkDataList_Detail();
        }

        //--------------------------------------------------------------
        //Getter And Setter
        //--------------------------------------------------------------
      

        private void SetWorkDataList_Detail()
        {
			textBox2.Text = _SeletedOrderDraft.Orderdraftcustomer;
			textBox3.Text = _SeletedOrderDraft.Orderdraftmemo;
			textBox4.Text = _SeletedOrderDraft.Orderdraftdate.Substring(0, 10);

			if (_SeletedOrderDraft.OrderDraftLists != null)
				foreach (OrderDraftList odl in _SeletedOrderDraft.OrderDraftLists)
					dataGridView1.Rows.Add(odl.Orderdraftlistname, odl.Orderdraftliststandard, odl.Orderdraftlistcount, odl.Orderdraftlistprice, odl.Orderdraftlisttax);

		}

		private Bitmap GetBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));

            return bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic_Print_Click(object sender, EventArgs e)
        {
            string sDirPath = @"C:\imagesave";
            DirectoryInfo di = new DirectoryInfo(sDirPath);
            if (di.Exists == false)
            {
                di.Create();
            }
            using (Bitmap bitmap = GetBitmap(panel3))
            {
                bitmap.Save(@"C:/imagesave/print.jpg");
                //PrintImage(bitmap);
            }
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = @"C:/imagesave/print.jpg" //put the correct path here
            };
            p.Start();
        }
    }
}
