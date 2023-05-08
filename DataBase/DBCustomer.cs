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
    public class DBCustomer
    {
        private DBMain _DBMain;
        public DBCustomer(DBMain dBMain)
        {
            _DBMain = dBMain;
        }

        public List<Customer> GetDgvCustomer()
        {
            List<Customer> customer = new List<Customer>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM Customer";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM Customer";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Customer cus = new Customer();

                            cus.CustomerNo = (int)rdr[0];
                            cus.CustomerGroup = rdr[1].ToString();
                            cus.CustomerName = rdr[2].ToString();
                            cus.CustomerGoods = rdr[3].ToString();
                            cus.CustomerAddress = rdr[4].ToString();
                            cus.CustomerNumber = rdr[5].ToString();
                            cus.CustomerFax = rdr[6].ToString();
                            cus.CustomerMemo = rdr[7].ToString();

                            customer.Add(cus);
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

            return customer;
        }
        public List<string> CustomerName()
        {
            List<string> CusName = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT CustomerName FROM Customer";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                        CusName.Add(rdr[0].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return CusName;
        }

        public string CustomerNo(String CustomerName)
        {
            string str =  "";
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT customer.customerNo FROM customer WHERE customer.CustomerName = @Customer limit 1 ;";

                cmd.Parameters.Add("@Customer", MySqlDbType.VarChar, 50, "Customer");
                cmd.Parameters["@Customer"].Value = CustomerName;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                        str = rdr[0].ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return str;
        }
        public string CustomerMemNo(String CustomerMemName, String CusNo)
        {
            string str = "";
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT customer_member.CustomerMemberNo FROM customer_member WHERE customer_member.CustomerNo = @param1 AND customer_member.CustomerMemberName = @param2 LIMIT 1;";

                cmd.Parameters.Add("@param1", MySqlDbType.VarChar, 50, "param1");
                cmd.Parameters.Add("@param2", MySqlDbType.VarChar, 50, "param2");
                cmd.Parameters["@param1"].Value = CusNo;
                cmd.Parameters["@param2"].Value = CustomerMemName;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                        str = rdr[0].ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return str;
        }
        public List<Customer> LastCustomerCode()
        {
            List<Customer> customer = new List<Customer>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                    "WHERE TABLE_SCHEMA = 'jg' AND TABLE_NAME = 'customer'";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();

                        Customer cus = new Customer();
                        cus.CustomerNo = check;

                        customer.Add(cus);
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

            return customer;
        }
        public Customer GetCustomerOne(int value)
        {
            Customer c = new Customer();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM Customer";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 50, "CustomerNo");
                cmd.Parameters["@CustomerNo"].Value = value;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT C.CustomerNo, C.CustomerName, C.CustomerAddress, C.CustomerNumber, C.CustomerMemo, C.CustomerGroup, CM.CustomerMemberName " +
                                          "FROM Customer AS C LEFT JOIN customer_member AS CM ON CM.CustomerNo = C.CustomerNo " +
                                          "LEFT JOIN work_order AS WO ON WO.CustomerMemberNo = CM.CustomerMemberNo " +
                                          "WHERE C.CustomerNo = @CustomerNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            c.CustomerNo = (int)rdr[0];
                            c.CustomerName = rdr[1].ToString();
                            c.CustomerAddress = rdr[2].ToString();
                            c.CustomerNumber = rdr[3].ToString();
                            c.CustomerMemo = rdr[4].ToString();
                            c.CustomerGroup = rdr[5].ToString();
                            c.CustomerGoods = rdr[6].ToString();
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
            return c;
        }

        //거래처 추가
        public void AddCustomerData(Customer cus)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Customer " +
                                    "(CustomerNo, CustomerName, CustomerAddress, CustomerNumber, CustomerMemo, CustomerGroup, CustomerGoods, CustomerFax) " +
                                    "VALUES(@CustomerNo, @CustomerName, @CustomerAddress, @CustomerNumber, @CustomerMemo, @CustomerGroup, @CustomerGoods, @CustomerFax);";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.VarChar, 50, "CustomerNo");
                cmd.Parameters.Add("@CustomerName", MySqlDbType.VarChar, 50, "CustomerName");
                cmd.Parameters.Add("@CustomerAddress", MySqlDbType.VarChar, 50, "CustomerAddress");
                cmd.Parameters.Add("@CustomerNumber", MySqlDbType.VarChar, 50, "CustomerNumber");
                cmd.Parameters.Add("@CustomerMemo", MySqlDbType.VarChar, 50, "CustomerMemo");
                cmd.Parameters.Add("@CustomerGroup", MySqlDbType.VarChar, 50, "CustomerGroup");
                cmd.Parameters.Add("@CustomerGoods", MySqlDbType.VarChar, 50, "CustomerGoods");
                cmd.Parameters.Add("@CustomerFax", MySqlDbType.VarChar, 50, "CustomerFax");

                cmd.Parameters["@CustomerNo"].Value = cus.CustomerNo;
                cmd.Parameters["@CustomerName"].Value = cus.CustomerName;
                cmd.Parameters["@CustomerAddress"].Value = cus.CustomerAddress;
                cmd.Parameters["@CustomerNumber"].Value = cus.CustomerNumber;
                cmd.Parameters["@CustomerMemo"].Value = cus.CustomerMemo;
                cmd.Parameters["@CustomerGroup"].Value = cus.CustomerGroup;
                cmd.Parameters["@CustomerGoods"].Value = cus.CustomerGoods;
                cmd.Parameters["@CustomerFax"].Value = cus.CustomerFax;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyCustomerData(Customer _SelectDataCustomer)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Customer SET " +
                                    "CustomerName = @CustomerName, CustomerName = @CustomerName, CustomerAddress = @CustomerAddress, CustomerGoods = @CustomerGoods, " +
                                    "CustomerNumber = @CustomerNumber, CustomerMemo = @CustomerMemo, CustomerGroup = @CustomerGroup, CustomerFax = @CustomerFax " +
                                    "WHERE CustomerNo = @CustomerNo; ";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.VarChar, 50, "CustomerNo");
                cmd.Parameters.Add("@CustomerName", MySqlDbType.VarChar, 50, "CustomerName");
                cmd.Parameters.Add("@CustomerAddress", MySqlDbType.VarChar, 50, "CustomerAddress");
                cmd.Parameters.Add("@CustomerNumber", MySqlDbType.VarChar, 50, "CustomerNumber");
                cmd.Parameters.Add("@CustomerMemo", MySqlDbType.VarChar, 50, "CustomerMemo");
                cmd.Parameters.Add("@CustomerGroup", MySqlDbType.VarChar, 50, "CustomerGroup");
                cmd.Parameters.Add("@CustomerFax", MySqlDbType.VarChar, 50, "CustomerFax");
                cmd.Parameters.Add("@CustomerGoods", MySqlDbType.VarChar, 50, "CustomerGoods");

                cmd.Parameters["@CustomerNo"].Value = _SelectDataCustomer.CustomerNo;
                cmd.Parameters["@CustomerName"].Value = _SelectDataCustomer.CustomerName;
                cmd.Parameters["@CustomerAddress"].Value = _SelectDataCustomer.CustomerAddress;
                cmd.Parameters["@CustomerNumber"].Value = _SelectDataCustomer.CustomerNumber;
                cmd.Parameters["@CustomerMemo"].Value = _SelectDataCustomer.CustomerMemo;
                cmd.Parameters["@CustomerGroup"].Value = _SelectDataCustomer.CustomerGroup;
                cmd.Parameters["@CustomerFax"].Value = _SelectDataCustomer.CustomerFax;
                cmd.Parameters["@CustomerGoods"].Value = _SelectDataCustomer.CustomerGoods;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomerMemberData(Customer _SelectDataCustomer)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM customer_member WHERE CustomerNo = @CustomerNo";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 11, "CustomerNo");

                cmd.Parameters["@CustomerNo"].Value = _SelectDataCustomer.CustomerNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomerData(int _No)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM customer WHERE CustomerNo = @CustomerNo";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 11, "CustomerNo");

                cmd.Parameters["@CustomerNo"].Value = _No;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }


        public List<CustomerMember> GetDgvMember(int CustomerNo)
        {
            List<CustomerMember> customermember = new List<CustomerMember>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM Customer_member";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 50, "CustomerNo");

                cmd.Parameters["@CustomerNo"].Value = CustomerNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT CustomerNo, CustomerMemberNo, CustomerMemberName, RankName, CustomerMemberNumber, " +
                            "CustomerMemberEmail, CustomerMemberMemo " +
                            "FROM Customer_member " +
                            "WHERE CustomerNo = @CustomerNo; ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            CustomerMember cusmem = new CustomerMember();

                            cusmem.CustomerNo = (int)rdr[0];
                            cusmem.CustomerMemberNo = (int)rdr[1];
                            cusmem.CustomerMemberName = rdr[2].ToString();
                            cusmem.RankName = rdr[3].ToString();
                            cusmem.CustomerMemberNumber = rdr[4].ToString();
                            cusmem.CustomerMembereMail = rdr[5].ToString();
                            cusmem.CustomerMemberMemo = rdr[6].ToString();
                            customermember.Add(cusmem);
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

            return customermember;
        }
        public List<CustomerMember> GetCMName(int CustomerNo, int CMNo)
        {
            List<CustomerMember> customermember = new List<CustomerMember>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM Customer_member";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 50, "CustomerNo");
                cmd.Parameters.Add("@CustomerMemberNo", MySqlDbType.Int32, 50, "CustomerNo");

                cmd.Parameters["@CustomerNo"].Value = CustomerNo;
                cmd.Parameters["@CustomerMemberNo"].Value = CMNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT CustomerNo, CustomerMemberNo, CustomerMemberName, RankName, CustomerMemberNumber, " +
                                          " CustomerMemberEmail, CustomerMemberMemo " +
                                          " FROM Customer_member WHERE CustomerNo = @CustomerNo AND CustomerMemberNo = @CustomerMemberNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            CustomerMember cusmem = new CustomerMember();

                            cusmem.CustomerNo = (int)rdr[0];
                            cusmem.CustomerMemberNo = (int)rdr[1];
                            cusmem.CustomerMemberName = rdr[2].ToString();
                            cusmem.RankName = rdr[3].ToString();
                            cusmem.CustomerMemberNumber = rdr[4].ToString();
                            cusmem.CustomerMembereMail = rdr[5].ToString();
                            cusmem.CustomerMemberMemo = rdr[6].ToString();
                            customermember.Add(cusmem);
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

            return customermember;
        }

        public List<String> ComboboxListCollection(String tableName, String Type)
        {
            List<String> result = new List<String>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS(SELECT DISTINCT @Type FROM  " + tableName + ")" +

                cmd.Parameters.Add("@Type", MySqlDbType.VarChar, 50, "Type");
                cmd.Parameters["@Type"].Value = Type;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT " + Type + " FROM " + tableName + " GROUP BY " + Type;

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            result.Add(rdr[0].ToString());
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

            return result;
        }

        public void AddCusMemberData(CustomerMember _SelectDataCusMember)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO customer_member " +
                                    "(CustomerNo, CustomerMemberName, RankName, CustomerMemberNumber, CustomerMemberEmail, CustomerMemberMemo) " +
                                    "VALUES(@CustomerNo, @CustomerMemberName, @RankName, @CustomerMemberNumber, @CustomerMemberEmail, @CustomerMemberMemo);";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.VarChar, 50, "CustomerNo");
                cmd.Parameters.Add("@CustomerMemberName", MySqlDbType.VarChar, 50, "CustomerMemberName");
                cmd.Parameters.Add("@RankName", MySqlDbType.VarChar, 50, "RankName");
                cmd.Parameters.Add("@CustomerMemberNumber", MySqlDbType.VarChar, 50, "CustomerMemberNumber");
                cmd.Parameters.Add("@CustomerMemberEmail", MySqlDbType.VarChar, 50, "CustomerMemberEmail");
                cmd.Parameters.Add("@CustomerMemberMemo", MySqlDbType.VarChar, 50, "CustomerMemberMemo");

                cmd.Parameters["@CustomerNo"].Value = _SelectDataCusMember.CustomerNo;
                cmd.Parameters["@CustomerMemberName"].Value = _SelectDataCusMember.CustomerMemberName;
                cmd.Parameters["@RankName"].Value = _SelectDataCusMember.RankName;
                cmd.Parameters["@CustomerMemberNumber"].Value = _SelectDataCusMember.CustomerMemberNumber;
                cmd.Parameters["@CustomerMemberEmail"].Value = _SelectDataCusMember.CustomerMembereMail;
                cmd.Parameters["@CustomerMemberMemo"].Value = _SelectDataCusMember.CustomerMemberMemo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyCusMemberData(CustomerMember _SelectDataCusMember)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE customer_member SET " +
                                    "CustomerMemberName = @CustomerMemberName, RankName = @RankName, " +
                                    "CustomerMemberNumber = @CustomerMemberNumber, CustomerMemberEmail = @CustomerMemberEmail, CustomerMemberMemo = @CustomerMemberMemo " +
                                    "WHERE CustomerNo = @CustomerNo AND CustomerMemberNo = @CustomerMemberNo; ";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.VarChar, 50, "CustomerNo");
                cmd.Parameters.Add("@CustomerMemberNo", MySqlDbType.Int32, 11, "CustomerMemberNo");
                cmd.Parameters.Add("@CustomerMemberName", MySqlDbType.VarChar, 50, "CustomerMemberName");
                cmd.Parameters.Add("@RankName", MySqlDbType.VarChar, 50, "RankName");
                cmd.Parameters.Add("@CustomerMemberNumber", MySqlDbType.VarChar, 50, "CustomerMemberNumber");
                cmd.Parameters.Add("@CustomerMemberEmail", MySqlDbType.VarChar, 50, "CustomerMemberEmail");
                cmd.Parameters.Add("@CustomerMemberMemo", MySqlDbType.VarChar, 50, "CustomerMemberMemo");

                cmd.Parameters["@CustomerNo"].Value = _SelectDataCusMember.CustomerNo;
                cmd.Parameters["@CustomerMemberNo"].Value = _SelectDataCusMember.CustomerMemberNo;
                cmd.Parameters["@CustomerMemberName"].Value = _SelectDataCusMember.CustomerMemberName;
                cmd.Parameters["@RankName"].Value = _SelectDataCusMember.RankName;
                cmd.Parameters["@CustomerMemberNumber"].Value = _SelectDataCusMember.CustomerMemberNumber;
                cmd.Parameters["@CustomerMemberEmail"].Value = _SelectDataCusMember.CustomerMembereMail;
                cmd.Parameters["@CustomerMemberMemo"].Value = _SelectDataCusMember.CustomerMemberMemo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCusMemberData(int _No)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM customer_member " +
                    "WHERE CustomerMemberNo = @CustomerMemberNo";

                cmd.Parameters.Add("@CustomerMemberNo", MySqlDbType.Int32, 11, "CustomerMemberNo");

                cmd.Parameters["@CustomerMemberNo"].Value = _No;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        //거래처 검색
        public List<Customer> CustomerFindData(string result, string value)
        {
            List<Customer> customer = new List<Customer>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM customer";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM customer where " + result + " LIKE " + "'%" + value + "%'";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Customer cus = new Customer();
                            cus.CustomerNo = (int)rdr[0];
                            cus.CustomerGroup = rdr[1].ToString();
                            cus.CustomerName = rdr[2].ToString();
                            cus.CustomerGoods = rdr[3].ToString();
                            cus.CustomerAddress = rdr[4].ToString();
                            cus.CustomerNumber = rdr[5].ToString();
                            cus.CustomerFax = rdr[6].ToString();
                            cus.CustomerMemo = rdr[7].ToString();

                            customer.Add(cus);
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

            return customer;
        }

    }//end
}
