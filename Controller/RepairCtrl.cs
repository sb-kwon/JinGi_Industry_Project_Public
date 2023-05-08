using DataBase;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
	public class RepairCtrl
	{
		private DBMain _Database = DBMain.Instance;
		public RepairCtrl() 
		{
			GetData();
		}

		#region Getter/Setter
		public List<String[]> DefList { get; set; }
		public List<Repairhistory> RepairhistoryList { get; set; }
		public List<Repairsituation> RepairsituationList { get; set; }
		#endregion

		public void GetData()
		{
			DefList = _Database.DBRepair.GetDefList();
			RepairhistoryList = _Database.DBRepair.GetHistoryList();
			RepairsituationList = _Database.DBRepair.GetSituation();

		}
		public string SetTimevalue(int time)
		{
			string ret = "";
			switch (time)
			{
				case 1:
					ret = "매일";
					break;
				case 7:
					ret = "매주";
					break;
				case 30:
					ret = "매월";
					break;
				case 90:
					ret = "분기";
					break;
				case 180:
					ret = "반기";
					break;
				case 365:
					ret = "일년";
					break;
			}
			return ret;
		}

		public void InsertDef(string text)
		{
			_Database.DBRepair.InsertDef(text);
			GetData();
		}

		public void UpdateDef(string[] selectValue)
		{
			_Database.DBRepair.UpdateDef(selectValue);
			GetData();
		}

		public void DeleteDef(string[] selectValue)
		{
			_Database.DBRepair.DeleteDef(selectValue);
			GetData();
		}

		public void InsertHistory(Repairhistory repairhistory)
		{
			_Database.DBRepair.InsertHistory(repairhistory);
			GetData();
		}

		public void DeleteHistory(int repairhistoryno)
		{
			_Database.DBRepair.DeleteHistory(repairhistoryno);
			GetData();
		}

		public void UpdateHistory(Repairhistory repairhistory)
		{
			_Database.DBRepair.UpdateHistory(repairhistory);
			GetData();
		}

		public List<string[]> GetDefFindList(int repairsituationHistory)
		{
			List<string[]> result = new List<string[]>();
			string str = "";
			foreach (Repairhistory rs in RepairhistoryList)
			{
				if (rs.Repairhistoryno.Equals(repairsituationHistory))
				{
					str = rs.Repairitem;
					break;
				}
			}

			if (str.Length != 0)
			{
				string[] array = str.Split(',');

				foreach (string value in array)
				{
					result.Add(_Database.DBRepair.GetDefList(value));
				}
			}


			return result;
		}

		public void InsertSituation(Repairhistory rs)
		{
			Repairsituation situation = new Repairsituation();
			situation.Repairname = rs.Repairname;
			situation.RepairsituationHistory = rs.Repairhistoryno;


			/*string[] array = rs.Repairitem.Split(',');
			string result = "";
			for (int i = 0; i < array.Length - 1; i++) result = result + ",";*/

			situation.Repairsituationdetails = rs.Repairitem;

			_Database.DBRepair.InsertSituration(situation);
		}

		public void UpdateRepairSituraion(Repairsituation rs)
		{
			_Database.DBRepair.UpdateRepairSituraion(rs);
		}
	}
}
