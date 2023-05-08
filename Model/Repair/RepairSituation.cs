using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    // 점검 현황 
    public class Repairsituation
    {
        // 고유번호 
        public int Repairsituationno { get; set; }

        // 검사시간 
        public DateTime? Repairsituationtime { get; set; }

        // 점검명 
        public string Repairname { get; set; }

        // 검사자 
        public string Repairsituationmember { get; set; }

        // 점검항목결과 
        public string Repairsituationdetails { get; set; }

        // 메모 
        public string Repairsituationmemo { get; set; }       
        public int RepairsituationHistory { get; set; }
    }
}
