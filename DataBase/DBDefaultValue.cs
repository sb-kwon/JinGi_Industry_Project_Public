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
	public class DBDefaultValue
	{
		private DBMain _DBMain;
		public DBDefaultValue(DBMain dBMain)
		{
			_DBMain = dBMain;
		}

		/// <summary>
		/// 표준 공정 목록 불러오기
		/// </summary>
		/// <returns></returns>
		public List<DefFair> GetFariList(String str)
		{
			List<DefFair> list = new List<DefFair>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM def_fair where def_fair.fairGroup = @fairGroup) as success";

				cmd.Parameters.Add("@fairGroup", MySqlDbType.VarChar, 50, "fairGroup");
				cmd.Parameters["@fairGroup"].Value = str;

				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = "SELECT def_fair.fairName, def_fair.fairSort, def_fair.fairColor, def_fair.fairGroup, def_fair.fairreal FROM def_fair  where def_fair.fairGroup = @fairGroup order by def_fair.fairSort";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							DefFair defFair = new DefFair();

							defFair.fairname = rdr[0].ToString();
							defFair.fairsort = (int)rdr[1];
							defFair.faircolor = (int)rdr[2];
							defFair.fairgroup = rdr[3].ToString();
							defFair.fairreal = rdr[4].ToString();
							list.Add(defFair);
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
					return null;
				}
			}
			return list;
		}


		//점검명
		public List<String> GetRepairName()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_repair.RepairName FROM def_repair ORDER BY RepairNo ASC";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return list;
		}

		public void DeleteFair(string fairno)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "DELETE FROM def_fair WHERE fairno = @fairno";

				cmd.Parameters.Add("@fairno", MySqlDbType.VarChar, 50, "fairno");
				cmd.Parameters["@fairno"].Value = fairno;

				cmd.Connection = conn;
				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateFair(DefFair df)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "UPDATE def_fair SET "
					+ " fairName = @fairName, fairSort = @fairSort, fairColor = @fairColor, fairGroup = @fairGroup, fairreal = @fairreal"
					+ " WHERE fairno = @fairno";

				cmd.Parameters.Add("@fairSort", MySqlDbType.Int32, 50, "fairSort");
				cmd.Parameters.Add("@fairColor", MySqlDbType.Int32, 50, "fairColor");
				cmd.Parameters.Add("@fairGroup", MySqlDbType.VarChar, 50, "fairGroup");
				cmd.Parameters.Add("@fairName", MySqlDbType.VarChar, 50, "fairName");
				cmd.Parameters.Add("@fairreal", MySqlDbType.VarChar, 50, "fairreal");
				cmd.Parameters.Add("@fairno", MySqlDbType.VarChar, 50, "fairno");

				cmd.Parameters["@fairSort"].Value = df.fairsort;
				cmd.Parameters["@fairColor"].Value = df.faircolor;
				cmd.Parameters["@fairGroup"].Value = df.fairgroup;
				cmd.Parameters["@fairName"].Value = df.fairname;
				cmd.Parameters["@fairreal"].Value = df.fairreal;
				cmd.Parameters["@fairno"].Value = df.fairno;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();

			}//using
		}

		public void InsertDefData(Def def, string text)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "INSERT INTO " + def.TableLogical + " (" + def.ValueLogical + ") " +
							"VALUES(@value)";

				cmd.Parameters.Add("@value", MySqlDbType.VarChar, 50, "value");
				cmd.Parameters["@value"].Value = text;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}//using
		}

		public void DeleteDefData(Def def)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "DELETE FROM " + def.TableLogical + " WHERE " + def.ValueLogical + " = @value";

				cmd.Parameters.Add("@value", MySqlDbType.VarChar, 50, "value");
				cmd.Parameters["@value"].Value = def.SelectValue;

				cmd.Connection = conn;
				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}

		public List<string[]> GetCustomerMember(int customer)
		{
			List<string[]> list = new List<string[]>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT customer_member.CustomerMemberName, customer_member.CustomerMemberNo FROM customer_member where CustomerNo = @CustomerNo";
				cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 11, "CustomerNo");
				cmd.Parameters["@CustomerNo"].Value = customer;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						string[] strArray = new string[2];

						strArray[0] = rdr[0].ToString();  //이름
						strArray[1] = rdr[1].ToString();  //위치
						list.Add(strArray);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return list;
		}

		public void UpdateDefData(Def def, string text)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "UPDATE " + def.TableLogical + " SET "
					+ def.ValueLogical + " = @value"
					+ " WHERE " + def.ValueLogical + " = @locateion";

				cmd.Parameters.Add("@value", MySqlDbType.VarChar, 50, "value");
				cmd.Parameters.Add("@locateion", MySqlDbType.VarChar, 50, "locateion");
				cmd.Parameters["@value"].Value = text;
				cmd.Parameters["@locateion"].Value = def.SelectValue;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();

			}//using
		}

		public bool FindDefData(string table, string location, string value)
		{
			bool result = false;
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM " + table + " WHERE " + location + " = @value) as success";

				cmd.Parameters.Add("@value", MySqlDbType.VarChar, 50, "value");
				cmd.Parameters["@value"].Value = value;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
						result = true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					result = false;
				};
			}
			return result;
		}
		/// <summary>
		/// 표준 공정 목록 불러오기
		/// </summary>
		/// <returns></returns>
		public List<DefFair> GetFariList()
		{
			List<DefFair> list = new List<DefFair>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM def_fair) as success";

				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = "SELECT def_fair.fairName, def_fair.fairSort, def_fair.fairColor, def_fair.fairGroup, def_fair.fairreal, def_fair.fairno FROM def_fair order by def_fair.fairName ";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							DefFair defFair = new DefFair();

							defFair.fairname = rdr[0].ToString();
							defFair.fairsort = (int)rdr[1];
							defFair.faircolor = (int)rdr[2];
							defFair.fairgroup = rdr[3].ToString();
							defFair.fairreal = rdr[4].ToString();
							defFair.fairno = rdr[5].ToString();
							list.Add(defFair);
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
					return null;
				}
			}
			return list;
		}
		//-------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///이하 리스트 가저오기
		/// </summary>
		/// <returns></returns>
		/// 
		public List<string[]> GetCustomerForType(bool v)
		{
			string value = "";
			if (v) value = "매출처";//트루이면 매출처
			else value = "매입처";
			List<string[]> list = new List<string[]>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select CustomerName, CustomerNo from Customer where CustomerGroup = @CustomerGroup";
				cmd.Parameters.Add("@CustomerGroup", MySqlDbType.VarChar, 50, "CustomerGroup");
				cmd.Parameters["@CustomerGroup"].Value = value;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();


					while (rdr.Read())
					{
						string[] strArray = new string[2];

						strArray[0] = rdr[0].ToString();  //이름
						strArray[1] = rdr[1].ToString();  //위치
						list.Add(strArray);
					}

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return list;
		}

		public List<string> GetUnitList()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT * FROM def_unit";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return list;
		}

		public List<String> GetRankList()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT * FROM def_rank";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return list;
		}
		public List<String> GetCustomerGroupList()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_customer_group.CustomerGroup FROM def_customer_group ORDER BY CustomerGroup DESC";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return list;
		}
		public List<string> GetDefAuthorityMain()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_authority_main.authorityName FROM def_authority_main";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return list;
		}
		public List<string> GetDefAuthorityList()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_authority_list.authorityLocation FROM def_authority_list";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return list;
		}
		public List<string> GetDefContinence()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT product.ProductName FROM product GROUP BY product.ProductName";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefMachineType()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_machine_type.MachineType FROM def_machine_type";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefContinenceAction()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_continence_action.continenceActionName FROM def_continence_action";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefContinenceType()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_continence_type.continenceType FROM def_continence_type";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefMaterial()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_material.materialName FROM def_material";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefContinenceLocation()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_continence_location.continenceLocation FROM def_continence_location";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefOrderState()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_order_state.orderStateName FROM def_order_state";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefWorkProcess()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_work_process.fairReal FROM def_work_process";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefWorkProcessState()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_work_process_state.workProcessStateName FROM def_work_process_state";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefFair()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_fair.fairName FROM def_fair GROUP BY def_fair.fairName ORDER BY def_fair.FairName";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}
		public List<string> GetDefFairGroup()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_fair_group.fairGroup FROM def_fair_group";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}

		//Machine
		public List<String> TypeList()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_machine_type.MachineType FROM def_machine_type";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}

		public bool CheckFair(DefFair DF)
		{
			bool result = true;
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();

				cmd.CommandText = " SELECT EXISTS (SELECT * FROM def_fair WHERE FairName = @FairName AND FairGroup = @FairGroup) AS success ";

				cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "FairName");
				cmd.Parameters.Add("@FairGroup", MySqlDbType.VarChar, 50, "FairGroup");

				cmd.Parameters["@FairName"].Value = DF.fairname;
				cmd.Parameters["@FairGroup"].Value = DF.fairgroup;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
						result = false;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					result = true;
				};
			}
			return result;
		}
		public void InsertFairGroup(DefFair DF)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = " INSERT INTO def_fair(FairName, FairSort, FairColor, FairGroup, FairReal) " +
								  " VALUES(@FairName, @FairSort, @FairColor, @FairGroup, @FairReal) ";

				cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "FairName");
				cmd.Parameters.Add("@FairSort", MySqlDbType.VarChar, 50, "FairSort");
				cmd.Parameters.Add("@FairGroup", MySqlDbType.VarChar, 50, "FairGroup");
				cmd.Parameters.Add("@FairReal", MySqlDbType.VarChar, 50, "FairReal");
				cmd.Parameters.Add("@FairColor", MySqlDbType.VarChar, 50, "FairColor");

				cmd.Parameters["@FairName"].Value = DF.fairname;
				cmd.Parameters["@FairSort"].Value = DF.fairsort;
				cmd.Parameters["@FairGroup"].Value = DF.fairgroup;
				cmd.Parameters["@FairReal"].Value = DF.fairreal;
				cmd.Parameters["@FairColor"].Value = DF.faircolor;


				cmd.Connection = conn;
				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();

			}//using
		}
		public List<string> GetDefProductType()
        {
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_product_type.ProductType FROM def_product_type";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return list;
		}

        public List<string> GetDefProcessMapping()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_work_process.fairReal FROM def_work_process";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
						list.Add(rdr[0].ToString());
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
