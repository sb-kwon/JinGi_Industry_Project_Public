using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    // 자재 정보(자체 제작)(창고) 
    public class Materials_Of_Product
    {
        // 자재 번호(생성) 
        public int ProductNo { get; set; }

        // 자재 타입 
        public bool mopB { get; set; }

        // 자재 명 
        public int mopNo { get; set; }

        // 수량 
        public int mopCnt { get; set; }


    }
}
