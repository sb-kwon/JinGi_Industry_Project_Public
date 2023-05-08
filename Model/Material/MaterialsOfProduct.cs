using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Material
{
    // 자재 정보(자체 제작)(창고) 
    public class MaterialsOfProduct
    {
        // 자재 번호(생성) 
        public int Productno { get; set; }

        // 반제품/자재(반제품 : t, 자재 :f) 
        public bool MopB { get; set; }

        // 품번 
        public int MopNo { get; set; }
        // 수량
        public int MopCnt { get; set; }
        public string MopMemo { get; set; }
    }
}
