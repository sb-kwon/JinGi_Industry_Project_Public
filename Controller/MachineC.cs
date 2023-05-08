using System;
using System.Collections.Generic;
using DataBase;
using Model;


namespace Controller
{

    public class MachineC
    {
        DBMain database = DBMain.Instance;

        private List<Machine> _LM;
        private List<Machine> _SF;
        private List<LiveMonitor> _Live;
        private List<LiveMonitor> _Error;
        private List<LiveMonitor> _AllError;
        private List<Operating_Rate> _ORR;
        private List<Operating_Rate> _OR;
        private List<Operating_Rate> _Non;
        public MachineC()
        {
            Repair = new Repair();
            TypeList();
        }
        public Repair Repair { get; set; }
        #region 검색 Machine
        private List<string> _Types;
        public List<string> Types
        {
            get { return _Types; }
            set { _Types = value; }
        }
        public List<Machine> Machine
        {
            get { return _LM; }
            set { _LM = value; }
        }
        public List<Machine> SF_Machine
        {
            get { return _SF; }
            set { _SF = value; }
        }
        public void GetMachine()
        {
            List<Machine> machines = new List<Machine>();
            _SF = database.DBMachine.GetMachine();
            if (machines is null)
                _SF = new List<Machine>();
        }
        public void GetMachineList()
        {
            List<Machine> machines = new List<Machine>();
            _LM = database.DBMachine.GetMachineList();

            if (machines is null)
                _LM = new List<Machine>();
        }
        public void TypeList()
        {
            Types = database.DBDefaultValue.TypeList();
        }
        public List<string> MachineList()
        {
            return database.DBMachine.MachineList();
        }
        public void AddMachine(Machine machine)
        {
            database.DBMachine.MachineAdd(machine);
        }
        public void AdditionalMachine(Machine machine)
        {
            database.DBMachine.AdditionalMachine(machine);
        }
        public bool CheckName(string machinename, string value)
        {
            return database.DBMachine.CheckName(machinename, value);
        }
        public bool CheckMachineName(string machinename, string value)
        {
            return database.DBMachine.CheckMachineName(machinename, value);
        }
        public bool CheckMachineNo(string MachineNo, string value)
        {
            return database.DBMachine.CheckMachineNo(MachineNo, value);
        }
        public void UpdateMachine(Machine machine)
        {
            database.DBMachine.UpdateMachine(machine);
        }
        public void ModifyMachine(Machine machine)
        {
            database.DBMachine.ModifyMachine(machine);
        }
        public void DeleteMachine(string machinename)
        {
            database.DBMachine.DeleteMachine(machinename);
        }
        public void MachineDelete(string MachineNo)
        {
            database.DBMachine.MachineDelete(MachineNo);
        }
        public List<Machine> SearchData(string result, string str)
        {
            return database.DBMachine.SearchData(result, str);
        }
        public List<Machine> SearchMachine(string result, string str)
        {
            return database.DBMachine.SearchMachine(result, str);
        }
        #endregion
        #region 검색 Live
        public List<LiveMonitor> Live
        {
            get { return _Live; }
            set { _Live = value; }
        }
        public List<LiveMonitor> Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
        public List<LiveMonitor> AllError
        {
            get { return _AllError; }
            set { _AllError = value; }
        }
        public void GetMonitor()
        {
            List<LiveMonitor> live = new List<LiveMonitor>();
            _Live = database.DBMonitor.GetMonitor();

            if (live is null)
                _Live = new List<LiveMonitor>();
        }
        public void GetError()
        {
            List<LiveMonitor> error = new List<LiveMonitor>();
            _Error = database.DBMonitor.GetError();

            if (error is null)
                _Error = new List<LiveMonitor>();
        }
        public void GetAllError()
        {
            List<LiveMonitor> error = new List<LiveMonitor>();
            _AllError = database.DBMonitor.GetAllError();

            if (error is null)
                _AllError = new List<LiveMonitor>();
        }
        public List<LiveMonitor> GetLastStateData()
        {
            List<LiveMonitor> list = database.DBMonitor.GetLastStateData();
            return list;
        }
        public Dictionary<String, LiveMonitor> keyValuePairs()
        {
            Dictionary<String, LiveMonitor> keyValuePairs = new Dictionary<String, LiveMonitor>();
            keyValuePairs.Add("TruLaser3030", new LiveMonitor());
            keyValuePairs.Add("TruLaser3030-2", new LiveMonitor());
            keyValuePairs.Add("CNC-1500", new LiveMonitor());
            keyValuePairs.Add("CNC-3000", new LiveMonitor());
            keyValuePairs.Add("CNC-5170", new LiveMonitor());

            keyValuePairs = database.DBMonitor.SetData("machineValue", keyValuePairs);

            return keyValuePairs;
        }
        #endregion
        #region 검색 기간별
        public List<Operating_Rate> ORR
        {
            get { return _ORR; }
            set { _ORR = value; }
        }
        public List<Operating_Rate> Get30DaysData()
        {
            DateTime StartDate = DateTime.Now.AddDays(-30);
            String Start = StartDate.ToString("yyyy-MM-dd");
            DateTime EndDate = DateTime.Now;
            String End = EndDate.ToString("yyyy-MM-dd");

            return _ORR = database.DBRate.Get30DaysData(Start, End);
        }
        public List<Operating_Rate> GetSearchData(DateTime Start, DateTime End)
        {
            return _ORR = database.DBRate.GetSearchData(Start, End);
        }
        public string[] GetSelectDayData(DateTime DateTime_1, DateTime DateTime_2)
        {
            string Operation = database.DBRate.GetSelectOperationData(DateTime_1.ToString(), DateTime_2.ToString());
            string Unoperation = database.DBRate.GetSelectUnoperationData(DateTime_1.ToString(), DateTime_2.ToString());

            if (Operation.Equals("")) Operation = "0";
            if (Unoperation.Equals("")) Unoperation = "0";

            string[] result = { Operation, Unoperation };

            return result;
        }
        #endregion
        #region 검색 설비별
        public List<Operating_Rate> Facility
        {
            get { return _OR; }
            set { _OR = value; }
        }
        public void GetComboBox()
        {
            List<Machine> machines = new List<Machine>();
            _LM = database.DBFacility.GetComboBox();
            if (machines is null)
                _LM = new List<Machine>();
        }
        public List<Operating_Rate> GetDataGridView(string MachineName)
        {
            DateTime StartDate = DateTime.Now.AddDays(-30);
            String Start = StartDate.ToString("yyyy-MM-dd");
            DateTime EndDate = DateTime.Now;
            String End = EndDate.ToString("yyyy-MM-dd");

            List<Operating_Rate> list = new List<Operating_Rate>();

            return _OR = database.DBFacility.Get30dayData(Start, End, MachineName);
        }
        public List<Operating_Rate> GetSearchDataGrid(DateTime Start, DateTime End , string MachineName)
        {
            return _OR = database.DBFacility.GetSearchDataGrid(Start, End, MachineName);
        }
        public string[] GetSelectDayData(DateTime Start, DateTime End, string CbText)
        {
            string Operation = database.DBFacility.GetSelectDayData(Start.ToString(), End.ToString(), CbText);
            string Unoperation = database.DBFacility.GetSelectDayDataUnoperation(Start.ToString(), End.ToString(), CbText);

            if (Operation.Equals("")) Operation = "0";
            if (Unoperation.Equals("")) Unoperation = "0";

            string[] result = { Operation, Unoperation };

            return result;
        }
        #endregion
        #region 검색 비가동
        public List<Operating_Rate> Non
        {
            get { return _Non; }
            set { _Non = value; }
        }
        public List<Operating_Rate> GetStattCnt(string MachineName)
        {
            return _Non = database.DBNonOperating.GetStattCnt(MachineName);
        }
        public List<Operating_Rate> GetBetweenCnt(string MachineName, string StartDate, string EndDate)
        {
            List<Operating_Rate> list = new List<Operating_Rate>();

            return _Non = database.DBNonOperating.GetBetweenCnt(MachineName, StartDate, EndDate);
        }
        public void InsertNon(String MachineName, String Detail, String Memo)
        {
            database.DBMachine.InsertNon(MachineName, Detail, Memo);
        }
        #endregion
        public List<String[]> AddData()
        {
            return database.DBMachine.AddData();
        }
    }
}
