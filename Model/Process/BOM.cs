using System;

public class BOM
{
    public BOM()
    {
    }

    public int BomNo { get; set; } //bom고유번호
    public int WorkInstructionNo { get; set; } //고유번호(바코드값)
    public int ProductNo { get; set; } //제품 번호(생성)
    public int OrderNo { get; set; } //수주 고유번호
    public int BomCount { get; set; } //제품 수량


}