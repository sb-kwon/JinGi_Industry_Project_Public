using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Material;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace DataBase
{
	public class DBMaterials
	{
		private DBMain _DBMain;
		public DBMaterials(DBMain dBMain)
		{
			_DBMain = dBMain;
		}

		#region MaterialsAction
		public List<string[]> GetMaterial_Actions()
		{
			List<string[]> list = new List<string[]>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials_action) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText =
											"SELECT ma.*, mtl.MaterialsName, mtl.MaterialsCount " +
											"FROM materials_action AS ma LEFT JOIN " +
											"materials as mtl ON ma.MaterialsNo = mtl.MaterialsNo " +
											"WHERE ma.WarehousingDate BETWEEN DATE_ADD(NOW(),INTERVAL -3 MONTH ) AND NOW()";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							String[] ma = new string[11];

							ma[0] = rdr[0].ToString();
							ma[1] = rdr[1].ToString().Substring(0,10);
							ma[2] = rdr[2].ToString();
							ma[3] = rdr[3].ToString();
							ma[4] = rdr[4].ToString();
							ma[5] = rdr[5].ToString();
							ma[6] = rdr[9].ToString();
							ma[7] = rdr[6].ToString();
							ma[8] = rdr[10].ToString();
							ma[9] = rdr[7].ToString();
							ma[10] = rdr[8].ToString();

							list.Add(ma);
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

		public List<string[]> GetSemiMaterials( string value)
		{
			List<string[]> result = new List<string[]>();
		
			if(value.Length != 0)
			{
				string[] str = value.Split(new char[] { ',' }); //자제 수만큼

				foreach (string material in str)
				{
					string[] name = new string[3];

					name = material.Split('_');

					using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
					{
						MySqlCommand cmd = new MySqlCommand();
						cmd.CommandText = "SELECT MaterialsName FROM materials where MaterialsNo = @MaterialsNo";

						cmd.Parameters.Add("@MaterialsNo", MySqlDbType.Int32, 11, "MaterialsNo");
						cmd.Parameters["@MaterialsNo"].Value = name[0];

						cmd.Connection = conn;
						conn.Open();

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							name[1] = rdr[0].ToString() + "(" + name[1] + ")";
						}

						result.Add(name);
					}
				}
			}
			

			return result;
		}

		public List<MaterialsSemi> GetSemis()
		{
			List<MaterialsSemi> list = new List<MaterialsSemi>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials_semi) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText =
											"SELECT * " +
											"FROM materials_semi ";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							MaterialsSemi ma = new MaterialsSemi();

							ma.Materialssemino = (int)rdr[0];
							ma.Materialsseminame = rdr[1].ToString();
							ma.Materialssemicnt = (int)rdr[2];
							ma.Materialssemivalue = rdr[3].ToString();

							list.Add(ma);
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

		public List<string[]> Material_Action_Location()
		{
			List<string[]> list = new List<string[]>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText =
											"SELECT m.MaterialsNo, m.MaterialsType, m.MaterialsName, m.MaterialsStandard, ms.MaterialsLocation, ms.materials_Site_Cnt, m.MaterialsCount, m.MaterialsPrice " +
											"FROM materials AS m LEFT JOIN " +
											"materials_site AS ms ON m.MaterialsNo = ms.materials_Site_No; ";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							String[] ma = new string[8];

							ma[0] = rdr[0].ToString();
							ma[1] = rdr[1].ToString();
							ma[2] = rdr[2].ToString();
							ma[3] = rdr[3].ToString();
							ma[4] = rdr[4].ToString();
							ma[5] = rdr[5].ToString();
							ma[6] = rdr[6].ToString();
							ma[7] = rdr[7].ToString();

							list.Add(ma);
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

		public List<string[]> GetAssembleSemi(int productNo, bool type)
		{
            string str = "";
            if (type) str =
 "SELECT ms.MaterialsSemiNo, mop.mopB, ms.MaterialsSemiName, mop.mopCnt FROM materials_of_product AS mop " +
 "LEFT JOIN materials_semi AS ms ON mop.mopNo = ms.MaterialsSemiNo " +
 "WHERE mop.mopB = 1 AND mop.ProductNo = @ProductNo; ";
            else str =
"SELECT ms.MaterialsNo, mop.mopB, ms.MaterialsName, mop.mopCnt FROM materials_of_product AS mop " +
"LEFT JOIN materials AS ms ON mop.mopNo = ms.MaterialsNo " +
"WHERE mop.mopB = 0 AND mop.ProductNo = @ProductNo ";
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials_of_product where ProductNo = @ProductNo ) as success";
				
				cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");
				cmd.Parameters["@ProductNo"].Value = productNo;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText =	str;

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							String[] ma = new string[8];

							ma[0] = rdr[0].ToString();
							ma[1] = rdr[1].ToString();
							ma[2] = rdr[2].ToString();
							ma[3] = rdr[3].ToString();

							list.Add(ma);
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

		public List<string[]> GetMaterialList(int productNo)
		{
			List<string[]> list = new List<string[]>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText =
									"SELECT m.MaterialsName, mop.mopCnt, m.MaterialsStandard, m.MaterialsMemo FROM materials_of_product AS mop " +
									"LEFT JOIN materials AS m ON mop.mopNo = m.MaterialsNo " +
									"WHERE mop.mopB = 0 AND mop.ProductNo = @ProductNo";

				cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");
				cmd.Parameters["@ProductNo"].Value = productNo;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						String[] ma = new string[8];

						ma[0] = rdr[0].ToString();
						ma[1] = rdr[1].ToString();
						ma[2] = rdr[2].ToString();
						ma[3] = rdr[3].ToString();

						list.Add(ma);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			return list;
		}

		public List<MaterialsSemi> GetProductList(int productNo)
		{
			List<MaterialsSemi> list = new List<MaterialsSemi>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT ms.MaterialsSemiNo, ms.MaterialsSemiName, mop.mopCnt, ms.MaterialsSemIValue FROM materials_of_product AS mop " +
									"LEFT JOIN materials_semi AS ms ON mop.mopNo = ms.MaterialsSemiNo " +
									"WHERE mop.mopB = 1 AND mop.ProductNo = @ProductNo";

				cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");
				cmd.Parameters["@ProductNo"].Value = productNo;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						MaterialsSemi ma = new MaterialsSemi();

						ma.Materialssemino = (int)rdr[0];
						ma.Materialsseminame = rdr[1].ToString();
						ma.Materialssemicnt = (int)rdr[2];
						ma.Materialssemivalue = rdr[3].ToString();

						list.Add(ma);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			return list;
		}
		public Materials GetMaterialsData(int key)
		{
			Materials m = new Materials();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT * FROM materials where MaterialsNo = @MaterialsNo";
				cmd.Parameters.Add("@MaterialsNo", MySqlDbType.Int32, 11, "MaterialsNo");
				cmd.Parameters["@MaterialsNo"].Value = key;
				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();


					while (rdr.Read())
					{
						m.MaterialsNo = (int)rdr[0];
						m.MaterialsType = rdr[1].ToString();
						m.MaterialsName = rdr[2].ToString();
						m.MaterialsCount = (int)rdr[3];
						m.MaterialsStandard = rdr[4].ToString();
						m.MaterialsPrice = (int)rdr[5];
						m.MaterialsMemo = rdr[6].ToString();
						m.Unit = rdr[7].ToString();
					}

				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			return m;
		}
		public bool WarehousingUseCheck(int no, string location, int cnt)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT EXISTS( " +
									"SELECT * " +
									"FROM materials_site " +
									"WHERE materials_site.materials_Site_No = @param1 AND materials_site.MaterialsLocation = @param2 AND  materials_site.materials_Site_Cnt >= @param3) AS success; ";

				cmd.Parameters.Add("@param1", MySqlDbType.VarChar, 50, "param1");
				cmd.Parameters.Add("@param2", MySqlDbType.VarChar, 50, "param2");
				cmd.Parameters.Add("@param3", MySqlDbType.Int32, 50, "param3");

				cmd.Parameters["@param1"].Value = no;
				cmd.Parameters["@param2"].Value = location;
				cmd.Parameters["@param3"].Value = cnt;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						return true;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					return false;
				}
			}
			return false;
		}

		public void DeleteSemi(string value)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "DELETE FROM materials_semi WHERE MaterialsSemiNo = @param1 ";

				cmd.Parameters.Add("@param1", MySqlDbType.Int32, 50, "param1");

				cmd.Parameters["@param1"].Value = value;

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

		public bool mopChek(Materials_Of_Product mop)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT EXISTS( " +
									"SELECT * " +
									"FROM materials_of_product " +
									"WHERE materials_of_product.ProductNo = @param1 AND materials_of_product.mopB = @param2 AND  materials_of_product.mopNo = @param3) AS success; ";

				cmd.Parameters.Add("@param1", MySqlDbType.Int32, 50, "param1");
				cmd.Parameters.Add("@param2", MySqlDbType.Bit, 50, "param2");
				cmd.Parameters.Add("@param3", MySqlDbType.Int32, 50, "param3");

				cmd.Parameters["@param1"].Value = mop.ProductNo;
				cmd.Parameters["@param2"].Value = mop.mopB;
				cmd.Parameters["@param3"].Value = mop.mopNo;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					//있으면 1 없으면 0
					if (check != 0)
					{
						return true;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					return false;
				}
			}
			return false;
		}

		public void mopDelete(Materials_Of_Product mop)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "DELETE FROM materials_of_product WHERE materials_of_product.ProductNo = @param1 AND materials_of_product.mopB = @param2 AND  materials_of_product.mopNo = @param3 ";

				cmd.Parameters.Add("@param1", MySqlDbType.Int32, 50, "param1");
				cmd.Parameters.Add("@param2", MySqlDbType.Bit, 50, "param2");
				cmd.Parameters.Add("@param3", MySqlDbType.Int32, 50, "param3");

				cmd.Parameters["@param1"].Value = mop.ProductNo;
				cmd.Parameters["@param2"].Value = mop.mopB;
				cmd.Parameters["@param3"].Value = mop.mopNo;

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

		public void mopInsert(Materials_Of_Product mop)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				try
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "INSERT INTO materials_of_product " +
										"(ProductNo, mopB, mopNo, mopCnt) " +
										"VALUES(@ProductNo, @mopB, @mopNo, @mopCnt)";
					cmd.CommandType = CommandType.Text;

					cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");
					cmd.Parameters.Add("@mopB", MySqlDbType.Bit, 1, "mopB");
					cmd.Parameters.Add("@mopNo", MySqlDbType.Int32, 11, "mopNo");
					cmd.Parameters.Add("@mopCnt", MySqlDbType.Int32, 11, "mopCnt");

					cmd.Parameters["@ProductNo"].Value = mop.ProductNo;
					cmd.Parameters["@mopB"].Value = mop.mopB;
					cmd.Parameters["@mopNo"].Value = mop.mopNo;
					cmd.Parameters["@mopCnt"].Value = mop.mopCnt;

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

		public void mopUpdate(Materials_Of_Product mop)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText =
								"UPDATE materials_of_product SET " +
								"mopCnt =  @mopCnt " +
								"WHERE ProductNo = @ProductNo  and mopB = @mopB and mopNo = @mopNo";

				cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");
				cmd.Parameters.Add("@mopB", MySqlDbType.Bit, 1, "mopB");
				cmd.Parameters.Add("@mopNo", MySqlDbType.Int32, 11, "mopNo");
				cmd.Parameters.Add("@mopCnt", MySqlDbType.Int32, 11, "mopCnt");

				cmd.Parameters["@ProductNo"].Value = mop.ProductNo;
				cmd.Parameters["@mopB"].Value = mop.mopB;
				cmd.Parameters["@mopNo"].Value = mop.mopNo;
				cmd.Parameters["@mopCnt"].Value = mop.mopCnt;
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

		public int GetPriceAvg(int no)
		{
			int result = 0;
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT MaterialsPrice FROM materials where MaterialsNo = @MaterialsNo";
				cmd.Parameters.Add("@MaterialsNo", MySqlDbType.Int32, 11, "MaterialsNo");
				cmd.Parameters["@MaterialsNo"].Value = no;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					result = Convert.ToInt32(cmd.ExecuteScalar());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			return result;
		}
	
		public void insertIOWarehousing(Materials_Action ma)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				try
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "INSERT INTO materials_action " +
										"(WarehousingDate, WarehousingCustomer, WarehousingType, WarehousingLocaion, MaterialsNo, WarehousingCount, WarehousingPrice, WarehousingMemo) " +
										"VALUES(@WarehousingDate, @WarehousingCustomer, @WarehousingType, @WarehousingLocaion, @MaterialsNo, @WarehousingCount, @WarehousingPrice, @WarehousingMemo)";
					cmd.CommandType = CommandType.Text;



					cmd.Parameters.Add("@WarehousingDate", MySqlDbType.Date, 50, "WarehousingDate");
					cmd.Parameters.Add("@WarehousingType", MySqlDbType.VarChar, 50, "WarehousingType");
					cmd.Parameters.Add("@WarehousingLocaion", MySqlDbType.VarChar, 50, "WarehousingLocaion");
					cmd.Parameters.Add("@MaterialsNo", MySqlDbType.VarChar, 50, "MaterialsNo");
					cmd.Parameters.Add("@WarehousingCount", MySqlDbType.VarChar, 50, "WarehousingCount");
					cmd.Parameters.Add("@WarehousingPrice", MySqlDbType.VarChar, 50, "WarehousingPrice");
					cmd.Parameters.Add("@WarehousingMemo", MySqlDbType.VarChar, 50, "WarehousingMemo");
					cmd.Parameters.Add("@WarehousingCustomer", MySqlDbType.VarChar, 50, "WarehousingCustomer");

					cmd.Parameters["@WarehousingDate"].Value = DateTime.Now;
					cmd.Parameters["@WarehousingType"].Value = ma.WarehousingType;
					cmd.Parameters["@WarehousingLocaion"].Value = ma.MaterialsLocation;
					cmd.Parameters["@MaterialsNo"].Value = ma.ProductNo;
					cmd.Parameters["@WarehousingCount"].Value = ma.WarehousingCount;
					cmd.Parameters["@WarehousingPrice"].Value = ma.WarehousingPrice;
					cmd.Parameters["@WarehousingMemo"].Value = ma.WarehousingMemo;
					cmd.Parameters["@WarehousingCustomer"].Value = ma.WarehousingCustomer;

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

		public void UpdateSemi(MaterialsSemi materialsSemi)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText =
								"UPDATE materials_semi SET " +
								"materials_semi.MaterialsSemiCnt =  @paramC, " +
								"materials_semi.MaterialsSemIValue =  @paramV " +
								"WHERE materials_semi.MaterialsSemiNo = @paramN ";
				cmd.Parameters.Add("@paramC", MySqlDbType.Int32, 11, "paramC");
				cmd.Parameters.Add("@paramV", MySqlDbType.VarChar, 1000, "paramV");
				cmd.Parameters.Add("@paramN", MySqlDbType.Int32, 11, "paramN");

				cmd.Parameters["@paramC"].Value = materialsSemi.Materialssemicnt;
				cmd.Parameters["@paramV"].Value = materialsSemi.Materialssemivalue;
				cmd.Parameters["@paramN"].Value = materialsSemi.Materialssemino;
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

		public void InsertSemi(MaterialsSemi ms)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				try
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "INSERT INTO materials_semi " +
										"(MaterialsSemiName, MaterialsSemiCnt, MaterialsSemIValue) " +
										"VALUES(@MaterialsSemiName, @MaterialsSemiCnt, @MaterialsSemIValue)";
					cmd.CommandType = CommandType.Text;



					cmd.Parameters.Add("@MaterialsSemiName", MySqlDbType.VarChar, 45, "MaterialsSemiName");
					cmd.Parameters.Add("@MaterialsSemiCnt", MySqlDbType.Int32, 11, "MaterialsSemiCnt");
					cmd.Parameters.Add("@MaterialsSemIValue", MySqlDbType.VarChar, 1000, "MaterialsSemIValue");

					cmd.Parameters["@MaterialsSemiName"].Value = ms.Materialsseminame;
					cmd.Parameters["@MaterialsSemiCnt"].Value = ms.Materialssemicnt;
					cmd.Parameters["@MaterialsSemIValue"].Value = ms.Materialssemivalue;

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

		public bool FindSemiName(string materialsseminame)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials_semi where MaterialsSemiName = '" + materialsseminame + "' ) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						return true;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			return false;
		}

		public List<string[]> GetOrderByMaterialsLocation(int materialsNo)
		{
			List<string[]> list = new List<string[]>();

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials_site) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = " SELECT materials_site.MaterialsLocation, materials_site.materials_Site_Cnt " +
										  " FROM materials_site " +
										  " WHERE materials_site.materials_Site_No = @param " +
										  " ORDER BY materials_site.MaterialsLocation ";

						cmd.Parameters.Add("@param", MySqlDbType.Int32, 11, "param");
						cmd.Parameters["@param"].Value = materialsNo;

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							string[] str = new string[2];
							str[0] = rdr[0].ToString();
							str[1] = rdr[1].ToString();
							list.Add(str);
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
		public void MaterialsRealsingUpdate(Materials mtr, int no)
		{

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText =
								"UPDATE materials SET " +
								"materials.MaterialsCount = materials.MaterialsCount + @paramC " +
								
								"WHERE materials.MaterialsNo = @paramN ";
				cmd.Parameters.Add("@paramC", MySqlDbType.VarChar, 50, "paramC");
				cmd.Parameters.Add("@paramN", MySqlDbType.Int32, 11, "paramN");

				cmd.Parameters["@paramC"].Value = mtr.MaterialsCount;
				cmd.Parameters["@paramN"].Value = no;
				try
				{
					cmd.Connection = conn;
					conn.Open();

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
		public void MaterialsWearingUpdate(Materials mtr, int no)
		{

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText =
								"UPDATE materials SET " +
								"materials.MaterialsPrice = ((materials.MaterialsPrice * materials.MaterialsCount) + (@paramC * @paramP)) / (materials.MaterialsCount + @paramC), " +
								"materials.MaterialsCount = materials.MaterialsCount + @paramC " +
								"WHERE materials.MaterialsNo = @paramN ";
				cmd.Parameters.Add("@paramC", MySqlDbType.VarChar, 50, "paramC");
				cmd.Parameters.Add("@paramP", MySqlDbType.Int32, 11, "paramP");
				cmd.Parameters.Add("@paramN", MySqlDbType.Int32, 11, "paramN");

				cmd.Parameters["@paramC"].Value = mtr.MaterialsCount;
				cmd.Parameters["@paramP"].Value = mtr.MaterialsPrice;
				cmd.Parameters["@paramN"].Value = no;
				try
				{
					cmd.Connection = conn;
					conn.Open();
				
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

		public void InsertMaterialsAction(Materials mtr, int no)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				try
				{
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "INSERT INTO materials_action " +
										"(WarehousingDate, WarehousingType, WarehousingLocaion, MaterialsNo, WarehousingCount, WarehousingPrice, WarehousingMemo) " +
										"VALUES(@WarehousingDate, @WarehousingType, @WarehousingLocaion, @MaterialsNo, @WarehousingCount, @WarehousingPrice, @WarehousingMemo)";
					cmd.CommandType = CommandType.Text;



					cmd.Parameters.Add("@WarehousingDate", MySqlDbType.Date, 50, "WarehousingDate");
					cmd.Parameters.Add("@WarehousingType", MySqlDbType.VarChar, 50, "WarehousingType");
					cmd.Parameters.Add("@WarehousingLocaion", MySqlDbType.VarChar, 50, "WarehousingLocaion");
					cmd.Parameters.Add("@MaterialsNo", MySqlDbType.VarChar, 50, "MaterialsNo");
					cmd.Parameters.Add("@WarehousingCount", MySqlDbType.VarChar, 50, "WarehousingCount");
					cmd.Parameters.Add("@WarehousingPrice", MySqlDbType.VarChar, 50, "WarehousingPrice");
					cmd.Parameters.Add("@WarehousingMemo", MySqlDbType.VarChar, 50, "WarehousingMemo");

					cmd.Parameters["@WarehousingDate"].Value = DateTime.Now;
					cmd.Parameters["@WarehousingType"].Value = "입고";
					cmd.Parameters["@WarehousingLocaion"].Value = "(미지정)";
					cmd.Parameters["@MaterialsNo"].Value = no;
					cmd.Parameters["@WarehousingCount"].Value = mtr.MaterialsCount;
					cmd.Parameters["@WarehousingPrice"].Value = mtr.MaterialsPrice;
					cmd.Parameters["@WarehousingMemo"].Value = "초기 생성으로 인한 입고";

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

		public void InsertOrUpdateSiteData(int No, string _location, int cnt) //쥐금
		{
			string location = "";
			if (_location is null) location = "(미지정)";
			else location = _location;

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS " +
					"(SELECT * FROM materials_site " +
					"Where MaterialsLocation = @MaterialsLocation and materials_Site_No = @materials_Site_No" +
					") as success";

				cmd.Parameters.Add("@MaterialsLocation", MySqlDbType.VarChar, 50, "MaterialsLocation");
				cmd.Parameters.Add("@materials_Site_No", MySqlDbType.Int32, 11, "materials_Site_No");
				cmd.Parameters.Add("@materials_Site_Cnt", MySqlDbType.Int32, 11, "materials_Site_Cnt");

				cmd.Parameters["@MaterialsLocation"].Value = location;
				cmd.Parameters["@materials_Site_No"].Value = No;
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						//update
						cmd.CommandText = "UPDATE materials_site SET "
							+ "materials_site.materials_Site_Cnt = materials_site.materials_Site_Cnt + @materials_Site_Cnt "
							+ "WHERE  MaterialsLocation = @MaterialsLocation and materials_Site_No = @materials_Site_No";


						cmd.Parameters["@materials_Site_Cnt"].Value = cnt;
						cmd.Parameters["@MaterialsLocation"].Value = location;
						cmd.Parameters["@materials_Site_No"].Value = No;
						cmd.Connection = conn;

						if (conn.State == ConnectionState.Open) conn.Close();
						conn.Open();

						cmd.ExecuteNonQuery();
					}
					else
					{
						cmd.CommandType = CommandType.Text;

						cmd.CommandText = "INSERT INTO materials_site (MaterialsLocation, materials_Site_No, materials_Site_Cnt) "
						   + "VALUES(@MaterialsLocation, @materials_Site_No, @materials_Site_Cnt)";

						cmd.Parameters["@materials_Site_Cnt"].Value = cnt;
						cmd.Parameters["@MaterialsLocation"].Value = location;
						cmd.Parameters["@materials_Site_No"].Value = No;

						cmd.Connection = conn;

						if (conn.State == ConnectionState.Open) conn.Close();
						conn.Open();

						cmd.ExecuteNonQuery();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());

				}
			}//using
		}
		#endregion

		#region GetData
		public List<string> GetTypes()
		{
			List<string> materials_Types = new List<string>();

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials_type) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = "SELECT MaterialsDef FROM materials_type";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							materials_Types.Add(rdr[0].ToString());
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
			return materials_Types;
		}

		//text1 기존 데이터, text2 변경 데이터
		public bool UpdateData(string dateType, string text1, string text2)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM " + dateType + " where MaterialsDef = '" + text1 + "') as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check == 0)
					{
						cmd.CommandText = "UPDATE " + dateType + " SET "
							+ "MaterialsDef = @MaterialsDef1 "
							+ "WHERE MaterialsDef = @MaterialsDef2";

						cmd.Parameters.Add("@MaterialsDef1", MySqlDbType.VarChar, 50, "MaterialsDef1");
						cmd.Parameters.Add("@MaterialsDef2", MySqlDbType.VarChar, 50, "MaterialsDef2");

						cmd.Parameters["@MaterialsDef1"].Value = text1;
						cmd.Parameters["@MaterialsDef2"].Value = text2;
						cmd.Connection = conn;

						if (conn.State == ConnectionState.Open) conn.Close();
						conn.Open();

						cmd.ExecuteNonQuery();

						return true;
					}
					else return false;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					return false;
				}
			}
		}
		public void DeleteData(string dateType, string text)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "DELETE FROM " + dateType + " WHERE MaterialsDef = @MaterialsDef";
				cmd.Parameters.Add("@MaterialsDef", MySqlDbType.VarChar, 50, "MaterialsDef");
				cmd.Parameters["@MaterialsDef"].Value = text;

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

		public List<string> GetLocations()
		{
			List<string> materials_Locations = new List<string>();

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM Materials_Location) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = "SELECT  MaterialsDef FROM Materials_Location where MaterialsDef != '(미지정)'";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							materials_Locations.Add(rdr[0].ToString());
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
			return materials_Locations;
		}
		public bool InsertDefData(string dateType, string text)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM Materials_Location) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandType = CommandType.Text;

						cmd.CommandText = "INSERT INTO " + dateType + "(MaterialsDef) "
						   + "VALUES(@MaterialsDef)";


						cmd.Parameters.Add("@MaterialsDef", MySqlDbType.VarChar, 50, "MaterialsDef");

						cmd.Parameters["@MaterialsDef"].Value = text;

						cmd.Connection = conn;

						if (conn.State == ConnectionState.Open) conn.Close();
						conn.Open();

						cmd.ExecuteNonQuery();
						return true;
					}
					else return false;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					return false;
				}
			}//using

		}
		#endregion
		#region Materials
		public List<Materials> GetMaterials()
		{
			List<Materials> materials = new List<Materials>();

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = "SELECT  * FROM materials";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							Materials material = new Materials();

							material.MaterialsNo = Convert.ToInt32(rdr[0].ToString());
							material.MaterialsType = rdr[1].ToString();
							material.MaterialsName = rdr[2].ToString();
							material.MaterialsCount = Convert.ToInt32(rdr[3].ToString());
							material.MaterialsStandard = rdr[4].ToString();
							material.MaterialsPrice = Convert.ToInt32(rdr[5].ToString());
							material.MaterialsMemo = rdr[6].ToString();
							material.Unit = rdr[7].ToString();
							materials.Add(material);
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
			return materials;
		}
		public void UpdateMaterials(Materials materials)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "UPDATE Materials SET "
					+ "MaterialsType = @MaterialsType, MaterialsName = @MaterialsName, MaterialsStandard = @MaterialsStandard, MaterialsMemo =@MaterialsMemo, Unit = @Unit "
					+ "WHERE MaterialsNo = @MaterialsNo";

				cmd.Parameters.Add("@MaterialsType", MySqlDbType.VarChar, 50, "MaterialsType");
				cmd.Parameters.Add("@MaterialsName", MySqlDbType.VarChar, 50, "MaterialsName");
				cmd.Parameters.Add("@MaterialsStandard", MySqlDbType.VarChar, 50, "MaterialsStandard");
				cmd.Parameters.Add("@MaterialsMemo", MySqlDbType.VarChar, 50, "MaterialsMemo");
				cmd.Parameters.Add("@MaterialsNo", MySqlDbType.VarChar, 50, "MaterialsNo");
				cmd.Parameters.Add("@Unit", MySqlDbType.VarChar, 50, "Unit");

				cmd.Parameters["@MaterialsType"].Value = materials.MaterialsType;
				cmd.Parameters["@MaterialsName"].Value = materials.MaterialsName;
				cmd.Parameters["@MaterialsStandard"].Value = materials.MaterialsStandard;
				cmd.Parameters["@MaterialsMemo"].Value = materials.MaterialsMemo;
				cmd.Parameters["@MaterialsNo"].Value = materials.MaterialsNo;
				cmd.Parameters["@Unit"].Value = materials.Unit;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}

		public int InsertMaterial(Materials mtr, bool check)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "INSERT INTO materials(MaterialsType, MaterialsName, MaterialsCount, MaterialsPrice, MaterialsStandard, MaterialsMemo, Unit) "
				   + "VALUES(@MaterialsType, @MaterialsName, @MaterialsCount, @MaterialsPrice, @MaterialsStandard, @MaterialsMemo, @Unit)";


				cmd.Parameters.Add("@MaterialsType", MySqlDbType.VarChar, 50, "MaterialsType");
				cmd.Parameters.Add("@MaterialsName", MySqlDbType.VarChar, 50, "MaterialsName");
				cmd.Parameters.Add("@MaterialsCount", MySqlDbType.Int32, 11, "MaterialsCount");
				cmd.Parameters.Add("@MaterialsPrice", MySqlDbType.Int32, 11, "MaterialsPrice");
				cmd.Parameters.Add("@MaterialsStandard", MySqlDbType.VarChar, 50, "MaterialsStandard");
				cmd.Parameters.Add("@MaterialsMemo", MySqlDbType.VarChar, 50, "MaterialsMemo");
				cmd.Parameters.Add("@Unit", MySqlDbType.VarChar, 50, "Unit");

				cmd.Parameters["@MaterialsType"].Value = mtr.MaterialsType;
				cmd.Parameters["@MaterialsName"].Value = mtr.MaterialsName;
				cmd.Parameters["@MaterialsCount"].Value = 0;
				cmd.Parameters["@MaterialsPrice"].Value = 0;
				cmd.Parameters["@MaterialsStandard"].Value = mtr.MaterialsStandard;
				cmd.Parameters["@MaterialsMemo"].Value = mtr.MaterialsMemo;
				cmd.Parameters["@Unit"].Value = mtr.Unit;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				 cmd.ExecuteNonQuery();



				if (check)
				{
					cmd.CommandText = "SELECT @@IDENTITY";

					cmd.Connection = conn;

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						return Convert.ToInt32(rdr[0]);
					}
				}
				else return 0;
			}//using
			return 0;
		}
		public bool FindMaterialName(string materialsName)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM materials where MaterialsName = '" + materialsName + "' ) as success";
				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						return true;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			return false;
		}
		public void DeleteMaterial(int materialsNo)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "DELETE FROM Materials WHERE MaterialsNo = @MaterialsNo";
				cmd.Parameters.Add("@MaterialsNo", MySqlDbType.Int32, 11, "MaterialsNo");
				cmd.Parameters["@MaterialsNo"].Value = materialsNo;

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
		#endregion







	}
}