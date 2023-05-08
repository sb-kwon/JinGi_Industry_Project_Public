using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;


namespace DataBase
{
    public class DBMachine
    {
        private DBMain _DBMain;
        public DBMachine(DBMain dBMain)
        {
            _DBMain = dBMain;
        }
        public string FindBcrType(string BcrPortName)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS (SELECT MachineName FROM bcr WHERE bcr.BcrPortName = @BcrPortName) as success";

                cmd.Parameters.Add("@BcrPortName", MySqlDbType.VarChar, 50, "BcrPortName");
                cmd.Parameters["@BcrPortName"].Value = BcrPortName;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT MachineMapping FROM bcr WHERE bcr.BcrPortName = @BcrPortName ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            result = rdr[0].ToString();
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return result;
        }

        public List<string> MachineList()
        {
            List<string> list = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT machine.MachineName FROM machine";
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

        public List<Machine> GetMachine()
        {
            List<Machine> machines = new List<Machine>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM machine_sf";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM machine_sf";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Machine machine = new Machine();

                            machine.MachineNo = (int)rdr[0];
                            machine.MachineName = rdr[1].ToString();
                            machine.MachineType = rdr[2].ToString();
                            machine.MachineManagementNo = rdr[3].ToString();
                            machine.MachineCompany = rdr[4].ToString();
                            if (!(rdr[5].Equals(DBNull.Value)))
                            {
                                machine.MachineDay = Convert.ToDateTime(rdr[5]).ToString("yyyy년 MM월 dd일");
                            }
                            machine.MachineLocation = rdr[6].ToString();
                            machine.MachineETC = rdr[7].ToString();

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

        public List<Bcr> BcrList()
        {
            List<Bcr> list = new List<Bcr>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS (SELECT * FROM  bcr) as success";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT BcrPortName, BcrParity, BcrBaudRate, BcrDataBit,  BcrStopBit, BcrMachineName FROM bcr";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Bcr bcr = new Bcr();

                            bcr.PortName = rdr[0].ToString();
                            if (rdr[1].ToString().Equals("None"))
                                bcr.Parity = Parity.None;
                            bcr.BaudRate = (int)rdr[2];
                            bcr.DataBits = (int)rdr[3];
                            if (rdr[4].ToString().Equals("One"))
                                bcr.StopBits = StopBits.One;
                            bcr.MachineName = rdr[5].ToString();

                            list.Add(bcr);
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

        public bool CheckMachineNo(string MachineNo, string value)
        {
            bool result = false;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM machine where " + MachineNo + " = " + value;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check == 0)
                    {
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return result;
        }

        public List<Machine> SearchMachine(string result, string str)
        {
            List<Machine> machines = new List<Machine>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM machine";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM machine where " + result + " LIKE " + "'%" + str + "%'";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Machine machine = new Machine();

                            machine.MachineNo = Convert.ToInt32(rdr[0].ToString());
                            machine.MachineName = rdr[1].ToString();
                            machine.MachineType = rdr[2].ToString();
                            machine.MachineManagementNo = rdr[3].ToString();
                            machine.MachineCompany = rdr[4].ToString();
                            machine.MachineDay = rdr[5].ToString();
                            machine.MachineManager = rdr[6].ToString();
                            machine.MachineLocation = rdr[7].ToString();
                            machine.MachineNote = rdr[8].ToString();
                            machine.MachineETC = rdr[9].ToString();

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

        public void AdditionalMachine(Machine machine)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO machine (MachineName, MachineType, MachineCompany, MachineDayDate, MachineManagementNo," +
                                  "MachineManager, MachineLocation, MachineNote, MachineETC)" +
                                  "VALUES(@MachineName, @MachineType, @MachineCompany, @MachineDayDate, @MachineManagementNo," +
                                  "@MachineManager, @MachineLocation, @MachineNote, @MachineETC)";

                cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 50, "MachineName");
                cmd.Parameters.Add("@MachineType", MySqlDbType.VarChar, 50, "MachineType");
                cmd.Parameters.Add("@MachineCompany", MySqlDbType.VarChar, 50, "MachineCompany");
                cmd.Parameters.Add("@MachineDayDate", MySqlDbType.VarChar, 50, "MachineDayDate");
                cmd.Parameters.Add("@MachineManagementNo", MySqlDbType.VarChar, 50, "MachineManagementNo");
                cmd.Parameters.Add("@MachineManager", MySqlDbType.VarChar, 50, "MachineManager");
                cmd.Parameters.Add("@MachineLocation", MySqlDbType.VarChar, 50, "MachineLocation");
                cmd.Parameters.Add("@MachineNote", MySqlDbType.VarChar, 50, "MachineNote");
                cmd.Parameters.Add("@MachineETC", MySqlDbType.VarChar, 50, "MachineETC");

                cmd.Parameters["@MachineName"].Value = machine.MachineName;
                cmd.Parameters["@MachineType"].Value = machine.MachineType;
                cmd.Parameters["@MachineCompany"].Value = machine.MachineCompany;
                cmd.Parameters["@MachineDayDate"].Value = machine.MachineDay;
                cmd.Parameters["@MachineManagementNo"].Value = machine.MachineManagementNo;
                cmd.Parameters["@MachineManager"].Value = machine.MachineManager;
                cmd.Parameters["@MachineLocation"].Value = machine.MachineLocation;
                cmd.Parameters["@MachineNote"].Value = machine.MachineNote;
                cmd.Parameters["@MachineETC"].Value = machine.MachineETC;

                cmd.Connection = conn;
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();

            }//using
        }
        public void MachineDelete(string MachineNo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM machine WHERE MachineNo = @MachineNo";
                cmd.Parameters.Add("@MachineNo", MySqlDbType.VarChar, 50, "MachineNo");
                cmd.Parameters["@MachineNo"].Value = MachineNo;

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


            }//using
        }
        public void ModifyMachine(Machine machine)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " UPDATE machine SET "
                                + " MachineName = @MachineName, MachineType = @MachineType, MachineCompany = @MachineCompany, "
                                + " MachineDayDate = @MachineDayDate, MachineManagementNo = @MachineManagementNo, MachineManager = @MachineManager,"
                                + " MachineLocation = @MachineLocation, MachineNote = @MachineNote, MachineETC = @MachineETC "
                                + " WHERE MachineName = @MachineName ";

                cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 50, "MachineName");
                cmd.Parameters.Add("@MachineType", MySqlDbType.VarChar, 50, "MachineType");
                cmd.Parameters.Add("@MachineCompany", MySqlDbType.VarChar, 50, "MachineCompany");
                cmd.Parameters.Add("@MachineDayDate", MySqlDbType.VarChar, 50, "MachineDate");
                cmd.Parameters.Add("@MachineManagementNo", MySqlDbType.VarChar, 50, "MachineManagementNo");
                cmd.Parameters.Add("@MachineManager", MySqlDbType.VarChar, 50, "MachineManager");
                cmd.Parameters.Add("@MachineLocation", MySqlDbType.VarChar, 50, "MachineLocation");
                cmd.Parameters.Add("@MachineNote", MySqlDbType.VarChar, 50, "MachineNote");
                cmd.Parameters.Add("@MachineETC", MySqlDbType.VarChar, 50, "MachineETC");

                cmd.Parameters["@MachineName"].Value = machine.MachineName;
                cmd.Parameters["@MachineType"].Value = machine.MachineType;
                cmd.Parameters["@MachineCompany"].Value = machine.MachineCompany;
                cmd.Parameters["@MachineDayDate"].Value = machine.MachineDay;
                cmd.Parameters["@MachineManagementNo"].Value = machine.MachineManagementNo;
                cmd.Parameters["@MachineManager"].Value = machine.MachineManager;
                cmd.Parameters["@MachineLocation"].Value = machine.MachineLocation;
                cmd.Parameters["@MachineNote"].Value = machine.MachineNote;
                cmd.Parameters["@MachineETC"].Value = machine.MachineETC;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public bool CheckMachineName(string machinename, string value)
        {
            bool result = false;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM machine where " + machinename + " = " + value;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check == 0)
                    {
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return result;
        }

        public List<Machine> GetMachineList()
        {
            List<Machine> machines = new List<Machine>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM machine";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM machine";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Machine machine = new Machine();

                            machine.MachineNo = Convert.ToInt32(rdr[0].ToString());
                            machine.MachineName = rdr[1].ToString();
                            machine.MachineType = rdr[2].ToString();
                            machine.MachineManagementNo = rdr[3].ToString();
                            machine.MachineCompany = rdr[4].ToString();
                            machine.MachineDay = rdr[5].ToString();
                            machine.MachineManager = rdr[6].ToString();
                            machine.MachineLocation = rdr[7].ToString();
                            machine.MachineNote = rdr[8].ToString();
                            machine.MachineETC = rdr[9].ToString();

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

        public List<Machine> SearchData(string result, string str)
        {
            List<Machine> machines = new List<Machine>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM bcr";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM bcr where " + result + " LIKE " + "'%" + str + "%'";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Machine machine = new Machine();

                            machine.PortName = rdr[1].ToString();
                            machine.ScannerMachineName = rdr[0].ToString();
                            machine.MachineScanner = rdr[6].ToString();

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
        public void DeleteMachine(string machinename)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM machine_sf WHERE SF_Machine_No = @SF_Machine_No";
                cmd.Parameters.Add("@SF_Machine_No", MySqlDbType.VarChar, 50, "SF_Machine_No");
                cmd.Parameters["@SF_Machine_No"].Value = machinename;

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
            }//using
        }

        public void UpdateMachine(Machine machine)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE machine_sf SET " +
                                  "SF_Machine_Name = @SF_Machine_Name, SF_Machine_Type = @SF_Machine_Type, SF_Machine_Model = @SF_Machine_Model, " +
                                  "SF_Machine_Company= @SF_Machine_Company, SF_Machine_Buy = @SF_Machine_Buy, SF_Machine_Location = @SF_Machine_Location, " +
                                  "SF_Machine_Memo = @SF_Machine_Memo " +
                                  "WHERE SF_Machine_No = @SF_Machine_No";

                cmd.Parameters.Add("@SF_Machine_Name", MySqlDbType.VarChar, 50, "SF_Machine_Name");
                cmd.Parameters.Add("@SF_Machine_Type", MySqlDbType.VarChar, 50, "SF_Machine_Type");
                cmd.Parameters.Add("@SF_Machine_Model", MySqlDbType.VarChar, 50, "SF_Machine_Model");
                cmd.Parameters.Add("@SF_Machine_Company", MySqlDbType.VarChar, 50, "SF_Machine_Company");
                cmd.Parameters.Add("@SF_Machine_Buy", MySqlDbType.Date, 50, "SF_Machine_Buy");
                cmd.Parameters.Add("@SF_Machine_Location", MySqlDbType.VarChar, 50, "SF_Machine_Location");
                cmd.Parameters.Add("@SF_Machine_Memo", MySqlDbType.VarChar, 50, "SF_Machine_Memo");
                cmd.Parameters.Add("@SF_Machine_No", MySqlDbType.Int32, 11, "SF_Machine_No");

                cmd.Parameters["@SF_Machine_Name"].Value = machine.MachineName;
                cmd.Parameters["@SF_Machine_Type"].Value = machine.MachineType;
                cmd.Parameters["@SF_Machine_Model"].Value = machine.MachineManagementNo;
                cmd.Parameters["@SF_Machine_Company"].Value = machine.MachineCompany;
                cmd.Parameters["@SF_Machine_Buy"].Value = machine.MachineDay;
                cmd.Parameters["@SF_Machine_Location"].Value = machine.MachineLocation;
                cmd.Parameters["@SF_Machine_Memo"].Value = machine.MachineETC;
                cmd.Parameters["@SF_Machine_No"].Value = machine.MachineNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public bool CheckName(string machinename, string value)
        {
            bool result = false;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM machine_sf where " + machinename + " = " + value;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check == 0)
                    {
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return result;
        }

        public void MachineAdd(Machine machine)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO machine_sf (SF_Machine_Name, SF_Machine_Type, SF_Machine_Model, SF_Machine_Company, " +
                                  "SF_Machine_Buy, SF_Machine_Location, SF_Machine_Memo) " +
                                  "VALUES(@SF_Machine_Name, @SF_Machine_Type, @SF_Machine_Model, @SF_Machine_Company, @SF_Machine_Buy, " +
                                  "@SF_Machine_Location, @SF_Machine_Memo)";

                cmd.Parameters.Add("@SF_Machine_Name", MySqlDbType.VarChar, 50, "SF_Machine_Name");
                cmd.Parameters.Add("@SF_Machine_Type", MySqlDbType.VarChar, 50, "SF_Machine_Type");
                cmd.Parameters.Add("@SF_Machine_Model", MySqlDbType.VarChar, 50, "SF_Machine_Model");
                cmd.Parameters.Add("@SF_Machine_Company", MySqlDbType.VarChar, 50, "SF_Machine_Company");
                cmd.Parameters.Add("@SF_Machine_Buy", MySqlDbType.Date, 50, "SF_Machine_Buy");
                cmd.Parameters.Add("@SF_Machine_Location", MySqlDbType.VarChar, 50, "SF_Machine_Location");
                cmd.Parameters.Add("@SF_Machine_Memo", MySqlDbType.VarChar, 50, "SF_Machine_Memo");


                cmd.Parameters["@SF_Machine_Name"].Value = machine.MachineName;
                cmd.Parameters["@SF_Machine_Type"].Value = /*"COM" + */machine.MachineType;
                cmd.Parameters["@SF_Machine_Model"].Value = machine.MachineManagementNo;
                cmd.Parameters["@SF_Machine_Company"].Value = machine.MachineCompany;
                cmd.Parameters["@SF_Machine_Buy"].Value = Convert.ToDateTime(machine.MachineDay);
                cmd.Parameters["@SF_Machine_Location"].Value = machine.MachineLocation;
                cmd.Parameters["@SF_Machine_Memo"].Value = machine.MachineETC;

                cmd.Connection = conn;
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();

            }//using
        }
        public void InsertNon(String MachineName, String Detail, String Memo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = " INSERT INTO dayofcnt(DAY, MachineName, VALUE, COUNT, Memo) VALUES(@DAY, @MachineName, @VALUE, @COUNT, @Memo) ";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@DAY", MySqlDbType.Date, 50, "DAY");
                    cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 50, "MachineName");
                    cmd.Parameters.Add("@VALUE", MySqlDbType.VarChar, 50, "VALUE");
                    cmd.Parameters.Add("@COUNT", MySqlDbType.Int32, 1, "COUNT");
                    cmd.Parameters.Add("@Memo", MySqlDbType.VarChar, 200, "Memo");

                    cmd.Parameters["@DAY"].Value = DateTime.Now;
                    cmd.Parameters["@MachineName"].Value = MachineName;
                    cmd.Parameters["@VALUE"].Value = Detail;
                    cmd.Parameters["@COUNT"].Value = 1;
                    cmd.Parameters["@Memo"].Value = Memo;

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
        public List<String[]> AddData()
        {
            List<String[]> list = new List<String[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT * FROM dg_machine_5 ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        String[] str = new string[4];

                        str[0] = rdr[0].ToString();
                        str[1] = rdr[1].ToString();
                        str[2] = rdr[2].ToString();
                        str[3] = rdr[3].ToString();

                        list.Add(str);
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