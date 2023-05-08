using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Controller;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Threading;

namespace View
{
    public partial class Label_Print_Multi : Form
    {
        private ProcessC _SelectPC;
        private ProcessC _ProcessC;
        private String OrderNo, ProductName;
        private List<ProcessC> _ProcessCtrl;
        private List<String[]> OrderName, ProductList;
        public Label_Print_Multi(List<ProcessC> pro)
        {
            InitializeComponent();
            _ProcessCtrl = pro;
            _ProcessC = new ProcessC();
            _SelectPC = _ProcessCtrl[0];
            GetOrderName();
            SetTextBox(_SelectPC);
        }
        private void SetTextBox(ProcessC pro)
        {
            Cb_PJT.Text = pro.WorkOrder.OrderName;
            Cb_Product.Text = pro.Product.ProductName;
            lbl_Customer.Text = pro.WorkOrder.CustomerName;
        }
        private void btn_Left_Click(object sender, EventArgs e)
        {
            //감소 왼쪽
            int value = Convert.ToInt32(lbl_PageNum.Text.Replace("Page", ""));

            if (value > 1)
            {
                value = value - 1;
                lbl_PageNum.Text = value.ToString() + "Page";

                _SelectPC = _ProcessCtrl[value - 1];

                SetTextBox(_SelectPC);
            }
        }
        private void btn_Right_Click(object sender, EventArgs e)
        {
            //증가 오른쪽
            int value = Convert.ToInt32(lbl_PageNum.Text.Replace("Page", ""));

            if (value < _ProcessCtrl.Count)
            {
                value = value + 1;
                lbl_PageNum.Text = value.ToString() + "Page";

                _SelectPC = _ProcessCtrl[value - 1];

                SetTextBox(_SelectPC);
            }
        }
        private void GetOrderName()
        {
            Cb_PJT.Items.Clear();
            OrderName = _SelectPC.GetOrderName();

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
            ProductList = _SelectPC.GetProductList(OrderNo);

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
                    lbl_RealEnd.Text = str[5];

                    Cb_Product.Items.Add(cbi);
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
            ProductList = _SelectPC.ProductData(ProductName, OrderNo);

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
            int Count = _ProcessCtrl.Count;
               
            if (MessageBox.Show("현품표를 출력하시겠습니까?", "인쇄 확인창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _ProcessC.InsertLabelTime(Count);
                int count = 0;
                string[] arg = new string[_ProcessCtrl.Count];
                string[] PDF = new string[_ProcessCtrl.Count];
                foreach (ProcessC pc in _ProcessCtrl)
                {
                    _SelectPC = pc;
                    SetTextBox(_SelectPC);

                    using (Bitmap bitmap = GetBitmap(panel14))
                    {
                        bitmap.Save(@"C:/Users/kkw95/Documents/PrintPDF/print" + count + ".jpg");
                        arg[count] = @"C:/Users/kkw95/Documents/PrintPDF/print" + count + ".jpg";

                        //bitmap.Save(@"C:\PrintPDF/print" + count + ".jpg");
                        //arg[count] = @"C:\PrintPDF/print" + count + ".jpg";

                        string jpgfile = arg[count];
                        string pdf = @"C:/Users/kkw95/Documents/PrintPDF/kkw" + count + ".pdf";
                        //string pdf = @"C:\PrintPDF/kkw" + count + ".pdf";
                        PDF[count] = pdf;

                        ConvertJPG2PDF(jpgfile, pdf);
                    }
                    File.Delete(arg[count]);

                    count++;
                }
                //string filename = @"C:\PrintPDF/new kkw.pdf";
                string filename = @"C:/Users/kkw95/Documents/PrintPDF/new kkw.pdf";

                CombineMultiplePDF(PDF, filename);
                kkw();
                File.Delete(filename);
                _ProcessC.UpdateLabelTime();
            }
            else MessageBox.Show("현품표 출력이 취소되었습니다.", "인쇄 취소창");
        }
        private void ConvertJPG2PDF(string jpgfile, string pdf) //사진 파일 PDF로 변환
        {
            var document = new Document(iTextSharp.text.PageSize.A6, 0, 70, 120, 0);
            using (var stream = new FileStream(pdf, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                using (var imageStream = new FileStream(jpgfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imageStream);
                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    document.Add(image);
                }
                document.Close();
            }
        }
        public static void CombineMultiplePDF(string[] fileNames, string outFile) //PDF 병합
        {
            Document document = new Document();
            using (FileStream newFileStream = new FileStream(outFile, FileMode.Create))
            {
                PdfCopy writer = new PdfCopy(document, newFileStream);
                if (writer == null)
                {
                    return;
                }
                document.Open();

                foreach (string fileName in fileNames)
                {
                    PdfReader reader = new PdfReader(fileName);
                    reader.ConsolidateNamedDestinations();

                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        page.Height = 325;
                        page.Width = 272;
                        writer.AddPage(page);
                        File.Delete(fileName);
                    }

                    PRAcroForm form = reader.AcroForm;
                    if (form != null)
                    {
                        writer.CopyAcroForm(reader);
                    }
                    reader.Close();
                }
                writer.Close();
                document.Close();
            }
        }
        private void kkw() //인쇄
        {
            Spire.Pdf.PdfDocument pdf = new Spire.Pdf.PdfDocument();
            pdf.LoadFromFile(@"C:/Users/kkw95/Documents/PrintPDF/new kkw.pdf");
            pdf.PrintSettings.PrinterName = "TSC TTP-244 Pro";
            //pdf.PrintSettings.SelectSomePages(new int[] { 1, 3 }); // 1, 3번 페이지'만' 출력
            pdf.PrintSettings.SelectPageRange(1, pdf.Pages.Count); // 1~N번 페이지 모두 출력
            pdf.Print();
             //라벨 프린터 멀티 쓸라면 Adobe 깔아야함
            //string Filepath = @"C:\PrintPDF/new kkw.pdf";
            //string Filepath = @"C:/Users/kkw95/Documents/PrintPDF/new kkw.pdf";

            /*using (PrintDialog Dialog = new PrintDialog())
            {
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    System.Diagnostics.Process printProcess = new System.Diagnostics.Process();
                    printProcess.StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        Verb = "PrintTo",
                        FileName = Filepath,
                        Arguments = "\"" + Dialog.PrinterSettings.PrinterName + "\"",
                    };
                   printProcess.Start();
                   printProcess.WaitForInputIdle();
                   
                   Thread.Sleep(3000);
                   
                   if (false == printProcess.CloseMainWindow())
                   {
                       printProcess.Kill();
                   }
                }
                else
                {
                    _ProcessC.DeleteLabelTime();
                }
            }*/
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Bitmap GetBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, control.Width, control.Height));

            return bitmap;
        }
    }
}