using System;
using System.ComponentModel;
using System.Windows.Forms;
using ZXing;
using ZXing.Presentation;

namespace View.UserController
{
    public partial class WorkProcess : UserControl
    {
        private OrderChildOrder _OrderChild;
        private WorkInstruction _WorkInstruction;

        [Description("MakeEvent"), Category("MakeEvent")]
        public event EventHandler DeleteWork;
        [Description("MakeEvent"), Category("MakeEvent")]
        public event EventHandler UpdateNote;

        public WorkProcess()
        {
            InitializeComponent();
        }
        public WorkProcess(WorkInstruction workInstruction)
        {
            InitializeComponent();
            _WorkInstruction = new WorkInstruction();
            WorkInstruction = workInstruction;
        }
        public void SetTextBox()
        {
            WorkInstruction.WorkinstructionMemo = tb_Memo.Text;
        }
        public WorkInstruction WorkInstruction
        {
            get
            {
                return _WorkInstruction;
            }
            set

            {
                _WorkInstruction = value;
                SetBcr();
            }
        }
        private void SetBcr()
        {
            ZXing.BarcodeWriter writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
            pictureBox1.Image = writer.Write(WorkInstruction.WorkinstructionNo.ToString());
            tb_Memo.Text = WorkInstruction.WorkinstructionMemo;
            lbl_Bcr.Text = WorkInstruction.WorkinstructionNo.ToString();
            lbl_State.Text = SetNote(WorkInstruction.WorkinstructionState);
        }
        private string SetNote(int state)
        {
            //작업 지시서 상태
            //0 : 등록
            //1 : 진행중
            //2 : 완료
            //3 : 폐기
            //4 : 취소

            string str = "";
            if (state == 0) str = "등록";
            if (state == 1) str = "작업 전";
            if (state == 2) str = "작업 중";
            if (state == 3) str = "작업 완료";
            if (state == 4) str = "폐기";
            if (state == 5) str = "취소";

            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_WorkInstruction.WorkinstructionState == 1)
            {
                _WorkInstruction.WorkinstructionState = 4;
                SetBcr();
            }
            else if (_WorkInstruction.WorkinstructionState == 0)
            {
                _WorkInstruction.WorkinstructionState = 5;
                SetBcr();
            }
            else
            {
                MessageBox.Show("진행중, 완료 작업은 폐기 불가능");
            }
        }
        public void ViewReset()
        {
            pictureBox1.Image = null;
            lbl_Bcr.Text = "";
            lbl_State.Text = "";
        }
    }
}
