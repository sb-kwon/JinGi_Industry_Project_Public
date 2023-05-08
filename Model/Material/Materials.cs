using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Material
{
    // 자재 정보(자체 제작)(창고) 
    public class Materials
    {
        // 자재 번호(생성) 
        public int MaterialsNo { get; set; }

        // 자재 타입 
        public string MaterialsType { get; set; }

        // 자재 명 
        public string MaterialsName { get; set; }

        // 수량 
        public int MaterialsCount { get; set; }

        // 규격 
        public string MaterialsStandard { get; set; }

        // 자재 평균 단가 
        public int MaterialsPrice { get; set; }

        // 메모(비고) 
        public string MaterialsMemo { get; set; }

        public string Unit { get; set; }

    }
}
