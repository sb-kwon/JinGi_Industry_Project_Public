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
	public class DBNonOperating
	{
		private DBMain _DBMain;
		public DBNonOperating(DBMain dBMain)
		{
			_DBMain = dBMain;
		}

		public List<Operating_Rate> GetStattCnt(string MachineName)
		{
			List<Operating_Rate> list = new List<Operating_Rate>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress + "allow user variables=true;"))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = //" SELECT `MachineName`, `Value`, SUM(COUNT) FROM dayofcnt " +
								  //" WHERE(`Value` = 'Unoperation' OR `Value` = 'Error') " +
								  //" AND MachineName = @MachineName GROUP BY `MachineName`, `Value` ORDER BY `MachineName` ";
								  " SELECT `MachineName`, `Value`, SUM(COUNT) FROM dayofcnt " +
								  " WHERE(`Value` NOT IN('Operation', 'Non-Error')) " +
								  " AND MachineName = @MachineName GROUP BY `MachineName`, `Value` ORDER BY `MachineName` ";

				cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 50, "MachineName");
				cmd.Parameters["@MachineName"].Value = MachineName;
				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						Operating_Rate Operating_Rate = new Operating_Rate();

						Operating_Rate.MachineName = rdr[0].ToString();
						Operating_Rate.MachineValue = rdr[1].ToString();
						int countsum = Int32.Parse(rdr[2].ToString());
						Operating_Rate.Count = countsum;

						list.Add(Operating_Rate);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}

		public List<Operating_Rate> GetBetweenCnt(string MachineName, string StartDate, string EndDate)
		{
			List<Operating_Rate> list = new List<Operating_Rate>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress + "allow user variables=true;"))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = //" SELECT `MachineName`, `Value`, sum(COUNT) FROM dayofcnt " +
								  //" WHERE (`Value` != 'Operation' OR `Value` != 'Non-Error') " +
								  //" AND MachineName = @MachineName AND DAY BETWEEN @Start AND @End " +
								  //" GROUP BY `MachineName`, `Value` ORDER BY `MachineName` ";
								  " SELECT `MachineName`, `Value`, sum(COUNT) FROM dayofcnt " +
								  " WHERE (`Value` NOT IN('Operation', 'Non-Error')) " +
								  " AND MachineName = @MachineName AND DAY BETWEEN @Start AND @End " +
								  " GROUP BY `MachineName`, `Value` ORDER BY `MachineName` ";

				cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 50, "MachineName");
				cmd.Parameters.Add("@Start", MySqlDbType.VarChar, 50, "Start");
				cmd.Parameters.Add("@End", MySqlDbType.VarChar, 50, "End");

				cmd.Parameters["@MachineName"].Value = MachineName;
				cmd.Parameters["@Start"].Value = StartDate;
				cmd.Parameters["@End"].Value = EndDate;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						Operating_Rate Between = new Operating_Rate();

						Between.MachineName = rdr[0].ToString();
						Between.MachineValue = rdr[1].ToString();
						Between.Count = Int32.Parse(rdr[2].ToString());

						list.Add(Between);
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
