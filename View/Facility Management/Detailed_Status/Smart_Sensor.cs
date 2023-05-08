using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class Smart_Sensor : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private MachineC _MachineCtrl;
        public Smart_Sensor(Member member, BasicForm form)
        {
            InitializeComponent();
            _MachineCtrl = new MachineC();
            _LoginInfo = member;
            _Mother = form;
            GetData();
        }
        #region IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            ;
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
#endregion
        private void GetData()
        {
            dgv_order.Rows.Clear();

            List<String[]> list = _MachineCtrl.AddData();
            foreach (String[] str in list)
            {
                dgv_order.Rows.Add(str[0], str[1], str[2], str[3]);
            }
        }
    }
}
        