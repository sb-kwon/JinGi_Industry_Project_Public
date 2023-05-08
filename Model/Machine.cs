using System.IO.Ports;
using System;
using Model;

namespace Model
{
    public class Machine
    {
        public Machine()
        {
            WorkProcess Workprocess = new WorkProcess();
            WorkProcess = Workprocess;
        }
        public WorkProcess WorkProcess { get; set; }
        public String PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public String Parity { get; set; }
        public String StopBits { get; set; }
        public String ScannerMachineName { get; set; }
        public String MachineScanner { get; set; }
        // 스캐너

        public int MachineNo { get; set; }
        public String MachineName { get; set; }
        public String MachineType { get; set; }
        public String MachineCompany { get; set; }
        public String MachineDay { get; set; }
        public String MachineManagementNo { get; set; }
        public String MachineManager { get; set; }
        public String MachineLocation { get; set; }
        public String MachineNote { get; set; }
        public String MachineETC { get; set; }
        // 장비 머신

        public string OrderName { get; set; }
        public string ProductName { get; set; }
        public string MemberName { get; set; }
        public string WorkProcessPlanStart { get; set; }
        public string WorkProcessPlanEnd { get; set; }
        public Int64 WorkInstructionNo { get; set; }

    }
}
