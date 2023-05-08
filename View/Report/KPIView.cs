using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace View
{
    public partial class KPIView : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private KpiCtrl _KPICtrl;
        private List<work_process> _work_process;
        private List<work_process> _work_process2;
        private List<Quality> _Quality;
        private work_process _wp;

        DateTime SetMonthsNextDate, SetMonthsPreviousDate;
        public double a = 0, b = 0, c = 0, k = 0, w = 0, h = 0;
        string[] ItemList;
        public KPIView(Member member, BasicForm form)
        {
            InitializeComponent();

            _LoginInfo = member;
            _Mother = form;
            _KPICtrl = new KpiCtrl();
            _wp = new work_process();

            ComboboxList();
        }
        //-----------------------------------------------------
        //Getter And Setter
        //-----------------------------------------------------
        public List<work_process> work_process
        {
            get
            {
                return _work_process;
            }
            set
            {
                _work_process = value;
            }
        }
        public List<work_process> work_process2
        {
            get
            {
                return _work_process2;
            }
            set
            {
                _work_process2 = value;
            }
        }
        public List<Quality> Quality
        {
            get
            {
                return _Quality;
            }
            set
            {
                _Quality = value;
            }
        }
        private void PChart()
        {
            dataGridView1.Rows.Clear();

            int cnt = 0, icnt = 0;

            // 그리드 뿌려줄 거 가져오기
            work_process = _KPICtrl.GetPChart(comboBox1.Text);

            cnt = work_process.Count;
            icnt = cnt - 1;
            for (int j = 0; j < work_process.Count; j++)
            {
                dataGridView1.Rows.Add(0, 0, 0);
            }
            foreach (work_process wp in work_process)
            {
                dataGridView1.Rows[icnt].Cells[0].Value = wp.EndTimeMonth;
                dataGridView1.Rows[icnt].Cells[1].Value = wp.workProcessTimestampdiff;
                dataGridView1.Rows[icnt].Cells[2].Value = wp.KPITotalAmount;

                icnt--;
                if (icnt == -1)
                    break;
            }
            if (cnt != 0)
            {
                chart1.Series.Clear();
                chart2.Series.Clear();

                TextboxReset();

                foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                {
                    string seriesname = "PChart";

                    if (dataGridView1.Rows[0].Cells[0].Value != null && textBox1.Text == "")
                    {
                        chart2.Series.Add(seriesname);
                        chart2.Series[seriesname].ChartType = SeriesChartType.Doughnut;
                        chart2.Series[seriesname].Points.AddXY("총 제작시간", dataGridView1.Rows[0].Cells[1].Value);
                        chart2.Series[seriesname].Points.AddXY("총 제작수량", dataGridView1.Rows[0].Cells[2].Value);

                        textBox3.Text = dgvr.Cells[0].Value.ToString().Substring(5, 2) + "월";

                        int z = Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value) / 60;
                        int x = Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value) % 60;
                        if (dataGridView1.Rows[0].Cells[2].Value == null)
                        {
                            //label39.Text = "0";

                            textBox1.Text = z + "시간" + x + "분";//dataGridView1.Rows[0].Cells[1].Value.ToString();
                        }
                        else
                        {
                            textBox1.Text = z + "시간" + x + "분";//dataGridView1.Rows[0].Cells[1].Value.ToString();
                            textBox2.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                        }
                        Calculation(true);
                        label43.Text = string.Format("{0:0.#}", c) + "분";
                        Shortening(true);
                        lbl_h.Text = string.Format("{0:0.#}", k) + "%";
                    }
                    else if (dataGridView1.Rows[0].Cells[0].Value != null && dataGridView1.Rows[1].Cells[1].Value != null && textBox6.Text == "")
                    {
                        chart1.Series.Add(seriesname);
                        chart1.Series[seriesname].ChartType = SeriesChartType.Doughnut;
                        chart1.Series[seriesname].Points.AddXY("총 제작시간", dataGridView1.Rows[1].Cells[1].Value);
                        chart1.Series[seriesname].Points.AddXY("총 제작수량", dataGridView1.Rows[1].Cells[2].Value);

                        textBox4.Text = dgvr.Cells[0].Value.ToString().Substring(5, 2) + "월";

                        int m = Convert.ToInt32(dataGridView1.Rows[1].Cells[1].Value) / 60;
                        int v = Convert.ToInt32(dataGridView1.Rows[1].Cells[1].Value) % 60;

                        if (dataGridView1.Rows[1].Cells[2].Value == null)
                        {
                            //label32.Text = "0";
                            textBox1.Text = m + "시간" + v + "분";//dataGridView1.Rows[1].Cells[1].Value.ToString();
                        }
                        else
                        {
                            textBox6.Text = m + "시간" + v + "분";//dataGridView1.Rows[1].Cells[1].Value.ToString();
                            textBox5.Text = dataGridView1.Rows[1].Cells[2].Value.ToString();
                        }
                        Calculation(false);
                        label6.Text = string.Format("{0:0.#}", c) + "분";
                        Shortening(false);
                        lbl_k.Text = string.Format("{0:0.#}", h) + "%";
                    }
                }
            }
        }
        private void Calculation(bool type)
        {
            if (type == true) //첫번째 차트
            {
                a = double.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                b = double.Parse(textBox2.Text);
            }
            else
            {
                a = double.Parse(dataGridView1.Rows[1].Cells[1].Value.ToString());
                b = double.Parse(textBox5.Text);
            }
            c = a / b;
        }
        private void Shortening(bool type)
        {
            if (type == true)
            {

                k = double.Parse(c.ToString());
            }
            else
            {

                w = double.Parse(c.ToString());
            }
            h = (k - w) / k * 100;
        }
        private void TextboxReset()
        {
            textBox3.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox5.Text = string.Empty;
            label6.Text = "";
            label43.Text = "";
        }
        private void QChart()
        {
            dataGridView2.Rows.Clear();

            double a = 0, b = 0, c = 0;
            int cnt = 0, icnt = 0;

            // 그리드 뿌려줄 거 가져오기
            Quality = _KPICtrl.GetQChart(comboBox2.Text);

            work_process2 = _KPICtrl.total(comboBox2.Text);

            //cnt = work_process2.Count;
            icnt = cnt - 1;
            int count1 = 0;
            for (int j = 0; j < 2; j++)
            {
                dataGridView2.Rows.Add(0, 0, 0);
            }
            if (Quality != null)
            {
                foreach (Quality qu in Quality)
                {
                    dataGridView2.Rows[count1].Cells[0].Value = qu.qualityCompletiontime;
                    dataGridView2.Rows[count1].Cells[1].Value = qu.KPIDefectTotalAmount;
                    count1++;
                }
            }
            count1 = 0;
            if (work_process2 != null)
            {
                foreach (work_process wp in work_process2)
                {
                    foreach (DataGridViewRow dgvr in dataGridView2.Rows)
                    {
                        if (dgvr.Cells[0].Value.Equals(wp.EndTimeMonth))
                        {
                            //dgvr.Cells[0].Value = wp.EndTimeMonth;
                            dgvr.Cells[2].Value = wp.KPITotalAmount;
                        }
                    }
                    count1++;
                }
            }
            if (Quality != null)
            {
                chart4.Series.Clear();
                chart3.Series.Clear();

                TextboxReset2();

                foreach (DataGridViewRow dgvr in dataGridView2.Rows)
                {
                    string seriesname = "QChart";

                    if (dataGridView2.Rows[0].Cells[0].Value != null && textBox11.Text == "")
                    {
                        int V = Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value) - Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value);
                        chart4.Series.Add(seriesname);
                        chart4.Series[seriesname].ChartType = SeriesChartType.Doughnut;
                        chart4.Series[seriesname].Points.AddXY("양품 개수", V);
                        chart4.Series[seriesname].Points.AddXY("현재 불량 건 수", dataGridView2.Rows[0].Cells[1].Value);
                        chart4.Series[0].Points[0].Color = Color.Lime;
                        chart4.Series[0].Points[1].Color = Color.Red;

                        textBox10.Text = dgvr.Cells[0].Value.ToString().Substring(5, 2) + "월";

                        a = double.Parse(dataGridView2.Rows[0].Cells[2].Value.ToString());
                        b = double.Parse(dataGridView2.Rows[0].Cells[1].Value.ToString());

                        c = b / a * 100;
                        //c = 100 - Math.Abs(c);
                        //c = Math.Abs(c);

                        label15.Text = string.Format("{0:0.#}", c) + "%";

                        if (dataGridView2.Rows[0].Cells[2].Value == null)
                        {
                            //label39.Text = "0";
                            textBox1.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                        }
                        else
                        {
                            textBox12.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();
                            textBox11.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                        }
                    }
                    else if (dataGridView2.Rows[0].Cells[1].Value != null && dataGridView2.Rows[1].Cells[1].Value != null && textBox8.Text == "" && dgvr.Cells[0].Value.ToString() != "0")
                    {
                        int G = Convert.ToInt32(dataGridView2.Rows[1].Cells[2].Value) - Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value);
                        chart3.Series.Add(seriesname);
                        chart3.Series[seriesname].ChartType = SeriesChartType.Doughnut;
                        chart3.Series[seriesname].Points.AddXY("양품 개수", G);
                        chart3.Series[seriesname].Points.AddXY("현재 불량 건 수", dataGridView2.Rows[1].Cells[1].Value);
                        chart3.Series[0].Points[0].Color = Color.Lime;
                        chart3.Series[0].Points[1].Color = Color.Red;
                        textBox7.Text = dgvr.Cells[0].Value.ToString().Substring(5, 2) + "월";

                        a = double.Parse(dataGridView2.Rows[1].Cells[2].Value.ToString());
                        b = double.Parse(dataGridView2.Rows[1].Cells[1].Value.ToString());

                        c = b / a * 100;
                        //c = 100 - Math.Abs(c);
                        //c = Math.Abs(c);

                        label11.Text = string.Format("{0:0.#}", c) + "%";

                        if (dataGridView2.Rows[1].Cells[2].Value == null)
                        {

                            textBox1.Text = dataGridView2.Rows[1].Cells[1].Value.ToString();
                        }
                        else
                        {
                            textBox9.Text = dataGridView2.Rows[1].Cells[2].Value.ToString();
                            textBox8.Text = dataGridView2.Rows[1].Cells[1].Value.ToString();
                        }
                    }
                }
            }
        }
        private void TextboxReset2()
        {
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox12.Text = string.Empty;
            label11.Text = "";
            label15.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag.ToString() == "p" && dataGridView1.Rows.Count != 1)
                MonthsPrevious(btn.Tag.ToString());
            else if (btn.Tag.ToString() == "q" && dataGridView2.Rows[1].Cells[0].Value != "0")
                MonthsPrevious(btn.Tag.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Tag.ToString() == "q" && dataGridView2.Rows[1].Cells[0].Value != "0")
                MonthsNext(btn.Tag.ToString());
            else if (btn.Tag.ToString() == "p")
                MonthsNext(btn.Tag.ToString());
        }
        private void MonthsPrevious(string tag)
        {
            if (tag == "p") //제조리드
            {
                DateTime months = DateTime.Parse(comboBox1.Text + "-01");
                SetMonthsPreviousDate = months.AddMonths(-1);
                comboBox1.SelectedItem = SetMonthsPreviousDate.ToString().Substring(0, 7);
            }
            else
            {
                DateTime months = DateTime.Parse(comboBox2.Text + "-01");
                SetMonthsPreviousDate = months.AddMonths(-1);
                comboBox2.SelectedItem = SetMonthsPreviousDate.ToString().Substring(0, 7);
            }
        }
        private void MonthsNext(string tag)
        {
            if (tag == "p") //제조리드
            {
                DateTime months = DateTime.Parse(comboBox1.Text + "-01");
                SetMonthsNextDate = months.AddMonths(+1);
                comboBox1.SelectedItem = SetMonthsNextDate.ToString().Substring(0, 7);
            }
            else
            {
                DateTime months = DateTime.Parse(comboBox2.Text + "-01");
                SetMonthsNextDate = months.AddMonths(+1);
                comboBox2.SelectedItem = SetMonthsNextDate.ToString().Substring(0, 7);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PChart();
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            QChart();
        }
        private void ComboboxList()
        {
            //리드타임
            comboBox1.Items.Clear();

            ComboListUp(true);

            //불량율
            comboBox2.Items.Clear();

            ComboListUp(true);
        }
        private void ComboListUp(bool type)
        {
            List<String> list = new List<string>();
            list = _KPICtrl.ComboListUp(type);

            if (!(list is null))
            {
                int cnt = 0;
                ItemList = new string[list.Count];
                foreach (string str in list)
                {
                    ItemList[cnt] = str;
                    cnt++;
                }

                if (type == true) //제조리드
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(ItemList);
                    if (comboBox1.Items.Count != 0)
                        comboBox1.SelectedIndex = 0;

                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(ItemList);
                    if (comboBox2.Items.Count != 0)
                        comboBox2.SelectedIndex = 0;
                }
                else if (type == false)
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(ItemList);
                    if (comboBox2.Items.Count != 0)
                        comboBox2.SelectedIndex = 0;
                }

                list.Clear();
            }
        }
        //-----------------------------------------------------
        //InterFace
        //-----------------------------------------------------
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            ComboboxList();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
    }
}