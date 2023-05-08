using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class OutDateForm : Form
    {
        private bool _kkw;
        private int _Result;
        private Point mousePoint;
        private ProcessC _ProcessCtrl;
        private Outsourcing_Status _OutForm;
        //public OutDateForm(bool kkw, ProcessC ProcessCtrl, Outsourcing_Status OutView)
        public OutDateForm(ProcessC ProcessCtrl)
        {
            InitializeComponent();

            _ProcessCtrl = ProcessCtrl;
            SetForm();
        }
        private void SetForm()
        {
            //if (_kkw == false) label_Text.Text = "입고 일자";
        }
        private void TimeSpan(int result)
        {
            DateTime OutTime = _ProcessCtrl.WorkProcess.BomOutTime;
            DateTime InTime = Dtp_Select.Value;

            _Result = DateTime.Compare(OutTime, InTime);
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            /*if (!(_kkw == false))
            {
                _ProcessCtrl.WorkProcess.BomOutTime = Dtp_Select.Value;
                _ProcessCtrl.OutInProduct(_kkw);
                _ProcessCtrl.OutProcess(_kkw);

                SetAlarm("출고 날짜 지정이 완료되었습니다.");
            }
            else
            {
                _ProcessCtrl.WorkProcess.BomInTime = Dtp_Select.Value;
                TimeSpan(_Result);

                if (_Result > 0) SetAlarm("입고 날짜가 출고 날짜보다 앞일 수 없습니다.");
                else
                {
                    _ProcessCtrl.OutInProduct(_kkw);
                    _ProcessCtrl.OutProcess(_kkw);

                    List<String[]> OutList = _ProcessCtrl.CheckWorkInstructionState();
                    foreach (String[] str in OutList)
                    {
                        if (str[0].ToString() == str[1].ToString())
                        {
                            _ProcessCtrl.OutProcess(_kkw);
                        }
                    }
                    List<String[]> FairList = _ProcessCtrl.ProcessCheckCompletion();
                    if (FairList != null)
                    {
                        foreach (String[] str in FairList)
                        {
                            if (str[0] == str[1])
                            {
                                _ProcessCtrl.UpdateProcessCompletion();
                            }
                        }
                    }
                    SetAlarm("입고 날짜 지정이 완료되었습니다.");
                }
            }*/
            _ProcessCtrl.WorkOrder.RealEndDate = Dtp_Select.Value.ToString("yyyy-MM-dd");
            this.Close();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            _ProcessCtrl.WorkOrder.OrderMemo = "1";
            MessageBox.Show("취소되었습니다.");
            this.Close();
        }
        private void OutDateForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void OutDateForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
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