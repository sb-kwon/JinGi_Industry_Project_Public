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
    public partial class Print_Form : Form
    {
        private Image printImage;
        private ProcessC _ProcessCtrl;
        private OrderChildOrder _OrderChildOrder;

        public Print_Form(ProcessC pro)
        {
            InitializeComponent();

            _ProcessCtrl = pro;
            _OrderChildOrder = new OrderChildOrder(_ProcessCtrl, this);
            SetTextBox();
            PanelSet(_OrderChildOrder, pnl_Order);
            _OrderChildOrder.DetailTextSave(pro);
            SetWorkDataList_Detail();
        }

        //--------------------------------------------------------------
        //Getter And Setter
        //--------------------------------------------------------------
        private void PanelSet(Form form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.Show();
        }
        private void txt_box_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            Label lbl = (Label)sender;

            lgsText = lbl.Text.Replace(",", "");
            lbl.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }
        private void SetWorkDataList_Detail()
        {
            dataGridView1.Rows.Clear();

            List<string[]> list = _ProcessCtrl.GetWorkDataList_Detail();
            if (list != null)
                foreach (string[] array in list)
                {
                    dataGridView1.Rows.Add(array[2], array[3], array[4], SetProcessState(array[6]), array[10], array[12], NullChange(array[13]), array[14]);
                }
        }
        private string NullChange(string str)
        {
            if (str == "") str = "검사 전";
            return str;
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

            return str;
        }
        public void SetTextBox()
        {
            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
            pic_BCR.Image = writer.Write(_ProcessCtrl.WorkInstruction.WorkinstructionNo.ToString());
            lbl_No.Text = _ProcessCtrl.WorkInstruction.WorkinstructionNo.ToString();
            lbl_State.Text = SetInstructionState(_ProcessCtrl.WorkInstruction.WorkinstructionState.ToString());
            lbl_Memo.Text = _ProcessCtrl.WorkInstruction.WorkinstructionMemo;
        }
        private String SetInstructionState(string state)
        {
            string str = "";

            if (state == "0") str = "대기";
            if (state == "1") str = "둥록";
            if (state == "2") str = "진행중";
            if (state == "3") str = "공정 완료";
            if (state == "4") str = "폐기";
            if (state == "5") str = "취소";
            if (state == "6") str = "품목 출고";
            if (state == "7") str = "출하";


            return str;
        }
        private void button1_Click(object sender, EventArgs e)
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
        private Bitmap GetBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));

            return bitmap;
        }
        private void PrintImage(Image image)
        {
            this.printImage = image;

            this.printPreviewDialog1.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic_Print_Click(object sender, EventArgs e)
        {
            /*string sDirPath = @"C:\imagesave";
            DirectoryInfo di = new DirectoryInfo(sDirPath);
            if (di.Exists == false)
            {
                di.Create();
            }폴더 만드는건데 안쓸꺼얌 kkw*/
            using (Bitmap bitmap = GetBitmap(panel3))
            {
                bitmap.Save(@"C:/PrintImage/print.jpg");
            }
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo = new ProcessStartInfo()
            //{
            //    CreateNoWindow = true,
            //    Verb = "print",
            //    FileName = @"C:/PrintImage/print.jpg" //put the correct path here
            //};
            //p.Start();

            File.Delete(@"C:/PrintImage/print.jpg");
        }
    }
}
