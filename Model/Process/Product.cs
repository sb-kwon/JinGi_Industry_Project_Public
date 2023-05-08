using System;

public class Product
{
    public Product()
    {
        WorkProcess workProcess = new WorkProcess();
        WorkProcess = workProcess;
    }
    public WorkProcess WorkProcess { get; set; }
    public int ProductNo { get; set; } //제품 번호
    public string ProductName { get; set; } //품목 이름
    public string ProductType { get; set; } //품목 타입 (외주, 자체)
    public int ProductPrice { get; set; }  //제품 단가
    public string Unit { get; set; } //
    public string BomStandard { get; set; } //
    public string BomDrawingNo { get; set; } //
    public string ProductMemo { get; set; } //메모(비고)

    public int OrderNo { get; set; }
    public string OrderName { get; set; }

    public string WorkProcessPlanStart { get; set; }
    public string WorkProcessPlanEnd { get; set; }




}