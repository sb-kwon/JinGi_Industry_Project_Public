using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataBase
{
	public class DBMonitor
	{
		private DBMain _DBMain;
		public DBMonitor(DBMain dBMain)
		{
			_DBMain = dBMain;
		}
		public Dictionary<string, LiveMonitor> SetData(string num, Dictionary<string, LiveMonitor> keyValuePairs)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = " SELECT machineNumber, `machineTime`, " + num + " from(SELECT* from machine_data where (machineNumber, `machineTime`) " +
								  " in (select machineNumber, max(`machineTime`) as `Time`	from machine_data group by machineNumber) " +
								  " order by `machineTime` DESC) t group by t.machineNumber ";


				cmd.Parameters.Add("@String", MySqlDbType.VarChar, 50, "String");

				cmd.Parameters["@String"].Value = num;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						keyValuePairs[rdr[0].ToString()].MachineName = rdr[0].ToString();
						keyValuePairs[rdr[0].ToString()].Time = Convert.ToDateTime(rdr[1]);
						keyValuePairs[rdr[0].ToString()].MachineValue = rdr[2].ToString();

						//if (num.Equals("num"))
						//{
						//    keyValuePairs[rdr[1].ToString()].num = Convert.ToDecimal(rdr[2]);
						//}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return keyValuePairs;
		}
		public List<LiveMonitor> GetMonitor()
		{
			List<LiveMonitor> list = new List<LiveMonitor>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "Select machineNumber, machineValue, COUNT(*) from machine_data " +
								  "group by machineValue, machineNumber order by machineValue; ";
				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						LiveMonitor live = new LiveMonitor();

						live.MachineName = rdr[0].ToString();
						live.MachineValue = rdr[1].ToString();
						live.Count = rdr[2].ToString();

						list.Add(live);
					}

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}

		public List<LiveMonitor> GetError()
		{
			List<LiveMonitor> list = new List<LiveMonitor>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = " SELECT MachineName, MachineErrorValue, count(*) from machine_errordata WHERE MachineErrorValue = 'Error' " +
								  " AND(MachineName = 'DOOSAN-DNM650P2' OR MachineName = 'DOOSAN-MYNX5400') " +
								  " group by MachineErrorValue, MachineName order by MachineErrorValue ";
				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						LiveMonitor live = new LiveMonitor();

						live.MachineName = rdr[0].ToString();
						live.MachineValue = rdr[1].ToString();
						live.Count = rdr[2].ToString();

						list.Add(live);
					}

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<LiveMonitor> GetAllError()
		{
			List<LiveMonitor> list = new List<LiveMonitor>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = " SELECT MachineName, MachineErrorValue, ROUND((COUNT(*) * 8) / 3600, 1) FROM machine_errordata " +
								  " WHERE MachineErrorValue = 'Error' group by MachineErrorValue, MachineName order by MachineErrorValue ";

				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						LiveMonitor live = new LiveMonitor();

						live.MachineName = rdr[0].ToString();
						live.MachineValue = rdr[1].ToString();
						live.Count = rdr[2].ToString();

						list.Add(live);
					}

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<LiveMonitor> GetLastStateData()
		{
			List<LiveMonitor> list = new List<LiveMonitor>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = " SELECT count(*) FROM(SELECT * from machine_data where (machineNumber, machineTime) "
								+ " in (select machineNumber, max(machineTime) as machineTime from machine_data group by machineNumber) "
								+ " order by machineTime DESC)K group by K.machineNumber ";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = " SELECT machineNumber, machineValue FROM(SELECT* from machine_data where (machineNumber, machineTime) "
										+ " in (select machineNumber, max(machineTime) as machineTime from machine_data group by machineNumber) "
										+ " order by machineTime DESC)K group by K.machineNumber ";


						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							LiveMonitor state = new LiveMonitor
							{
								MachineName = rdr[0].ToString(),
								MachineValue = rdr[1].ToString()
							};
							list.Add(state);
						}
					}
					else
					{
						return null;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
	}
}
