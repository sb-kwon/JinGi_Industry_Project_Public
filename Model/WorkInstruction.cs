// 작업지시서(바코드 생성) 
using System;

public class WorkInstruction
{
    public WorkInstruction()
    {
        Product product = new Product();
        Product = product;
    }
    public Product Product { get; set; }
    // 고유번호(바코드값) 
    public Int64 WorkinstructionNo { get; set; }
    // 수주 고유번호 
    public int OrderNo { get; set; }
    // 작업지시서 상태 
    public int WorkinstructionState { get; set; }
    // 작업지시서 메모 
    public string WorkinstructionMemo { get; set; }
    // (인성한정)제품 번호 
    public int? ProductNo { get; set; }
    // 제품명 
    public string ProductName { get; set; }
    // 작업자 
    public string WorkinstructionMember { get; set; }
    // 장비명 
    public string MachineName { get; set; }
}