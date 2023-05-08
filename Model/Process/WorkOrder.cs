// 수주/출하 
using System;

public class WorkOrder
{
    public WorkOrder()
    {
    }
    public int OrderNo { get; set; } 
    public string OrderName { get; set; }
    public string OrderStateName { get; set; }
    public string OrderDate { get; set; }
    public string OrderDateEnd { get; set; }
    public string OrderStartSchedule { get; set; }
    public string OrderEndSchedule { get; set; }
    public string RealEndDate { get; set; }
    public int CustomerNo { get; set; }
    public int CustomerMemberNo { get; set; }
    public string CustomerName { get; set; }
    public string CustomerGroup { get; set; }
    public string CustomerMemberName { get; set; }
    public string OrderMemo { get; set; }
    public Int64 OrderPrice { get; set; }
    public String OrderEmergency { get; set; }



}