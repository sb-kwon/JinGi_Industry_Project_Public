using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class Equipment_Monitoring : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private MachineC _MachineCtrl;
        public Equipment_Monitoring(Member member, BasicForm form)
        {
            InitializeComponent();
            _LoginInfo = member;
            _Mother = form;
            _MachineCtrl = new MachineC();
        }
        private void Equipment_Monitoring_Load(object sender, EventArgs e)
        {
            InvokoClear();
            SetData();
        }
        #region IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            InvokoClear();
            SetData();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            InvokoClear();
            SetData();
        }
        #endregion
        #region Method
        private void InvokoClear()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => dgv_Monitoring.Rows.Clear()));
            }
            else
            {
                dgv_Monitoring.Rows.Clear();
            }
        }
        private void SetData()
        {
            Dictionary<String, LiveMonitor> keyValuePairs = _MachineCtrl.keyValuePairs();

            if (!(keyValuePairs is null))
            {
                foreach (KeyValuePair<String, LiveMonitor> monitor in keyValuePairs)
                {
                    InvokeHub(monitor.Value);
                }
            }
        }
        private void InvokeHub(LiveMonitor monitor)
        {
            dgv_Monitoring.Rows.Clear();
            string state = "";
            if(monitor.MachineValue != null)
            {
                if (monitor.MachineValue.Equals("Operation")) state = "Operation";
                else if (monitor.MachineValue.Equals("Unoperation")) state = "Unoperation";
                else state = "";
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    dgv_Monitoring.Rows.Add(monitor.MachineName, monitor.Time, state, monitor.MachineValue)));
                    if (circularProgressBar1.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation") )
                    {
                        circularProgressBar1.Text = monitor.MachineName;
                        circularProgressBar1.SubscriptText = "가동중";
                        circularProgressBar1.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar1.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar1.Text = monitor.MachineName;
                        circularProgressBar1.SubscriptText = "비가동";
                        circularProgressBar1.ProgressColor = Color.DarkOrange;
                        circularProgressBar1.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar2.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar2.Text = monitor.MachineName;
                        circularProgressBar2.SubscriptText = "가동중";
                        circularProgressBar2.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar1.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar2.Text = monitor.MachineName;
                        circularProgressBar2.SubscriptText = "비가동";
                        circularProgressBar2.ProgressColor = Color.DarkOrange;
                        circularProgressBar2.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar3.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar3.Text = monitor.MachineName;
                        circularProgressBar3.SubscriptText = "가동중";
                        circularProgressBar3.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar3.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar3.Text = monitor.MachineName;
                        circularProgressBar3.SubscriptText = "비가동";
                        circularProgressBar3.ProgressColor = Color.DarkOrange;
                        circularProgressBar3.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar4.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar4.Text = monitor.MachineName;
                        circularProgressBar4.SubscriptText = "가동중";
                        circularProgressBar4.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar4.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar4.Text = monitor.MachineName;
                        circularProgressBar4.SubscriptText = "비가동";
                        circularProgressBar4.ProgressColor = Color.DarkOrange;
                        circularProgressBar4.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar5.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar5.Text = monitor.MachineName;
                        circularProgressBar5.SubscriptText = "가동중";
                        circularProgressBar5.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar5.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar5.Text = monitor.MachineName;
                        circularProgressBar5.SubscriptText = "비가동";
                        circularProgressBar5.ProgressColor = Color.DarkOrange;
                        circularProgressBar5.Style = ProgressBarStyle.Blocks;
                    }
                    /*if (circularProgressBar6.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation") || monitor.MachineValue.Equals(""))
                    {                      
                        circularProgressBar6.Text = monitor.MachineName;
                        circularProgressBar6.SubscriptText = "가동중";
                        circularProgressBar6.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar6.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar6.Text = monitor.MachineName;
                        circularProgressBar6.SubscriptText = "비가동";
                        circularProgressBar6.ProgressColor = Color.DarkOrange;
                        circularProgressBar6.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar7.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {                      
                        circularProgressBar7.Text = monitor.MachineName;
                        circularProgressBar7.SubscriptText = "가동중";
                        circularProgressBar7.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar7.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar7.Text = monitor.MachineName;
                        circularProgressBar7.SubscriptText = "비가동";
                        circularProgressBar7.ProgressColor = Color.DarkOrange;
                        circularProgressBar7.Style = ProgressBarStyle.Blocks;
                    }*/
                }
                else
                {
                    dgv_Monitoring.Rows.Add(monitor.MachineName, monitor.Time, state, monitor.MachineValue);
                    if (circularProgressBar1.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar1.Text = monitor.MachineName;
                        circularProgressBar1.SubscriptText = "가동중";
                        circularProgressBar1.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar1.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar1.Text = monitor.MachineName;
                        circularProgressBar1.SubscriptText = "비가동";
                        circularProgressBar1.ProgressColor = Color.DarkOrange;
                        circularProgressBar1.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar2.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar2.Text = monitor.MachineName;
                        circularProgressBar2.SubscriptText = "가동중";
                        circularProgressBar2.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar2.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar2.Text = monitor.MachineName;
                        circularProgressBar2.SubscriptText = "비가동";
                        circularProgressBar2.ProgressColor = Color.DarkOrange;
                        circularProgressBar2.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar3.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar3.Text = monitor.MachineName;
                        circularProgressBar3.SubscriptText = "가동중";
                        circularProgressBar3.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar3.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar3.Text = monitor.MachineName;
                        circularProgressBar3.SubscriptText = "비가동";
                        circularProgressBar3.ProgressColor = Color.DarkOrange;
                        circularProgressBar3.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar4.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar4.Text = monitor.MachineName;
                        circularProgressBar4.SubscriptText = "가동중";
                        circularProgressBar4.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar4.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar4.Text = monitor.MachineName;
                        circularProgressBar4.SubscriptText = "비가동";
                        circularProgressBar4.ProgressColor = Color.DarkOrange;
                        circularProgressBar4.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar5.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {
                        circularProgressBar5.Text = monitor.MachineName;
                        circularProgressBar5.SubscriptText = "가동중";
                        circularProgressBar5.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar5.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar5.Text = monitor.MachineName;
                        circularProgressBar5.SubscriptText = "비가동";
                        circularProgressBar5.ProgressColor = Color.DarkOrange;
                        circularProgressBar5.Style = ProgressBarStyle.Blocks;
                    }
                    /*if (circularProgressBar6.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation") || monitor.MachineValue.Equals(""))
                    {                      
                        circularProgressBar6.Text = monitor.MachineName;
                        circularProgressBar6.SubscriptText = "가동중";
                        circularProgressBar6.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar6.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar6.Text = monitor.MachineName;
                        circularProgressBar6.SubscriptText = "비가동";
                        circularProgressBar6.ProgressColor = Color.DarkOrange;
                        circularProgressBar6.Style = ProgressBarStyle.Blocks;
                    }
                    if (circularProgressBar7.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Operation"))
                    {                      
                        circularProgressBar7.Text = monitor.MachineName;
                        circularProgressBar7.SubscriptText = "가동중";
                        circularProgressBar7.ProgressColor = Color.Lime;
                    }
                    else if (circularProgressBar7.Tag.Equals(monitor.MachineName) && monitor.MachineValue.Equals("Unoperation"))
                    {
                        circularProgressBar7.Text = monitor.MachineName;
                        circularProgressBar7.SubscriptText = "비가동";
                        circularProgressBar7.ProgressColor = Color.DarkOrange;
                        circularProgressBar7.Style = ProgressBarStyle.Blocks;
                    }*/
                }
            }
        }
        #endregion
    }
}