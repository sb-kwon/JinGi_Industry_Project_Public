using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace View
{
    public partial class OrderRecipt : Form
    {
        private Image printImage;
        private string[] ViewList;
        private List<String[]> ViewList2;
        public OrderRecipt(string[] list1, List<string[]> list2, string str)
        {
            InitializeComponent();

            ViewList = list1;
            ViewList2 = list2;
            label3.Text = str;

            SetWorkDataList_Detail();
        }
        //--------------------------------------------------------------
        //Getter And Setter
        //--------------------------------------------------------------
        private void SetWorkDataList_Detail()
        {
            lbl_Today.Text = DateTime.Now.ToString("yyyyy-MM-dd HH:mm:ss");
            lbl_Date.Text = ViewList[0];
            lbl_Customer.Text = ViewList[1] + "귀하";
            lbl_Customer_Address.Text = ViewList[2];
            lbl_Customer_Phone.Text = ViewList[3];
            lbl_CustomerName.Text = ViewList[4];

            int sum = 0;
            if (ViewList2 != null)
                foreach (string[] str in ViewList2)
                {
                    dataGridView1.Rows.Add(str[0], str[1], str[2], str[3], str[4]);
                    if (str[4].Equals("")) str[4] = "0";
                    sum = sum + Convert.ToInt32(str[4].Replace(",", ""));
                }
            lbl_Total.Text = string.Format("{0:#,###}", sum);
            lbl_Tax.Text = string.Format("{0:#,###}", (sum / 10));
            int Total = 0;
            if (sum.Equals(0) || sum.Equals(1)) Total = 0;
            else Total = Convert.ToInt32(lbl_Total.Text.Replace(",", "")) + Convert.ToInt32(lbl_Tax.Text.Replace(",", ""));
            lbl_All_Price.Text = "합계 :    " + NumToString(Total) + " (￦ " + string.Format("{0:#,###}", Total) + ")";
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
        private string NumToString(Int64 Price)
        {
            string W = ""; string Y = ""; string HAmt = ""; string EAmt = "";
            Int64 KLen = 0; Int64 ELen = 0; int j = 0; int k = 0;
            try
            {
                EAmt = Price.ToString();
                ELen = EAmt.Length;
                k = 0;
                for (j = 0; j < ELen; j++)
                {
                    KLen = Convert.ToInt64(EAmt.Substring(j, 1));
                    switch (KLen)
                    {
                        case 1:
                            W = "일";
                            break;
                        case 2:
                            W = "이";
                            break;
                        case 3:
                            W = "삼";
                            break;
                        case 4:
                            W = "사";
                            break;
                        case 5:
                            W = "오";
                            break;
                        case 6:
                            W = "육";
                            break;
                        case 7:
                            W = "칠";
                            break;
                        case 8:
                            W = "팔";
                            break;
                        case 9:
                            W = "구";
                            break;
                        case 0:
                            W = "영";
                            break;
                    }
                    switch (ELen)
                    {
                        case 10:
                            Y = "십억천백십만천백십원";
                            break;
                        case 9:
                            Y = "억천백십만천백십원";
                            break;
                        case 8:
                            Y = "천백십만천백십원";
                            break;
                        case 7:
                            Y = "백십만천백십원";
                            break;
                        case 6:
                            Y = "십만천백십원";
                            break;
                        case 5:
                            Y = "만천백십원";
                            break;
                        case 4:
                            Y = "천백십원";
                            break;
                        case 3:
                            Y = "백십원";
                            break;
                        case 2:
                            Y = "십원";
                            break;
                        case 1:
                            Y = "원";
                            break;
                    }
                    if (W != "영")
                    {
                        HAmt = HAmt + (W + Y.Substring(k, 1));
                    }
                    if (Y.Substring(k, 1) == "억")
                    {
                        if (W == "영")
                        {
                            HAmt = HAmt + "억";
                        }
                    }
                    else if (Y.Substring(k, 1) == "만")
                    {
                        if (W == "영")
                        {
                            HAmt = HAmt + "만";
                        }
                    }
                    else if (Y.Substring(k, 1) == "원")
                    {
                        if (W == "영")
                        {
                            HAmt = HAmt + "원";
                        }
                    }
                    k = k + 1;
                }
                HAmt = HAmt + " 정";
            }
            catch (Exception err)
            {
                throw err;
            }
            return HAmt;
        }
    }
}