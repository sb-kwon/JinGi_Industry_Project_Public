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
    public class DBKpi
    {
        private DBMain _DBMain;
        public DBKpi(DBMain dBMain)
        {
            _DBMain = dBMain;
        }

        public List<work_process> total(string str)
        {
            List<work_process> quality = new List<work_process>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS(SELECT DISTINCT workprocessstarttime FROM work_process)";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT * FROM(SELECT DATE_FORMAT(A.workProcessEndTime, '%Y-%m') AS MONTH, " +
                                          " SUM(B.ProductCnt) FROM work_process A INNER JOIN producths B " +
                                          " ON A.workInstructionNo = B.WorkInstructionNo " +
                                          " WHERE A.workProcessEndTime <= @str1 AND DATE_ADD(@str, INTERVAL - 12 MONTH) <= A.workProcessEndTime " +
                                          " AND A.fiarName = '가공' " +
                                          " GROUP BY MONTH DESC " +
                                          " ORDER BY MONTH DESC LIMIT 2) sub " +
                                          " ORDER BY MONTH ASC ";

                        cmd.Parameters.Add("@str", MySqlDbType.VarChar, 50, "str");
                        cmd.Parameters.Add("@str1", MySqlDbType.VarChar, 50, "str1");
                        cmd.Parameters["@str"].Value = str + "-01";
                        cmd.Parameters["@str1"].Value = str + "-31";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            work_process qu = new work_process();
                            qu.EndTimeMonth = rdr[0].ToString();
                            qu.KPITotalAmount = rdr[1].ToString();

                            quality.Add(qu);
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

            return quality;
        }

        //현재 달 불량 건 수
        public List<Quality> GetQChart(string str)
        {
            List<Quality> quality = new List<Quality>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS(SELECT DISTINCT workprocessstarttime FROM work_process)";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM ( " +
"SELECT DATE_FORMAT(qualityDeadline,'%Y-%m') AS MONTH, SUM(qualityCnt) " +
"FROM quality_management " +
"WHERE qualityDeadline <= @str AND DATE_ADD(@str1, INTERVAL - 12 MONTH) <= qualityDeadline " +
"GROUP BY MONTH DESC " +
"ORDER BY MONTH DESC LIMIT 2) sub " +
"ORDER BY MONTH ASC; ";

                        cmd.Parameters.Add("@str1", MySqlDbType.VarChar, 50, "str1");
                        cmd.Parameters.Add("@str", MySqlDbType.VarChar, 50, "str");
                        cmd.Parameters["@str1"].Value = str + "-01";
                        cmd.Parameters["@str"].Value = str + "-31";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Quality qu = new Quality();
                            qu.qualityCompletiontime = rdr[0].ToString();
                            qu.KPIDefectTotalAmount = rdr[1].ToString();

                            quality.Add(qu);
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

            return quality;
        }

        public List<work_process> GetPChart(string str)
        {
            List<work_process> workprocess = new List<work_process>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS(SELECT DISTINCT workprocessstarttime FROM work_process)";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT DATE_FORMAT(A.workProcessEndTime, '%Y-%m') AS MONTH, SUM(A.workProcessTimestampdiff) " +
                                          " AS SUM, SUM(B.ProductCnt) AS COUNT FROM work_process A INNER JOIN producths B " +
                                          " ON A.workInstructionNo = B.WorkInstructionNo WHERE(A.workProcessStateName = '양호' " +
                                          " OR A.workProcessStateName = '불량' OR A.workProcessStateName = '작업완료') " +
                                          " AND A.fiarName = '가공' AND DATE_ADD(@str1, INTERVAL - 12 MONTH) <= A.workProcessEndTime " +
                                          " AND A.workProcessEndTime <= @str GROUP BY MONTH DESC ORDER BY MONTH DESC LIMIT 2 ";



                        cmd.Parameters.Add("@str1", MySqlDbType.VarChar, 50, "str1");
                        cmd.Parameters.Add("@str", MySqlDbType.VarChar, 50, "str");
                        cmd.Parameters["@str1"].Value = str + "-01";
                        cmd.Parameters["@str"].Value = str + "-31";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            work_process wp = new work_process();
                            wp.EndTimeMonth = rdr[0].ToString();
                            if (rdr[1].ToString() == "")
                                wp.workProcessTimestampdiff = "0";
                            else
                                wp.workProcessTimestampdiff = rdr[1].ToString();
                            if (rdr[2].ToString() == "")
                                wp.KPITotalAmount = "0";
                            else
                                wp.KPITotalAmount = rdr[2].ToString();

                            workprocess.Add(wp);
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

            return workprocess;
        }

        public List<String> ComboListUp(bool type)
        {
            List<String> result = new List<String>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS(SELECT DISTINCT workprocessstarttime FROM work_process)";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        if (type == true) //리드타임
                        {
                            cmd.CommandText = "SELECT DISTINCT DATE_FORMAT(workProcessEndTime, '%Y-%m') AS CREATE_DATE " +
                                              "FROM work_process " +
                                              "WHERE workProcessEndTime IS NOT NULL " +
                                              "GROUP BY workProcessEndTime " +
                                              "ORDER BY workProcessEndTime DESC ";
                        }
                        else if (type == false)// 불량
                        {
                            cmd.CommandText = "SELECT DATE_FORMAT(qualityDeadline,'%Y-%m') AS MONTH, COUNT(*) " +
                                              "FROM quality_management " +
                                              "WHERE qualityDeadline IS NOT NULL " +
                                              "GROUP BY MONTH DESC " +
                                              "ORDER BY MONTH DESC ";
                        }

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
    }
}
