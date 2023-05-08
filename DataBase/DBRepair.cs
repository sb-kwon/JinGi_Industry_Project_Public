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
	public class DBRepair
	{
		private DBMain _DBMain;
		public DBRepair(DBMain dBMain)
		{
			_DBMain = dBMain;
		}

		public List<string[]> GetDefList()
		{
			List<string[]> defList = new List<string[]>();

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM def_repair) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = "SELECT  * FROM def_repair";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							String[] ma = new string[2];

							ma[0] = rdr[0].ToString();
							ma[1] = rdr[1].ToString();

							defList.Add(ma);
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
			return defList;
		}

		public string[] GetDefList(string str)
		{
			string[] defList = new string[2];

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM def_repair) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = "SELECT  * FROM def_repair where RepairNo = " + str;

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							defList[0] = rdr[0].ToString();
							defList[1] = rdr[1].ToString();
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
			return defList;
		}

		public void InsertHistory(Repairhistory repairhistory)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				try
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "INSERT INTO repairhistory " +
						"(RepairName, MachineName, RepairHistoryTime, RepairItem, RepairHistoryMemo) " +
						"VALUES (@RepairName, @MachineName, @RepairHistoryTime, @RepairItem, @RepairHistoryMemo) ";
					cmd.CommandType = CommandType.Text;

					cmd.Parameters.Add("@RepairName", MySqlDbType.VarChar, 45, "RepairName");
					cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 45, "MachineName");
					cmd.Parameters.Add("@RepairHistoryTime", MySqlDbType.VarChar, 45, "RepairHistoryTime");
					cmd.Parameters.Add("@RepairItem", MySqlDbType.VarChar, 45, "RepairItem");
					cmd.Parameters.Add("@RepairHistoryMemo", MySqlDbType.VarChar, 45, "RepairHistoryMemo");

					cmd.Parameters["@RepairName"].Value = repairhistory.Repairname;
					cmd.Parameters["@MachineName"].Value = repairhistory.Machinename;
					cmd.Parameters["@RepairHistoryTime"].Value = repairhistory.Repairhistorytime;
					cmd.Parameters["@RepairItem"].Value = repairhistory.Repairitem;
					cmd.Parameters["@RepairHistoryMemo"].Value = repairhistory.Repairhistorymemo;

					cmd.Connection = conn;

					if (conn.State == ConnectionState.Open) conn.Close();
					conn.Open();

					cmd.ExecuteNonQuery();


				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}//using
		}

		public void UpdateRepairSituraion(Repairsituation rs)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText =
								"UPDATE repairsituation SET " +
								"RepairsituationTime =  @RepairsituationTime, RepairsituationMember =  @RepairsituationMember, " +
								"RepairsituationDetails =  @RepairsituationDetails, RepairsituationMemo =  @RepairsituationMemo " +
								"WHERE RepairsituationNo = @RepairsituationNo";

				cmd.Parameters.Add("@RepairsituationTime", MySqlDbType.Date, 45, "RepairsituationTime");
				cmd.Parameters.Add("@RepairsituationMember", MySqlDbType.VarChar, 45, "RepairsituationMember");
				cmd.Parameters.Add("@RepairsituationDetails", MySqlDbType.VarChar, 45, "RepairsituationDetails");
				cmd.Parameters.Add("@RepairsituationMemo", MySqlDbType.VarChar, 45, "RepairsituationMemo");
				cmd.Parameters.Add("@RepairsituationNo", MySqlDbType.VarChar, 11, "RepairsituationNo");

				cmd.Parameters["@RepairsituationTime"].Value = DateTime.Now;
				cmd.Parameters["@RepairsituationMember"].Value = rs.Repairsituationmember;
				cmd.Parameters["@RepairsituationDetails"].Value = rs.Repairsituationdetails;
				cmd.Parameters["@RepairsituationMemo"].Value = rs.Repairsituationmemo;
				cmd.Parameters["@RepairsituationNo"].Value = rs.Repairsituationno;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}//using
		}

		public void InsertSituration(Repairsituation situation)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				try
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "INSERT INTO repairsituation " +
						"(RepairName, RepairsituationDetails, RepairsituationHistory) " +
						"VALUES (@RepairName, @RepairsituationDetails, @RepairsituationHistory) ";
					cmd.CommandType = CommandType.Text;

					cmd.Parameters.Add("@RepairName", MySqlDbType.VarChar, 45, "RepairName");
					cmd.Parameters.Add("@RepairsituationDetails", MySqlDbType.VarChar, 45, "RepairsituationDetails");
					cmd.Parameters.Add("@RepairsituationHistory", MySqlDbType.Int32, 11, "RepairsituationHistory");

					cmd.Parameters["@RepairName"].Value = situation.Repairname;
					cmd.Parameters["@RepairsituationDetails"].Value = situation.Repairsituationdetails;
					cmd.Parameters["@RepairsituationHistory"].Value = situation.RepairsituationHistory;

					cmd.Connection = conn;

					if (conn.State == ConnectionState.Open) conn.Close();
					conn.Open();

					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}//using
		}

		public void UpdateHistory(Repairhistory repairhistory)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText =
								"UPDATE repairhistory SET " +
								"RepairName =  @RepairName, MachineName =  @MachineName, RepairHistoryTime =  @RepairHistoryTime, " +
								"RepairItem =  @RepairItem, RepairHistoryMemo =  @RepairHistoryMemo " +
								"WHERE RepairhistoryNo = @RepairhistoryNo";

				cmd.Parameters.Add("@RepairName", MySqlDbType.VarChar, 45, "RepairName");
				cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 45, "MachineName");
				cmd.Parameters.Add("@RepairHistoryTime", MySqlDbType.VarChar, 45, "RepairHistoryTime");
				cmd.Parameters.Add("@RepairItem", MySqlDbType.VarChar, 45, "RepairItem");
				cmd.Parameters.Add("@RepairHistoryMemo", MySqlDbType.VarChar, 45, "RepairHistoryMemo");
				cmd.Parameters.Add("@RepairhistoryNo", MySqlDbType.Int32, 11, "RepairhistoryNo");

				cmd.Parameters["@RepairName"].Value = repairhistory.Repairname;
				cmd.Parameters["@MachineName"].Value = repairhistory.Machinename;
				cmd.Parameters["@RepairHistoryTime"].Value = repairhistory.Repairhistorytime;
				cmd.Parameters["@RepairItem"].Value = repairhistory.Repairitem;
				cmd.Parameters["@RepairHistoryMemo"].Value = repairhistory.Repairhistorymemo;
				cmd.Parameters["@RepairhistoryNo"].Value = repairhistory.Repairhistoryno;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}//using
		}

		public void DeleteHistory(int repairhistoryno)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "DELETE FROM repairhistory WHERE RepairhistoryNo = @RepairhistoryNo";
				cmd.Parameters.Add("@RepairhistoryNo", MySqlDbType.Int32, 11, "RepairhistoryNo");
				cmd.Parameters["@RepairhistoryNo"].Value = repairhistoryno;

				try
				{
					cmd.Connection = conn;
					if (conn.State == ConnectionState.Open) conn.Close();
					conn.Open();

					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
		}

		public List<Repairhistory> GetHistoryList()
		{
			List<Repairhistory> list = new List<Repairhistory>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM repairhistory) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText =
											"SELECT * " +
											"FROM repairhistory ";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							Repairhistory rs = new Repairhistory();

							rs.Repairhistoryno = (int)rdr[0];
							rs.Repairname = rdr[1].ToString();
							rs.Machinename = rdr[2].ToString();
							rs.Repairhistorytime = (int)rdr[3];
							rs.Repairitem = rdr[4].ToString();
							rs.Repairhistorymemo = rdr[5].ToString();
							rs.RepairhistorytimeCount = (int)rdr[6];

							list.Add(rs);
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
		public List<Repairsituation> GetSituation()
		{
			List<Repairsituation> list = new List<Repairsituation>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM repairsituation) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText =
											"SELECT * " +
											"FROM repairsituation ";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							Repairsituation rs = new Repairsituation();

							rs.Repairsituationno = (int)rdr[0];
							if (rdr.IsDBNull(1)) rs.Repairsituationtime = null;
							else rs.Repairsituationtime = (DateTime)rdr[1];
							rs.Repairname = rdr[2].ToString();
							rs.Repairsituationmember = rdr[3].ToString();
							rs.Repairsituationdetails = rdr[4].ToString();
							rs.Repairsituationmemo = rdr[5].ToString();
							rs.RepairsituationHistory = (int)rdr[6];

							list.Add(rs);
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
		public void DeleteDef(string[] selectValue)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "DELETE FROM def_repair WHERE RepairNo = @RepairNo";
				cmd.Parameters.Add("@RepairNo", MySqlDbType.Int32, 11, "RepairNo");
				cmd.Parameters["@RepairNo"].Value = selectValue[0];

				try
				{
					cmd.Connection = conn;
					if (conn.State == ConnectionState.Open) conn.Close();
					conn.Open();

					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
		}

		public void UpdateDef(string[] selectValue)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText =
								"UPDATE def_repair SET " +
								"RepairName =  @RepairName " +
								"WHERE RepairNo = @RepairNo";

				cmd.Parameters.Add("@RepairName", MySqlDbType.VarChar, 45, "RepairName");
				cmd.Parameters.Add("@RepairNo", MySqlDbType.Int32, 11, "RepairNo");

				cmd.Parameters["@RepairName"].Value = selectValue[1];
				cmd.Parameters["@RepairNo"].Value = selectValue[0];
				try
				{
					cmd.Connection = conn;
					conn.Open();

					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}//using
		}

		public void InsertDef(string text)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				try
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "INSERT INTO def_repair " +
										"(RepairName) " +
										"VALUES(@RepairName)";
					cmd.CommandType = CommandType.Text;

					cmd.Parameters.Add("@RepairName", MySqlDbType.VarChar, 45, "RepairName");

					cmd.Parameters["@RepairName"].Value = text;

					cmd.Connection = conn;

					if (conn.State == ConnectionState.Open) conn.Close();
					conn.Open();

					cmd.ExecuteNonQuery();


				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}//using
		}
	}
}