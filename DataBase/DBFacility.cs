using System;
using System.Collections.Generic;
using System.Data;
using Model;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataBase
{
	public class DBFacilityRate
	{
		private DBMain _DBMain;
		public DBFacilityRate(DBMain dBMain)
		{
			_DBMain = dBMain;
		}

		public List<Machine> GetComboBox()
		{
			List<Machine> machines = new List<Machine>();

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT COUNT(*) FROM machine;";


				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = "SELECT MachineName FROM machine";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							Machine machine = new Machine();

							machine.MachineName = rdr[0].ToString();

							machines.Add(machine);
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
			return machines;
		}

		public List<Operating_Rate> Get30dayData(string start, string end, string MachineName)
		{
			List<Operating_Rate> list = new List<Operating_Rate>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = " SELECT `day`, `Value`, `Count`, `MachineName` " +
								  " FROM dayofcnt WHERE `MachineName` = @MachineName AND DAY BETWEEN @Start AND @End ";

				cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
				cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");
				cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 50, "MachineName");

				cmd.Parameters["@Start"].Value = start;
				cmd.Parameters["@End"].Value = end;
				cmd.Parameters["@MachineName"].Value = MachineName;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						Operating_Rate Facility = new Operating_Rate();

						Facility.Day = rdr[0].ToString();
						Facility.MachineValue = rdr[1].ToString();
						Facility.Count = (int)rdr[2];

						list.Add(Facility);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<Operating_Rate> GetSearchDataGrid(DateTime start, DateTime end, string MachineName)
		{
			List<Operating_Rate> list = new List<Operating_Rate>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = " SELECT `day`, `Value`, `Count`, `MachineName` " +
								  " FROM dayofcnt WHERE `MachineName` = @MachineName AND DAY BETWEEN @Start AND @End ";

				cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
				cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");
				cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 50, "MachineName");

				cmd.Parameters["@Start"].Value = start;
				cmd.Parameters["@End"].Value = end;
				cmd.Parameters["@MachineName"].Value = MachineName;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						Operating_Rate Facility = new Operating_Rate();

						Facility.Day = rdr[0].ToString();
						Facility.MachineValue = rdr[1].ToString();
						Facility.Count = (int)rdr[2];

						list.Add(Facility);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}

		public string GetSelectDayDataUnoperation(string Start, string End, string CbText)
		{
			string result = "";
			{
				List<Operating_Rate> list = new List<Operating_Rate>();
				using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "SELECT SUM(`Count`) FROM dayofcnt WHERE DAY BETWEEN @START AND @END AND `Value` = 'Unoperation' " +
									  "AND `MachineName` = @CbText ";

					cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
					cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");
					cmd.Parameters.Add("@CbText", MySqlDbType.VarChar, 50, "CbText");

					cmd.Parameters["@Start"].Value = Start;
					cmd.Parameters["@End"].Value = End;
					cmd.Parameters["@CbText"].Value = CbText;

					try
					{
						cmd.Connection = conn;
						conn.Open();

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							result = rdr[0].ToString();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
				return result;
			}
		}

		public string GetSelectDayData(string Start, string End, string CbText)
		{
			string result = "";
			{
				List<Operating_Rate> list = new List<Operating_Rate>();
				using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "SELECT SUM(`Count`) FROM dayofcnt WHERE DAY BETWEEN @START AND @END AND `Value` = 'Operation' " +
									  "AND `MachineName` = @CbText ";

					cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
					cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");
					cmd.Parameters.Add("@CbText", MySqlDbType.VarChar, 50, "CbText");

					cmd.Parameters["@Start"].Value = Start;
					cmd.Parameters["@End"].Value = End;
					cmd.Parameters["@CbText"].Value = CbText;

					try
					{
						cmd.Connection = conn;
						conn.Open();

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							result = rdr[0].ToString();
						}

					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
				return result;
			}
		}
	}
}
