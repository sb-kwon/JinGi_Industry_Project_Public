using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Material
{
    // 입출고 내역 (가계부) 
    public class Materials_Action
    {
        // 입출고 번호 
        public int WarehousingNo { get; set; }

        // 타입(입고인지, 출고인지) 
        public string WarehousingType { get; set; }

        // 제품 번호 (생성) 
        public int ProductNo { get; set; }

        // 수량 
        public int WarehousingCount { get; set; }

        // 비고 
        public string WarehousingMemo { get; set; }

        // 거래처 
        public string WarehousingCustomer { get; set; }

        // 자재 단가 
        public int WarehousingPrice { get; set; }

        // 입출고 날짜 
        public DateTime WarehousingDate { get; set; }

        // 자재 위치 
        public string MaterialsLocation { get; set; }


    }
}
