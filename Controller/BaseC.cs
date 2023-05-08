using System;
using System.Collections.Generic;
using DataBase;
using Model;

namespace Controller
{
    public class BaseC
    {
        DBMain database = DBMain.Instance;
        private List<Customer> _LCCUS;
        private List<CustomerMember> _LCMB;
        private List<CustomerMember> _LCM;        

        private ILoginForm _form;
        private int _LimitCnt;
        public BaseC()
        {
            GroupListUp();
        }

        #region 검색 Customer
        public List<Customer> Customers
        {
            get { return _LCCUS; }
            set { _LCCUS = value; }
        }
        public List<CustomerMember> CustomerMembers
        {
            get { return _LCMB; }
            set { _LCMB = value; }
        }
        public List<CustomerMember> CustomerMember
        {
            get { return _LCM; }
            set { _LCM = value; }
        }
        private List<string> _GroupList;
        public List<string> GroupList
        {
            get { return _GroupList; }
            set { _GroupList = value; }
        }
        public void GetDgvCustomer()
        {
            List<Customer> customer = new List<Customer>();
            _LCCUS = database.DBCustomer.GetDgvCustomer();

            if (customer.Count != 0)
                _LCCUS = new List<Customer>();
        }
        public void LastCustomerCode()
        {
            List<Customer> customer = new List<Customer>();
            _LCCUS = database.DBCustomer.LastCustomerCode();

            if (customer.Count != 0)
                _LCCUS = new List<Customer>();
        }
        public void AddCustomerData(Customer cus)
        {
            database.DBCustomer.AddCustomerData(cus);
        }

        public void ModifyCustomerData(Customer _SelectDataCustomer)
        {
            database.DBCustomer.ModifyCustomerData(_SelectDataCustomer);
        }

        public void DeleteCustomerData(int _No)
        {
            //     database.DBCustomer.DeleteCustomerMemberData(_SelectDataCustomer);
            database.DBCustomer.DeleteCustomerData(_No);
        }
        public List<string> GetAuthority()
        {
            return database.DBAthority.GetAuthority();
        }

        public void GetDgvMember(int CustomerNo)
        {
            List<CustomerMember> customermember = new List<CustomerMember>();
            _LCMB = database.DBCustomer.GetDgvMember(CustomerNo);

            if (customermember.Count != 0)
                _LCMB = new List<CustomerMember>();
        }
        public void CustomerName(int CustomerNo, int CMNo)
        {
            List<CustomerMember> customermember = new List<CustomerMember>();
            _LCM = database.DBCustomer.GetCMName(CustomerNo, CMNo);

            if (customermember.Count != 0)
                _LCM = new List<CustomerMember>();
        }

        public List<string> ComboboxListCollection(string tableName, string Type)
        {
            return database.DBCustomer.ComboboxListCollection(tableName, Type);
        }

        public void AddCusMemberData(CustomerMember _SelectDataCusMember)
        {
            database.DBCustomer.AddCusMemberData(_SelectDataCusMember);
        }

        public void ModifyCusMemberData(CustomerMember _SelectDataCusMember)
        {
            database.DBCustomer.ModifyCusMemberData(_SelectDataCusMember);
        }

        public void DeleteCusMemberData(int _No)
        {
            database.DBCustomer.DeleteCusMemberData(_No);
        }

        public void FindData(string result, string value)
        {
            List<Customer> customer = new List<Customer>();
            _LCCUS = database.DBCustomer.CustomerFindData(result, value);

            if (customer.Count != 0)
                _LCCUS = new List<Customer>();
        }

        public void GroupListUp()
        {
            GroupList =  database.DBDefaultValue.GetCustomerGroupList();
        }
        #endregion
        
        #region 검색 Login
        public int LimitCnt
        {
            get { return _LimitCnt; }
            set { _LimitCnt = value; }
        }
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        //Init
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        public BaseC(ILoginForm from)
        {
            _form = from;
            LimitCnt = 5;
        }
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        //Method Function
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        public void LastPwCheck(Member member)
        {
            database.DBAthority.LastPwCheck(member);
        }

        public void LastPwSave(Member member, string lastpw)
        {
            database.DBAthority.LastPwSave(member, lastpw);
        }

        public void UserPwChange(Member member)
        {
            database.DBAthority.UserPwChange(member);
            //dataBaseM.UserPwChange(member);
        }
        public void InsertMember(Member member)
        {
            database.DBAthority.InsertMember_Access(member);
            //dataBaseM.InsertMember(member);

        }
        public bool IdCheck(String str)
        {
            return database.DBAthority.MemberExistsBool(str);
        }
        /// <summary>
        /// 1. 아이디 존재 확인
        /// (존재 한다면 아이디에 대한 자료값 불러오기
        /// 2. 비밀번호 일치 여부 확인
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        public void LoginCheck(string id, string pw)
        {
            bool check = false;
            Member member = new Member();

            member.Memberid = id;
            member = database.DBAthority.MemberExists(member.Memberid);

            if (member != null)
            {
                member.Memberpw = pw;
                check = database.DBAthority.LoginCheck(member.Memberid, member.Memberpw);
            }
            LoginCheckCnt(member, check);
        }

        /// <summary>
        /// 접속 이력 관리
        /// </summary>
        /// <param name="id"> 로그기록될 ID </param>
        /// <param name="type"> 로그 기록명 </param>
        public void LoginLogListAdd(string memberId, String type)
        {
            database.DBAthority.LoginLogListAdd(memberId, type);
        }
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        //UI Function
        //---------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------
        public Boolean TextBoxCheck(string ID, string PassWord)  //null check Function
        {
            Boolean check = false;
            if (ID.Length != 0 && PassWord.Length != 0) check = true;
            return check;
        }
        /// <summary>
        /// 로그인 상태 확인해서 
        /// 해당 형식으로 반환
        /// </summary>
        /// <param name="member"> 로그인 정보 </param>
        /// <param name="check"> t : 로그인, f : 실패 </param>
        private void LoginCheckCnt(Member member, bool check)
        {
            if (member.Memberid is null)
                _form.SetAlarm("로그인 정보 또는 네트워크 불안정.");
            else if (member.MemberAccess.Memberpwfailcnt > LimitCnt)
            {
                database.DBAthority.MemberAuthorityChange(member.Memberid);
                _form.SetAlarm("비밀번호 오류입력 기준횟수(" + LimitCnt + "회) 초과되어" + member.Memberid + "계정이 차단되었습니다. 관리자에게 문의 해주세요.");
                LoginLogListAdd(member.Memberid, "Disable");
            }
            else if (!check && member != null && member.MemberAccess.Memberpwfailcnt <= LimitCnt)  //
            {
                _form.SetAlarm("비밀번호 오류 입력.\r\n" + member.MemberAccess.Memberpwfailcnt + " 회 오류 발생하였습니다. \r\n 기준횟수(5회) 초과시 " + member.Memberid + "계정이 차단 됩니다.");
                database.DBAthority.SetCnt(member, false);
                LoginLogListAdd(member.Memberid, "LogTry");
            }
            else
            {
                _form.LoginData = member;
                if (member.MemberAccess.Memberlpct != "")
                {
                    DateTime now = DateTime.Parse(member.MemberAccess.Memberlpct);
                    DateTime dt1Mp = now.AddMonths(3);

                    if (DateTime.Now > dt1Mp)
                        _form.LoginAlarm("마지막으로 비밀번호를 변경한 지 3개월이 지났습니다. \r\n 비밀번호를 변경해주세요.");
                }
                database.DBAthority.SetCnt(member, true);
                database.DBAthority.FindLog(member);
                if (member.MemberAccess.MemberLogData.Equals("LogIn")) LoginLogListAdd(member.Memberid, "LogOut");
                LoginLogListAdd(member.Memberid, "LogIn");
                _form.LoginData = member;
                _form.ResultOk();
            }
        }
        #endregion
        #region 검색 Def_Ctrl
        public void DeleteFair(string fairno)
        {
            database.DBDefaultValue.DeleteFair(fairno);
        }

        public void UpdateFair(DefFair df)
        {
            database.DBDefaultValue.UpdateFair(df);
        }
        public void InsertDefData(Model.Def def, string text)
        {
            database.DBDefaultValue.InsertDefData(def, text);
        }
        public void UpdateDefData(Model.Def def, string text)
        {
            database.DBDefaultValue.UpdateDefData(def, text);
        }
        public void DeleteDefData(Model.Def def)
        {
            database.DBDefaultValue.DeleteDefData(def);
        }


        public List<string> GetUnitList()
        {
            return database.DBDefaultValue.GetUnitList();
        }
        public List<string> GetRankList()
        {
            return database.DBDefaultValue.GetRankList();
        }
        public List<string> GetCustomerGroupList()
        {
            return database.DBDefaultValue.GetCustomerGroupList();
        }
        private List<string> GetAuthorityMain()
        {
            return database.DBDefaultValue.GetDefAuthorityMain();
        }
        private List<string> GetDefAuthorityList()
        {
            return database.DBDefaultValue.GetDefAuthorityList();
        }
        private List<string> GetDefContinence()
        {
            return database.DBDefaultValue.GetDefContinence();
        }
        private List<string> GetDefMachineType()
        {
            return database.DBDefaultValue.GetDefMachineType();
        }
        private List<string> GetDefMaterial()
        {
            return database.DBDefaultValue.GetDefMaterial();
        }
        private List<string> GetDefContinenceAction()
        {
            return database.DBDefaultValue.GetDefContinenceAction();
        }
        private List<string> GetDefContinenceType()
        {
            return database.DBDefaultValue.GetDefContinenceType();
        }
        private List<string> GetDefContinenceLocation()
        {
            return database.DBDefaultValue.GetDefContinenceLocation();
        }
        public List<string> GetDefOrderState()
        {
            return database.DBDefaultValue.GetDefOrderState();
        }
        private List<string> GetDefWorkProcessState()
        {
            return database.DBDefaultValue.GetDefWorkProcessState();
        }
        private List<string> GetDefWorkProcess()
        {
            return database.DBDefaultValue.GetDefWorkProcess();
        }
        public List<string> GetDefFair()
        {
            return database.DBDefaultValue.GetDefFair();
        }
        private List<string> GetDefProductType()
        {
            return database.DBDefaultValue.GetDefProductType();
        }
        public List<string> GetDefFairGroup()
        {
            return database.DBDefaultValue.GetDefFairGroup();
        }
        public List<string> GetDefProcessMapping()
        {
            return database.DBDefaultValue.GetDefProcessMapping();
        }
        public bool FindDefData(string table, string location, string value)
        {
            //true 반환시 이미 존재 하는거
            return database.DBDefaultValue.FindDefData(table, location, value);
        }

        public List<string[]> GetCustomerForType(bool v)  //true면 매출처만 가져오기
        {
            return database.DBDefaultValue.GetCustomerForType(v);
        }

        //public Customer GetCustomer(int value)
        //{
        //	return _Database.DBCustomer.GetCustomerOne(value);
        //}
        public List<Def> GetDefList(List<String> list)
        {
            return FindDef(list);
        }
        private List<Def> FindDef(List<String> list)
        {
            List<Def> result = new List<Def>();
            foreach (String str in list)
            {
                Def def = new Def();
                switch (str)
                {
                    //권한
                    case "def_authority_main":
                        def.TableLogical = str;
                        def.TableName = "권한 명";
                        def.ValueLogical = "authorityName";
                        def.Columns = GetAuthorityMain();
                        break;
                    case "def_authority_list":
                        def.TableLogical = str;
                        def.TableName = "권한 주소";
                        def.ValueLogical = "authorityLocation";
                        def.Columns = GetDefAuthorityList();
                        break;
                    //공정
                    case "def_order_state":
                        def.TableLogical = str;
                        def.TableName = "수주 상태";
                        def.ValueLogical = "orderStateName";
                        def.Columns = GetDefOrderState();
                        break;
                    case "def_work_process_state":
                        def.TableLogical = str;
                        def.TableName = "작업공정 상태";
                        def.ValueLogical = "workProcessStateName";
                        def.Columns = GetDefWorkProcessState();
                        break;
                    case "def_work_process":
                        def.TableLogical = str;
                        def.TableName = "공정 매핑";
                        def.ValueLogical = "fairReal";
                        def.Columns = GetDefWorkProcess();
                        break;
                    case "def_fair":
                        def.TableLogical = str;
                        def.TableName = "공정 명";
                        def.ValueLogical = "fairName";
                        def.Columns = GetDefFair();
                        break;
                    case "def_fair_group":
                        def.TableLogical = str;
                        def.TableName = "공정 그룹";
                        def.ValueLogical = "fairGroup";
                        def.Columns = GetDefFairGroup();
                        break;

                    //자제 관련
                    case "product":
                        def.TableLogical = str;
                        def.TableName = "품 목";
                        def.ValueLogical = "ProductName";
                        def.Columns = GetDefContinence();
                        break;
                    case "def_machine_type":
                        def.TableLogical = str;
                        def.TableName = "장비 타입";
                        def.ValueLogical = "MachineType";
                        def.Columns = GetDefMachineType();
                        break;
                    case "def_material":
                        def.TableLogical = str;
                        def.TableName = "제질";
                        def.ValueLogical = "materialName";
                        def.Columns = GetDefMaterial();
                        break;
                    case "def_product_type":
                        def.TableLogical = str;
                        def.TableName = "품목 타입";
                        def.ValueLogical = "ProductType";
                        def.Columns = GetDefProductType();
                        break;
                    case "def_continence_type":
                        def.TableLogical = str;
                        def.TableName = "자제 타입";
                        def.ValueLogical = "continenceType";
                        def.Columns = GetDefContinenceType();
                        break;
                    case "def_continence_location":
                        def.TableLogical = str;
                        def.TableName = "자제 위치";
                        def.ValueLogical = "continenceLocation";
                        def.Columns = GetDefContinenceLocation();
                        break;
                    //기타
                    case "def_rank":
                        def.TableLogical = str;
                        def.TableName = "직급";
                        def.ValueLogical = "RankName";
                        def.Columns = GetRankList();
                        break;
                    case "def_customer_group":
                        def.TableLogical = str;
                        def.TableName = "거래처 구분";
                        def.ValueLogical = "CustomerGroup";
                        def.Columns = GetCustomerGroupList();
                        break;
                }
                result.Add(def);
            }
            return result;
        }
        public bool DefCheck(Def def)
        {
            bool result = true;

            if (def.TableLogical.Equals("authorityName") && def.SelectValue.Equals("Disable")) result = false;
            if (def.TableLogical.Equals("continenceActionName") && def.SelectValue.Equals("입고")) result = false;
            if (def.TableLogical.Equals("continenceActionName") && def.SelectValue.Equals("출고")) result = false;
            if (def.TableLogical.Equals("continenceActionName") && def.SelectValue.Equals("이동")) result = false;

            return result;
        }
        public List<DefFair> GetFariList()
        {
            return database.DBDefaultValue.GetFariList();
        }
        public bool CheckFair(DefFair df)
        {
            return database.DBDefaultValue.CheckFair(df);
        }
        public void InsertFairGroup(DefFair df)
        {
            database.DBDefaultValue.InsertFairGroup(df);
        }
        #endregion
    }
}
