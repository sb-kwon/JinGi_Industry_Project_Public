using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Model
{
    public class OrderDraft
    {
        // 발주서 고유번호 
        public int Orderdraftno { get; set; }

        // 발주서 날짜 
        public string Orderdraftdate { get; set; }

        // 발주서 발주처 
        public string Orderdraftcustomer { get; set; }

        // 발주서 비고 
        public string Orderdraftmemo { get; set; }
   
        //항목들
        public List<OrderDraftList> OrderDraftLists { get; set; }

        public string OrderDraftCusMem { get; set; }



    }
}
