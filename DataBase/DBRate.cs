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
	public class DBOperatingRate
	{
		private DBMain _DBMain;
		public DBOperatingRate(DBMain dBMain)
		{
			_DBMain = dBMain;
		}

		public List<Operating_Rate> Get30DaysData(string Start, string End)
		{
			List<Operating_Rate> operating_Rates = new List<Operating_Rate>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT `day`, `Value`, `count` FROM dayofcnt WHERE DAY BETWEEN @Start AND @End";



				cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
				cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");

				cmd.Parameters["@Start"].Value = Start;
				cmd.Parameters["@End"].Value = End;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						Operating_Rate operating_Rate = new Operating_Rate();

						operating_Rate.Day = rdr[0].ToString();
						operating_Rate.MachineValue = rdr[1].ToString();
						operating_Rate.Count = (int)rdr[2];

						operating_Rates.Add(operating_Rate);
					}

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return operating_Rates;
		}
		public List<Operating_Rate> GetSearchData(DateTime Start, DateTime End)
		{
			List<Operating_Rate> operating_Rates = new List<Operating_Rate>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT `day`, `Value`, `count` FROM dayofcnt WHERE DAY BETWEEN @Start AND @End";



				cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
				cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");

				cmd.Parameters["@Start"].Value = Start;
				cmd.Parameters["@End"].Value = End;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						Operating_Rate operating_Rate = new Operating_Rate();

						operating_Rate.Day = rdr[0].ToString();
						operating_Rate.MachineValue = rdr[1].ToString();
						operating_Rate.Count = (int)rdr[2];

						operating_Rates.Add(operating_Rate);
					}

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return operating_Rates;
		}
		public string GetSelectUnoperationData(string Start, string End)
		{
			string result = "";
			{
				List<Operating_Rate> list = new List<Operating_Rate>();
				using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "SELECT SUM(`Count`) FROM dayofcnt WHERE DAY BETWEEN @START AND @END AND `Value` = 'Unoperation' ";

					cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
					cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");

					cmd.Parameters["@Start"].Value = Start;
					cmd.Parameters["@End"].Value = End;

					try
					{
						cmd.Connection = conn;
						conn.Open();

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							result = rdr[0].ToString(); ;
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

		public string GetSelectOperationData(string Start, string End)
		{
			string result = "";
			{
				List<Operating_Rate> list = new List<Operating_Rate>();
				using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "SELECT SUM(`Count`) FROM dayofcnt WHERE DAY BETWEEN @START AND @END AND `Value` = 'Operation' ";

					cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
					cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");

					cmd.Parameters["@Start"].Value = Start;
					cmd.Parameters["@End"].Value = End;

					try
					{
						cmd.Connection = conn;
						conn.Open();

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							result = rdr[0].ToString(); ;
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
