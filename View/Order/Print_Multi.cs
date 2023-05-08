using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using Controller;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace View
{
    public partial class Print_Multi : Form
    {
        private System.Drawing.Image printImage;
        private List<ProcessC> _ProcessCtrl;
        private ProcessC _SelectPC;
        private OrderChildOrder _OrderChildOrder;

        public Print_Multi(List<ProcessC> pro)
        {
            InitializeComponent();

            _ProcessCtrl = pro;
            _SelectPC = _ProcessCtrl[0];
            _OrderChildOrder = new OrderChildOrder(_SelectPC, this);
            SetTextBox();
            PanelSet(_OrderChildOrder, pnl_Order);
            _OrderChildOrder.DetailTextSave(_SelectPC);
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
        private void SetWorkDataList_Detail()
        {
            dgv_Work.Rows.Clear();

            List<string[]> list = _SelectPC.GetWorkDataList_Detail();
            if (list != null)
                foreach (string[] array in list)
                {
                    dgv_Work.Rows.Add(array[2], array[3], array[4], SetProcessState(array[6]), array[10], array[12], NullChange(array[13]), array[14]);
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
        public void SetTextBox()
        {
            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
            pic_BCR.Image = writer.Write(_SelectPC.WorkInstruction.WorkinstructionNo.ToString());
            lbl_No.Text = _SelectPC.WorkInstruction.WorkinstructionNo.ToString();
            lbl_State.Text = SetInstructionState(_SelectPC.WorkInstruction.WorkinstructionState.ToString());
            lbl_Memo.Text = _SelectPC.WorkInstruction.WorkinstructionMemo;
        }
        #region 검색 Print
        private Bitmap GetBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, control.Width, control.Height));

            return bitmap;
        }
        private void pic_Print_Click(object sender, EventArgs e) //출력 사진 클릭
        {
            //string sDirPath = @"C:/Users/kkw95/Documents/imagesave"; 나중에 쓸지도 모르니까 놔둠 kkw
            //DirectoryInfo di = new DirectoryInfo(sDirPath);
            //
            //CreateCheck(di);
            //
            ////모든 폴더 삭제 하고
            //DirectoryInfo dir = new DirectoryInfo(sDirPath);
            //System.IO.FileInfo[] files = dir.GetFiles("*.*", SearchOption.AllDirectories);
            //
            //foreach (System.IO.FileInfo file in files)
            //    file.Attributes = FileAttributes.Normal;
            //Directory.Delete(sDirPath, true);
            //
            ////for 수량만큼 panel 찍어서 bitmap으로 저장
            //
            //if (CreateCheck(di))
            //{
            if (MessageBox.Show("작업지시서를 출력하시겠습니까?", "인쇄 확인창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int count = 0;
                string[] arg = new string[_ProcessCtrl.Count];
                string[] PDF = new string[_ProcessCtrl.Count];
                foreach (ProcessC pc in _ProcessCtrl)
                {
                    _SelectPC = pc;

                    SetTextBox();
                    _OrderChildOrder.DetailTextSave(_SelectPC);
                    SetWorkDataList_Detail();

                    using (Bitmap bitmap = GetBitmap(panel3))
                    {
                        bitmap.Save(@"C:/Users/kkw95/Documents/PrintPDF/print" + count + ".jpg");
                        arg[count] = @"C:/Users/kkw95/Documents/PrintPDF/print" + count + ".jpg";

                        string jpgfile = arg[count];
                        string pdf = @"C:/Users/kkw95/Documents/PrintPDF/kkw" + count + ".pdf";
                        PDF[count] = pdf;

                        ConvertJPG2PDF(jpgfile, pdf);
                    }
                    File.Delete(arg[count]);

                    count++;
                }
                string filename = @"C:/Users/kkw95/Documents/PrintPDF/new kkw.pdf";

                CombineMultiplePDF(PDF, filename);
                kkw();
                File.Delete(filename);
            }
            else MessageBox.Show("작업지시서 출력이 취소되었습니다.", "인쇄 취소창");
        }
        private void ConvertJPG2PDF(string jpgfile, string pdf) //사진 파일 PDF로 변환
        {
            var document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
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
            pdf.PrintSettings.PrinterName = "iR C3125";
            pdf.PrintSettings.SelectSomePages(new int[] { 2, 4 });
            pdf.PrintSettings.SelectPageRange(1, 15);
            pdf.Print();
        }
        //private bool CreateCheck(DirectoryInfo di)
        //{
        //    if (di.Exists == false)
        //    {
        //        di.Create();
        //    }
        //    return true;
        //} kkw 폴더 생성 체크해서 없으면 생성
        #endregion
        #region 검색 Button
        private void btn_Left_Click(object sender, EventArgs e)
        {
            //감소 왼쪽
            int value = Convert.ToInt32(lbl_PageNum.Text.Replace("Page",""));

            if (value > 1)
            {
                value = value - 1;
                lbl_PageNum.Text = value.ToString() + "Page";

                _SelectPC = _ProcessCtrl[value - 1];

                SetTextBox();
                _OrderChildOrder.DetailTextSave(_SelectPC);
                SetWorkDataList_Detail();
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

                SetTextBox();
                _OrderChildOrder.DetailTextSave(_SelectPC);
                SetWorkDataList_Detail();
            }
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}