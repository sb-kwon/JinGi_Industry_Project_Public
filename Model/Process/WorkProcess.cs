using System;

public class WorkProcess
{
    public WorkProcess()
    {
        WorkOrder workOrder = new WorkOrder();
        WorkOrder = workOrder;
    }
    public WorkOrder WorkOrder { get; set; }
    public int WorkProcessNo { get; set; } //
    public Int64 WorkInstructionNo { get; set; } //
    public string WorkProcessStateName { get; set; } //
    public string FairReal { get; set; } //
    public string FairName { get; set; } //
    public int FairSort { get; set; } //
    public string FairGroup { get; set; } //
    public string MemberId { get; set; } //
    public string MemberName { get; set; } //
    public int MachineNo { get; set; } //
    public string MachineName { get; set; } //
    public string WorkProcessPlanStart { get; set; } //
    public string WorkProcessPlanEnd { get; set; } //
    public DateTime WorkProcessStartTime { get; set; } //
    public DateTime WorkProcessEndTime { get; set; } //
    public DateTime BomOutTime { get; set; } //
    public DateTime BomInTime { get; set; } //
    public string WorkProcessMemo { get; set; } //



    public int OrderNo { get; set; }
    public string OrderName { get; set; }
    public int ProductNo { get; set; } //제품 번호
    public string ProductName { get; set; } //품목 이름
    public string ProductType { get; set; } //품목 타입 (외주, 자체)
    public string OrderMemo { get; set; }

    public string OrderStartSchedule { get; set; }
    public string OrderEndSchedule { get; set; }

}