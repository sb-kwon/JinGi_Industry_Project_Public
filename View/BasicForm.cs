using System;
using Controller;
using System.Windows.Forms;
using System.Timers;
using Model;
using System.Diagnostics;
using System.Web;
using System.Net;
using System.IO;
//using View.Process;

namespace View
{
	public partial class BasicForm : Form
	{
		//Local Value
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		private Member _LoginInfo;
		private IBasicForm _SelectedBasicForm;
		private String _SeletedPageName;
		private System.Timers.Timer _Timer;
		//public BcrController _BcrController;
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		//Getter And Setter
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		public Member LoginInfo  //로그인 정보
		{
			get { return _LoginInfo; }
			set { _LoginInfo = value; }
		}
		public IBasicForm SelectedBasicForm  //선택된 화면
		{
			get { return _SelectedBasicForm; }
			set { _SelectedBasicForm = value; }
		}
		public string SeletedPageName  //선택된 화면
		{
			get { return _SeletedPageName; }
			set { _SeletedPageName = value; }
		}
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		//Init
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		public BasicForm()
		{
			InitializeComponent();
			//_BcrController = new BcrController();
		}
		private void BasicForm_Load(object sender, EventArgs e)
		{
			this.Hide();
			LoginForm loginForm = new LoginForm();

			if (loginForm.ShowDialog(this) != DialogResult.OK)
			Application.Exit();
			else
			{
				this.Show();
				login();
			}
			_Timer = new System.Timers.Timer();
			threadStart();
		}
		/// <summary>
		/// 1. 선택된 tab 찾기
		/// 2. 없으면 생성 있으면 띄우기
		/// </summary>
		/// <param name="sender"></param>
		private void SetManuTab(object sender)
		{
			string str = sender.ToString();

			Boolean check = false;
			TabPage selectTab = new TabPage();
			foreach (TabPage tab in tab_Control.TabPages)
			{
				if (tab.Text == str)
				{
					check = true;
					selectTab = tab;
				}
			}
			if (check) this.tab_Control.SelectedTab = selectTab;
			else
			{
				//if(str.Equals("권한 설정") && _AuthorityCtrl.GetAuthority(_LoginInfo.MemberAccess.Authorityname, "권한 설정"))
				//{
				//    MakeTag(str);
				//}
				//else if (str != "권한 설정")  //다른 페이지는 그냥 생성 되게 
				MakeTag(str);
			}
		}
		/// <summary>
		/// 선택된 tab이 없으면 생성하는거
		/// </summary>
		/// <param name="str"></param>
		private void MakeTag(String str)
		{
			string title = str;
			TabPage myTabPage = new TabPage(title);
			tab_Control.TabPages.Add(myTabPage);

			IBasicForm it = SetForm(str);

			it.TopLevel = false;
			myTabPage.Controls.Add(it.SetForm());
			it.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			it.Show();
			this.tab_Control.SelectedTab = myTabPage;

			SelectedBasicForm = it; //page생성시 해당 페이지의 interval 주기
		}
		private IBasicForm SetForm(String tag)
		{
			IBasicForm ift = null;
			switch (tag)
			{
				//기준 정보
				case "표준 코드":
					ift = new DefCord(_LoginInfo, this);
					break;
				case "표준 설비":
					ift = new MachineView(_LoginInfo, this);
					break;
				case "표준 공정":
					ift = new DefProcess(_LoginInfo, this);
					break;
				case "거래처 정보":
					ift = new CustomerView(_LoginInfo, this);
					break;
				case "사원 정보":
					ift = new MemberView(_LoginInfo, this);
					break;

				//수주 관리
				case "수주 등록":
					ift = new OrderInput(_LoginInfo, this);
					break;
				case "품목 정보":
					ift = new ProductView(_LoginInfo, this);
					break;
				case "출하 등록":
					ift = new OrderShipmentInput(_LoginInfo, this);
					break;
				case "수주 현황":
					ift = new OrderStatus(_LoginInfo, this);
					break;
				case "출하 현황":
					ift = new OrderShipmentStatus(_LoginInfo, this);
                    break;
                case "거래명세서":
                    ift = new OrderReciptView(_LoginInfo, this);
                    break;
                case "부품식별라벨":
                    ift = new Part_Identification_Label(_LoginInfo, this);
                    break;

                //자재 관리
                case "재고 관리":
					ift = new MaterialsForm(_LoginInfo, this);
					break;
				case "입/출고 관리":
					ift = new IOForm(_LoginInfo, this);
					break;
				case "품목별 자재 현황":
					ift = new SemiView(_LoginInfo, this);
					break;

				//생산관리
				case "수주별":
					ift = new Order_Schedule(_LoginInfo, this);
					break;
				case "아이템별":
					ift = new Schedule_Item(_LoginInfo, this);
					break;
				case "장비별":
					ift = new Machine_Schedule(_LoginInfo, this);
					break;
				case "작업지시서":
					ift = new WorkInstructionsView(_LoginInfo, this);
					break;
				case "외주 현황":
					ift = new Outsourcing_Status(_LoginInfo, this);
					break;

				////현장 관리
				case "작업 현황":
					ift = new WorkList(_LoginInfo, this);
					break;
				case "작업 이력":
					ift = new WorkLog(_LoginInfo, this);
					break;

				//설비 관리
				case "상태 모니터링":
					ift = new Equipment_Monitoring(_LoginInfo, this);
					break;
				case "상세 현황":
					ift = new LiveMonitoring(_LoginInfo, this);
					break;
				case "설비 점검 관리":
					ift = new RepairView1(_LoginInfo, this);
					break;
				case "설비 점검 현황":
					ift = new RepairView2(_LoginInfo, this);
					break;

				//품질 관리
				case "불량 리스트":
					ift = new DefectRegistration(_LoginInfo, this);
					break;
				case "불량 수정":
					ift = new DefectUpdate(_LoginInfo, this);
					break;
				case "불량 조치 현황":
					ift = new DefectSituation(_LoginInfo, this);
					break;

				//리포트
				case "기간별 가동율":
					ift = new Operating_Rate_by_Period(_LoginInfo, this);
					break;
				case "설비별 가동율":
					ift = new Operating_Rate_by_Facility(_LoginInfo, this);
					break;
				case "비가동 분석":
					ift = new Non_Operation_Analysis(_LoginInfo, this);
					break;
				case "불량 분석":
					ift = new DefectAnalysis(_LoginInfo, this);
					break;
				case "KPI":
					ift = new KPI(_LoginInfo, this);
					break;

				//공통 사항
				case "권한 설정":
					ift = new Authority_Setting(_LoginInfo, this);
					break;
				case "공지 사항":
					ift = new NoticeView(_LoginInfo, this);
					break;
				case "로그인로그":
					ift = new LogInLog(_LoginInfo, this);
					break;
			}
			return ift;
		}
		private void threadStart()
		{
			_Timer.Interval = 10000;
			_Timer.Elapsed += new ElapsedEventHandler(intervalThread);
			_Timer.Start();
		}
		private void intervalThread(object sender, EventArgs e)  //interfal
		{
			bool check = false;
			if (tab_Control.TabPages.Count == 1) check = true;
			if (!(SelectedBasicForm is null))
			{
				SelectedBasicForm.SetInterval(SeletedPageName, check);
			}
			string Day = DateTime.Now.ToString("dd-MM-yyyy");
			if (Day != DateTime.Now.ToString("dd-MM-yyyy"))
			{
				BaseC _BaseCtrl = new BaseC();
				string MemberId = _LoginInfo.MemberAccess.Memberid;
				_BaseCtrl.LoginLogListAdd(MemberId, "LogOut");
				_BaseCtrl.LoginLogListAdd(MemberId, "LogIn");
			}
		}
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		//UI Function
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		private void Manu_Click(object sender, EventArgs e)
		{
			if (tab_Control.TabPages.Count == -1)
				panel4.BringToFront(); //트루면 이미지
			else
				tab_Control.BringToFront(); //아니면 텝 컨트롤

			SetManuTab(sender);
		}
		private void tab_Control_Selected(object sender, TabControlEventArgs e)
		{
			TabControl tabControl = (TabControl)sender;
			TabPage tab = tabControl.SelectedTab;

			if (!(tab is null))
			{
				SelectedBasicForm = (IBasicForm)tab.Controls[0];
				SeletedPageName = _SelectedBasicForm.GetText();
			}
		}
		public void btn_Close_Click(object sender, EventArgs e)
		{
			if (!(tab_Control.SelectedTab is null))
			{
				tab_Control.TabPages.Remove(tab_Control.SelectedTab);
			}
			if (tab_Control.TabPages.Count == 0)
			{
				panel4.Visible = true;
				panel4.BringToFront(); //트루면 이미지
			}
			else
			{
				tab_Control.BringToFront(); //아니면 텝 컨트롤
				panel4.Visible = false;
			}
		}
		private void btn_Refresh_Click(object sender, EventArgs e)
		{
			if (!(_SelectedBasicForm is null))
				_SelectedBasicForm.RefreshForm();
		}
        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			Process.Start("http://www3.startsupport.com/citek");
        }
		private void button2_Click(object sender, EventArgs e)
		{
			bool check = false;
			while (check)
			{
			}
			if (!(tab_Control.SelectedTab is null))
			{
				tab_Control.TabPages.Clear();
					//tab_Control.TabPages.Remove(tab_Control.TabPages[0]);
			}
			else check = true;
			
			panel4.Visible = true;
			panel4.BringToFront(); //트루면 이미지
		}
        private void BasicForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BaseC _BaseCtrl = new BaseC();

			if (!(_LoginInfo is null))
			{
				string MemberId = _LoginInfo.MemberAccess.Memberid;
				_BaseCtrl.LoginLogListAdd(MemberId, "LogOut");

				string A = "{\"crtfcKey\":\"" + "$5$API$5wVfv2U7w3OQ52d33SsF3KtoNVdrkeRytOCV.2Nbsa7" + "\",\"logDt\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\",\"useSe\":\"" + "종료" + "\",\"sysUser\":\"" + _LoginInfo.Memberid + "\",\"conectIp\":\"" + GETIP() + "\",\"dataUsgqty\":\"" + "0" + "\"}";
				string str = HttpUtility.UrlEncode(A);
				string url = "https://log.smart-factory.kr/apisvc/sendLogDataJSON.do?logData=" + str;

				//System.Diagnostics.Process.Start(url);
				WebRequest request = WebRequest.Create(url);
				request.Method = "GET";

				WebResponse response = request.GetResponse();
				Stream DataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(DataStream);

				String responseFromServer = reader.ReadToEnd();

				//MessageBox.Show(responseFromServer);

				reader.Close();
				DataStream.Close();
				response.Close();
			}
        }
		private void login()
        {
			string A = "{\"crtfcKey\":\"" + "$5$API$5wVfv2U7w3OQ52d33SsF3KtoNVdrkeRytOCV.2Nbsa7" + "\",\"logDt\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\",\"useSe\":\"" + "접속" + "\",\"sysUser\":\"" + _LoginInfo.Memberid + "\",\"conectIp\":\"" + GETIP() + "\",\"dataUsgqty\":\"" + "0" + "\"}";
			string str = HttpUtility.UrlEncode(A);
			string url = "https://log.smart-factory.kr/apisvc/sendLogDataJSON.do?logData=" + str;

			//System.Diagnostics.Process.Start(url);
			WebRequest request = WebRequest.Create(url);
			request.Method = "GET";

			WebResponse response = request.GetResponse();
			Stream DataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(DataStream);

			String responseFromServer = reader.ReadToEnd();

			//MessageBox.Show(responseFromServer);

			reader.Close();
			DataStream.Close();
			response.Close();
		}
		private string GETIP()
		{
			string MyIp = "";
			MyIp = System.Net.Dns.GetHostName();

			IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					MyIp = ip.ToString();
				}
			}
			return MyIp;
		}
	}
}