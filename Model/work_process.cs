// 작업공정 
using System;

public class work_process
{
    // 작업 공정 고유번호 
    public int workProcessNo { get; set; }
    // 자제명 
    public string continenceName { get; set; }
    // 공정 명 
    public string fiarName { get; set; }
    public string FiarReal { get; set; }
    // 공정 순서 
    public int fiarSort { get; set; }
    // 작업공정 시작시간 
    public DateTime? workProcessStartTime { get; set; }
    // 작업공정 종료시간 
    public DateTime? workProcessEndTime { get; set; }
    // 작업공정 상태 
    public string workProcessStateName { get; set; }
    // 고유번호(바코드값) 
    public Int64 workInstructionNo { get; set; }
    // 작업공정 메모 
    public string workProcessMemo { get; set; }
    public string MachineName { get; set; }
    public string MemberName { get; set; }
    public string workProcessTimestampdiff { get; set; }
    // kpi months
    public string EndTimeMonth { get; set; }
    // kpi 총 수량
    public string KPITotalAmount { get; set; }
}