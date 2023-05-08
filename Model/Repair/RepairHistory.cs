using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    // 점검관리(이력) 
    public class Repairhistory
    {
        // 점검번호 
        public int Repairhistoryno { get; set; }

        // 점검명 
        public string Repairname { get; set; }

        // 장비명 
        public string Machinename { get; set; }

        // 주기 
        public int Repairhistorytime { get; set; }
        public string RepairhistorytimeS { get; set; }
        public int RepairhistorytimeCount { get; set; }


        // 점검항목 
        public string Repairitem { get; set; }

        // 메모 
        public string Repairhistorymemo { get; set; }
    }
}
