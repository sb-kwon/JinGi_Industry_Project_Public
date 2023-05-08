using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataBase;
using System.Globalization;
using Controller;
using Model;

namespace Controller
{
    public class KpiCtrl
    {
        DBMain database = DBMain.Instance;
        public KpiCtrl()
        {
        }

        public work_process work_process { get; set; }

        public List<string> ComboListUp(bool type)
        {
            return database.DBKpi.ComboListUp(type);
        }
        public List<work_process> GetPChart(string str)
        {
            return database.DBKpi.GetPChart(str);
        }
        public List<Quality> GetQChart(string str)
        {
            return database.DBKpi.GetQChart(str);
        }
        public List<work_process> total(string str)
        {
            return database.DBKpi.total(str);
        }
    }
}
