using System;
using System.IO.Ports;

namespace Model
{
    public class OrderDraftList
    {
        // 발주 항목 
        public int Orderdraftlistno { get; set; }

        // 발주서 고유번호 
        public int Orderdraftno { get; set; }

        // 발주 항목 명 
        public string Orderdraftlistname { get; set; }

        // 발주 항목 규격 
        public string Orderdraftliststandard { get; set; }

        // 발주 항목 수량 
        public string Orderdraftlistcount { get; set; }

        // 발주 항목 공급가 
        public string Orderdraftlistprice { get; set; }

        // 발주 항목 새액 
        public string Orderdraftlisttax { get; set; }



    }
}
