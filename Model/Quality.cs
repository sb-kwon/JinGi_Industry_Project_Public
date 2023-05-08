using System;
using Model;

public class Quality
{
    public Quality()
    {
        Machine machine = new Machine();
        Machine = machine;
    }
    public Machine Machine { get; set; }

    public String MemberName { get; set; } //자재 이름
    public String continenceName { get; set; } //자재 이름
    public String FairName { get; set; } //공정 이름

    public String InnercontinenceName { get; set; } //자재 이름
    public String InnerfiarName { get; set; } //공정 이름
    public String InnerStartTime { get; set; } //작업시작 시간
    public String InnerEndTime { get; set; } //작업종료 시간
    public String InnerNumber { get; set; } //공정번호
    public String InnerCause { get; set; } //원인
    public String InnerActions { get; set; } //조치사항
    public String InnerManager { get; set; } //담당자
    public String InnerDeadline { get; set; } //조치기한
    public String InnerErrorTime { get; set; } //불량발생시간
    public String InnerRemark { get; set; } //비고
    public String InnerOrder { get; set; } //수주명
    public String InnerProductName { get; set; } //품명
    public String InnerState { get; set; } //Quality_상태
    public string qualityCompletiontime { get; set; } //조치날짜
    public string KPIDefectTotalAmount { get; set; }// kpi 불량 총 수량
    public string InstructionNo { get; set; }
    public string WorkProcessNo { get; set; }
    public string DefectCount { get; set; }
    public string ClearCount { get; set; }
}