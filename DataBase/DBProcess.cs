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
    public class DBProcess
    {
        private DBMain _DBMain;
        public DBProcess(DBMain dBMain)
        {
            _DBMain = dBMain;
        }
        #region 검색 불량
        public List<Quality> GetDefect()
        {
            List<Quality> qualities = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM work_process";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT QM.workInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                          " OrderName, P.ProductName, QM.FairName, QM.QualityMember, QM.QualityMachine, wp.workProcessStartTime, " +
                                          " wp.workProcessEndTime, wp.WorkProcessNo, QM.QualityCause FROM work_process wp " +
                                          " INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN bom B " +
                                          " ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P ON P.ProductNo = B.ProductNo " +
                                          " INNER JOIN quality_management QM ON QM.workProcessNo = wp.WorkProcessNo AND wp.workProcessEndTime IS NOT NULL " +
                                          " WHERE wp.WorkProcessStateName = '5' AND QM.QualityDeadline IS NULL ";


                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Quality quality = new Quality();

                            quality.InstructionNo = rdr[0].ToString();
                            quality.InnerOrder = rdr[1].ToString();
                            quality.InnerProductName = rdr[2].ToString();
                            quality.FairName = rdr[3].ToString();
                            quality.MemberName = rdr[4].ToString();
                            quality.Machine.MachineName = rdr[5].ToString();
                            quality.InnerStartTime = rdr[6].ToString();
                            quality.InnerEndTime = rdr[7].ToString();
                            quality.WorkProcessNo = rdr[8].ToString();
                            quality.InnerCause = rdr[9].ToString();
                            qualities.Add(quality);
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
            return qualities;
        }

        public List<Quality> SearchDefectData(string[] registSearchValue)
        {
            throw new NotImplementedException();
        }

        public List<Quality> GetFairName()
        {
            List<Quality> FairName = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT work_process.FairReal FROM work_process GROUP BY work_process.FairReal ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality quality = new Quality();

                        quality.FairName = rdr[0].ToString();

                        FairName.Add(quality);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return FairName;
        }
        public List<Quality> GetDefectFairName()
        {
            List<Quality> FairName = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT quality_management.FairName FROM quality_management " +
                                      " WHERE quality_management.QualityState = '불량' GROUP BY quality_management.FairName ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality quality = new Quality();

                        quality.FairName = rdr[0].ToString();

                        FairName.Add(quality);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return FairName;
        }
        public List<Quality> GetSituationFairName()
        {
            List<Quality> FairName = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT quality_management.FairName FROM quality_management WHERE QualityState != '불량' " +
                                      " GROUP BY quality_management.FairName ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality quality = new Quality();

                        quality.FairName = rdr[0].ToString();

                        FairName.Add(quality);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return FairName;
        }
        public List<Quality> GetdefectRegistration(String[] RegistSearchValue)
        {
            List<Quality> RegistrData = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    if (RegistSearchValue[2] == null)
                    {
                        cmd.CommandText = " SELECT wp.workInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                          " OrderName, P.ProductName, wp.FairReal, qm.QualityMember, " +
                                          " (SELECT MachineName FROM Machine M WHERE M.MachineNo = wp.MachineNo) MachineName, " +
                                          " wp.workProcessStartTime, wp.workProcessEndTime, wp.WorkProcessNo, qm.QualityCause FROM work_process wp " +
                                          " INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN bom B " +
                                          " ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P ON P.ProductNo = B.ProductNo" +
                                          " INNER JOIN quality_management qm ON qm.workProcessNo = wp.WorkProcessNo " +
                                          " AND wp.WorkProcessStateName IS NOT NULL AND wp.WorkProcessEndTime IS NOT NULL AND qm.QualityState = '불량' " +
                                          " AND qm.QualityDeadline IS NULL " +
                                          " AND((date_format(wp.workProcessStartTime, '%Y-%m-%d') BETWEEN @workProcessStartTime " +
                                          " AND @workProcessEndTime) OR((date_format(wp.workProcessEndTime, '%Y-%m-%d') " +
                                          " BETWEEN @workProcessStartTime AND @workProcessEndTime))) or(wp.FairReal = @FairReal)";

                        cmd.Parameters.Add("@workProcessStartTime", MySqlDbType.VarChar, 50, "workProcessStartTime");
                        cmd.Parameters.Add("@workProcessEndTime", MySqlDbType.VarChar, 50, "workProcessEndTime");
                        cmd.Parameters.Add("@FairReal", MySqlDbType.VarChar, 50, "wp.FairReal");

                        cmd.Parameters["@workProcessStartTime"].Value = RegistSearchValue[0];
                        cmd.Parameters["@workProcessEndTime"].Value = RegistSearchValue[1];
                        cmd.Parameters["@FairReal"].Value = RegistSearchValue[2];
                    }
                    else
                    {
                        cmd.CommandText = " SELECT wp.workInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                          " OrderName, P.ProductName, wp.FairReal, qm.QualityMember, " +
                                          " (SELECT MachineName FROM Machine M WHERE M.MachineNo = wp.MachineNo) MachineName, " +
                                          " wp.workProcessStartTime, wp.workProcessEndTime, wp.WorkProcessNo, qm.QualityCause FROM work_process wp " +
                                          " INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN bom B " +
                                          " ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P ON P.ProductNo = B.ProductNo" +
                                          " INNER JOIN quality_management qm ON qm.workProcessNo = wp.WorkProcessNo " +
                                          " AND wp.WorkProcessStateName IS NOT NULL AND wp.WorkProcessEndTime IS NOT NULL AND qm.QualityState = '불량' " +
                                          " AND qm.QualityDeadline IS NULL" +
                                          " AND (wp.FairReal = @FairReal) And((date_format(wp.workProcessStartTime, '%Y-%m-%d') " +
                                          " BETWEEN @workProcessStartTime AND @workProcessEndTime)OR " +
                                          " ((date_format(wp.workProcessEndTime, '%Y-%m-%d') BETWEEN @workProcessStartTime " +
                                          " AND @workProcessEndTime))) ";

                        cmd.Parameters.Add("@workProcessStartTime", MySqlDbType.VarChar, 50, "workProcessStartTime");
                        cmd.Parameters.Add("@workProcessEndTime", MySqlDbType.VarChar, 50, "workProcessEndTime");
                        cmd.Parameters.Add("@FairReal", MySqlDbType.VarChar, 50, "wp.FairReal");

                        cmd.Parameters["@workProcessStartTime"].Value = RegistSearchValue[0];
                        cmd.Parameters["@workProcessEndTime"].Value = RegistSearchValue[1];
                        cmd.Parameters["@FairReal"].Value = RegistSearchValue[2];

                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality InnerJoinData = new Quality();

                        InnerJoinData.InstructionNo = rdr[0].ToString();
                        InnerJoinData.InnerOrder = rdr[1].ToString();
                        InnerJoinData.InnerProductName = rdr[2].ToString();
                        InnerJoinData.FairName = rdr[3].ToString();
                        InnerJoinData.MemberName = rdr[4].ToString();
                        InnerJoinData.Machine.MachineName = rdr[5].ToString();
                        InnerJoinData.InnerStartTime = rdr[6].ToString();
                        InnerJoinData.InnerEndTime = rdr[7].ToString();
                        InnerJoinData.WorkProcessNo = rdr[8].ToString();
                        InnerJoinData.InnerCause = rdr[9].ToString();

                        RegistrData.Add(InnerJoinData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return RegistrData;
        }

        public List<string[]> CheckWorkInstructionState(WorkProcess wp)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                   "SELECT " +
                         "COUNT(wp.WorkProcessNo) AS cnt, " +
                         "COUNT(CASE WHEN wp.WorkProcessStateName = '15' THEN 1 WHEN wp.WorkProcessStateName = '14' THEN 1 WHEN wp.WorkProcessStateName = '5' THEN 1 WHEN wp.WorkProcessStateName = '4' THEN 1 END) AS com " +
                         "FROM work_order AS wo " +
                         "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                         "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                         "LEFT JOIN product AS pro ON pro.ProductNo = bo.ProductNo " +
                         "LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                         "WHERE wp.WorkProcessStateName NOT IN('2') " +
                         "AND wo.OrderNo = @OrderNo " +
                         "AND wi.WorkInstructionNo = @WorkInstructionNo " +
                         "AND wp.WorkInstructionNo = @WorkInstructionNo " +
                         "GROUP BY wo.OrderNo " +
                   ") AS success ";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.VarChar, 50, "OrderNo");
                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.VarChar, 50, "WorkInstructionNo");

                cmd.Parameters["@OrderNo"].Value = wp.OrderNo;
                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT " +
                           "COUNT(wp.WorkProcessNo) AS cnt, " +
                           "COUNT(CASE WHEN wp.WorkProcessStateName = '15' THEN 1 WHEN wp.WorkProcessStateName = '14' THEN 1 WHEN wp.WorkProcessStateName = '5' THEN 1 WHEN wp.WorkProcessStateName = '4' THEN 1 END) AS com " +
                           "FROM work_order AS wo " +
                           "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                           "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                           "LEFT JOIN product AS pro ON pro.ProductNo = bo.ProductNo " +
                           "LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                           "WHERE wp.WorkProcessStateName NOT IN('2') " +
                           "AND wo.OrderNo = @OrderNo " +
                           "AND wp.WorkInstructionNo = @WorkInstructionNo " +
                           "AND wi.WorkInstructionNo = @WorkInstructionNo " +
                           "GROUP BY wo.OrderNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                        rdr[0].ToString(),
                        rdr[1].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        public List<Quality> SearchData(String[] RegistSearchValue)
        {
            List<Quality> RegistrData = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    if (RegistSearchValue[2] == null)
                    {
                        cmd.CommandText = " SELECT QM.workProcessNo, QM.WorkInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                          " OrderName, P.ProductName, QM.FairName, QM.QualityState, QM.QualityMember, QM.QualityMachine, wp.workProcessStartTime, " +
                                          " wp.workProcessEndTime, QM.QualityManager, QM.QualityCause, QM.QualityDeadline, QM.QualityActions, " +
                                          " QM.QualityMemo FROM work_process wp INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                          " INNER JOIN bom B ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P " +
                                          " ON P.ProductNo = B.ProductNo INNER JOIN quality_management QM ON QM.workProcessNo = wp.WorkProcessNo " +
                                          " AND wp.WorkProcessStateName IS NOT NULL AND wp.WorkProcessEndTime IS NOT NULL AND QM.QualityState NOT IN ('폐기', '양호') " +
                                          " AND((date_format(wp.workProcessStartTime, '%Y-%m-%d') BETWEEN @workProcessStartTime " +
                                          " AND @workProcessEndTime) OR((date_format(wp.workProcessEndTime, '%Y-%m-%d') " +
                                          " BETWEEN @workProcessStartTime AND @workProcessEndTime))) or(QM.FairName = @FairName) ";

                        cmd.Parameters.Add("@workProcessStartTime", MySqlDbType.VarChar, 50, "workProcessStartTime");
                        cmd.Parameters.Add("@workProcessEndTime", MySqlDbType.VarChar, 50, "workProcessEndTime");
                        cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "QM.FairName");

                        cmd.Parameters["@workProcessStartTime"].Value = RegistSearchValue[0];
                        cmd.Parameters["@workProcessEndTime"].Value = RegistSearchValue[1];
                        cmd.Parameters["@FairName"].Value = RegistSearchValue[2];
                    }
                    else
                    {
                        cmd.CommandText = " SELECT QM.workProcessNo, QM.WorkInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                          " OrderName, P.ProductName, QM.FairName, QM.QualityState, QM.QualityMember, QM.QualityMachine, wp.workProcessStartTime, " +
                                          " wp.workProcessEndTime, QM.QualityManager, QM.QualityCause, QM.QualityDeadline, QM.QualityActions, " +
                                          " QM.QualityMemo FROM work_process wp INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                          " INNER JOIN bom B ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P " +
                                          " ON P.ProductNo = B.ProductNo INNER JOIN quality_management QM ON QM.workProcessNo = wp.WorkProcessNo " +
                                          " AND wp.WorkProcessStateName IS NOT NULL AND wp.WorkProcessEndTime IS NOT NULL AND QM.QualityState NOT IN ('폐기', '양호') " +
                                          " AND(QM.FairName = @FairName) And((date_format(wp.workProcessStartTime, '%Y-%m-%d') BETWEEN @workProcessStartTime AND @workProcessEndTime) OR " +
                                          " ((date_format(wp.workProcessEndTime, '%Y-%m-%d') BETWEEN @workProcessStartTime AND @workProcessEndTime))) ";

                        cmd.Parameters.Add("@workProcessStartTime", MySqlDbType.VarChar, 50, "workProcessStartTime");
                        cmd.Parameters.Add("@workProcessEndTime", MySqlDbType.VarChar, 50, "workProcessEndTime");
                        cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "QM.FairName");

                        cmd.Parameters["@workProcessStartTime"].Value = RegistSearchValue[0];
                        cmd.Parameters["@workProcessEndTime"].Value = RegistSearchValue[1];
                        cmd.Parameters["@FairName"].Value = RegistSearchValue[2];

                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality InnerJoinData = new Quality();

                        InnerJoinData.WorkProcessNo = rdr[0].ToString();
                        InnerJoinData.InstructionNo = rdr[1].ToString();
                        InnerJoinData.InnerOrder = rdr[2].ToString();
                        InnerJoinData.InnerProductName = rdr[3].ToString();
                        InnerJoinData.FairName = rdr[4].ToString();
                        InnerJoinData.InnerState = rdr[5].ToString();
                        InnerJoinData.MemberName = rdr[6].ToString();
                        InnerJoinData.Machine.MachineName = rdr[7].ToString();
                        InnerJoinData.InnerStartTime = rdr[8].ToString();
                        InnerJoinData.InnerEndTime = rdr[9].ToString();
                        InnerJoinData.InnerManager = rdr[10].ToString();
                        InnerJoinData.InnerCause = rdr[11].ToString();
                        InnerJoinData.InnerDeadline = Convert.ToDateTime(rdr[12]).ToString("yyyy-MM-dd");
                        InnerJoinData.InnerActions = rdr[13].ToString();
                        InnerJoinData.InnerRemark = rdr[14].ToString();

                        RegistrData.Add(InnerJoinData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return RegistrData;
        }
        public List<Quality> SearchSituationData(String[] RegistSearchValue)
        {
            List<Quality> RegistrData = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    if (RegistSearchValue[2] == null)
                    {
                        cmd.CommandText = " SELECT QM.workProcessNo, QM.WorkInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                          " OrderName, P.ProductName, QM.FairName, QM.QualityState, QM.QualityMember, QM.QualityMachine, wp.workProcessStartTime, " +
                                          " wp.workProcessEndTime, QM.QualityManager, QM.QualityCause, QM.QualityDeadline, QM.QualityActions, " +
                                          " QM.QualityMemo FROM work_process wp INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                          " INNER JOIN bom B ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P " +
                                          " ON P.ProductNo = B.ProductNo INNER JOIN quality_management QM ON QM.workProcessNo = wp.WorkProcessNo " +
                                          " AND wp.WorkProcessStateName IS NOT NULL AND wp.WorkProcessEndTime IS NOT NULL AND QM.QualityState IN ('양호', '폐기', '불량') " +
                                          " AND DATE(QualityDeadline) BETWEEN @workProcessStartTime AND @workProcessEndTime OR(QM.FairName = @FairName)";

                        cmd.Parameters.Add("@workProcessStartTime", MySqlDbType.VarChar, 50, "workProcessStartTime");
                        cmd.Parameters.Add("@workProcessEndTime", MySqlDbType.VarChar, 50, "workProcessEndTime");
                        cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "QM.FairName");

                        cmd.Parameters["@workProcessStartTime"].Value = RegistSearchValue[0];
                        cmd.Parameters["@workProcessEndTime"].Value = RegistSearchValue[1];
                        cmd.Parameters["@FairName"].Value = RegistSearchValue[2];
                    }
                    else
                    {
                        cmd.CommandText = " SELECT QM.workProcessNo, QM.WorkInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                          " OrderName, P.ProductName, QM.FairName, QM.QualityState, QM.QualityMember, QM.QualityMachine, wp.workProcessStartTime, " +
                                          " wp.workProcessEndTime, QM.QualityManager, QM.QualityCause, QM.QualityDeadline, QM.QualityActions, " +
                                          " QM.QualityMemo FROM work_process wp INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                          " INNER JOIN bom B ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P " +
                                          " ON P.ProductNo = B.ProductNo INNER JOIN quality_management QM ON QM.workProcessNo = wp.WorkProcessNo " +
                                          " AND wp.WorkProcessStateName IS NOT NULL AND wp.WorkProcessEndTime IS NOT NULL AND QM.QualityState IN ('양호', '폐기', '불량') " +
                                          " AND(QM.FairName = @FairName) AND DATE(QualityDeadline) BETWEEN @workProcessStartTime AND @workProcessEndTime ";

                        cmd.Parameters.Add("@workProcessStartTime", MySqlDbType.VarChar, 50, "workProcessStartTime");
                        cmd.Parameters.Add("@workProcessEndTime", MySqlDbType.VarChar, 50, "workProcessEndTime");
                        cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "QM.FairName");

                        cmd.Parameters["@workProcessStartTime"].Value = RegistSearchValue[0];
                        cmd.Parameters["@workProcessEndTime"].Value = RegistSearchValue[1];
                        cmd.Parameters["@FairName"].Value = RegistSearchValue[2];
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality InnerJoinData = new Quality();

                        InnerJoinData.WorkProcessNo = rdr[0].ToString();
                        InnerJoinData.InstructionNo = rdr[1].ToString();
                        InnerJoinData.InnerOrder = rdr[2].ToString();
                        InnerJoinData.InnerProductName = rdr[3].ToString();
                        InnerJoinData.FairName = rdr[4].ToString();
                        InnerJoinData.InnerState = rdr[5].ToString();
                        InnerJoinData.MemberName = rdr[6].ToString();
                        InnerJoinData.Machine.MachineName = rdr[7].ToString();
                        InnerJoinData.InnerStartTime = rdr[8].ToString();
                        InnerJoinData.InnerEndTime = rdr[9].ToString();
                        InnerJoinData.InnerManager = rdr[10].ToString();
                        InnerJoinData.InnerCause = rdr[11].ToString();
                        InnerJoinData.InnerDeadline = Convert.ToDateTime(rdr[12]).ToString("yyyy-MM-dd");
                        InnerJoinData.InnerActions = rdr[13].ToString();
                        InnerJoinData.InnerRemark = rdr[14].ToString();

                        RegistrData.Add(InnerJoinData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return RegistrData;
        }
        public void UpdateDefectRegistration(String Number, string[] RegistValue)
        {
            //
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " UPDATE quality_management SET QualityManager = @QualityManager, QualityCause = @QualityCause, " +
                                      " QualityDeadline = @QualityDeadline, QualityActions = @QualityActions , QualityMemo = @QualityMemo " +
                                      " WHERE workProcessNo = @workProcessNo ";

                    cmd.Parameters.Add("@QualityManager", MySqlDbType.VarChar, 50, "QualityManager");
                    cmd.Parameters.Add("@QualityCause", MySqlDbType.VarChar, 50, "QualityCause");
                    cmd.Parameters.Add("@QualityDeadline", MySqlDbType.VarChar, 50, "QualityDeadline");
                    cmd.Parameters.Add("@QualityActions", MySqlDbType.VarChar, 50, "QualityActions");
                    cmd.Parameters.Add("@QualityMemo", MySqlDbType.VarChar, 50, "QualityMemo");
                    cmd.Parameters.Add("@workProcessNo", MySqlDbType.VarChar, 50, "workProcessNo");

                    cmd.Parameters["@QualityManager"].Value = RegistValue[0];
                    cmd.Parameters["@QualityCause"].Value = RegistValue[1];
                    cmd.Parameters["@QualityDeadline"].Value = RegistValue[2];
                    cmd.Parameters["@QualityActions"].Value = RegistValue[3];
                    cmd.Parameters["@QualityMemo"].Value = RegistValue[4];
                    cmd.Parameters["@workProcessNo"].Value = Number;

                    cmd.Connection = conn;

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public List<Quality> GetDefectUpdate()
        {
            List<Quality> InnerData = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT QM.WorkProcessNo, QM.workInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                      " OrderName, P.ProductName, QM.FairName, QM.QualityState, QM.QualityMember, " +
                                      " QM.QualityMachine, wp.workProcessStartTime, wp.workProcessEndTime, QM.QualityManager, QM.QualityCause, " +
                                      " QM.QualityDeadline, QM.QualityActions, QM.QualityMemo FROM work_process wp " +
                                      " INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN bom B " +
                                      " ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P ON P.ProductNo = B.ProductNo " +
                                      " INNER JOIN quality_management QM ON QM.workProcessNo = wp.WorkProcessNo AND wp.workProcessEndTime IS NOT NULL " +
                                      " WHERE wp.WorkProcessStateName = '5' AND QM.QualityState = '불량' ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality InnerJoinData = new Quality();

                        InnerJoinData.WorkProcessNo = rdr[0].ToString();
                        InnerJoinData.InstructionNo = rdr[1].ToString();
                        InnerJoinData.InnerOrder = rdr[2].ToString();
                        InnerJoinData.InnerProductName = rdr[3].ToString();
                        InnerJoinData.FairName = rdr[4].ToString();
                        InnerJoinData.InnerState = rdr[5].ToString();
                        InnerJoinData.MemberName = rdr[6].ToString();
                        InnerJoinData.Machine.MachineName = rdr[7].ToString();
                        InnerJoinData.InnerStartTime = rdr[8].ToString();
                        InnerJoinData.InnerEndTime = rdr[9].ToString();
                        InnerJoinData.InnerManager = rdr[10].ToString();
                        InnerJoinData.InnerCause = rdr[11].ToString();
                        InnerJoinData.InnerDeadline = Convert.ToDateTime(rdr[12]).ToString("yyyy-MM-dd");
                        InnerJoinData.InnerActions = rdr[13].ToString();
                        InnerJoinData.InnerRemark = rdr[14].ToString();
                        InnerData.Add(InnerJoinData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return InnerData;
        }
        public void DefectUpdate(Quality InnerData, String Number, string[] UpdateValue, String ItemCheck)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@QualityCause", MySqlDbType.VarChar, 50, "QualityCause");
                cmd.Parameters.Add("@qualityActions", MySqlDbType.VarChar, 50, "qualityActions");
                cmd.Parameters.Add("@qualityManager", MySqlDbType.VarChar, 50, "qualityManager");
                cmd.Parameters.Add("@QualityDeadline", MySqlDbType.VarChar, 50, "QualityDeadline");
                cmd.Parameters.Add("@QualityMemo", MySqlDbType.VarChar, 50, "QualityMemo");
                cmd.Parameters.Add("@workProcessNo", MySqlDbType.VarChar, 50, "workProcessNo");
                cmd.Parameters.Add("@QualityState", MySqlDbType.VarChar, 50, "QualityState");

                cmd.Parameters["@QualityCause"].Value = UpdateValue[0];
                cmd.Parameters["@qualityActions"].Value = UpdateValue[1];
                cmd.Parameters["@qualityManager"].Value = UpdateValue[2];
                cmd.Parameters["@QualityDeadline"].Value = UpdateValue[3];
                cmd.Parameters["@QualityMemo"].Value = UpdateValue[4];
                cmd.Parameters["@workProcessNo"].Value = Number;
                cmd.Parameters["@QualityState"].Value = ItemCheck;

                if (ItemCheck.Equals("양호"))
                    cmd.CommandText = " UPDATE quality_management SET QualityState = @QualityState, qualityActions = @qualityActions, " +
                                      " QualityCause = @QualityCause, qualityManager = @qualityManager, QualityMemo = @QualityMemo, " +
                                      " QualityDeadline = @QualityDeadline WHERE workProcessNo = @workProcessNo ";

                else if (ItemCheck.Equals("폐기"))
                    cmd.CommandText = " UPDATE quality_management SET QualityState = @QualityState, qualityActions = @qualityActions, " +
                                      " QualityCause = @QualityCause, qualityManager = @qualityManager, QualityMemo = @QualityMemo, " +
                                      " QualityDeadline = @QualityDeadline WHERE workProcessNo = @workProcessNo; ";

                else
                    cmd.CommandText = " UPDATE quality_management SET QualityState = '6', qualityActions = @qualityActions, " +
                                      " QualityCause = @QualityCause, qualityManager = @qualityManager, QualityMemo = @QualityMemo, " +
                                      " QualityDeadline = @QualityDeadline WHERE workProcessNo = @workProcessNo; ";

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<Quality> GetDefectSituation()
        {
            List<Quality> InnerData = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT QM.WorkProcessNo, QM.workInstructionNo, (SELECT orderName FROM work_order wo WHERE wo.OrderNo = wi.OrderNo) " +
                                      " OrderName, P.ProductName, QM.FairName, QM.QualityState, QM.QualityMember, " +
                                      " QM.QualityMachine, wp.workProcessStartTime, wp.workProcessEndTime, QM.QualityManager, QM.QualityCause, " +
                                      " QM.QualityDeadline, QM.QualityActions, QM.QualityMemo, QM.ActionTime FROM work_process wp " +
                                      " INNER JOIN work_instruction wi ON wi.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN bom B " +
                                      " ON B.WorkInstructionNo = wp.WorkInstructionNo INNER JOIN product P ON P.ProductNo = B.ProductNo " +
                                      " INNER JOIN quality_management QM ON QM.workProcessNo = wp.WorkProcessNo AND wp.workProcessEndTime IS NOT NULL " +
                                      " WHERE wp.WorkProcessStateName = '5' "; /*AND QM.QualityState != '불량'*/

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality InnerJoinData = new Quality();

                        InnerJoinData.WorkProcessNo = rdr[0].ToString();
                        InnerJoinData.InstructionNo = rdr[1].ToString();
                        InnerJoinData.InnerOrder = rdr[2].ToString();
                        InnerJoinData.InnerProductName = rdr[3].ToString();
                        InnerJoinData.FairName = rdr[4].ToString();
                        InnerJoinData.InnerState = rdr[5].ToString();
                        InnerJoinData.MemberName = rdr[6].ToString();
                        InnerJoinData.Machine.MachineName = rdr[7].ToString();
                        InnerJoinData.InnerStartTime = rdr[8].ToString();
                        InnerJoinData.InnerEndTime = rdr[9].ToString();
                        InnerJoinData.InnerManager = rdr[10].ToString();
                        InnerJoinData.InnerCause = rdr[11].ToString();
                        if (rdr[12] == DBNull.Value) InnerJoinData.InnerDeadline = "";
                        else InnerJoinData.InnerDeadline = Convert.ToDateTime(rdr[12]).ToString("yyyy-MM-dd");
                        InnerJoinData.InnerActions = rdr[13].ToString();
                        InnerJoinData.InnerRemark = rdr[14].ToString();
                        if (rdr[15] == DBNull.Value) InnerJoinData.InnerErrorTime = "";
                        else InnerJoinData.InnerErrorTime = Convert.ToDateTime(rdr[15]).ToString("yyyy-MM-dd");
                        InnerData.Add(InnerJoinData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return InnerData;
        }
        public List<Quality> GetDefectCount()
        {
            List<Quality> InnerData = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT COUNT(case when QualityState = '양호' then 1 END) AS A, " +
                                      " COUNT(case when QualityState = '폐기' then 1 END) AS B, " +
                                      " COUNT(case when QualityState = '불량' then 1 END) AS C FROM quality_management ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality InnerJoinData = new Quality();

                        InnerJoinData.ClearCount = rdr[0].ToString();
                        InnerJoinData.DefectCount = rdr[1].ToString();
                        InnerJoinData.KPIDefectTotalAmount = rdr[2].ToString();

                        InnerData.Add(InnerJoinData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return InnerData;
        }
        public List<Quality> GetDefectSearchCount(String[] RegistSearchValue)
        {
            List<Quality> InnerData = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT COUNT(case when QualityState = '양호' then 1 END) AS A, " +
                                      " COUNT(case when QualityState = '폐기' then 1 END) AS B " +
                                      " COUNT(case when QualityState = '불량' then 1 END) AS C " +
                                      " FROM quality_management WHERE DATE(QualityDeadline) BETWEEN @workProcessStartTime AND @workProcessEndTime ";

                    cmd.Parameters.Add("@workProcessStartTime", MySqlDbType.VarChar, 50, "workProcessStartTime");
                    cmd.Parameters.Add("@workProcessEndTime", MySqlDbType.VarChar, 50, "workProcessEndTime");

                    cmd.Parameters["@workProcessStartTime"].Value = RegistSearchValue[0];
                    cmd.Parameters["@workProcessEndTime"].Value = RegistSearchValue[1];

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Quality InnerJoinData = new Quality();

                        InnerJoinData.ClearCount = rdr[0].ToString();
                        InnerJoinData.DefectCount = rdr[1].ToString();
                        InnerJoinData.KPIDefectTotalAmount = rdr[2].ToString();

                        InnerData.Add(InnerJoinData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return InnerData;
        }
        #endregion
        public List<string[]> GetSearchView(string tablename, string tablecolumn)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                               "SELECT " + tablecolumn + " FROM " + tablename +
                               ") AS success ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT " + tablecolumn + " FROM " + tablename;

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string> MaxValue(string column, string table)
        {
            List<string> list = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT MAX(" + column + ") AS " + column + " FROM " + table + ";";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        int result = 0;
                        if (rdr[0] == DBNull.Value)
                            result = 0;
                        else if (column == "OrderNo")
                            result = Int32.Parse(rdr[0].ToString());
                        else
                            result = Int32.Parse(rdr[0].ToString());

                        result += 1;
                        list.Add(result.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public void AllDataTruncate()
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = " DELETE FROM A, B, C, D, E USING customer AS A " +
                                  " LEFT JOIN work_order AS B ON A.CustomerNo = B.CustomerNo " +
                                  " LEFT JOIN bom AS C ON C.OrderNo = B.OrderNo " +
                                  " LEFT JOIN work_instruction AS D ON D.WorkInstructionNo = C.BomNo " +
                                  " LEFT JOIN work_process AS E ON E.WorkInstructionNo = D.WorkInstructionNo ";

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<string[]> GetWorkLogData(WorkOrder wo)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                    "SELECT DISTINCT wo.OrderNo, wo.OrderName, wp.FairName, me.MemberName, mc.MachineName, wp.WorkProcessStartTime, wp.WorkProcessEndTime, " +
                    "IFNULL(qm.QualityState, '검사전'), wp.WorkProcessStateName, wp.WorkProcessMemo " +
                    "FROM work_order AS wo " +
                    "LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                    "LEFT JOIN machine AS mc ON mc.MachineNo = wp.MachineNo " +
                    "LEFT JOIN quality_management AS qm ON qm.workProcessNo = wp.WorkProcessNo " +
                    "WHERE wo.OrderNo = @OrderNo" +
                    ") AS success ";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.VarChar, 45, "OrderNo");

                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT DISTINCT wp.WorkProcessNo, wo.OrderName, wp.FairName, me.MemberName, mc.MachineName, wp.WorkProcessStartTime, wp.WorkProcessEndTime, " +
                            "IFNULL(qm.QualityState, '검사전'), wp.WorkProcessStateName, wp.WorkProcessMemo " +
                            "FROM work_order AS wo " +
                            "LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                            "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                            "LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                            "LEFT JOIN machine AS mc ON mc.MachineNo = wp.MachineNo " +
                            "LEFT JOIN quality_management AS qm ON qm.workProcessNo = wp.WorkProcessNo " +
                            "WHERE wo.OrderNo = @OrderNo " +
                            "ORDER BY wp.WorkProcessNo DESC ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        #region 검색 작업현황
        public string[] GetWorkProcessDetail(int wpNo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                            "SELECT * from work_process" +
                            ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText =
                           "SELECT " +
                           "wo.OrderNo, wo.OrderName, wo.OrderDate, wo.OrderDateEnd, " +
                           "c.CustomerName, c.CustomerGroup, c.CustomerGoods, c.CustomerAddress, c.CustomerNumber, c.CustomerFax, c.CustomerMemo,  " +
                           "p.ProductNo, p.ProductName, b.BomSortation, b.BomManager, p.BomDrawingNo, b.BomETC1, '',    " +
                           "wp.FairName, wp.FairReal, wp.WorkProcessStateName,  wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, " +
                           "wp.WorkProcessStartTime, wp.WorkProcessEndTime, ma.MachineName, m.MemberName , wi.WorkInstructionNo, wp.WorkProcessNo, " +
                           "wp.WorkProcessPlanStart, wp.WorkProcessEndTime  " +
                           "FROM work_process AS wp " +
                           "LEFT JOIN work_instruction AS wi ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                           "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                           "LEFT JOIN bom AS b ON b.WorkInstructionNo = wi.WorkInstructionNo " +
                           "LEFT JOIN product AS p ON b.ProductNo = p.ProductNo " +
                           "LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                           "LEFT JOIN customer AS c ON wo.CustomerNo = c.CustomerNo " +
                           "LEFT JOIN customer_member AS cm ON wo.CustomerMemberNo = cm.CustomerMemberNo " +
                           "LEFT JOIN member AS m ON wp.MemberId = m.MemberId " +
                           "LEFT JOIN machine AS ma ON wp.MachineNo = ma.MachineNo " +
                           "WHERE wp.WorkProcessNo = @WorkProcessNo ";

                        cmd.Parameters.Add("@WorkProcessNo", MySqlDbType.Int32, 22, "WorkProcessNo");
                        cmd.Parameters["@WorkProcessNo"].Value = wpNo;

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                        rdr[0].ToString(),
                        rdr[1].ToString(),
                        rdr[2].ToString(),
                        rdr[3].ToString(),
                        rdr[4].ToString(),
                        rdr[5].ToString(),
                        rdr[6].ToString(),
                        rdr[7].ToString(),
                        rdr[8].ToString(),
                        rdr[9].ToString(),
                        rdr[10].ToString(),
                        rdr[11].ToString(),
                        rdr[12].ToString(),
                        rdr[13].ToString(),
                        rdr[14].ToString(),
                        rdr[15].ToString(),
                        rdr[16].ToString(),
                        rdr[17].ToString(),
                        rdr[18].ToString(),
                        rdr[19].ToString(),
                        rdr[20].ToString(),
                        rdr[21].ToString(),
                        rdr[22].ToString(),
                        rdr[23].ToString(),
                        rdr[24].ToString(),
                        rdr[25].ToString(),
                        rdr[26].ToString(),
                        rdr[27].ToString(),
                        rdr[28].ToString()
                            };
                            return strArray;
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return null;
        }
        public List<string[]> GetWorkProcess()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                               "SELECT * from work_process" +
                               ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText =
                        /*"SELECT " +
                        " wo.OrderName, wi.WorkInstructionNo, p.ProductName, wp.FairReal, wp.FairName, wp.WorkProcessStateName, wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, " +
                        "c.CustomerName, cm.CustomerMemberName, wp.WorkProcessStartTime, wp.WorkProcessEndTime, m.MemberName , wo.OrderNo, wp.WorkProcessNo " +
                        "FROM work_process AS wp " +
                        "LEFT JOIN work_instruction AS wi ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                        "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                        "LEFT JOIN bom AS b ON b.WorkInstructionNo = wi.WorkInstructionNo " +
                        "LEFT JOIN product AS p ON b.ProductNo = p.ProductNo " +
                        "LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                        "LEFT JOIN customer AS c ON wo.CustomerNo = c.CustomerNo " +
                        "LEFT JOIN customer_member AS cm ON wo.CustomerMemberNo = cm.CustomerMemberNo " +
                        "LEFT JOIN member AS m ON wp.MemberId = m.MemberId " +
                        "WHERE wp.WorkProcessStateName = '0' or wp.WorkProcessStateName = '1' ORDER BY wp.WorkProcessNo DESC "*/
                        " SELECT " +
                        " wo.OrderName, wi.WorkInstructionNo, p.ProductName, wp.FairReal, wp.FairName, wp.WorkProcessStateName, wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, " +
                        " c.CustomerName, cm.CustomerMemberName, wp.WorkProcessStartTime, wp.WorkProcessEndTime, m.MemberName , wo.OrderNo, wp.WorkProcessNo, (SELECT COUNT(*) FROM work_order AS A LEFT JOIN work_instruction AS B ON B.OrderNo = A.OrderNo WHERE B.WorkInstructionNo = wi.WorkInstructionNo) " +
                        " FROM work_process AS wp " +
                        " LEFT JOIN work_instruction AS wi ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                        " LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                        " LEFT JOIN bom AS b ON b.WorkInstructionNo = wi.WorkInstructionNo " +
                        " LEFT JOIN product AS p ON b.ProductNo = p.ProductNo " +
                        " LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                        " LEFT JOIN customer AS c ON wo.CustomerNo = c.CustomerNo " +
                        " LEFT JOIN customer_member AS cm ON wo.CustomerMemberNo = cm.CustomerMemberNo " +
                        " LEFT JOIN member AS m ON wp.MemberId = m.MemberId " +
                        " WHERE wp.WorkProcessStateName = '0' or wp.WorkProcessStateName = '1' GROUP BY wp.FairReal, wo.OrderName ORDER BY wp.WorkProcessNo DESC ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                        rdr[0].ToString(),
                        rdr[1].ToString(),
                        rdr[2].ToString(),
                        rdr[3].ToString(),
                        rdr[4].ToString(),
                        rdr[5].ToString(),
                        rdr[6].ToString(),
                        rdr[7].ToString(),
                        rdr[8].ToString(),
                        rdr[9].ToString(),
                        rdr[10].ToString(),
                        rdr[11].ToString(),
                        rdr[12].ToString(),
                        rdr[13].ToString(),
                        rdr[14].ToString(),
                        rdr[15].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetWorkProcessLog()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                               "SELECT * from work_process" +
                               ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText =
                        "SELECT " +
                        "wo.OrderName, wi.WorkInstructionNo, p.ProductName, wp.FairReal, wp.FairName, wp.WorkProcessStateName, wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, " +
                        "c.CustomerName, cm.CustomerMemberName, wp.WorkProcessStartTime, wp.WorkProcessEndTime, m.MemberName , wo.OrderNo, wp.WorkProcessNo, wp.WorkProcessMemo, (SELECT COUNT(*) FROM work_order AS A LEFT JOIN work_instruction AS B ON A.OrderNo = B.OrderNo WHERE B.WorkInstructionNo = wi.WorkInstructionNo), wo.RealEndDate " +
                        "FROM work_process AS wp " +
                        "LEFT JOIN work_instruction AS wi ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                        "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                        "LEFT JOIN bom AS b ON b.WorkInstructionNo = wi.WorkInstructionNo " +
                        "LEFT JOIN product AS p ON b.ProductNo = p.ProductNo " +
                        "LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                        "LEFT JOIN customer AS c ON wo.CustomerNo = c.CustomerNo " +
                        "LEFT JOIN customer_member AS cm ON wo.CustomerMemberNo = cm.CustomerMemberNo " +
                        "LEFT JOIN member AS m ON wp.MemberId = m.MemberId GROUP BY wp.FairReal, wo.OrderName ORDER BY wp.WorkProcessNo DESC";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                        rdr[0].ToString(),
                        rdr[1].ToString(),
                        rdr[2].ToString(),
                        rdr[3].ToString(),
                        rdr[4].ToString(),
                        rdr[5].ToString(),
                        rdr[6].ToString(),
                        rdr[7].ToString(),
                        rdr[8].ToString(),
                        rdr[9].ToString(),
                        rdr[10].ToString(),
                        rdr[11].ToString(),
                        rdr[12].ToString(),
                        rdr[13].ToString(),
                        rdr[14].ToString(),
                        rdr[15].ToString(),
                        rdr[16].ToString(),
                        rdr[17].ToString()
                            };
                        list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetWorkProcessList_Ongoing(string SearchTable, string SearchName, bool type, WorkProcess str)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                    "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                    "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wp.FairGroup " +
                    "FROM work_instruction AS wi " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                    "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "WHERE wp.FairName IS NOT NULL " +
                    "AND wo.OrderStateName  IN('2')  " +
                    "AND wp.WorkProcessStateName IN ('1') " +
                    "AND wi.WorkInstructionState NOT IN('4') " +
                    "ORDER BY wi.WorkInstructionNo DESC" +
                    ") AS success ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 11, "WorkInstructionNo");
                        cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 11, "FairName");
                        cmd.Parameters["@WorkInstructionNo"].Value = str.WorkInstructionNo;
                        cmd.Parameters["@FairName"].Value = str.FairName;
                        if (type == true)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                               "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                               "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wp.WorkProcessPlanStart,  wp.WorkProcessPlanEnd, wp.FairGroup " +
                               "FROM work_instruction AS wi " +
                               "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                               "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                               "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                               "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                               "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                               "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                               "WHERE wp.FairName IS NOT NULL AND wp.WorkInstructionNo = @WorkInstructionNo AND wp.FairName = @FairName " +
                    "AND wo.OrderStateName  IN('2')  " +
                               "AND wp.WorkProcessStateName IN ('1') " +
                               "AND wi.WorkInstructionState NOT IN('4') " +
                               "GROUP BY wi.WorkInstructionNo ORDER BY wi.WorkInstructionNo DESC  ";
                        else if (type == false)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                               "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                               "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wp.WorkProcessPlanStart,  wp.WorkProcessPlanEnd, wp.FairGroup " +
                               "FROM work_instruction AS wi " +
                               "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                               "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                               "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                               "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                               "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                               "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                               "WHERE wp.FairName IS NOT NULL " +
                    "AND wo.OrderStateName  IN('2')  " +
                               "AND wp.WorkProcessStateName IN ('1') " +
                               "AND wi.WorkInstructionState NOT IN('4') " +
                               "AND " + SearchTable + " = '" + SearchName + "' ORDER BY wi.WorkInstructionNo" +
                               " DESC  ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString(),
                                rdr[14].ToString(),
                                rdr[15].ToString(),
                                rdr[16].ToString(),
                                rdr[17].ToString(),
                                rdr[18].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        //출하
        public List<string[]> SearchShipment(string OrderName, string Start, string End, int K)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.Connection = conn;
                    conn.Open();

                    if (K == 0)
                    {
                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderStartSchedule, '%Y년 %m월 %d일'), " +
                                          " DATE_FORMAT(wo.OrderEndSchedule, '%Y년 %m월 %d일'), wo.OrderMemo " +
                                          " FROM work_instruction AS wi LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                          " WHERE wo.OrderName LIKE '%" + OrderName + "%' AND wo.OrderStateName NOT IN('5') " +
                                          " GROUP BY wo.OrderNo ";
                    }
                    else
                    {
                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderStartSchedule, '%Y년 %m월 %d일'), " +
                                          " DATE_FORMAT(wo.OrderEndSchedule, '%Y년 %m월 %d일'), wo.OrderMemo " +
                                          " FROM work_instruction AS wi LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                          " WHERE wo.OrderName LIKE '%" + OrderName + "%' AND DATE(wo.OrderStartSchedule) BETWEEN '" + Start + "' " +
                                          " AND '" + End + "' AND wo.OrderStateName NOT IN('5') " +
                                          " GROUP BY wo.OrderNo ";
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[6];

                        strArray[0] = rdr[0].ToString();
                        strArray[1] = rdr[1].ToString();
                        strArray[2] = rdr[2].ToString();
                        strArray[3] = rdr[3].ToString();
                        strArray[4] = rdr[4].ToString();
                        strArray[5] = rdr[5].ToString();

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
        public List<string[]> SearchShipmentStatus(string OrderName, string OrderState, string CustomerName, string Start, string End, int K)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();


                try
                {
                    cmd.Connection = conn;
                    conn.Open();

                    if (K == 0)
                    {
                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), " +
                                          " DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo " +
                                          " FROM work_order AS wo  LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wo.OrderName LIKE '%" + OrderName + "%' AND wo.OrderStateName LIKE '%" + OrderState + "%' " +
                                          " AND cu.CustomerName LIKE '%" + CustomerName + "%' AND wo.OrderStateName NOT IN('6', '5') ORDER BY wo.OrderNo ASC ";
                    }
                    else
                    {
                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), " +
                                          " DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo " +
                                          " FROM work_order AS wo  LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wo.OrderName LIKE '%" + OrderName + "%' AND wo.OrderStateName LIKE '%" + OrderState + "%' " +
                                          " AND cu.CustomerName LIKE '%" + CustomerName + "%' AND DATE(wo.OrderDate) BETWEEN '" + Start + "' " +
                                          " AND '" + End + "' AND wo.OrderStateName NOT IN('6', '5') ORDER BY wo.OrderNo ASC ";
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[8];

                        strArray[0] = rdr[0].ToString();
                        strArray[1] = rdr[1].ToString();
                        strArray[2] = rdr[2].ToString();
                        strArray[3] = rdr[3].ToString();
                        strArray[4] = rdr[4].ToString();
                        strArray[5] = rdr[5].ToString();
                        strArray[6] = rdr[6].ToString();
                        strArray[7] = rdr[7].ToString();

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
        public List<string[]> SearchOrderShipment(string OrderName, string Start, string End, int K)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.Connection = conn;
                    conn.Open();

                    if (K == 0)
                    {
                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wo.OrderStartSchedule, wo.OrderEndSchedule, wo.OrderMemo " +
                                          " FROM work_instruction AS wi LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                          " WHERE wo.OrderName LIKE '%" + OrderName + "%' AND wo.OrderStateName IN('5') GROUP BY wo.OrderNo ";
                    }
                    else
                    {
                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wo.OrderStartSchedule, wo.OrderEndSchedule, wo.OrderMemo " +
                                          " FROM work_instruction AS wi LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                          " WHERE wo.OrderName LIKE '%" + OrderName + "%' DATE(wo.OrderDate) BETWEEN ' " + Start + "' " +
                                          " AND ' " + End + "' AND wo.OrderStateName IN('5') GROUP BY wo.OrderNo ";
                    }

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string[] strArray = new string[6];

                        strArray[0] = rdr[0].ToString();
                        strArray[1] = rdr[1].ToString();
                        strArray[2] = rdr[2].ToString();
                        strArray[3] = rdr[3].ToString();
                        strArray[4] = rdr[4].ToString();
                        strArray[5] = rdr[5].ToString();

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
        //출하
        public List<string[]> GetWorkShipmentList_Ongoing(string SearchTable, string SearchName, bool type)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                    "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                    "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo " +
                    "FROM work_instruction AS wi " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                    "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "WHERE wp.FairName IS NOT NULL " +
                    "AND wo.OrderStateName NOT IN('2') AND wo.OrderStateName NOT IN('5') " +
                    "AND wp.WorkProcessStateName NOT IN ('0', '1', '2', '3', '4', '5')  " +
                    "AND wi.WorkInstructionState NOT IN('4') " +
                    "ORDER BY wi.WorkInstructionNo DESC" +
                    ") AS success ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        if (type == true)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                                "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                                "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo " +
                                "FROM work_instruction AS wi " +
                                "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                                "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                "WHERE wp.FairName IS NOT NULL " +
                                "AND wo.OrderStateName NOT IN('2') AND wo.OrderStateName NOT IN('5') " +
                                "AND wp.WorkProcessStateName NOT IN ('0', '1', '2', '3', '4', '5', '15') " +
                                "AND wi.WorkInstructionState NOT IN('4') " +
                                "ORDER BY wi.WorkInstructionNo DESC  ";
                        else if (type == false)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                                "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                                "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo " +
                                "FROM work_instruction AS wi " +
                                "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                                "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                "WHERE wp.FairName IS NOT NULL " +
                                "AND wo.OrderStateName NOT IN('2') AND wo.OrderStateName NOT IN('5') " +
                                "AND wp.WorkProcessStateName NOT IN ('0', '1', '2', '3', '4', '5', '15') " +
                                "AND wi.WorkInstructionState NOT IN('4') " +
                                "AND " + SearchTable + " = '" + SearchName + "' ORDER BY wi.WorkInstructionNo" +
                                " DESC  ";


                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString(),
                                rdr[14].ToString(),
                                rdr[15].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetWorkProcessList_Start_Shipment(string SearchTable, string SearchName, bool type)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                    "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                    "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule " +
                    "FROM work_instruction AS wi " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                    "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "WHERE wp.FairName IS NOT NULL " +
                    "AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                    "AND wp.WorkProcessStateName IN ('0', '3') " +
                    "AND wi.WorkInstructionState NOT IN('4') " +
                    "ORDER BY wi.WorkInstructionNo DESC" +
                    ") AS success ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        if (type == true)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                                "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                                "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule " +
                                "FROM work_instruction AS wi " +
                                "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                                "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                "WHERE wp.FairName IS NOT NULL " +
                                "AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                                "AND wp.WorkProcessStateName IN ('0', '3') " +
                                "AND wi.WorkInstructionState NOT IN('4') " +
                                "ORDER BY wi.WorkInstructionNo DESC  ";
                        else if (type == false)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                                "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                                "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule " +
                                "FROM work_instruction AS wi " +
                                "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                                "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                "WHERE wp.FairName IS NOT NULL " +
                                "AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                                "AND wp.WorkProcessStateName IN ('0', '3') " +
                                "AND wi.WorkInstructionState NOT IN('4') " +
                                "AND " + SearchTable + " = '" + SearchName + "' ORDER BY wi.WorkInstructionNo" +
                                " DESC  ";


                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString(),
                                rdr[14].ToString(),
                                rdr[15].ToString(),
                                rdr[16].ToString(),
                                rdr[17].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        public List<string[]> GetWorkProcessList_Start(string SearchTable, string SearchName, bool type, WorkProcess wp)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                   "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                   "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                   "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule, wp.FairGroup " +
                   "FROM work_instruction AS wi " +
                   "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                   "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                   "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                   "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                   "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                   "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                   "WHERE wp.FairName IS NOT NULL " +
                   "AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                   "AND wp.WorkProcessStateName IN ('0', '3') " +
                   "AND wi.WorkInstructionState NOT IN('4') " +
                   "ORDER BY wi.WorkInstructionNo DESC" +
                   ") AS success ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 11, "WorkInstructionNo");
                        cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 11, "FairName");
                        cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                        cmd.Parameters["@FairName"].Value = wp.FairName;
                        if (type == true)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                               " wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                               " wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule, wp.FairGroup " +
                               " FROM work_instruction AS wi " +
                               " LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                               " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                               " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                               " LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                               " LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                               " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                               " WHERE wp.FairName IS NOT NULL AND wp.WorkInstructionNo = @WorkInstructionNo AND wp.FairName = @FairName " +
                               " AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                               " AND wp.WorkProcessStateName IN('0', '3') " +
                               " AND wi.WorkInstructionState NOT IN('4') " +
                               " GROUP BY wi.WorkInstructionNo ORDER BY wi.WorkInstructionNo DESC ";
                        else if (type == false)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                               "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                               "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule, wp.FairGroup " +
                               "FROM work_instruction AS wi " +
                               "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                               "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                               "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                               "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                               "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                               "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                               "WHERE wp.FairName IS NOT NULL " +
                               "AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                               "AND wp.WorkProcessStateName IN ('0', '3') " +
                               "AND wi.WorkInstructionState NOT IN('4') " +
                               "AND " + SearchTable + " = '" + SearchName + "' ORDER BY wi.WorkInstructionNo" +
                               " DESC  ";


                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString(),
                                rdr[14].ToString(),
                                rdr[15].ToString(),
                                rdr[16].ToString(),
                                rdr[17].ToString(),
                                rdr[18].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        public List<string[]> GetWorkShipmentList_Start(string SearchTable, string SearchName, bool type)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                    "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                    "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule " +
                    "FROM work_instruction AS wi " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                    "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "WHERE wp.FairName IS NOT NULL " +
                    "AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                    "AND wp.WorkProcessStateName IN ('10', '13') " +
                    "AND wp.WorkProcessStateName NOT IN ('0', '1', '2', '3', '4', '5') " +
                    "AND wi.WorkInstructionState NOT IN('4') " +
                    "ORDER BY wi.WorkInstructionNo DESC" +
                    ") AS success ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        if (type == true)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                                "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                                "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule " +
                                "FROM work_instruction AS wi " +
                                "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                                "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                "WHERE wp.FairName IS NOT NULL " +
                                "AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                                "AND wp.WorkProcessStateName IN ('10', '13') " +
                                "AND wp.WorkProcessStateName NOT IN ('0', '1', '2', '3', '4', '5') " +
                                "AND wi.WorkInstructionState NOT IN('4') " +
                                "ORDER BY wi.WorkInstructionNo DESC  ";
                        else if (type == false)
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wi.WorkInstructionNo, pr.ProductNo, pr.ProductName, " +
                                "wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, " +
                                "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wo.OrderStartSchedule, wo.OrderEndSchedule " +
                                "FROM work_instruction AS wi " +
                                "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                                "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                                "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                                "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                "WHERE wp.FairName IS NOT NULL " +
                                "AND wo.OrderStateName NOT IN('6') AND wo.OrderStateName NOT IN('5') " +
                                "AND wp.WorkProcessStateName IN ('0', '3') " +
                                "AND wi.WorkInstructionState NOT IN('4') " +
                                "AND " + SearchTable + " = '" + SearchName + "' ORDER BY wi.WorkInstructionNo" +
                                " DESC  ";


                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString(),
                                rdr[14].ToString(),
                                rdr[15].ToString(),
                                rdr[16].ToString(),
                                rdr[17].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        public void InsertDefectiveCheck(WorkProcess wp)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO quality_management(WorkProcessNo, WorkInstructionNo, FairName, QualityState, QualityMember, QualityMachine, QualityCause, ActionTime) " +
                   "VALUES(@WorkProcessNo, @WorkInstructionNo, @FairName, @QualityState, @MemberName, @MachineName, @Cause, NOW())";


                cmd.Parameters.Add("@WorkProcessNo", MySqlDbType.Int32, 11, "WorkProcessNo");
                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 50, "WorkInstructionNo");
                cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "FairName");
                cmd.Parameters.Add("@QualityState", MySqlDbType.VarChar, 50, "QualityState");
                cmd.Parameters.Add("@MemberName", MySqlDbType.VarChar, 11, "MemberName");
                cmd.Parameters.Add("@MachineName", MySqlDbType.VarChar, 11, "MachineName");
                cmd.Parameters.Add("@Cause", MySqlDbType.VarChar, 11, "Cause");

                cmd.Parameters["@WorkProcessNo"].Value = wp.WorkProcessNo;
                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                cmd.Parameters["@FairName"].Value = wp.FairReal;
                cmd.Parameters["@QualityState"].Value = "불량";
                cmd.Parameters["@MemberName"].Value = wp.MemberName;
                cmd.Parameters["@MachineName"].Value = wp.MachineName;
                cmd.Parameters["@Cause"].Value = wp.ProductType;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateOrderState(WorkOrder wo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                if (wo.OrderMemo == "1") cmd.CommandText = " UPDATE work_order AS wo, work_instruction AS wi SET " +
                                                           " wo.OrderStateName = '3', wi.WorkInstructionState = '6' , wo.RealEndDate = @RealEndDate " +
                                                           " WHERE wo.OrderNo = @OrderNo " +
                                                           " AND wi.OrderNo = @OrderNo ";
                else cmd.CommandText = " UPDATE work_order AS wo, work_instruction AS wi SET " +
                                       " wo.OrderStateName = '5', wi.WorkInstructionState = '6' , wo.RealEndDate = @RealEndDate " +
                                       " WHERE wo.OrderNo = @OrderNo " +
                                       " AND wi.OrderNo = @OrderNo ";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters.Add("@RealEndDate", MySqlDbType.DateTime, 11, "RealEndDate");

                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;
                cmd.Parameters["@RealEndDate"].Value = wo.RealEndDate;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateProcessCompletion(WorkProcess wp)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE work_instruction AS wi, work_order AS wo SET " +
                   "wi.WorkInstructionState = '3', " +
                   "wo.OrderEndSchedule = @OrderEndSchedule, " +
                   "wo.OrderStateName = '3' " +
                   "WHERE wi.OrderNo = @OrderNo " +
                   "AND wo.OrderNo = @OrderNo ";

                cmd.Parameters.Add("@OrderEndSchedule", MySqlDbType.DateTime, 11, "OrderEndSchedule");
                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 11, "WorkInstructionNo");
                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");

                cmd.Parameters["@OrderEndSchedule"].Value = wp.WorkProcessEndTime;
                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                cmd.Parameters["@OrderNo"].Value = wp.OrderNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void OrderScheduleStart(WorkProcess wp)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE work_order SET " +
                    "OrderStartSchedule = @OrderStartSchedule " +
                    "WHERE OrderNo = @OrderNo";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters.Add("@OrderStartSchedule", MySqlDbType.DateTime, 11, "OrderStartSchedule");

                cmd.Parameters["@OrderNo"].Value = wp.OrderNo;
                cmd.Parameters["@OrderStartSchedule"].Value = wp.WorkProcessStartTime;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateShipmentState(WorkProcess wp)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE work_instruction SET " +
                    "WorkInstructionState = '6' " +
                    "WHERE WorkInstructionNo = @WorkInstructionNo ";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 11, "WorkInstructionNo");

                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProcessState(WorkProcess wp, string _type)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE work_process AS wp, work_instruction AS wi, work_order AS wo SET " +
                   "wp.WorkProcessStartTime = @WorkProcessStartTime, " +
                   "wp.WorkProcessEndTime = @WorkProcessEndTime, " +
                   "wp.WorkProcessStateName = @WorkProcessStateName, " +
                   "wp.MemberId = @MemberId, " +
                   "wo.OrderStateName = '2', " +
                   "wi.WorkInstructionState = @WorkInstructionState " +
                   "WHERE wp.WorkProcessNo = @WorkProcessNo " +
                   "AND wi.WorkInstructionNo = @WorkInstructionNo " +
                   "AND wo.OrderNo = @OrderNo";

                cmd.Parameters.Add("@WorkProcessNo", MySqlDbType.Int32, 11, "WorkProcessNo");
                cmd.Parameters.Add("@WorkProcessStartTime", MySqlDbType.DateTime, 50, "WorkProcessStartTime");
                cmd.Parameters.Add("@WorkProcessEndTime", MySqlDbType.DateTime, 50, "WorkProcessEndTime");
                cmd.Parameters.Add("@WorkProcessStateName", MySqlDbType.VarChar, 50, "WorkProcessStateName");
                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters.Add("@MemberId", MySqlDbType.VarChar, 50, "MemberId");
                cmd.Parameters.Add("@WorkInstructionState", MySqlDbType.VarChar, 50, "WorkInstructionState");
                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 50, "WorkInstructionNo");

                cmd.Parameters["@WorkProcessNo"].Value = wp.WorkProcessNo;
                cmd.Parameters["@WorkProcessStartTime"].Value = wp.WorkProcessStartTime;
                if (wp.WorkProcessEndTime.ToString() == "0001-01-01 오전 12:00:00")
                    cmd.Parameters["@WorkProcessEndTime"].Value = DBNull.Value;
                else
                    cmd.Parameters["@WorkProcessEndTime"].Value = wp.WorkProcessEndTime;
                cmd.Parameters["@WorkProcessStateName"].Value = wp.WorkProcessStateName;
                cmd.Parameters["@OrderNo"].Value = wp.OrderNo;
                cmd.Parameters["@MemberId"].Value = wp.MemberId;
                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;

                if (_type == "2" || _type == null) cmd.Parameters["@WorkInstructionState"].Value = "2"; // 진행중
                else if (_type == "3") cmd.Parameters["@WorkInstructionState"].Value = "3"; //작업ㅈ시시ㅓ 완료


                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProcessState(WorkProcess wp)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE work_process SET " +
                    "WorkProcessStateName = '2', " +
                    "MemberId = @MemberId, " +
                    "WorkProcessMemo = @WorkProcessMemo " +
                    "WHERE WorkProcessNo = @WorkProcessNo ";

                cmd.Parameters.Add("@WorkProcessNo", MySqlDbType.Int32, 50, "WorkProcessNo");
                cmd.Parameters.Add("@MemberId", MySqlDbType.VarChar, 50, "MemberId");
                cmd.Parameters.Add("@WorkProcessMemo", MySqlDbType.VarChar, 50, "WorkProcessMemo");

                cmd.Parameters["@WorkProcessNo"].Value = wp.WorkProcessNo;
                cmd.Parameters["@MemberId"].Value = wp.MemberId;
                cmd.Parameters["@WorkProcessMemo"].Value = "폐기 시간 : " + DateTime.Now;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void ProcessPauseLog(WorkProcess wp)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO work_process(WorkInstructionNo, WorkProcessStateName, FairName, FairGroup, FairReal, FairSort, MemberId, MachineNo, " +
                    "WorkProcessPlanStart, WorkProcessPlanEnd, WorkProcessMemo) " +
                    "VALUES(@WorkInstructionNo, @WorkProcessStateName, @FairName, @FairGroup, @FairReal, @FairSort, @MemberId, @MachineNo, " +
                    "@WorkProcessPlanStart, @WorkProcessPlanEnd, @WorkProcessMemo)";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 50, "WorkInstructionNo");
                cmd.Parameters.Add("@WorkProcessStateName", MySqlDbType.VarChar, 50, "WorkProcessStateName");
                cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "FairName");
                cmd.Parameters.Add("@FairGroup", MySqlDbType.VarChar, 50, "FairGroup");
                cmd.Parameters.Add("@FairReal", MySqlDbType.VarChar, 50, "FairReal");
                cmd.Parameters.Add("@FairSort", MySqlDbType.Int32, 50, "FairSort");
                cmd.Parameters.Add("@MemberId", MySqlDbType.VarChar, 50, "MemberId");
                cmd.Parameters.Add("@MachineNo", MySqlDbType.Int32, 50, "MachineNo");
                cmd.Parameters.Add("@WorkProcessPlanStart", MySqlDbType.DateTime, 50, "WorkProcessPlanStart");
                cmd.Parameters.Add("@WorkProcessPlanEnd", MySqlDbType.DateTime, 50, "WorkProcessPlanEnd");
                cmd.Parameters.Add("@WorkProcessMemo", MySqlDbType.VarChar, 50, "WorkProcessMemo");

                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                cmd.Parameters["@WorkProcessStateName"].Value = "3"; //일시 중지
                cmd.Parameters["@FairName"].Value = wp.FairName;
                cmd.Parameters["@FairGroup"].Value = wp.FairGroup;
                cmd.Parameters["@FairReal"].Value = wp.FairReal;
                cmd.Parameters["@FairSort"].Value = wp.FairSort;
                cmd.Parameters["@MemberId"].Value = wp.MemberId;
                cmd.Parameters["@MachineNo"].Value = wp.MachineNo;
                cmd.Parameters["@WorkProcessPlanStart"].Value = wp.WorkProcessPlanStart;
                cmd.Parameters["@WorkProcessPlanEnd"].Value = wp.WorkProcessPlanEnd;
                cmd.Parameters["@WorkProcessMemo"].Value = wp.WorkProcessMemo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdatePause(WorkProcess wp)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE work_process SET " +
                    "WorkProcessStateName = '4', " +
                    "WorkProcessEndTime = @WorkProcessEndTime " +
                    "WHERE WorkProcessNo = @WorkProcessNo ";

                cmd.Parameters.Add("@WorkProcessNo", MySqlDbType.Int32, 50, "WorkProcessNo");
                cmd.Parameters.Add("@WorkProcessEndTime", MySqlDbType.DateTime, 50, "WorkProcessEndTime");

                cmd.Parameters["@WorkProcessNo"].Value = wp.WorkProcessNo;
                cmd.Parameters["@WorkProcessEndTime"].Value = DateTime.Now;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<string[]> GetWorkProcessList(WorkProcess wp)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, " +
                    "mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, wp.WorkProcessMemo, " +
                    "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd " +
                    "FROM work_process AS wp " +
                    "LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                    "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "WHERE wi.WorkInstructionNo = @WorkInstructionNo " +
                    "AND wp.WorkProcessStateName NOT IN ('4') " +
                    "ORDER BY wp.FairName DESC " +
                    ") AS success ";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.VarChar, 50, "WorkInstructionNo");

                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, " +
                            "mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, wp.WorkProcessMemo, " +
                            "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd " +
                            "FROM work_process AS wp " +
                            "LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                            "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                            "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                            "WHERE wi.WorkInstructionNo = @WorkInstructionNo " +
                            "AND wp.WorkProcessStateName NOT IN ('4') " +
                            "ORDER BY wp.FairName DESC ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        //출하
        public List<string[]> GetWorkShipmentList(WorkProcess wp)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, " +
                    "mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, wp.WorkProcessMemo, " +
                    "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd " +
                    "FROM work_process AS wp " +
                    "LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                    "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "WHERE wi.WorkInstructionNo = @WorkInstructionNo " +
                    "AND wp.WorkProcessStateName NOT IN ('0', '1', '2', '3', '4', '5') " +
                    "ORDER BY wp.FairName DESC " +
                    ") AS success ";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.VarChar, 50, "WorkInstructionNo");

                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT wp.FairName, wp.FairReal, wp.FairSort, wp.WorkProcessStateName, " +
                            "mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, wp.WorkProcessMemo, " +
                            "wp.WorkProcessStartTime, wp.WorkProcessEndTime, wp.WorkProcessNo, wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd " +
                            "FROM work_process AS wp " +
                            "LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                            "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                            "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                            "WHERE wi.WorkInstructionNo = @WorkInstructionNo " +
                            "AND wp.WorkProcessStateName NOT IN ('0', '1', '2', '3', '4', '5') " +
                            "ORDER BY wp.FairName DESC ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        #endregion

        #region 검색 작업지시서
        public List<string[]> GetDefFairList(WorkInstruction wi)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT fairNo, FairSort, FairGroup, FairReal, FairName, FairColor FROM def_fair " +
                    ") AS success ";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 45, "WorkInstructionNo");

                cmd.Parameters["@WorkInstructionNo"].Value = wi.WorkinstructionNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT fairNo, FairSort, FairGroup, FairReal, FairName, FairColor " +
                            "FROM def_fair ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> ProcessCheckCompletion(WorkProcess wp)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText =  " SELECT EXISTS( " +
                                   " SELECT COUNT(wi.OrderNo) AS cnt, COUNT(CASE WHEN wi.WorkInstructionState = '3' THEN 1 END) AS com " +
                                   " FROM work_order AS wo " +
                                   " LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                                   " LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                                   " LEFT JOIN product AS pro ON pro.ProductNo = bo.ProductNo " +
                                   " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                                   " WHERE wp.WorkProcessStateName NOT IN('2') " +
                                   " AND wo.OrderNo = @OrderNo " +
                                   " GROUP BY wo.OrderNo " +
                                   " ) as success ";
                    /*"select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wp.WorkInstructionNo, " +
                    "pro.ProductNo, pro.ProductName, bo.ProductType, " +
                    "COUNT(wp.WorkProcessNo) AS cnt, " +
                    "COUNT(CASE WHEN wp.WorkProcessStateName = '15' THEN 1 WHEN wp.WorkProcessStateName = '14' THEN 1 WHEN wp.WorkProcessStateName = '5' THEN 1 WHEN wp.WorkProcessStateName = '4' THEN 1 END) AS com " +
                    "FROM work_order AS wo " +
                    "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                    "LEFT JOIN product AS pro ON pro.ProductNo = bo.ProductNo " +
                    "WHERE wp.WorkProcessStateName NOT IN('2') " +
                    "AND wo.OrderNo = @OrderNo " +
                    "GROUP BY wo.OrderNo " +
                    ") AS success ";*/

                cmd.Parameters.Add("@OrderNo", MySqlDbType.VarChar, 45, "OrderNo");
                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 45, "WorkInstructionNo");

                cmd.Parameters["@OrderNo"].Value = wp.OrderNo;
                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = " SELECT COUNT(wi.OrderNo) AS cnt, COUNT(CASE WHEN wi.WorkInstructionState = '3' THEN 1 END) AS com " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                                          " LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                                          " LEFT JOIN product AS pro ON pro.ProductNo = bo.ProductNo " +
                                          " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                                          " WHERE wp.WorkProcessStateName NOT IN('2') " +
                                          " AND wo.OrderNo = @OrderNo " +
                                          " GROUP BY wo.OrderNo ";
                            /*"SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wp.WorkInstructionNo, " +
                            "pro.ProductNo, pro.ProductName, bo.ProductType, " +
                            "COUNT(wp.WorkProcessNo) AS cnt, " +
                            "COUNT(CASE WHEN wp.WorkProcessStateName = '15' THEN 1 WHEN wp.WorkProcessStateName = '14' THEN 1 WHEN wp.WorkProcessStateName = '5' THEN 1 WHEN wp.WorkProcessStateName = '4' THEN 1 END) AS com " +
                            "FROM work_order AS wo " +
                            "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                            "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                            "LEFT JOIN product AS pro ON pro.ProductNo = bo.ProductNo " +
                            "WHERE wp.WorkProcessStateName NOT IN('2') " +
                            "AND wo.OrderNo = @OrderNo " +
                            "GROUP BY wo.OrderNo; ";*/

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString()
                                /*rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()*/

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        public void DeleteInstruction(WorkInstruction wi)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE  work_instruction AS wi, work_process AS wp " +
                    "SET wi.WorkInstructionState = '4', " +
                    "wp.WorkProcessStateName = '2' " +
                    "WHERE wi.WorkInstructionNo = @WorkInstructionNo " +
                    "AND wp.WorkInstructionNo = @WorkInstructionNo ";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 50, "WorkInstructionNo");

                cmd.Parameters["@WorkInstructionNo"].Value = wi.WorkinstructionNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteALL(WorkInstruction wi)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = " DELETE FROM A, C USING product AS A " +
                                  " LEFT JOIN bom AS B ON A.ProductNo = B.ProductNo " +
                                  " LEFT JOIN work_order AS C ON C.OrderNo = B.OrderNo " +
                                  " LEFT JOIN work_instruction AS D ON D.WorkInstructionNo = B.WorkInstructionNo WHERE D.WorkInstructionNo = @WorkInstructionNo ";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 50, "WorkInstructionNo");
                cmd.Parameters["@WorkInstructionNo"].Value = wi.WorkinstructionNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteWorkOrder(WorkOrder wo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = " DELETE FROM A, C USING product AS A " +
                                  " LEFT JOIN bom AS B ON A.ProductNo = B.ProductNo " +
                                  " LEFT JOIN work_order AS C ON C.OrderNo = B.OrderNo WHERE B.OrderNo = @OrderNo ";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 50, "OrderNo");
                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void InsertInstructions(List<string> list)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO work_process(WorkInstructionNo, WorkProcessStateName, FairSort, FairGroup, FairReal, FairName, " +
                    "WorkProcessPlanStart, WorkProcessPlanEnd, MemberId, MachineNo, WorkProcessMemo) "
                    + "VALUES(@WorkInstructionNo, @WorkProcessStateName, @FairSort, @FairGroup, @FairReal, @FairName, " +
                    "@WorkProcessPlanStart, @WorkProcessPlanEnd, @MemberId, @MachineNo, @WorkProcessMemo)";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 11, "WorkInstructionNo");
                cmd.Parameters.Add("@WorkProcessStateName", MySqlDbType.VarChar, 50, "WorkProcessStateName");
                cmd.Parameters.Add("@FairSort", MySqlDbType.Int32, 50, "FairSort");
                cmd.Parameters.Add("@FairGroup", MySqlDbType.VarChar, 50, "FairGroup");
                cmd.Parameters.Add("@FairReal", MySqlDbType.VarChar, 50, "FairReal");
                cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 11, "FairName");
                cmd.Parameters.Add("@WorkProcessPlanStart", MySqlDbType.DateTime, 11, "WorkProcessPlanStart");
                cmd.Parameters.Add("@WorkProcessPlanEnd", MySqlDbType.DateTime, 11, "WorkProcessPlanEnd");
                cmd.Parameters.Add("@MemberId", MySqlDbType.VarChar, 50, "MemberId");
                cmd.Parameters.Add("@MachineNo", MySqlDbType.Int32, 11, "MachineNo");
                cmd.Parameters.Add("@WorkProcessMemo", MySqlDbType.VarChar, 200, "WorkProcessMemo");

                cmd.Parameters["@WorkInstructionNo"].Value = list[0].ToString();
                cmd.Parameters["@WorkProcessStateName"].Value = "0";
                cmd.Parameters["@FairSort"].Value = list[1].ToString();
                cmd.Parameters["@FairGroup"].Value = list[2].ToString();
                cmd.Parameters["@FairReal"].Value = list[3].ToString();
                cmd.Parameters["@FairName"].Value = list[4].ToString();
                cmd.Parameters["@WorkProcessPlanStart"].Value = list[5].ToString();
                cmd.Parameters["@WorkProcessPlanEnd"].Value = list[6].ToString();
                if (list[7].ToString() == "") cmd.Parameters["@MemberId"].Value = DBNull.Value;
                else cmd.Parameters["@MemberId"].Value = list[7].ToString();
                if (list[9].ToString() == "") cmd.Parameters["@MachineNo"].Value = DBNull.Value;
                else cmd.Parameters["@MachineNo"].Value = list[9].ToString();
                if (list[11].ToString() == "") cmd.Parameters["@WorkProcessMemo"].Value = DBNull.Value;
                else cmd.Parameters["@WorkProcessMemo"].Value = list[11].ToString();

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateWorkinstruction(List<string> list)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = " UPDATE work_instruction SET WorkInstructionState = @WorkInstructionState " +
                                  " WHERE WorkInstructionNo = @WorkInstructionNo ";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 11, "WorkInstructionNo");
                cmd.Parameters.Add("@WorkInstructionState", MySqlDbType.Int32, 50, "WorkInstructionState");

                cmd.Parameters["@WorkInstructionNo"].Value = list[0].ToString();
                cmd.Parameters["@WorkInstructionState"].Value = 1;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<string[]> GetComboMachine()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT MachineNo, MachineName FROM machine ORDER BY MachineName ASC ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[2];

                        strArray[0] = rdr[0].ToString();  //MachineNo
                        strArray[1] = rdr[1].ToString();  //MachineName
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
        public List<string[]> GetComboMember()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT MemberId, MemberName FROM member ORDER BY MemberName ASC ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[2];

                        strArray[0] = rdr[0].ToString();  //id
                        strArray[1] = rdr[1].ToString();  //name
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
        public List<string> GetDefFairName()
        {
            List<string> list = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * " +
                   "FROM def_work_process ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        list.Add(rdr[0].ToString());
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return list;
        }


        public List<string[]> GetWorkDataList_Detail(WorkInstruction wi)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wp.FairSort, wp.FairReal, wp.FairName, wp.FairGroup, " +
                    "wp.WorkProcessStateName,wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, " +
                    "mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, qm.QualityState, wp.WorkProcessMemo " +
                    "FROM work_process AS wp " +
                    "LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                    "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "LEFT JOIN quality_management AS qm ON qm.workProcessNo = wp.WorkProcessNo " +
                    "WHERE wi.WorkInstructionNo = @WorkInstructionNo " +
                    "ORDER BY wp.FairName DESC" +
                    ") AS success ";

                cmd.Parameters.Add("@WorkinstructionNo", MySqlDbType.VarChar, 50, "WorkinstructionNo");

                cmd.Parameters["@WorkinstructionNo"].Value = wi.WorkinstructionNo;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = /*"SELECT wo.OrderNo, wo.OrderName, wp.FairSort, wp.FairReal, wp.FairName, wp.FairGroup, " +
                            "wp.WorkProcessStateName,wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, " +
                            "mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, qm.QualityState, wp.WorkProcessMemo " +
                            "FROM work_process AS wp " +
                            "LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                            "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                            "LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                            "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                            "LEFT JOIN quality_management AS qm ON qm.workProcessNo = wp.WorkProcessNo " +
                            "WHERE wi.WorkInstructionNo = @WorkInstructionNo " +
                            "ORDER BY wp.FairName DESC "*/ //진기수정
                            " SELECT wo.OrderNo, wo.OrderName, wp.FairSort, wp.FairReal, wp.FairName, wp.FairGroup, " +
                            " wp.WorkProcessStateName,wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, " +
                            " mem.MemberId, mem.MemberName, ma.MachineNo, ma.MachineName, qm.QualityState, wp.WorkProcessMemo " +
                            " FROM work_process AS wp " +
                            " LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                            " LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                            " LEFT JOIN member AS mem ON mem.MemberId = wp.MemberId " +
                            " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                            " LEFT JOIN quality_management AS qm ON qm.workProcessNo = wp.WorkProcessNo " +
                            " WHERE wi.WorkInstructionNo = @WorkInstructionNo " +
                            " GROUP BY wp.FairName ORDER BY wp.FairSort ASC ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString(),
                                rdr[14].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetWorkDataList()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS( " +
                                  " SELECT wi.WorkInstructionTime, wi.WorkInstructionNo, wi.WorkInstructionState, wo.OrderNo, wo.OrderName, wo.OrderStateName, " +
                                  " pr.ProductNo, pr.ProductName, bo.ProductType, wo.OrderDate, wo.OrderDateEnd, " +
                                  " cu.CustomerName, cum.CustomerMemberName, wo.OrderMemo " +
                                  " FROM work_order AS wo " +
                                  " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                                  " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                  " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                  " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                  " LEFT JOIN customer_member AS cum ON cum.CustomerMemberNo = wo.CustomerMemberNo " +
                                  " WHERE wi.WorkInstructionNo IS NOT NULL AND bo.ProductType = '자체 제작' " +
                                  " ) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = /*" SELECT wi.WorkInstructionTime, wi.WorkInstructionNo, wi.WorkInstructionState, wo.OrderNo, wo.OrderName, wo.OrderStateName, " +
                                          " pr.ProductNo, pr.ProductName, bo.ProductType, wo.OrderDate, wo.OrderDateEnd, " +
                                          " cu.CustomerName, cum.CustomerMemberName, wo.OrderMemo " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                                          " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                          " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cum ON cum.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wi.WorkInstructionNo IS NOT NULL AND bo.ProductType = '자체 제작' ";*/ //진기수정
                                           " SELECT wi.WorkInstructionTime, wi.WorkInstructionNo, wi.WorkInstructionState, wo.OrderNo, wo.OrderName, wo.OrderStateName, " +
                                           " pr.ProductNo, pr.ProductName, bo.ProductType, wo.OrderDate, wo.OrderDateEnd, " +
                                           " cu.CustomerName, cum.CustomerMemberName, wo.OrderMemo, (SELECT COUNT(B.WorkInstructionNo) " +
                                           " FROM work_order A LEFT JOIN work_instruction B ON A.OrderNo = B.OrderNo " +
                                           " WHERE B.WorkInstructionNo = wi.WorkInstructionNo GROUP BY A.OrderName) " +
                                           " FROM work_order AS wo " +
                                           " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                                           " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wi.WorkInstructionNo " +
                                           " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                           " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                           " LEFT JOIN customer_member AS cum ON cum.CustomerMemberNo = wo.CustomerMemberNo " +
                                           " WHERE wi.WorkInstructionNo IS NOT NULL AND bo.ProductType = '자체 제작' GROUP BY wi.WorkInstructionNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString(),
                                rdr[14].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetCheck(WorkInstruction wi)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS( " +
                                  " SELECT DISTINCT C.OrderName, A.WorkInstructionNo, A.WorkProcessStateName, A.FairGroup, A.FairName, A.FairReal, A.WorkProcessStartTime, A.WorkProcessEndTime " +
                                  " FROM work_process A " +
                                  " LEFT JOIN work_instruction B ON A.WorkInstructionNo = B.WorkInstructionNo " +
                                  " LEFT JOIN work_order C ON C.OrderNo = B.OrderNo " +
                                  " ) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT DISTINCT C.OrderName, A.WorkInstructionNo, A.WorkProcessStateName, A.FairGroup, A.FairName, A.FairReal, A.WorkProcessStartTime, A.WorkProcessEndTime " +
                                          " FROM work_process A " +
                                          " LEFT JOIN work_instruction B ON A.WorkInstructionNo = B.WorkInstructionNo " +
                                          " LEFT JOIN work_order C ON C.OrderNo = B.OrderNo WHERE A.WorkInstructionNo = @WorkInstructionNo ";

                        cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 11, "WorkInstructionNo");
                        cmd.Parameters["@WorkInstructionNo"].Value = wi.WorkinstructionNo;

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public void CompleteWorkInstruction(WorkProcess wp)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " UPDATE work_process A LEFT JOIN work_instruction B ON A.WorkInstructionNo = B.WorkInstructionNo " +
                                  " LEFT JOIN work_order C ON C.OrderNo = B.OrderNo SET " +
                                  " A.WorkProcessStateName = '5', A.WorkProcessStartTime = @WorkProcessStartTime, A.WorkProcessEndTime = @WorkProcessEndTime, " +
                                  " B.WorkInstructionState = 3, C.OrderStateName = '3' " +
                                  " WHERE A.WorkInstructionNo = @WorkInstructionNo AND A.FairName = @FairName ";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 50, "WorkInstructionNo");
                cmd.Parameters.Add("@WorkProcessStateName", MySqlDbType.VarChar, 50, "WorkProcessStateName");
                cmd.Parameters.Add("@WorkProcessStartTime", MySqlDbType.DateTime, 50, "WorkProcessStartTime");
                cmd.Parameters.Add("@WorkProcessEndTime", MySqlDbType.DateTime, 50, "WorkProcessEndTime");
                cmd.Parameters.Add("@FairName", MySqlDbType.VarChar, 50, "FairName");

                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                cmd.Parameters["@WorkProcessStateName"].Value = wp.WorkProcessStateName;
                cmd.Parameters["@WorkProcessStartTime"].Value = wp.WorkProcessStartTime;
                cmd.Parameters["@WorkProcessEndTime"].Value = wp.WorkProcessEndTime;
                cmd.Parameters["@FairName"].Value = wp.FairName;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<string> DefOrderStateList()
        {
            List<string> list = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT OrderStateName FROM def_order_state";
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
        #endregion


        #region 검색 스케쥴
        public List<string[]> GetMachineNameData()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS (SELECT  ma.MachineName, wp.WorkProcessStateName, " +
                                    " wo.OrderName, pro.ProductName, wp.FairReal, DATE_FORMAT(wp.WorkProcessPlanStart, '%Y년 %m월 %d일'), " +
                                    " DATE_FORMAT(wp.WorkProcessPlanEnd, '%Y년 %m월 %d일') , " +
                                    " DATE_FORMAT(wp.WorkProcessStartTime, '%Y년 %m월 %d일'), " +
                                    " DATE_FORMAT(wp.WorkProcessEndTime, '%Y년 %m월 %d일') " +
                                    "FROM work_process AS wp " +
                                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                    "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                    "LEFT JOIN product AS pro ON bo.ProductNo = pro.ProductNo " +
                                    "LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                                    "WHERE wp.MachineNo IS NOT NULL " +
                                    "ORDER BY ma.MachineNo) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT  ma.MachineName, wp.WorkProcessStateName, " +
                                          " wo.OrderName, pro.ProductName, wp.FairReal, DATE_FORMAT(wp.WorkProcessPlanStart, '%Y년 %m월 %d일'), " +
                                          " DATE_FORMAT(wp.WorkProcessPlanEnd, '%Y년 %m월 %d일') , " +
                                          " DATE_FORMAT(wp.WorkProcessStartTime, '%Y년 %m월 %d일'), " +
                                          " DATE_FORMAT(wp.WorkProcessEndTime, '%Y년 %m월 %d일') " +
                                          " FROM work_process AS wp " +
                                          " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                          " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                          " LEFT JOIN product AS pro ON bo.ProductNo = pro.ProductNo " +
                                          " LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                                          " WHERE wp.MachineNo IS NOT NULL " +
                                          " ORDER BY ma.MachineNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()
                            };
                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<WorkOrder> GetWorkOrders()
        {
            List<WorkOrder> list = new List<WorkOrder>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(SELECT * from work_order) AS success ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT * from work_order ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            WorkOrder wo = new WorkOrder();

                            wo.OrderNo = (int)rdr[0];
                            wo.OrderName = rdr[1].ToString();
                            wo.OrderStateName = rdr[2].ToString();
                            wo.OrderDate = rdr[3].ToString();
                            wo.OrderDateEnd = rdr[4].ToString();
                            wo.OrderStartSchedule = rdr[5].ToString();
                            wo.OrderEndSchedule = rdr[6].ToString();
                            if (rdr[7] == DBNull.Value) wo.CustomerNo = 0;
                            else wo.CustomerNo = (int)rdr[7];
                            if (rdr[8] == DBNull.Value) wo.CustomerMemberNo = 0;
                            else wo.CustomerMemberNo = (int)rdr[8];
                            wo.OrderMemo = rdr[9].ToString();
                            wo.OrderPrice = Convert.ToInt64(rdr[10]);
                            wo.RealEndDate = rdr[11].ToString();

                            list.Add(wo);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetMachineSchedule(Machine ma)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT ma.MachineName, wo.OrderName, pr.ProductName, me.MemberName, " +
                    "wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, wp.WorkInstructionNo " +
                    "FROM work_process AS wp " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                    "LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                    "WHERE wp.MachineNo IS NOT NULL AND wp.MachineNo = @MachineNo " +
                    ") AS success ";

                cmd.Parameters.Add("@MachineNo", MySqlDbType.Int32, 11, "MachineNo");
                cmd.Parameters["@MachineNo"].Value = ma.MachineNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT ma.MachineName, wo.OrderName, pr.ProductName, me.MemberName, " +
                    "wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, wp.WorkInstructionNo " +
                    "FROM work_process AS wp " +
                    "LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                    "LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                    "LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                    "WHERE wp.MachineNo IS NOT NULL AND wp.MachineNo = @MachineNo";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetOrderDataSchedule(WorkOrder wo)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wo.OrderDate, wo.OrderDateEnd, cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo, cu.CustomerNumber " +
                                          "FROM work_order AS wo " +
                                          "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          "WHERE wo.OrderNo = @OrderNo " +
                                          "ORDER BY wo.OrderNo ASC " +
                                          ") AS success ";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, " +
                                          "DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo, cu.CustomerNumber " +
                                          "FROM work_order AS wo " +
                                          "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          "WHERE wo.OrderNo = @OrderNo " +
                                          "ORDER BY wo.OrderNo ASC  ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        public List<string[]> GetProductDataSchedule(Product pro)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT bo.ProductNo, pr.ProductName, wo.OrderNo, wo.OrderName, COUNT(pr.ProductNo) AS ProductCount, pr.ProductMemo, " +
                    "wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, bo.WorkInstructionNo " +
                    "FROM bom AS bo " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                    "WHERE bo.ProductNo = @ProductNo " +
                    "GROUP BY bo.OrderNo" +
                    ") AS success ";

                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");

                cmd.Parameters["@ProductNo"].Value = pro.ProductNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT bo.ProductNo, pr.ProductName, wo.OrderNo, wo.OrderName, COUNT(pr.ProductNo) AS ProductCount, pr.ProductMemo, " +
                            "wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, bo.WorkInstructionNo " +
                            "FROM bom AS bo " +
                            "LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                            "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                            "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                            "WHERE bo.ProductNo = @ProductNo " +
                            "GROUP BY bo.OrderNo; ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()

                            };
                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetScheduleItemData(Product pro)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, " +
                    "COUNT(pr.ProductNo) AS ProductCount, pr.ProductMemo " +
                    "FROM bom AS bo " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "WHERE bo.ProductNo = @ProductNo " +
                    "GROUP BY bo.OrderNo" +
                    ") AS success ";

                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");
                cmd.Parameters["@ProductNo"].Value = pro.ProductNo;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, " +
                            "COUNT(pr.ProductNo) AS ProductCount, pr.ProductMemo, " +
                            "wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, bo.WorkInstructionNo, " +
                            "bo.ProductNo, pr.ProductName " +
                            "FROM bom AS bo " +
                            "LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                            "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                            "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = bo.WorkInstructionNo " +
                            "WHERE bo.ProductNo = @ProductNo " +
                            "GROUP BY bo.OrderNo; ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        #endregion
        #region 검색 공통 조회
        //거래처 담당자
        public List<string[]> SetCustomerMemberList(string CustomerName)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT CustomerMemberName, CustomerMemberNo FROM customer_member WHERE CustomerNo = @CustomerNo" +
                                  " Group BY CustomerMemberName ";

                cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 11, "CustomerNo");
                cmd.Parameters["@CustomerNo"].Value = CustomerName;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[2];

                        strArray[0] = rdr[0].ToString();  //이름
                        strArray[1] = rdr[1].ToString();  //번호
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

        //거래처 이름
        public List<string[]> SetCustomerList()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT CustomerName, CustomerNo FROM customer ORDER BY CustomerName ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[2];

                        strArray[0] = rdr[0].ToString();  //이름
                        strArray[1] = rdr[1].ToString();  //번호
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

        //품목 이름
        public List<string[]> SetProductList()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT ProductName, ProductNo FROM product ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[2];

                        strArray[0] = rdr[0].ToString();  //이름
                        strArray[1] = rdr[1].ToString();  //번호
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

        public List<string> SetProductTypeList()
        {
            List<string> list = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT ProductType FROM def_product_type";
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
        #endregion
        #region 검색 품목정보
        public List<string[]> SearchProduct(string result, string Text)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT * FROM product WHERE " + result + " LIKE '%" + Text + "%' ";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[4];

                        strArray[0] = rdr[0].ToString();
                        strArray[1] = rdr[1].ToString();
                        strArray[2] = rdr[2].ToString();
                        strArray[3] = rdr[3].ToString();
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
        public void DeleteProduct(Product pro)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM product WHERE ProductNo = @ProductNo ";

                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");

                cmd.Parameters["@ProductNo"].Value = pro.ProductNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Product pro)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE product SET " +
                                    "ProductName = @ProductName, ProductPrice = @ProductPrice, " +
                                    "unit = @unit, BomStandard = @BomStandard, BomDrawingNo = @BomDrawingNo, " +
                                    "ProductMemo = @ProductMemo " +
                                    "WHERE ProductNo = @ProductNo; ";

                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 50, "ProductNo");
                cmd.Parameters.Add("@ProductName", MySqlDbType.VarChar, 50, "ProductName");
                cmd.Parameters.Add("@ProductPrice", MySqlDbType.VarChar, 50, "ProductPrice");
                cmd.Parameters.Add("@unit", MySqlDbType.VarChar, 50, "unit");
                cmd.Parameters.Add("@BomStandard", MySqlDbType.VarChar, 50, "BomStandard");
                cmd.Parameters.Add("@BomDrawingNo", MySqlDbType.VarChar, 50, "BomDrawingNo");
                cmd.Parameters.Add("@ProductMemo", MySqlDbType.VarChar, 50, "ProductMemo");

                cmd.Parameters["@ProductNo"].Value = pro.ProductNo;
                cmd.Parameters["@ProductName"].Value = pro.ProductName;
                cmd.Parameters["@ProductPrice"].Value = pro.ProductPrice;
                cmd.Parameters["@unit"].Value = pro.Unit;
                cmd.Parameters["@BomStandard"].Value = pro.BomStandard;
                cmd.Parameters["@BomDrawingNo"].Value = pro.BomDrawingNo;
                cmd.Parameters["@ProductMemo"].Value = pro.ProductMemo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void AddProduct(Product pro)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO product " +
                                  "(ProductNo, ProductName, ProductPrice, unit, BomStandard, BomDrawingNo, ProductMemo)" +
                                  "VALUE" +
                                  "(@ProductNo, @ProductName, @ProductPrice, @unit, @BomStandard, @BomDrawingNo, @ProductMemo) ";

                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 50, "ProductNo");
                cmd.Parameters.Add("@ProductName", MySqlDbType.VarChar, 50, "ProductName");
                cmd.Parameters.Add("@ProductPrice", MySqlDbType.VarChar, 50, "ProductPrice");
                cmd.Parameters.Add("@unit", MySqlDbType.VarChar, 50, "unit");
                cmd.Parameters.Add("@BomStandard", MySqlDbType.VarChar, 50, "BomStandard");
                cmd.Parameters.Add("@BomDrawingNo", MySqlDbType.VarChar, 50, "BomDrawingNo");
                cmd.Parameters.Add("@ProductMemo", MySqlDbType.VarChar, 50, "ProductMemo");

                cmd.Parameters["@ProductNo"].Value = pro.ProductNo;
                cmd.Parameters["@ProductName"].Value = pro.ProductName;
                cmd.Parameters["@ProductPrice"].Value = pro.ProductPrice;
                cmd.Parameters["@unit"].Value = pro.Unit;
                cmd.Parameters["@BomStandard"].Value = pro.BomStandard;
                cmd.Parameters["@BomDrawingNo"].Value = pro.BomDrawingNo;
                cmd.Parameters["@ProductMemo"].Value = pro.ProductMemo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<string[]> GetBOMList(WorkOrder wo)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                    "SELECT pr.ProductNo, pr.ProductName, bo.ProductType, pr.ProductPrice, cu.CustomerName, " +
                    "bo.BomSortation, bo.BomManager, pr.BomDrawingNo, pr.BomStandard, COUNT(bo.BomNo), pr.unit, bo.BomETC1 " +
                    "FROM work_order AS wo " +
                    "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN customer AS cu ON cu.CustomerNo = bo.CustomerNo " +
                    "WHERE wo.OrderNo = @OrderNo " +
                    "GROUP BY pr.ProductName" +
                    ") AS success ";

                cmd.Parameters.Add("@orderno", MySqlDbType.Int32, 11, "orderno");

                cmd.Parameters["@orderno"].Value = wo.OrderNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT pr.ProductNo, pr.ProductName, bo.ProductType, pr.ProductPrice, cu.CustomerName, " +
                            "bo.BomSortation, bo.BomManager, pr.BomDrawingNo, pr.BomStandard, COUNT(bo.BomNo), pr.unit, bo.BomETC1 " +
                            "FROM work_order AS wo " +
                            "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                            "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                            "LEFT JOIN customer AS cu ON cu.CustomerNo = bo.CustomerNo " +
                            "WHERE wo.OrderNo = @OrderNo " +
                            "GROUP BY pr.ProductName";



                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GeItemSchedule()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS(SELECT pr.ProductNo, pr.ProductName, wp.FairReal, wp.WorkProcessStateName, wo.OrderName, DATE_FORMAT(wp.WorkProcessPlanStart, '%Y년 %m월 %d일'), DATE_FORMAT(wp.WorkProcessPlanEnd, '%Y년 %m월 %d일'), pr.ProductMemo, wo.OrderMemo " +
                                  " FROM work_process AS wp INNER JOIN bom AS B ON B.WorkInstructionNo = wp.WorkInstructionNo " +
                                  " INNER JOIN work_order AS wo ON wo.OrderNo = B.OrderNo " +
                                  " INNER JOIN product AS pr ON pr.ProductNo = B.ProductNo " +
                                  " WHERE wp.WorkProcessStateName = '1' ORDER BY pr.ProductNo) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = /*" SELECT pr.ProductNo, pr.ProductName, wp.FairReal, wp.WorkProcessStateName, wo.OrderName, " +
                                          " DATE_FORMAT(wp.WorkProcessPlanStart, '%Y년 %m월 %d일'), DATE_FORMAT(wp.WorkProcessPlanEnd, '%Y년 %m월 %d일'), pr.ProductMemo, wo.OrderMemo " +
                                          " FROM work_process AS wp INNER JOIN bom AS B ON B.WorkInstructionNo = wp.WorkInstructionNo " +
                                          " INNER JOIN work_order AS wo ON wo.OrderNo = B.OrderNo " +
                                          " INNER JOIN product AS pr ON pr.ProductNo = B.ProductNo " +
                                          " WHERE wp.WorkProcessStateName = '1' ORDER BY pr.ProductNo ";*/ //진기수정
                                           " SELECT pr.ProductNo, pr.ProductName, wp.FairReal, wp.WorkProcessStateName, wo.OrderName, " +
                                           " DATE_FORMAT(wp.WorkProcessPlanStart, '%Y년 %m월 %d일'), DATE_FORMAT(wp.WorkProcessPlanEnd, '%Y년 %m월 %d일'), pr.ProductMemo, wo.OrderMemo , " +
                                           " (SELECT COUNT(*) FROM work_order AS A LEFT JOIN work_instruction AS B ON B.OrderNo = A.OrderNo WHERE A.OrderNo = wo.OrderNo) " +
                                           " FROM work_process AS wp INNER JOIN bom AS B ON B.WorkInstructionNo = wp.WorkInstructionNo " +
                                           " INNER JOIN work_order AS wo ON wo.OrderNo = B.OrderNo " +
                                           " INNER JOIN product AS pr ON pr.ProductNo = B.ProductNo " +
                                           " WHERE wp.WorkProcessStateName = '1' GROUP BY wp.FairReal ORDER BY pr.ProductNo ";
                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetProductData()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT pr.ProductNo, pr.ProductName, pr.ProductPrice,  pr.unit, pr.BomStandard, pr.BomDrawingNo, pr.ProductMemo  " +
                    "FROM product AS pr " +
                    ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT pr.ProductNo, pr.ProductName, pr.ProductPrice,  pr.unit, pr.BomStandard, pr.BomDrawingNo, pr.ProductMemo  " +
                            "FROM product AS pr ";
                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        #endregion
        #region 검색 수주등록
        public List<WorkOrder> GetOrderState()
        {
            List<WorkOrder> OrderState = new List<WorkOrder>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT OrderStateName FROM def_order_state ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        WorkOrder wo = new WorkOrder();

                        wo.OrderStateName = rdr[0].ToString();

                        OrderState.Add(wo);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return OrderState;
        }
        public List<WorkOrder> GetCustomerGroup()
        {
            List<WorkOrder> CustomerGroup = new List<WorkOrder>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT CustomerGroup FROM def_customer_group ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        WorkOrder wo = new WorkOrder();

                        wo.CustomerGroup = rdr[0].ToString();

                        CustomerGroup.Add(wo);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return CustomerGroup;
        }
        public List<WorkOrder> GetOrderState2()
        {
            List<WorkOrder> OrderState = new List<WorkOrder>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT OrderStateName FROM work_order WHERE OrderStateName NOT IN('6', '5') " +
                                      " GROUP BY OrderStateName ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        WorkOrder wo = new WorkOrder();

                        wo.OrderStateName = rdr[0].ToString();

                        OrderState.Add(wo);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return OrderState;
        }
        public List<string[]> SearchOrder(string CustomerName, string OrderName, string OrderState, string Start, string End, int K)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.Connection = conn;
                    conn.Open();

                    if (K == 0)
                    {
                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
                                          " cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo FROM work_order AS wo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE cu.CustomerName LIKE '%" + CustomerName + "%' AND wo.OrderName LIKE '%" + OrderName + "%' " +
                                          " AND wo.OrderStateName LIKE '%" + OrderState + "%'" +
                                          " AND wo.OrderStateName NOT IN('6', '5') ORDER BY wo.OrderNo; ";
                    }
                    else
                    {
                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
                                          " cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo FROM work_order AS wo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE cu.CustomerName LIKE '%" + CustomerName + "%' AND wo.OrderName LIKE '%" + OrderName + "%' " +
                                          " AND wo.OrderStateName LIKE '%" + OrderState + "%' AND DATE(wo.OrderDate)  BETWEEN '" + Start + "' AND '" + End + "' " +
                                          " AND wo.OrderStateName NOT IN('6', '5') ORDER BY wo.OrderNo; ";
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string[] strArray = new string[8];

                        strArray[0] = rdr[0].ToString();
                        strArray[1] = rdr[1].ToString();
                        strArray[2] = rdr[2].ToString();
                        strArray[3] = rdr[3].ToString();
                        strArray[4] = rdr[4].ToString();
                        strArray[5] = rdr[5].ToString();
                        strArray[6] = rdr[6].ToString();
                        strArray[7] = rdr[7].ToString();
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
        public void UpdateOrder(WorkOrder wo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE work_order SET OrderName = @OrderName, OrderDate = @OrderDate, OrderDateEnd = @OrderDateEnd, OrderPrice = @OrderPrice, " +
                                  "CustomerMemberNo = (SELECT CustomerMemberNo FROM customer_member WHERE CustomerMemberName = @CustomerMemberName), " +
                                  "CustomerNo = (SELECT CustomerNo FROM customer WHERE CustomerName = @CustomerName), " +
                                  "OrderMemo = @OrderMemo, OrderEmergency = @OrderEmergency WHERE OrderNo = @OrderNo";

                cmd.Parameters.Add("@OrderName", MySqlDbType.VarChar, 50, "OrderName");
                cmd.Parameters.Add("@OrderDateEnd", MySqlDbType.VarChar, 50, "OrderDateEnd");
                cmd.Parameters.Add("@OrderDate", MySqlDbType.VarChar, 50, "OrderDate");
                cmd.Parameters.Add("@CustomerMemberName", MySqlDbType.VarChar, 50, "CustomerMemberName");
                cmd.Parameters.Add("@CustomerMemberNo", MySqlDbType.VarChar, 50, "CustomerMemberNo");
                cmd.Parameters.Add("@CustomerName", MySqlDbType.VarChar, 50, "CustomerName");
                cmd.Parameters.Add("@OrderMemo", MySqlDbType.VarChar, 50, "OrderMemo");
                cmd.Parameters.Add("@OrderNo", MySqlDbType.VarChar, 50, "OrderNo");
                cmd.Parameters.Add("@OrderPrice", MySqlDbType.Int64, 50, "OrderPrice");
                cmd.Parameters.Add("@OrderEmergency", MySqlDbType.VarChar, 50, "OrderEmergency");

                cmd.Parameters["@OrderName"].Value = wo.OrderName;
                cmd.Parameters["@OrderDateEnd"].Value = wo.OrderDateEnd;
                cmd.Parameters["@OrderDate"].Value = wo.OrderDate;
                cmd.Parameters["@CustomerMemberName"].Value = wo.CustomerMemberName;
                cmd.Parameters["@CustomerName"].Value = wo.CustomerName;
                cmd.Parameters["@OrderMemo"].Value = wo.OrderMemo;
                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;
                cmd.Parameters["@OrderPrice"].Value = wo.OrderPrice;
                cmd.Parameters["@OrderEmergency"].Value = wo.OrderEmergency;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<string> DefUnit()
        {
            List<string> list = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT unit FROM def_unit";
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
        public List<string> DefProductType()
        {
            List<string> list = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT ProductType FROM def_product_type";
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

        public void DeleteOrder(WorkOrder wo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE work_order AS wo " +
                                  " LEFT JOIN work_instruction AS wi " +
                                  " ON wo.OrderNo = wi.OrderNo " +
                                  " LEFT JOIN work_process AS wp " +
                                  " ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                                  " SET wo.OrderStateName = '6', " +
                                  " wi.WorkInstructionState = '4', " +
                                  " wp.WorkProcessStateName = '2' " +
                                  " WHERE wo.OrderNo = @OrderNo";

                cmd.Parameters.Add("@orderno", MySqlDbType.VarChar, 50, "orderno");

                cmd.Parameters["@orderno"].Value = wo.OrderNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<string[]> GetBOMData(WorkOrder wo)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                    "SELECT wo.OrderNo, wo.OrderName, cu.CustomerName, cm.CustomerMemberName, wo.OrderDate, wo.OrderDateEnd, " +
                    "bo.ProductNo, pr.ProductName, bo.ProductType, pr.ProductPrice, COUNT(pr.ProductNo) AS ProductCount, null AS TotalPrice, " +
                    "wo.OrderStartSchedule, wo.OrderEndSchedule, pr.ProductMemo " +
                    "FROM work_order AS wo " +
                    "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                    "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                    "WHERE wo.OrderNo = @orderno " +
                    "AND bo.ProductNo IS NOT NULL " +
                    "GROUP BY pr.ProductNo" +
                    ") AS success ";

                cmd.Parameters.Add("@orderno", MySqlDbType.Int32, 11, "orderno");

                cmd.Parameters["@orderno"].Value = wo.OrderNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, cu.CustomerName, cm.CustomerMemberName, wo.OrderDate, wo.OrderDateEnd, " +
                            "bo.ProductNo, pr.ProductName, bo.ProductType, pr.ProductPrice, COUNT(pr.ProductNo) AS ProductCount, " +
                            "wo.OrderStartSchedule, wo.OrderEndSchedule, pr.ProductMemo " +
                            "FROM work_order AS wo " +
                            "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                            "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                            "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                            "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                            "WHERE wo.OrderNo = @orderno " +
                            "AND bo.ProductNo IS NOT NULL " +
                            "GROUP BY pr.ProductNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString(),
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetMachineBomData(Machine machine)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS( " +
                                  " SELECT bo.ProductNo, pr.ProductName, wp.FairReal, bo.ProductType, wp.WorkProcessStateName, COUNT(pr.ProductNo AND wp.FairReal), pr.ProductMemo " +
                                  " FROM work_process AS wp " +
                                  " LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                  " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                  " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                  " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                  " WHERE ma.MachineNo = @ma.MachineNo " +
                                  " AND bo.ProductNo IS NOT NULL " +
                                  " GROUP BY pr.ProductNo)AS success ";

                cmd.Parameters.Add("@ma.MachineNo", MySqlDbType.Int32, 11, "ma.MachineNo");

                cmd.Parameters["@ma.MachineNo"].Value = machine.MachineNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        if (machine.WorkProcess.WorkProcessStateName.Equals("작업 중"))
                        {
                            cmd.CommandText = " SELECT bo.ProductNo, pr.ProductName, wp.FairReal, bo.ProductType, wp.WorkProcessStateName, COUNT(pr.ProductNo AND wp.FairReal), pr.ProductMemo " +
                                              " FROM work_process AS wp " +
                                              " LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                              " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                              " WHERE ma.MachineNo = @ma.MachineNo " +
                                              " AND bo.ProductNo IS NOT NULL AND wp.WorkProcessStateName = '1' " +
                                              " GROUP BY pr.ProductNo ";
                        }
                        else if (machine.WorkProcess.WorkProcessStateName.Equals("작업완료"))
                        {
                            cmd.CommandText = " SELECT bo.ProductNo, pr.ProductName, wp.FairReal, bo.ProductType, wp.WorkProcessStateName, COUNT(pr.ProductNo AND wp.FairReal), pr.ProductMemo " +
                                              " FROM work_process AS wp " +
                                              " LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                              " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                              " WHERE ma.MachineNo = @ma.MachineNo " +
                                              " AND bo.ProductNo IS NOT NULL AND wp.WorkProcessStateName = '5' " +
                                              " GROUP BY pr.ProductNo ";
                        }
                        else
                        {
                            cmd.CommandText = " SELECT bo.ProductNo, pr.ProductName, wp.FairReal, bo.ProductType, wp.WorkProcessStateName, COUNT(pr.ProductNo AND wp.FairReal), pr.ProductMemo " +
                                              " FROM work_process AS wp " +
                                              " LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                              " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                              " WHERE ma.MachineNo = @ma.MachineNo " +
                                              " AND bo.ProductNo IS NOT NULL AND wp.WorkProcessStateName = '2' " +
                                              " GROUP BY pr.ProductNo ";
                        }
                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        public bool NumberCheck(string ColumnName, string TableName, string Number)
        {
            bool result = false;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS (SELECT " + ColumnName + " FROM " + TableName + " WHERE " + ColumnName + " = @Number) as success";

                cmd.Parameters.Add("@Number", MySqlDbType.VarChar, 50, "Number");

                cmd.Parameters["@Number"].Value = Number;

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
                }
            }
            return result;
        }
        public void InsertBarcodeNumber(string barcodenum, WorkOrder wo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO work_instruction(WorkInstructionNo, OrderNo, WorkInstructionState, WorkInstructionTime) "
                   + "VALUES(@WorkInstructionNo, @OrderNo, @WorkInstructionState, @WorkInstructionTime)";


                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 50, "WorkInstructionNo");
                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 50, "OrderNo");
                cmd.Parameters.Add("@WorkInstructionState", MySqlDbType.Int32, 50, "WorkInstructionState");
                cmd.Parameters.Add("@WorkInstructionTime", MySqlDbType.Date, 50, "WorkInstructionTime");

                cmd.Parameters["@WorkInstructionNo"].Value = barcodenum;
                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;
                cmd.Parameters["@WorkInstructionState"].Value = "0";
                cmd.Parameters["@WorkInstructionTime"].Value = DateTime.Now.ToString("yyyy-MM-dd");


                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertBomSave(List<string> Bomlist, WorkOrder wo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO bom(WorkInstructionNo, ProductNo, OrderNo, ProductType, " +
                    "CustomerNo, BomSortation, BomManager, BomETC1) "
                   + "VALUES(@WorkInstructionNo, @ProductNo, @OrderNo, @ProductType, " +
                   "(SELECT CustomerNo FROM customer WHERE CustomerName = @CustomerName), " +
                   "@BomSortation, @BomManager, @BomETC1)";

                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 50, "WorkInstructionNo");
                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 50, "ProductNo");
                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 50, "OrderNo");
                cmd.Parameters.Add("@ProductType", MySqlDbType.VarChar, 50, "ProductType");
                cmd.Parameters.Add("@CustomerName", MySqlDbType.VarChar, 50, "CustomerName");
                cmd.Parameters.Add("@BomSortation", MySqlDbType.VarChar, 50, "BomSortation");
                cmd.Parameters.Add("@BomManager", MySqlDbType.VarChar, 50, "BomManager");
                cmd.Parameters.Add("@BomETC1", MySqlDbType.VarChar, 50, "BomETC1");

                cmd.Parameters["@ProductNo"].Value = Bomlist[0].ToString();
                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;
                cmd.Parameters["@ProductType"].Value = Bomlist[2].ToString();
                cmd.Parameters["@CustomerName"].Value = Bomlist[4].ToString();
                cmd.Parameters["@BomSortation"].Value = Bomlist[5].ToString();
                cmd.Parameters["@BomManager"].Value = Bomlist[6].ToString();
                cmd.Parameters["@BomETC1"].Value = Bomlist[11].ToString();
                cmd.Parameters["@WorkInstructionNo"].Value = Bomlist[12].ToString();

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void InsertProductExcel(Product pr)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO product(ProductNo, ProductName, ProductPrice, unit, BomStandard, BomDrawingNo, ProductMemo) " +
                                  "VALUES(@ProductNo, @ProductName, @ProductPrice, @unit, @BomStandard, @BomDrawingNo, @ProductMemo)";


                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int32, 11, "ProductNo");
                cmd.Parameters.Add("@ProductName", MySqlDbType.VarChar, 50, "ProductName");
                cmd.Parameters.Add("@ProductPrice", MySqlDbType.Int32, 11, "ProductPrice");
                cmd.Parameters.Add("@unit", MySqlDbType.VarChar, 50, "unit");
                cmd.Parameters.Add("@BomStandard", MySqlDbType.VarChar, 50, "BomStandard");
                cmd.Parameters.Add("@BomDrawingNo", MySqlDbType.VarChar, 50, "BomDrawingNo");
                cmd.Parameters.Add("@ProductMemo", MySqlDbType.VarChar, 500, "ProductMemo");

                cmd.Parameters["@ProductNo"].Value = pr.ProductNo;
                cmd.Parameters["@ProductName"].Value = pr.ProductName;
                cmd.Parameters["@ProductPrice"].Value = pr.ProductPrice;
                cmd.Parameters["@unit"].Value = pr.Unit;
                cmd.Parameters["@BomStandard"].Value = pr.BomStandard;
                cmd.Parameters["@BomDrawingNo"].Value = pr.BomDrawingNo;
                cmd.Parameters["@ProductMemo"].Value = pr.ProductMemo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void InsertOrderExcel(WorkOrder wo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO work_order(OrderNo, OrderName, OrderStateName, CustomerNo, CustomerMemberNo, OrderDate, OrderDateEnd, OrderMemo, OrderPrice) "
                   + "VALUES(@OrderNo, @OrderName, '1', @CustomerNo, @CustomerMemberNo, @OrderDate, @OrderDateEnd, @OrderMemo, @OrderPrice)";


                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters.Add("@OrderName", MySqlDbType.VarChar, 50, "OrderName");
                cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 11, "CustomerNo");
                cmd.Parameters.Add("@CustomerMemberNo", MySqlDbType.Int32, 11, "CustomerMemberNo");
                cmd.Parameters.Add("@OrderDate", MySqlDbType.DateTime, 50, "OrderDate");
                cmd.Parameters.Add("@OrderDateEnd", MySqlDbType.DateTime, 50, "OrderDateEnd");
                cmd.Parameters.Add("@OrderMemo", MySqlDbType.VarChar, 500, "OrderMemo");
                cmd.Parameters.Add("@OrderPrice", MySqlDbType.Int64, 50, "OrderPrice");

                cmd.Parameters["@OrderNo"].Value =              wo.OrderNo;
                cmd.Parameters["@OrderName"].Value =            wo.OrderName;
                cmd.Parameters["@CustomerNo"].Value =           wo.CustomerNo;
                cmd.Parameters["@CustomerMemberNo"].Value =     wo.CustomerMemberNo;
                cmd.Parameters["@OrderDate"].Value =            wo.OrderDate.Substring(0,10);
                cmd.Parameters["@OrderDateEnd"].Value =         wo.OrderDateEnd.Substring(0, 10);
                cmd.Parameters["@OrderMemo"].Value =            wo.OrderMemo;
                cmd.Parameters["@OrderPrice"].Value =           wo.OrderPrice;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void InsertOrderSave(WorkOrder wo)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO work_order(OrderNo, OrderName, OrderStateName, CustomerNo, CustomerMemberNo, OrderDate, OrderDateEnd, OrderMemo, OrderPrice, OrderEmergency) "
                   + "VALUES(@OrderNo, @OrderName, '1', @CustomerNo, @CustomerMemberNo, @OrderDate, @OrderDateEnd, @OrderMemo, @OrderPrice, @OrderEmergency)";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters.Add("@OrderName", MySqlDbType.VarChar, 50, "OrderName");
                cmd.Parameters.Add("@CustomerNo", MySqlDbType.Int32, 11, "CustomerNo");
                cmd.Parameters.Add("@CustomerMemberNo", MySqlDbType.Int32, 11, "CustomerMemberNo");
                cmd.Parameters.Add("@OrderDate", MySqlDbType.DateTime, 50, "OrderDate");
                cmd.Parameters.Add("@OrderDateEnd", MySqlDbType.DateTime, 50, "OrderDateEnd");
                cmd.Parameters.Add("@OrderMemo", MySqlDbType.VarChar, 500, "OrderMemo");
                cmd.Parameters.Add("@OrderPrice", MySqlDbType.Int64, 50, "OrderPrice");
                cmd.Parameters.Add("@OrderEmergency", MySqlDbType.VarChar, 50, "OrderEmergency");

                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;
                cmd.Parameters["@OrderName"].Value = wo.OrderName;
                cmd.Parameters["@CustomerNo"].Value = wo.CustomerNo;
                cmd.Parameters["@CustomerMemberNo"].Value = wo.CustomerMemberNo;
                cmd.Parameters["@OrderDate"].Value = wo.OrderDate;
                cmd.Parameters["@OrderDateEnd"].Value = wo.OrderDateEnd;
                cmd.Parameters["@OrderMemo"].Value = wo.OrderMemo;
                cmd.Parameters["@OrderPrice"].Value = wo.OrderPrice;
                cmd.Parameters["@OrderEmergency"].Value = wo.OrderEmergency;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<string[]> SetOrderDetailListView()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wo.OrderDate, wo.OrderDateEnd, cu.CustomerName, wo.OrderMemo " +
                    "FROM work_order AS wo " +
                    "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                    "LEFT JOIN customer AS cu ON cu.CustomerNo = cm.CustomerNo " +
                    ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wo.OrderDate, wo.OrderDateEnd, cu.CustomerName, wo.OrderMemo " +
                                "FROM work_order AS wo " +
                                "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                "LEFT JOIN customer AS cu ON cu.CustomerNo = cm.CustomerNo ";
                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetOrderDataList()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS( " +
                                  " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cm.CustomerMemberName, " +
                                  " DATE_FORMAT(wo.OrderDate, '%Y-%m-%d'), DATE_FORMAT(wo.OrderDateEnd, '%Y-%m-%d'), " +
                                  " wo.OrderPrice, wo.OrderMemo, cu.CustomerGroup, wo.OrderEmergency " +
                                  " FROM work_order AS wo " +
                                  " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                  " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                  " WHERE wo.OrderStateName NOT IN('3', '4', '5', '6') " +
                                  " ORDER BY wo.OrderNo " +
                                  " ) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cm.CustomerMemberName, " +
                            "DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
                            "FORMAT(wo.OrderPrice, 0), wo.OrderMemo, cu.CustomerGroup, wo.OrderEmergency " +
                            "FROM work_order AS wo " +
                            "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                            "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                            "WHERE wo.OrderStateName NOT IN('3', '4', '5', '6') " +
                            "ORDER BY wo.OrderNo";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetSearchOrderSchedule(String str)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                    "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cm.CustomerMemberName, " +
                    "DATE_FORMAT(wo.OrderDate, '%Y-%m-%d'), DATE_FORMAT(wo.OrderDateEnd, '%Y-%m-%d'), " +
                    "wo.OrderMemo " +
                    "FROM work_order AS wo " +
                    "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                    "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                    "WHERE wo.OrderStateName IN('2', '5', '6') " +
                    "ORDER BY wo.OrderNo" +
                    ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        if (str.Equals("진행중"))
                        {
                            cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cm.CustomerMemberName, " +
                                "DATE_FORMAT(wo.OrderDate, '%Y-%m-%d'), DATE_FORMAT(wo.OrderDateEnd, '%Y-%m-%d'), " +
                                "wo.OrderMemo " +
                                "FROM work_order AS wo " +
                                "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                "WHERE wo.OrderStateName IN('2') " +
                                "ORDER BY wo.OrderNo";
                        }
                        else
                        {
                            cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cm.CustomerMemberName, " +
                                              " DATE_FORMAT(wo.OrderStartSchedule, '%Y-%m-%d'), DATE_FORMAT(wo.OrderEndSchedule, '%Y-%m-%d'), " +
                                              " wo.OrderMemo FROM work_order AS wo " +
                                              " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                              " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                              " WHERE wo.OrderStateName IN('5', '6') ORDER BY wo.OrderNo ";

                        }
                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetSearchItemSchedule(String str)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS(SELECT pr.ProductNo, pr.ProductName, wp.FairReal, wp.WorkProcessStateName, wo.OrderName, " +
                                  " wp.WorkProcessPlanStart, wp.WorkProcessPlanEnd, pr.ProductMemo, wo.OrderMemo " +
                                  " FROM work_process AS wp INNER JOIN bom AS B ON B.WorkInstructionNo = wp.WorkInstructionNo " +
                                  " INNER JOIN work_order AS wo ON wo.OrderNo = B.OrderNo " +
                                  " INNER JOIN product AS pr ON pr.ProductNo = B.ProductNo " +
                                  " WHERE wp.WorkProcessStateName IN('1', '2', '5') ORDER BY pr.ProductNo) AS success";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        if (str.Equals("작업 중"))
                            cmd.CommandText = " SELECT pr.ProductNo, pr.ProductName, wp.FairReal, wp.WorkProcessStateName, wo.OrderName, " +
                                              " DATE_FORMAT(wp.WorkProcessPlanStart, '%Y년 %m월 %d일'), DATE_FORMAT(wp.WorkProcessPlanEnd, '%Y년 %m월 %d일'), pr.ProductMemo, wo.OrderMemo " +
                                              " FROM work_process AS wp INNER JOIN bom AS B ON B.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " INNER JOIN work_order AS wo ON wo.OrderNo = B.OrderNo INNER JOIN product " +
                                              " AS pr ON pr.ProductNo = B.ProductNo WHERE wp.WorkProcessStateName IN('1') ORDER BY pr.ProductNo ";
                        else
                        {
                            cmd.CommandText = " SELECT pr.ProductNo, pr.ProductName, wp.FairReal, wp.WorkProcessStateName, wo.OrderName, " +
                                              " wp.WorkProcessStartTime, wp.WorkProcessEndTime, pr.ProductMemo, wo.OrderMemo " +
                                              " FROM work_process AS wp INNER JOIN bom AS B ON B.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " INNER JOIN work_order AS wo ON wo.OrderNo = B.OrderNo INNER JOIN product " +
                                              " AS pr ON pr.ProductNo = B.ProductNo WHERE wp.WorkProcessStateName IN('2', '5') ORDER BY pr.ProductNo ";
                        }

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetSearchMachineSchedule(String str)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS(SELECT ma.MachineNo, ma.MachineName, ma.MachineType, wp.WorkProcessStateName, wo.OrderName, me.MemberName, DATE_FORMAT(wp.WorkProcessPlanStart, '%Y년 %m월 %d일'), DATE_FORMAT(wp.WorkProcessPlanEnd, '%Y년 %m월 %d일') " +
                                  " FROM work_process AS wp " +
                                  " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                  " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                  " LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                                  " LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                                  " WHERE wp.MachineNo IS NOT NULL AND wp.WorkProcessStateName IN ('1', '2', '5')) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        if (str.Equals("작업 중"))
                            cmd.CommandText = " SELECT ma.MachineNo, ma.MachineName, ma.MachineType, wp.WorkProcessStateName, wo.OrderName, me.MemberName, DATE_FORMAT(wp.WorkProcessPlanStart, '%Y년 %m월 %d일'), DATE_FORMAT(wp.WorkProcessPlanEnd, '%Y년 %m월 %d일'), ma.MachineETC " +
                                              " FROM work_process AS wp " +
                                              " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                              " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                                              " LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                                              " WHERE wp.MachineNo IS NOT NULL AND wp.WorkProcessStateName IN('1') ORDER BY machineName ";
                        else
                        {
                            cmd.CommandText = " SELECT ma.MachineNo, ma.MachineName, ma.MachineType, wp.WorkProcessStateName, wo.OrderName, me.MemberName, wp.WorkProcessStartTime, wp.WorkProcessEndTime, ma.MachineETC " +
                                              " FROM work_process AS wp " +
                                              " LEFT JOIN machine AS ma ON ma.MachineNo = wp.MachineNo " +
                                              " LEFT JOIN bom AS bo ON bo.WorkInstructionNo = wp.WorkInstructionNo " +
                                              " LEFT JOIN work_order AS wo ON wo.OrderNo = bo.OrderNo " +
                                              " LEFT JOIN member AS me ON me.MemberId = wp.MemberId " +
                                              " WHERE wp.MachineNo IS NOT NULL AND wp.WorkProcessStateName IN('2', '5') ORDER BY machineName ";
                        }
                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetOrderData()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
                                          " cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wo.OrderStateName = '2' " +
                                          " ORDER BY wo.OrderNo DESC) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
                                          " cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wo.OrderStateName = '2' " +
                                          " ORDER BY wo.OrderNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        //출고
        public List<string[]> GetEndOrder()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
                                          " cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wo.OrderStateName IN ('5', '6') " +
                                          " ORDER BY wo.OrderNo DESC) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
                                          " cu.CustomerName, cm.CustomerMemberName, wo.OrderMemo " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wo.OrderStateName IN ('5', '6') " +
                                          " ORDER BY wo.OrderNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetShipmentOrderDataList_ALL()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wo.OrderStartSchedule, wo.OrderEndSchedule, wo.OrderMemo " +
                    "FROM work_instruction AS wi " +
                    "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                    "WHERE wo.OrderStateName IN ('5') " +
                    "GROUP BY wo.OrderNo" +
                    ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, wo.OrderStartSchedule, wo.OrderEndSchedule, wo.OrderMemo " +
                            "FROM work_instruction AS wi " +
                            "LEFT JOIN work_order AS wo ON wo.OrderNo = wi.OrderNo " +
                            "WHERE wo.OrderStateName IN ('5') " +
                            "GROUP BY wo.OrderNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        public List<string[]> GetShipmentOrderDataList()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), " +
                    " DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderStartSchedule, '%Y년 %m월 %d일'), " +
                    " DATE_FORMAT(wo.OrderEndSchedule, '%Y년 %m월 %d일'), FORMAT(wo.OrderPrice, 0), " +
                    " COUNT(case when wi.WorkInstructionState = '6' then 1 when wi.WorkInstructionState = '7' then 1 END) " +
                    " AS COMPLETION, COUNT(wi.WorkInstructionNo) AS cnt, wo.OrderMemo, cm.CustomerMemberName, cu.CustomerName, DATE_FORMAT(wo.RealEndDate, '%Y년 %m월 %d일') " +
                    " FROM work_order AS wo " +
                    " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                    " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                    " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                    " WHERE wo.OrderStateName IN('3', '4', '5') " +
                    " GROUP BY wo.OrderNo" +
                    ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), " +
                                          " DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderStartSchedule, '%Y년 %m월 %d일'), " +
                                          " DATE_FORMAT(wo.OrderEndSchedule, '%Y년 %m월 %d일'), FORMAT(wo.OrderPrice, 0), " +
                                          " COUNT(case when wi.WorkInstructionState = '6' then 1 when wi.WorkInstructionState = '7' then 1 END) " +
                                          " AS COMPLETION, COUNT(wi.WorkInstructionNo) AS cnt, wo.OrderMemo, cm.CustomerMemberName, cu.CustomerName, DATE_FORMAT(wo.RealEndDate, '%Y년 %m월 %d일') " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wo.OrderStateName IN('3', '4', '5') " +
                                          " GROUP BY wo.OrderNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString(),
                                rdr[12].ToString(),
                                rdr[13].ToString()
                            };
                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetShipmentProductData(WorkOrder wo)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS( " +
                    "SELECT wo.OrderName, pr.ProductNo, pr.ProductName, bo.ProductType, " +
                    "wi.WorkInstructionState,  " +
                    "COUNT(case when qm.QualityState = '불량' then 1 END) AS cnt, " +
                    "COUNT(wp.WorkProcessNo) AS allcnt, " +
                    "COUNT(CASE WHEN wp.WorkProcessStateName = '5' THEN 1 WHEN wp.WorkProcessStateName = '4' THEN 1 END) AS allcom, " +
                    "wi.WorkInstructionNo  " +
                    "FROM work_order AS wo " +
                    "LEFT JOIN bom AS bo ON wo.OrderNo = bo.OrderNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = bo.WorkInstructionNo  " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN quality_management AS qm ON qm.workProcessNo = wp.WorkProcessNo " +
                    "WHERE wo.OrderNo = @OrderNo " +
                    "GROUP BY wi.WorkInstructionNo" +
                    ") AS success "; //진기수정

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 50, "OrderNo");
                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT wo.OrderName, pr.ProductNo, pr.ProductName, bo.ProductType, " +
                    "wi.WorkInstructionState,  " +
                    "COUNT(case when qm.QualityState = '불량' then 1 END) AS cnt, " +
                    "COUNT(wp.WorkProcessNo) AS allcnt, " +
                    "COUNT(CASE WHEN wp.WorkProcessStateName = '5' THEN 1 WHEN wp.WorkProcessStateName = '4' THEN 1 END) AS allcom, " +
                    "wi.WorkInstructionNo  " +
                    "FROM work_order AS wo " +
                    "LEFT JOIN bom AS bo ON wo.OrderNo = bo.OrderNo " +
                    "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                    "LEFT JOIN work_instruction AS wi ON wi.WorkInstructionNo = bo.WorkInstructionNo  " +
                    "LEFT JOIN work_process AS wp ON wp.WorkInstructionNo = wi.WorkInstructionNo " +
                    "LEFT JOIN quality_management AS qm ON qm.workProcessNo = wp.WorkProcessNo " +
                    "WHERE wo.OrderNo = @OrderNo " +
                    "GROUP BY wi.WorkInstructionNo, pr.ProductNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()

                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        #endregion
        #region 검색 외주 현황
        public List<string[]> GetOutDataList()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS(" +
                                  " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cu.CustomerGroup, " +
                                  " DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
							      " FORMAT(wo.OrderPrice, 0), wo.OrderMemo " +
                                  " FROM work_order AS wo " +
                                  " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                  " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                                  " LEFT JOIN bom AS B ON B.WorkInstructionNo = wi.WorkInstructionNo " +
                                  " LEFT JOIN product AS P ON P.ProductNo = B.ProductNo " +
                                  " WHERE B.ProductType = '외주 제작' " +
                                  " GROUP BY wo.OrderNo) AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cu.CustomerGroup, " +
                                          " DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
							              " FORMAT(wo.OrderPrice, 0), wo.OrderMemo " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN work_instruction AS wi ON wi.OrderNo = wo.OrderNo " +
                                          " LEFT JOIN bom AS B ON B.WorkInstructionNo = wi.WorkInstructionNo " +
                                          " LEFT JOIN product AS P ON P.ProductNo = B.ProductNo " +
                                          " WHERE B.ProductType = '외주 제작' " +
                                          " GROUP BY wo.OrderNo";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public List<string[]> GetOutProductList(WorkOrder wo)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT EXISTS(" +
                                  " SELECT wo.OrderNo, wo.OrderName, pr.ProductName, bo.ProductType, cm.CustomerMemberName, COUNT(pr.ProductNo)AS ProductCount, pr.ProductPrice, " +
                                  " DATE_FORMAT(bo.BomOutTime, '%Y년 %m월 %d일'), DATE_FORMAT(bo.BomInTime, '%Y년 %m월 %d일'), pr.ProductMemo, bo.WorkInstructionNo, pr.ProductNo " +
                                  " FROM work_order AS wo " +
                                  " LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                                  " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                  " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                  " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                  " WHERE wo.OrderNo = @OrderNo AND bo.ProductType = '외주 제작' " +
                                  " AND bo.ProductNo IS NOT NULL " +
                                  " GROUP BY pr.ProductNo" +
                                  ") AS success ";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters["@OrderNo"].Value = wo.OrderNo;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = " SELECT wo.OrderNo, wo.OrderName, pr.ProductName, bo.ProductType, cm.CustomerMemberName, COUNT(pr.ProductNo)AS ProductCount, pr.ProductPrice, " +
                                          " DATE_FORMAT(bo.BomOutTime, '%Y년 %m월 %d일'), DATE_FORMAT(bo.BomInTime, '%Y년 %m월 %d일'), pr.ProductMemo, bo.WorkInstructionNo, pr.ProductNo " +
                                          " FROM work_order AS wo " +
                                          " LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                                          " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                          " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                          " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                          " WHERE wo.OrderNo = @OrderNo AND bo.ProductType = '외주 제작' " +
                                          " AND bo.ProductNo IS NOT NULL " +
                                          " GROUP BY pr.ProductNo "; 

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                                rdr[0].ToString(),
                                rdr[1].ToString(),
                                rdr[2].ToString(),
                                rdr[3].ToString(),
                                rdr[4].ToString(),
                                rdr[5].ToString(),
                                rdr[6].ToString(),
                                rdr[7].ToString(),
                                rdr[8].ToString(),
                                rdr[9].ToString(),
                                rdr[10].ToString(),
                                rdr[11].ToString()
                            };
                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public void OutInProduct(WorkProcess wp, bool kkw)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                if (kkw is true)
                {
                    cmd.CommandText = " UPDATE bom AS B, work_order AS wo SET B.BomOutTime = @BomOutTime, wo.OrderStateName = '2' " +
                                      " WHERE wo.OrderNo = @OrderNo AND B.ProductNo = @ProductNo AND B.ProductType = '외주 제작' ";
                }
                else cmd.CommandText = " UPDATE bom SET BomInTime = @BomInTime WHERE OrderNo = @OrderNo AND ProductNo = @ProductNo AND ProductType = '외주 제작' ";


                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int64, 11, "ProductNo");
                cmd.Parameters.Add("@BomOutTime", MySqlDbType.DateTime, 11, "BomOutTime");
                cmd.Parameters.Add("@BomInTime", MySqlDbType.DateTime, 11, "BomInTime");

                cmd.Parameters["@OrderNo"].Value = wp.WorkOrder.OrderNo;
                cmd.Parameters["@ProductNo"].Value = wp.ProductNo;
                cmd.Parameters["@BomOutTime"].Value = wp.BomOutTime;
                cmd.Parameters["@BomInTime"].Value = wp.BomInTime;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void OutProcess(WorkProcess wp, bool kkw)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                if (kkw == true) cmd.CommandText = "INSERT INTO work_process(WorkInstructionNo, WorkProcessStateName, FairSort, FairGroup, FairReal, FairName, " +
                                                   "WorkProcessPlanStart, WorkProcessPlanEnd, WorkProcessMemo) " +
                                                   "VALUES(@WorkInstructionNo, @WorkProcessStateName, '0', '외주 제작', '외주', '외주', " +
                                                   "@WorkProcessPlanStart, @WorkProcessPlanEnd, @WorkProcessMemo)";
                else cmd.CommandText = " UPDATE work_process wp, work_instruction wi " +
                                       " INNER JOIN bom B ON B.WorkInstructionNo = wi.WorkInstructionNo " +
                                       " INNER JOIN work_order wo ON wo.OrderNo = B.OrderNo " +
                                       " INNER JOIN product pro ON pro.ProductNo = B.ProductNo " +
                                       " SET wp.WorkProcessStateName = 5, wp.FairSort = '0', wp.FairGroup = '외주 제작', wp.FairReal = '외주', wp.FairName = '외주', " +
                                       " wp.WorkProcessPlanStart = @WorkProcessPlanStart,wp.WorkProcessPlanEnd = @WorkProcessPlanEnd, wp.WorkProcessMemo = '', wi.WorkInstructionState = '3' " +
                                       " WHERE wp.WorkInstructionNo = @WorkInstructionNo AND B.ProductNo = @ProductNo AND B.OrderNo = @OrderNo ";

                                     /*" UPDATE work_process AS wp, work_instruction AS wi SET wp.WorkProcessStateName = @WorkProcessStateName, " +
                                       " wp.FairSort = '0', wp.FairGroup = '외주 제작', wp.FairReal = '외주', wp.FairName = '외주', wp.WorkProcessPlanStart = @WorkProcessPlanStart, " +
                                       " wp.WorkProcessPlanEnd = @WorkProcessPlanEnd, wp.WorkProcessMemo = @WorkProcessMemo, wi.WorkInstructionState = '3' " +
                                       " WHERE wp.WorkInstructionNo = @WorkInstructionNo AND wi.WorkInstructionNo = @WorkInstructionNo"*/;

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters.Add("@ProductNo", MySqlDbType.Int64, 11, "ProductNo");
                cmd.Parameters.Add("@WorkProcessMemo", MySqlDbType.VarChar, 200, "WorkProcessMemo");
                cmd.Parameters.Add("@WorkInstructionNo", MySqlDbType.Int64, 11, "WorkInstructionNo");
                cmd.Parameters.Add("@WorkProcessPlanEnd", MySqlDbType.DateTime, 50, "WorkProcessPlanEnd");
                cmd.Parameters.Add("@WorkProcessStateName", MySqlDbType.VarChar, 50, "WorkProcessStateName");
                cmd.Parameters.Add("@WorkProcessPlanStart", MySqlDbType.DateTime, 50, "WorkProcessPlanStart");

                cmd.Parameters["@OrderNo"].Value = wp.OrderNo;
                cmd.Parameters["@ProductNo"].Value = wp.ProductNo;
                cmd.Parameters["@WorkProcessMemo"].Value = wp.OrderMemo;
                cmd.Parameters["@WorkInstructionNo"].Value = wp.WorkInstructionNo;
                cmd.Parameters["@WorkProcessPlanStart"].Value = Convert.ToDateTime(wp.WorkOrder.OrderDate).ToString("yyyy-MM-dd");
                cmd.Parameters["@WorkProcessPlanEnd"].Value = Convert.ToDateTime(wp.WorkOrder.OrderDateEnd).ToString("yyyy-MM-dd");
                if (kkw == true) cmd.Parameters["@WorkProcessStateName"].Value = "1";
                else cmd.Parameters["@WorkProcessStateName"].Value = "5";

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<String[]> GetOrderName()
        {
            List<String[]> OrderState = new List<String[]>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT OrderName, OrderNo FROM work_order WHERE OrderStateName IN ('5') ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string[] strArray = new string[2];

                        strArray[0] = rdr[0].ToString();  //이름
                        strArray[1] = rdr[1].ToString();  //번호
                        OrderState.Add(strArray);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return OrderState;
        }
        public List<string[]> GetProductList(string str)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT ProductName, pro.BomDrawingNo, DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), " +
                                  " DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), COUNT(B.ProductNo) AS Cnt, DATE_FORMAT(wo.OrderEndSchedule, '%Y년 %m월 %d일') " +
                                  " FROM work_order wo " +
                                  " INNER JOIN bom B ON B.OrderNo = wo.OrderNo " +
                                  " INNER JOIN product pro ON pro.ProductNo = B.ProductNo " +
                                  " WHERE wo.OrderNo = @orderNo " +
                                  " GROUP BY B.ProductNo ";

                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");
                cmd.Parameters["@OrderNo"].Value = str;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[6];

                        strArray[0] = rdr[0].ToString();  //품명
                        strArray[1] = rdr[1].ToString();  //도번
                        strArray[2] = rdr[2].ToString();  //수주예정일
                        strArray[3] = rdr[3].ToString();  //출하예정일
                        strArray[4] = rdr[4].ToString();  //수량
                        strArray[5] = rdr[5].ToString();  //납품일
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
        public List<string[]> ProductData(string ProductName, string OrderNo)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " SELECT pro.ProductName, pro.BomDrawingNo, COUNT(B.ProductNo) AS Cnt " +
                                  " FROM product pro INNER JOIN bom B ON B.ProductNo = pro.ProductNo " +
                                  " WHERE pro.ProductName = @ProductName AND B.OrderNo = @OrderNo GROUP BY B.ProductNo "; 

                cmd.Parameters.Add("@ProductName", MySqlDbType.VarChar, 11, "ProductName");
                cmd.Parameters.Add("@OrderNo", MySqlDbType.Int32, 11, "OrderNo");

                cmd.Parameters["@ProductName"].Value = ProductName;
                cmd.Parameters["@OrderNo"].Value = OrderNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        string[] strArray = new string[3];

                        strArray[0] = rdr[0].ToString();  //품명
                        strArray[1] = rdr[1].ToString();  //도번
                        strArray[2] = rdr[2].ToString();  //개수
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
        #endregion
        #region 검색 거래명세서
        public List<string[]> GetOrderDataListAll()
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                   "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cm.CustomerMemberName, " +
                   "DATE_FORMAT(wo.OrderDate, '%Y-%m-%d'), DATE_FORMAT(wo.OrderDateEnd, '%Y-%m-%d'), " +
                   "wo.OrderPrice, wo.OrderMemo " +
                   "FROM work_order AS wo " +
                   "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                   "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                   "ORDER BY wo.OrderNo" +
                   ") AS success ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {

                        cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, wo.OrderStateName, cu.CustomerName, cm.CustomerMemberName, " +
                           "DATE_FORMAT(wo.OrderDate, '%Y년 %m월 %d일'), DATE_FORMAT(wo.OrderDateEnd, '%Y년 %m월 %d일'), " +
                           "FORMAT(wo.OrderPrice, 0), wo.OrderMemo " +
                           "FROM work_order AS wo " +
                           "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                           "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                           "ORDER BY wo.OrderNo";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                        rdr[0].ToString(),
                        rdr[1].ToString(),
                        rdr[2].ToString(),
                        rdr[3].ToString(),
                        rdr[4].ToString(),
                        rdr[5].ToString(),
                        rdr[6].ToString(),
                        rdr[7].ToString(),
                        rdr[8].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public int getCusNo(int num)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    cmd.CommandText = " SELECT CustomerNo FROM work_order WHERE OrderNo =  " + num;

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        return (int)rdr[0];
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return 0;
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
                        cmd.CommandText = "SELECT CustomerNo, CustomerName, CustomerAddress, CustomerNumber, CustomerMemo, CustomerGroup " +
                            "FROM Customer " +
                            "WHERE CustomerNo = @CustomerNo; ";

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
        public List<string[]> GetBOMDataRecipt(WorkOrder wo)
        {
            List<string[]> list = new List<string[]>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS(" +
                   "SELECT wo.OrderNo, wo.OrderName, cu.CustomerName, cm.CustomerMemberName, wo.OrderDate, wo.OrderDateEnd, " +
                   "bo.ProductNo, pr.ProductName, bo.ProductType, pr.ProductPrice, COUNT(pr.ProductNo) AS ProductCount, null AS TotalPrice, " +
                   "wo.OrderStartSchedule, wo.OrderEndSchedule, pr.ProductMemo, pr.BomStandard " +
                   "FROM work_order AS wo " +
                   "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                   "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                   "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                   "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                   "WHERE wo.OrderNo = @orderno " +
                   "AND bo.ProductNo IS NOT NULL " +
                   "GROUP BY pr.ProductNo" +
                   ") AS success ";

                cmd.Parameters.Add("@orderno", MySqlDbType.Int32, 11, "orderno");
                cmd.Parameters["@orderno"].Value = wo.OrderNo;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT wo.OrderNo, wo.OrderName, cu.CustomerName, cm.CustomerMemberName, wo.OrderDate, wo.OrderDateEnd, " +
                           "bo.ProductNo, pr.ProductName, bo.ProductType, pr.ProductPrice, COUNT(pr.ProductNo) AS ProductCount, " +
                           "wo.OrderStartSchedule, wo.OrderEndSchedule, pr.ProductMemo, pr.BomStandard  " +
                           "FROM work_order AS wo " +
                           "LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                           "LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                           "LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                           "LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                           "WHERE wo.OrderNo = @OrderNo " +
                           "AND bo.ProductNo IS NOT NULL " +
                           "GROUP BY pr.ProductNo ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] strArray;
                            strArray = new string[]
                            {
                             rdr[0].ToString(),
                             rdr[1].ToString(),
                             rdr[2].ToString(),
                             rdr[3].ToString(),
                             rdr[4].ToString(),
                             rdr[5].ToString(),
                             rdr[6].ToString(),
                             rdr[7].ToString(),
                             rdr[8].ToString(),
                             rdr[9].ToString(),
                             rdr[10].ToString(),
                             rdr[11].ToString(),
                             rdr[12].ToString(),
                             rdr[13].ToString(),
                             rdr[14].ToString()
                            };

                            list.Add(strArray);
                        }
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        #endregion
        #region 검색 라벨
        public List<WorkOrder> GetCount(string str)
        {
            List<WorkOrder> Count = new List<WorkOrder>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.Parameters.Add("@OrderNo", MySqlDbType.VarChar, 50, "OrderNo");

                cmd.Parameters["@OrderNo"].Value = str;
                try
                {
                    cmd.CommandText = " SELECT COUNT(*) over() AS total, wo.OrderName " +
                                      " FROM work_order AS wo " +
                                      " LEFT JOIN bom AS bo ON bo.OrderNo = wo.OrderNo " +
                                      " LEFT JOIN product AS pr ON pr.ProductNo = bo.ProductNo " +
                                      " LEFT JOIN customer AS cu ON cu.CustomerNo = wo.CustomerNo " +
                                      " LEFT JOIN customer_member AS cm ON cm.CustomerMemberNo = wo.CustomerMemberNo " +
                                      " WHERE wo.OrderNo = @OrderNo " +
                                      " AND bo.ProductNo IS NOT NULL " +
                                      " GROUP BY pr.ProductNo ";

                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        WorkOrder GetCount = new WorkOrder();

                        GetCount.OrderMemo = rdr[0].ToString();
                        GetCount.OrderName = rdr[1].ToString();

                        Count.Add(GetCount);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Count;
        }
        public void InsertLabelTime(int Count)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO label_data(LabelCount, LabelStartTime) " +
                                  "VALUES(@LabelCount, @LabelStartTime)";

                cmd.Parameters.Add("@LabelCount", MySqlDbType.Int32, 50, "LabelCount");
                cmd.Parameters.Add("@LabelStartTime", MySqlDbType.DateTime, 50, "LabelStartTime");

                cmd.Parameters["@LabelCount"].Value = Count;
                cmd.Parameters["@LabelStartTime"].Value = DateTime.Now;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateLabelTime()
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " UPDATE label_data SET labelEndTime = NOW() " +
                                      " WHERE LabelStartTime = (SELECT MAX(LabelStartTime) FROM label_data) AND LabelEndTime IS NULL ";

                    //cmd.Parameters.Add("@QualityManager", MySqlDbType.VarChar, 50, "QualityManager");

                    //cmd.Parameters["@QualityManager"].Value = RegistValue[0];

                    cmd.Connection = conn;

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void UpdateTimeLag()
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " UPDATE label_data SET TimeLag = TIMESTAMPDIFF(SECOND, LabelStartTime, LabelEndTime) " +
                                      " WHERE LabelStartTime = (SELECT MAX(LabelStartTime) FROM label_data) ";

                    //cmd.Parameters.Add("@QualityManager", MySqlDbType.VarChar, 50, "QualityManager");

                    //cmd.Parameters["@QualityManager"].Value = RegistValue[0];

                    cmd.Connection = conn;

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void DeleteLabelTime()
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM label_data WHERE LabelStartTime = (SELECT MAX(LabelStartTime) FROM label_data) ";

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
