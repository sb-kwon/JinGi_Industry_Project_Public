using System;

namespace Model
{
    public class LiveMonitor
    {
        public LiveMonitor()
        {
        }
        //public int machinenumber { get; set; } //번호로만
        public String MachineName { get; set; } // 이름 들어갈 시
        public String MachineValue { get; set; }
        public String Count { get; set; }
        public DateTime Time { get; set; }
    }
}
