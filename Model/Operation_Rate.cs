using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Operating_Rate
    {
        public Operating_Rate()
        {
        }
        // 장비 이름
        public String MachineName { get; set; }
        // 전류 값
        public String MachineValue { get; set; }
        // 전류 값 카운팅
        public int Count { get; set; }

        public String Day { get; set; }
    }
}
