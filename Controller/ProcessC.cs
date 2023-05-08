using DataBase;
using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class ProcessC
    {
        private DBMain _Database = DBMain.Instance;
        public List<WorkOrder> _WorkOrders;
        private List<Quality> _QT;
        public ProcessC()
        {
            WorkOrder = new WorkOrder();
            Product = new Product();
            Machine = new Machine();
            WorkProcess = new WorkProcess();
            WorkInstruction = new WorkInstruction();
            _WorkOrders = new List<WorkOrder>();
        }
        public List<WorkOrder> WorkOrders
        {
            get
            {
                return _WorkOrders;
            }
            set
            {
                _WorkOrders = value;
            }
        }
        public WorkOrder WorkOrder { get; set; }
        public Product Product { get; set; }
        public Machine Machine { get; set; }
        public WorkProcess WorkProcess { get; set; }
        public WorkInstruction WorkInstruction { get; set; }
        public List<Quality> Qualities
        {
            get { return _QT; }
            set { _QT = value; }
        }
        #region 검색 불량
        public void GetDefect()
        {
            List<Quality> quality = new List<Quality>();
            _QT = _Database.DBProcess.GetDefect();

            if (quality is null)
                _QT = new List<Quality>();
        }
        public List<Quality> GetFairName()
        {
            return _Database.DBProcess.GetFairName();
        }
        public List<Quality> GetDefectFairName()
        {
            return _Database.DBProcess.GetDefectFairName();
        }
        public List<Quality> GetSituationFairName()
        {
            return _Database.DBProcess.GetSituationFairName();
        }
        public List<Quality> GetdefectRegistration(String[] RegistSearchValue)
        {
            return _Database.DBProcess.GetdefectRegistration(RegistSearchValue);
        }
        public List<Quality> SearchData(String[] RegistSearchValue)
        {
            return _Database.DBProcess.SearchData(RegistSearchValue);
        }
        public void UpdateDefectRegistration(String Number, string[] RegistValue)
        {
            _Database.DBProcess.UpdateDefectRegistration(Number, RegistValue);
        }
        public List<Quality> GetDefectUpdate()
        {
            return _Database.DBProcess.GetDefectUpdate();
        }
        public void DefectUpdate(Quality InnerData, String Number, string[] UpdateValue, String ItemCheck)
        {
            _Database.DBProcess.DefectUpdate(InnerData, Number, UpdateValue, ItemCheck);
        }
        public List<Quality> GetDefectSituation()
        {
            return _Database.DBProcess.GetDefectSituation();
        }
        public List<Quality> SearchSituationData(String[] RegistSearchValue)
        {
            return _Database.DBProcess.SearchSituationData(RegistSearchValue);
        }
        public List<Quality> GetDefectCount()
        {
            return _Database.DBProcess.GetDefectCount();
        }
        public List<Quality> GetDefectSearchCount(String[] RegistSearchValue)
        {
            return _Database.DBProcess.GetDefectSearchCount(RegistSearchValue);
        }
        public List<Quality> SearchDefectData(String[] RegistSearchValue)
        {
            return _Database.DBProcess.SearchDefectData(RegistSearchValue);
        }
        #endregion
        public List<string[]> GetSearchView(string tablename, string tablecolumn)
        {
            return _Database.DBProcess.GetSearchView(tablename, tablecolumn);
        }
        //작업 현황
        public string[] GetProcessDetail(int wpNo)
        {
            return _Database.DBProcess.GetWorkProcessDetail(wpNo);
        }
        public List<string[]> GetWorkProcess()
        {
            return _Database.DBProcess.GetWorkProcess();
        }
        public List<string[]> GetWorkProcessLog()
        {
            return _Database.DBProcess.GetWorkProcessLog();
        }
        //고유번호 중 제일 큰 값 가져오기
        public List<string> MaxValue(string column, string table)
        {
            return _Database.DBProcess.MaxValue(column, table);
        }
        public void AllDataTruncate()
        {
            _Database.DBProcess.AllDataTruncate();
        }
        #region 검색 출하등록
        public List<string[]> SearchShipment(string OrderName, string Start, string End, int K)
        {
            return _Database.DBProcess.SearchShipment(OrderName, Start, End, K);
        }
        public List<string[]> SearchShipmentStatus(string OrderName, string OrderState, string CustomerName, string Start, string End, int K)
        {
            return _Database.DBProcess.SearchShipmentStatus(OrderName, OrderState, CustomerName, Start, End, K);
        }
        public List<string[]> SearchOrderShipment(string OrderName, string Start, string End, int K)
        {
            return _Database.DBProcess.SearchOrderShipment(OrderName, Start, End, K);
        }
        #endregion
        #region 검색 스케쥴
        public List<string[]> GetMachineNameData()
        {
            return _Database.DBProcess.GetMachineNameData();
        }
        public List<string[]> GetMachineSchedule()
        {
            return _Database.DBProcess.GetMachineSchedule(Machine);
        }
        public List<string[]> GetOrderDataSchedule()
        {
            return _Database.DBProcess.GetOrderDataSchedule(WorkOrder);
        }
        public List<string[]> GetProductDataSchedule()
        {
            return _Database.DBProcess.GetProductDataSchedule(Product);
        }
        public List<string[]> GeItemSchedule()
        {
            return _Database.DBProcess.GeItemSchedule();
        }
        public List<WorkOrder> GetWorkOrders()
        {
            return _Database.DBProcess.GetWorkOrders();
        }
        #endregion
        #region 검색 외주 현황
        public List<string[]> GetOutDataList()
        {
            return _Database.DBProcess.GetOutDataList();
        }
        public List<string[]> GetOutProductList(WorkOrder wo)
        {
            return _Database.DBProcess.GetOutProductList(wo);
        }
        public void OutInProduct(bool kkw)
        {
            _Database.DBProcess.OutInProduct(WorkProcess, kkw);
        }
        public void OutProcess(bool kkw)
        {
            _Database.DBProcess.OutProcess(WorkProcess, kkw);
        }
        public List<String[]> GetOrderName()
        {
            return _Database.DBProcess.GetOrderName();
        }
        public List<String[]> GetProductList(string str)
        {
            return _Database.DBProcess.GetProductList(str);
        }
        public List<String[]> ProductData(string ProductName, string OrderNo)
        {
            return _Database.DBProcess.ProductData(ProductName, OrderNo);
        }
        #endregion
        #region 검색 작업지시서
        public List<string[]> ProcessCheckCompletion()
        {
            return _Database.DBProcess.ProcessCheckCompletion(WorkProcess);
        }
        public void InsertDefectiveCheck()
        {
            _Database.DBProcess.InsertDefectiveCheck(WorkProcess);
        }
        public void OrderScheduleStart()
        {
            _Database.DBProcess.OrderScheduleStart(WorkProcess);
        }
        public List<string[]> GetDefFairList()
        {
            return _Database.DBProcess.GetDefFairList(WorkInstruction);
        }
        public void UpdateProcessState(string type)
        {
            _Database.DBProcess.UpdateProcessState(WorkProcess, type);
        }
        public void UpdateShipmentState()
        {
            _Database.DBProcess.UpdateShipmentState(WorkProcess);
        }
        public void UpdateProcessCompletion()
        {
            _Database.DBProcess.UpdateProcessCompletion(WorkProcess);
        }
        public void UpdateOrderState()
        {
            _Database.DBProcess.UpdateOrderState(WorkOrder);
        }
        public void DeleteProcessState()
        {
            _Database.DBProcess.DeleteProcessState(WorkProcess);
        }
        public List<string[]> GetWorkProcessList_Start(string SearchTable, string SearchName, bool type, WorkProcess pro)
        {
            return _Database.DBProcess.GetWorkProcessList_Start(SearchTable, SearchName, type, pro);
        }
        public List<string[]> GetWorkShipmentList_Start(string SearchTable, string SearchName, bool type)
        {
            return _Database.DBProcess.GetWorkShipmentList_Start(SearchTable, SearchName, type);
        }
        public List<string[]> GetWorkProcessList_Ongoing(string SearchTable, string SearchName, bool type, WorkProcess str)
        {
            return _Database.DBProcess.GetWorkProcessList_Ongoing(SearchTable, SearchName, type, str);
        }
        public List<string[]> CheckWorkInstructionState()
        {
            return _Database.DBProcess.CheckWorkInstructionState(WorkProcess);
        }
        public void ProcessPauseLog()
        {
            _Database.DBProcess.ProcessPauseLog(WorkProcess);
        }
        public void UpdatePause()
        {
            _Database.DBProcess.UpdatePause(WorkProcess);
        }
        public void DeleteInstruction()
        {
            _Database.DBProcess.DeleteInstruction(WorkInstruction);
            _Database.DBProcess.DeleteALL(WorkInstruction);
        }
        public void DeleteWorkOrder()
        {
            _Database.DBProcess.DeleteWorkOrder(WorkOrder);
        }
        public void InsertInstructions(List<string> list)
        {
            _Database.DBProcess.InsertInstructions(list);
            _Database.DBProcess.UpdateWorkinstruction(list);
        }
        public List<string[]> GetComboMachine()
        {
            return _Database.DBProcess.GetComboMachine();
        }
        public List<string[]> GetComboMember()
        {
            return _Database.DBProcess.GetComboMember();
        }
        public List<string> GetDefFairName()
        {
            return _Database.DBProcess.GetDefFairName();
        }
        public List<string[]> GetWorkDataList_Detail()
        {
            return _Database.DBProcess.GetWorkDataList_Detail(WorkInstruction);
        }
        public List<string[]> GetWorkDataList()
        {
            return _Database.DBProcess.GetWorkDataList();
        }
        public List<string[]> GetCheck()
        {
            return _Database.DBProcess.GetCheck(WorkInstruction);
        }
        public void CompleteWorkInstruction()
        {
            _Database.DBProcess.CompleteWorkInstruction(WorkProcess);
        }
        #endregion
        #region 검색 수주등록
        public List<WorkOrder> GetOrderState()
        {
            return _Database.DBProcess.GetOrderState();
        }
        public List<WorkOrder> GetCustomerGroup()
        {
            return _Database.DBProcess.GetCustomerGroup();
        }
        public void UpdateOrder(WorkOrder wo)
        {
            _Database.DBProcess.UpdateOrder(wo);
        }
        public List<string> DefUnit()
        {
            return _Database.DBProcess.DefUnit();
        }
        public List<string[]> SearchOrder(string CustomerName, string OrderName, string OrderState, string Start, string End, int K)
        {
            return _Database.DBProcess.SearchOrder(CustomerName, OrderName, OrderState, Start, End, K);
        }
        public void DeleteOrder()
        {
            _Database.DBProcess.DeleteOrder(WorkOrder);
        }
        public void InsertOrderSave()
        {
            _Database.DBProcess.InsertOrderSave(WorkOrder);
        }
        public void InsertBomSave(List<string> Bomlist)
        {
            _Database.DBProcess.InsertBomSave(Bomlist, WorkOrder);
        }
        public void InsertBarcodeNumber(string barcodenum)
        {
            _Database.DBProcess.InsertBarcodeNumber(barcodenum, WorkOrder);
        }
        public List<string[]> GetBOMData(WorkOrder wo)
        {
            return _Database.DBProcess.GetBOMData(wo);
        }
        public List<string[]> GetMachineBomData(Machine machine)
        {
            return _Database.DBProcess.GetMachineBomData(machine);
        }
        public List<string[]> GetBOMList()
        {
            return _Database.DBProcess.GetBOMList(WorkOrder);
        }
        public bool NumberCheck(string ColumnName, string TableName, string Number)
        {
            return _Database.DBProcess.NumberCheck(ColumnName, TableName, Number);
        }
        public List<string[]> GetOrderDataList()
        {
            return _Database.DBProcess.GetOrderDataList();
        }
        public List<string[]> GetSearchOrderSchedule(String str)
        {
            return _Database.DBProcess.GetSearchOrderSchedule(str);
        }
        public List<string[]> GetSearchItemSchedule(String str)
        {
            return _Database.DBProcess.GetSearchItemSchedule(str);
        }
        public List<string[]> GetSearchMachineSchedule(String str)
        {
            return _Database.DBProcess.GetSearchMachineSchedule(str);
        }
        public List<string[]> GetOrderData()
        {
            return _Database.DBProcess.GetOrderData();
        }
        public List<string[]> GetEndOrder()
        {
            return _Database.DBProcess.GetEndOrder();
        }
        public List<string[]> GetShipmentOrderDataList_ALL()
        {
            return _Database.DBProcess.GetShipmentOrderDataList_ALL();
        }
        public List<string[]> GetShipmentOrderDataList()
        {
            return _Database.DBProcess.GetShipmentOrderDataList();
        }
        public List<string[]> GetShipmentProductData()
        {
            return _Database.DBProcess.GetShipmentProductData(WorkOrder);
        }
        #endregion
        #region 검색 품목정보
        public void DeleteProduct()
        {
            _Database.DBProcess.DeleteProduct(Product);
        }
        public void AddProduct()
        {
            _Database.DBProcess.AddProduct(Product);
        }
        public void UpdateProduct()
        {
            _Database.DBProcess.UpdateProduct(Product);
        }
        public List<string[]> GetProductData()
        {
            return _Database.DBProcess.GetProductData();
        }
        public List<string[]> SearchProduct(string result, string Text)
        {
            return _Database.DBProcess.SearchProduct(result, Text);
        }
        #endregion
        #region 검색 디폴트 값
        public List<string> DefProductType()
        {
            return _Database.DBProcess.DefProductType();
        }
        public List<string> DefOrderStateList()
        {
            return _Database.DBProcess.DefOrderStateList();
        }

        public List<string[]> SetCustomerMemberList(string CustomerName)
        {
            return _Database.DBProcess.SetCustomerMemberList(CustomerName);
        }
        public List<string[]> SetCustomerList()
        {
            return _Database.DBProcess.SetCustomerList();
        }
        #endregion
        #region 검색 거래명세서
        public List<string[]> GetOrderDataListAll()
        {
            return _Database.DBProcess.GetOrderDataListAll();
        }
        public Customer GetCus()
        {
            return _Database.DBCustomer.GetCustomerOne(_Database.DBProcess.getCusNo(WorkOrder.OrderNo));
        }
        public List<string[]> GetBOMDataRecipt(WorkOrder wo)
        {
            return _Database.DBProcess.GetBOMDataRecipt(wo);
        }
        #region 검색 라벨
        public List<WorkOrder> GetCount(string Count)
        {
            return _Database.DBProcess.GetCount(Count);
        }
        public void InsertLabelTime(int Count)
        {
            _Database.DBProcess.InsertLabelTime(Count);
        }
        public void UpdateLabelTime()
        {
            _Database.DBProcess.UpdateLabelTime();
            _Database.DBProcess.UpdateTimeLag();
        }
        public void DeleteLabelTime()
        {
            _Database.DBProcess.DeleteLabelTime();
        }
        public void InsertExcelProduct(List<string[]> rtnList)
        {
            foreach (string[] str in rtnList)
            {
                string ProdutNo = "";
                List<String> max = new List<string>();
                max = MaxValue("ProductNo", "product");

                foreach (string value in max)
                {
                    ProdutNo = value;
                }

                Product pr = new Product();

                pr.ProductNo = Convert.ToInt32(ProdutNo);
                pr.ProductName = str[0];
                pr.ProductPrice = Convert.ToInt32(str[1]);
                pr.Unit = str[2];
                pr.BomStandard = str[3];
                pr.BomDrawingNo = str[4];
                pr.ProductMemo = str[5];

                _Database.DBProcess.InsertProductExcel(pr);
            }
        }
        public void InsertExcelValue(List<string[]> rtnList)
		{

            foreach(string[] str in rtnList)
            {
                string OrderNo = "" ;
                List<String> max = new List<string>();
                max = MaxValue("OrderNo", "work_order");

                foreach (string value in max)
                {
                    OrderNo = value;
                }
                string cus = "";
                cus = _Database.DBCustomer.CustomerNo(str[3]);

                string cusmem = "";
                if(cus.Length != 0) cusmem = _Database.DBCustomer.CustomerMemNo(str[4], cus);
                //고객사


                str[3] = cus;
                str[4] = cusmem;

                //OrderNo = 수주번호
                //rtnList   :   수주명	작성 일자	출하예정일	고객사	고객사 담당자	비고	수주 금액

                WorkOrder wo = new WorkOrder();

                //wo.


                wo.OrderNo = Convert.ToInt32(OrderNo);
                wo.OrderName = str[0];

                if (str[3].Length != 0) wo.CustomerNo = Convert.ToInt32(str[3]);
                if (str[4].Length != 0) wo.CustomerMemberNo = Convert.ToInt32(str[4]);

                wo.OrderDate = str[1];
                wo.OrderDateEnd = str[2];
                wo.OrderMemo = str[5];
                wo.OrderPrice = Convert.ToInt32( str[6]);

                _Database.DBProcess.InsertOrderExcel(wo);
            }

        }
		#endregion
		#endregion
	}
}
