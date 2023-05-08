using System;
using System.Collections.Generic;
using System.Data;
using Model;
using MySql.Data.MySqlClient;


namespace DataBase
{
    public class DBNotice
    {
        string user_str;
        private DBMain _DBMain;
        public DBNotice(DBMain dBMain)
        {
            _DBMain = dBMain;
        }
        #region 공지사항
        public List<Notice> NoticesSearch(string result, string value)
        {
            List<Notice> notices = new List<Notice>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS (SELECT * FROM  notice) as success";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT noti.noticeNo, noti.noticeTitle, mem.memberName, noti.noticeTime, noti.noticeContent " +
                            "FROM notice AS noti " +
                            "LEFT JOIN member AS mem ON mem.memberId = noti.memberId " +
                            "WHERE " + result + " LIKE " + "'%" + value + "%'";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Notice notice = new Notice();
                            notice.NoticeNo = (int)rdr[0];
                            notice.NoticeTitle = rdr[1].ToString();
                            notice.memberName = rdr[2].ToString();
                            notice.NoticeTime = rdr[3].ToString();
                            notice.NoticeContent = rdr[4].ToString();

                            notices.Add(notice);
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

            return notices;
        }


        public void DeleteOrderDraftList(int orderdraftno)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM order_draft_list  " +
                            "WHERE OrderDraftNo = @OrderDraftNo";

                cmd.Parameters.Add("@OrderDraftNo", MySqlDbType.VarChar, 50, "OrderDraftNo");
                cmd.Parameters["@OrderDraftNo"].Value = orderdraftno;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }



        public void UpdateOrderDraftList(OrderDraft od)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress + "allow user variables=true;"))
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction Mtran = null;


                if (conn.State == ConnectionState.Open) conn.Close();
                cmd.Connection = conn;
                conn.Open();
                Mtran = conn.BeginTransaction();
                try
                {
                    cmd.Parameters.Add("@OrderDraftNo", MySqlDbType.VarChar, 50, "OrderDraftNo");
                    cmd.Parameters.Add("@OrderDraftListName", MySqlDbType.VarChar, 50, "OrderDraftListName");
                    cmd.Parameters.Add("@OrderDraftListStandard", MySqlDbType.VarChar, 50, "OrderDraftListStandard");
                    cmd.Parameters.Add("@OrderDraftListCount", MySqlDbType.VarChar, 50, "OrderDraftListCount");
                    cmd.Parameters.Add("@OrderDraftListPrice", MySqlDbType.VarChar, 50, "OrderDraftListPrice");
                    cmd.Parameters.Add("@OrderDraftListTax", MySqlDbType.VarChar, 50, "OrderDraftListTax");

                    foreach (OrderDraftList odl in od.OrderDraftLists)
                    {
                        cmd.CommandText = "UPDATE order_draft_list SET " +
                           "OrderDraftListCount = @OrderDraftListCount, OrderDraftListStandard = @OrderDraftListStandard, OrderDraftListName = @OrderDraftListName " +
                           ", OrderDraftListPrice = @OrderDraftListPrice , OrderDraftListTax = @OrderDraftListTax" +
                           "WHERE OrderDraftNo = @OrderDraftNo";

                        cmd.Parameters["@OrderDraftNo"].Value = odl.Orderdraftno;
                        cmd.Parameters["@OrderDraftListName"].Value = odl.Orderdraftlistname;
                        cmd.Parameters["@OrderDraftListStandard"].Value = odl.Orderdraftliststandard;
                        cmd.Parameters["@OrderDraftListCount"].Value = odl.Orderdraftlistcount;
                        cmd.Parameters["@OrderDraftListPrice"].Value = odl.Orderdraftlistprice;
                        cmd.Parameters["@OrderDraftListTax"].Value = odl.Orderdraftlisttax;

                        if (conn.State == ConnectionState.Open) conn.Close();
                        conn.Open();

                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                    }
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    Mtran.Commit();
                }
                catch (Exception e)
                {
                    Mtran.Rollback();
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void InsertOrderDraftList(List<OrderDraftList> orderDraftLists, int no)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress + "allow user variables=true;"))
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction Mtran = null;


                if (conn.State == ConnectionState.Open) conn.Close();
                cmd.Connection = conn;
                conn.Open();
                Mtran = conn.BeginTransaction();
                try
                {
                    cmd.Parameters.Add("@OrderDraftNo", MySqlDbType.VarChar, 50, "OrderDraftNo");
                    cmd.Parameters.Add("@OrderDraftListName", MySqlDbType.VarChar, 50, "OrderDraftListName");
                    cmd.Parameters.Add("@OrderDraftListStandard", MySqlDbType.VarChar, 50, "OrderDraftListStandard");
                    cmd.Parameters.Add("@OrderDraftListCount", MySqlDbType.VarChar, 50, "OrderDraftListCount");
                    cmd.Parameters.Add("@OrderDraftListPrice", MySqlDbType.VarChar, 50, "OrderDraftListPrice");
                    cmd.Parameters.Add("@OrderDraftListTax", MySqlDbType.VarChar, 50, "OrderDraftListTax");

                    foreach (OrderDraftList MA in orderDraftLists)
                    {
                        cmd.CommandText = "INSERT INTO order_draft_list ( OrderDraftNo, OrderDraftListName, OrderDraftListStandard, OrderDraftListCount, OrderDraftListPrice, OrderDraftListTax) " +
                                    "VALUES(@OrderDraftNo, @OrderDraftListName, @OrderDraftListStandard, @OrderDraftListCount, @OrderDraftListPrice,  @OrderDraftListTax)";

                        cmd.Parameters["@OrderDraftNo"].Value = no;
                        cmd.Parameters["@OrderDraftListName"].Value = MA.Orderdraftlistname;
                        cmd.Parameters["@OrderDraftListStandard"].Value = MA.Orderdraftliststandard;
                        cmd.Parameters["@OrderDraftListCount"].Value = MA.Orderdraftlistcount;
                        cmd.Parameters["@OrderDraftListPrice"].Value = MA.Orderdraftlistprice;
                        cmd.Parameters["@OrderDraftListTax"].Value = MA.Orderdraftlisttax;

                        if (conn.State == ConnectionState.Open) conn.Close();
                        conn.Open();

                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                    }
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    Mtran.Commit();
                }
                catch (Exception e)
                {
                    Mtran.Rollback();
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public int InsertOrderDraft(OrderDraft od)
        {
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO order_draft ( OrderDraftDate, OrderDraftCustomer, OrderDraftMemo, OrderDraftCusMem) " +
                            "VALUES( NOW(), @OrderDraftCustomer,  @OrderDraftMemo, @OrderDraftCusMem)";

                cmd.Parameters.Add("@OrderDraftNo", MySqlDbType.VarChar, 50, "OrderDraftNo");
                cmd.Parameters.Add("@OrderDraftCustomer", MySqlDbType.VarChar, 50, "OrderDraftCustomer");
                cmd.Parameters.Add("@OrderDraftMemo", MySqlDbType.VarChar, 50, "OrderDraftMemo");
                cmd.Parameters.Add("@OrderDraftCusMem", MySqlDbType.VarChar, 50, "OrderDraftCusMem");

                cmd.Parameters["@OrderDraftNo"].Value = od.Orderdraftno;
                cmd.Parameters["@OrderDraftCustomer"].Value = od.Orderdraftcustomer;
                cmd.Parameters["@OrderDraftMemo"].Value = od.Orderdraftmemo;
                cmd.Parameters["@OrderDraftCusMem"].Value = od.OrderDraftCusMem;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();



                cmd.CommandText = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                    "WHERE TABLE_SCHEMA = 'dg' AND TABLE_NAME = 'order_draft'";

                try
                {
                    cmd.Connection = conn;

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

        public List<string> NoticeSysTitleList()
        {
            List<string> list = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select EXISTS (SELECT * FROM  notice) as success";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT noticeSysTitle FROM  notice_sys  GROUP BY noticeSysTitle";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            list.Add(rdr[0].ToString());
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

        public void AddNotice(Notice _Noti)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO notice (NoticeTitle, memberId, NoticeTime, NoticeContent) " +
                            "VALUES(@NoticeTitle, @memberId, NOW(), @NoticeContent)";

                cmd.Parameters.Add("@NoticeTitle", MySqlDbType.VarChar, 50, "NoticeTitle");
                cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
                cmd.Parameters.Add("@NoticeContent", MySqlDbType.VarChar, 50, "NoticeContent");

                cmd.Parameters["@NoticeTitle"].Value = _Noti.NoticeTitle;
                cmd.Parameters["@memberId"].Value = _Noti.memberId;
                cmd.Parameters["@NoticeContent"].Value = _Noti.NoticeContent;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }//using
        }

        public void AddNoticeSys(string Type, string Title, string Content)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO notice_sys (noticeSysType, noticeSysTitle, noticeSysDate, noticeSysContent) " +
                            "VALUES(@noticeSysType, @noticeSysTitle, NOW(), @NoticeContent)";

                cmd.Parameters.Add("@noticeSysType", MySqlDbType.VarChar, 50, "noticeSysType");
                cmd.Parameters.Add("@noticeSysTitle", MySqlDbType.VarChar, 50, "noticeSysTitle");
                cmd.Parameters.Add("@noticeSysContent", MySqlDbType.VarChar, 50, "noticeSysContent");

                cmd.Parameters["@noticeSysType"].Value = Type;
                cmd.Parameters["@noticeSysTitle"].Value = Title;
                cmd.Parameters["@noticeSysContent"].Value = Content;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }//using
        }

        public void ModifyNotice(Notice _Noti)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE notice SET " +
                            "NoticeTitle = @NoticeTitle, NoticeContent = @NoticeContent " +
                            "WHERE NoticeNo = @NoticeNo";

                cmd.Parameters.Add("@NoticeTitle", MySqlDbType.VarChar, 50, "NoticeTitle");
                cmd.Parameters.Add("@NoticeNo", MySqlDbType.VarChar, 50, "NoticeNo");
                cmd.Parameters.Add("@NoticeContent", MySqlDbType.VarChar, 50, "NoticeContent");

                cmd.Parameters["@NoticeTitle"].Value = _Noti.NoticeTitle;
                cmd.Parameters["@NoticeNo"].Value = _Noti.NoticeNo;
                cmd.Parameters["@NoticeContent"].Value = _Noti.NoticeContent;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void DelNotice(Notice _Noti)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM notice  " +
                            "WHERE NoticeNo = @NoticeNo";

                cmd.Parameters.Add("@NoticeNo", MySqlDbType.VarChar, 50, "NoticeNo");
                cmd.Parameters["@NoticeNo"].Value = _Noti.NoticeNo;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public List<Notice> GetNotices()
        {
            List<Notice> repairhistorys = new List<Notice>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS (SELECT * FROM  notice) as success";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT noti.NoticeNo, noti.NoticeTitle, mem.memberName, noti.NoticeTime, noti.NoticeContent " +
                            "FROM notice AS noti " +
                            "LEFT JOIN member AS mem ON mem.memberId = noti.memberId";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Notice notice = new Notice();
                            notice.NoticeNo = (int)rdr[0];
                            notice.NoticeTitle = rdr[1].ToString();
                            notice.memberName = rdr[2].ToString();
                            notice.NoticeTime = rdr[3].ToString();
                            notice.NoticeContent = rdr[4].ToString();

                            repairhistorys.Add(notice);
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
            return repairhistorys;
        }
        public List<string[]> GetNoticesSys()
        {
            List<string[]> repairhistorys = new List<string[]>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS (SELECT * FROM  notice) as success";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM notice_sys";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string[] str = new string[5];

                            str[0] = rdr[0].ToString();
                            str[1] = rdr[1].ToString();
                            str[2] = rdr[2].ToString();
                            str[3] = rdr[3].ToString();
                            str[4] = rdr[4].ToString();



                            repairhistorys.Add(str);
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

            return repairhistorys;
        }
        #endregion

        #region 발주서
        public List<OrderDraft> GetOrderDarfts()
        {
            List<OrderDraft> repairhistorys = new List<OrderDraft>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS (SELECT * FROM  order_draft) as success";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM order_draft";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            OrderDraft orderDraft = new OrderDraft();

                            orderDraft.Orderdraftno = (int)rdr[0];
                            orderDraft.Orderdraftdate = rdr[1].ToString();
                            orderDraft.Orderdraftcustomer = rdr[2].ToString();
                            orderDraft.Orderdraftmemo = rdr[3].ToString();
                            orderDraft.OrderDraftCusMem = rdr[4].ToString();

                            repairhistorys.Add(orderDraft);
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

            return repairhistorys;
        }
        public List<OrderDraftList> OrderDraftLists(int no)
        {
            List<OrderDraftList> repairhistorys = new List<OrderDraftList>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT EXISTS (SELECT * FROM  order_draft_list where OrderDraftNo = @OrderDraftNo) as success";


                cmd.Parameters.Add("@OrderDraftNo", MySqlDbType.Int32, 11, "OrderDraftNo");
                cmd.Parameters["@OrderDraftNo"].Value = no;
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT * FROM order_draft_list where OrderDraftNo = @OrderDraftNo";
                        cmd.Parameters["@OrderDraftNo"].Value = no;

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            OrderDraftList orderDraftList = new OrderDraftList();

                            orderDraftList.Orderdraftno = (int)rdr[0];
                            orderDraftList.Orderdraftlistname = rdr[1].ToString();
                            orderDraftList.Orderdraftliststandard = rdr[2].ToString();
                            orderDraftList.Orderdraftlistcount = rdr[3].ToString();
                            orderDraftList.Orderdraftlistprice = rdr[4].ToString();
                            orderDraftList.Orderdraftlisttax = rdr[5].ToString();

                            repairhistorys.Add(orderDraftList);
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

            return repairhistorys;
        }
        #endregion
        #region KPI
        public List<Int64> GetSelectTime(DateTime value1, DateTime value2)
        {
            List<Int64> list = new List<Int64>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();


                cmd.Parameters.Add("@start", MySqlDbType.Datetime, 50, "start");
                cmd.Parameters.Add("@end", MySqlDbType.Datetime, 50, "end");

                try
                {
                    cmd.CommandText =
                        "SELECT TIMESTAMPDIFF(SECOND,wp.WorkProcessStartTime, wp.WorkProcessEndTime) FROM work_order AS wo  " +
                        "LEFT JOIN work_instruction AS wi ON wo.OrderNo = wi.OrderNo " +
                        "LEFT JOIN work_process AS wp ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                        "WHERE wo.orderDateEnd <= @end AND wo.orderDateEnd >= @start AND wi.workInstructionState = 3 ";

                    cmd.Parameters["@start"].Value = value1;
                    cmd.Parameters["@end"].Value = value2;

                    cmd.Connection = conn;
                    conn.Open();

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        list.Add((Int64)rdr[0]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        public double GetTotalCount(DateTime value1, DateTime value2)
        {
            double Count = 0;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = " SELECT count(*) FROM work_instruction AS wi " +
                                  " INNER JOIN work_process AS wp ON wi.WorkInstructionNo = wp.WorkInstructionNo " +
                                  " WHERE wp.WorkProcessEndTime <= @end AND wp.WorkProcessEndTime >= @start " +
                                  " AND(wi.workInstructionState = 3 OR wi.WorkInstructionState = 6) AND wp.WorkProcessEndTime IS NOT NULL ";

                cmd.Parameters.Add("@start", MySqlDbType.DateTime, 50, "start");
                cmd.Parameters.Add("@end", MySqlDbType.DateTime, 50, "end");

                cmd.Parameters["@start"].Value = value1;
                cmd.Parameters["@end"].Value = value2;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Count = Convert.ToDouble(rdr[0]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Count;
        }
        public double GetBadCount(DateTime value1, DateTime value2)
        {
            double Count = 0;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = " SELECT COUNT(*) FROM quality_management AS qm " +
                                  " INNER JOIN work_instruction AS wi ON qm.WorkInstructionNo = wi.WorkInstructionNo " +
                                  " INNER JOIN work_process AS wp ON qm.workProcessNo = wp.workProcessNo " +
                                  " WHERE wp.WorkProcessEndTime <= @end AND wp.WorkProcessEndTime >= @start " +
                                  " AND(wi.WorkInstructionState = 3 OR wi.WorkInstructionState = 6) " +
                                  " AND wp.WorkProcessStateName = '5'";


                cmd.Parameters.Add("@start", MySqlDbType.DateTime, 50, "start");
                cmd.Parameters.Add("@end", MySqlDbType.DateTime, 50, "end");

                cmd.Parameters["@start"].Value = value1;
                cmd.Parameters["@end"].Value = value2;

                try
                {
                    cmd.Connection = conn;
                    conn.Open();

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Count = Convert.ToDouble(rdr[0]); //2;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Count;
        }
        public bool NoticeCheck(string MachineName, string Time)
        {
            bool result = false;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = " SELECT EXISTS(SELECT noticeSysContent FROM notice_sys WHERE noticeSysContent " +
                                  " LIKE " + "'%" + MachineName + "%' AND noticeSysContent LIKE " + "'%" + Time + "%') AS success ";

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
        public List<int[]> GetOperationHour()
        {
            List<int[]> list = new List<int[]>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText =
                                    "select EXISTS (SELECT " +
                                    "HOUR(operation_hour.OperationHourTime), " +
                                    "MINUTE(operation_hour.OperationHourTime), " +
                                    "SECOND(operation_hour.OperationHourTime) " +
                                    "FROM operation_hour ORDER BY operation_hour.OperationHourStandard) as success";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText =
                                            "SELECT " +
                                            "HOUR(operation_hour.OperationHourTime), " +
                                            "MINUTE(operation_hour.OperationHourTime), " +
                                            "SECOND(operation_hour.OperationHourTime) " +
                                            "FROM operation_hour ORDER BY operation_hour.OperationHourStandard; ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            int[] str = new int[3];

                            str[0] = (int)rdr[0];
                            str[1] = (int)rdr[1];
                            str[2] = (int)rdr[2];

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
        public Int32 GetSelectOperationgTime(DateTime value1, DateTime value2)
        {
            Int32 result = 0;
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.Parameters.Add("@start", MySqlDbType.VarChar, 50, "start");
                cmd.Parameters.Add("@end", MySqlDbType.VarChar, 50, "end");

                cmd.CommandText =
                "SELECT SUM(operating_hour_log.OperatingHourLogCount) FROM operating_hour_log " +
                "WHERE " +
                "operating_hour_log.OperatingHourLogDate <= @end AND " +
                "operating_hour_log.OperatingHourLogDate >= @start AND " +
                "operating_hour_log.OperatingHourLogValue = 'Operation'; ";

                cmd.Parameters["@start"].Value = value1.ToString("yyyy-MM-dd");
                cmd.Parameters["@end"].Value = value2.ToString("yyyy-MM-dd");

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    Int32? check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != null) result = (Int32)check;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }
        public int GetSelectOperationgTimeMachineCnt()
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText =
                                    "SELECT COUNT(g.OperatingHourLogMachineName) FROM( " +
                                    "SELECT * FROM operating_hour_log GROUP BY operating_hour_log.OperatingHourLogMachineName) AS g ";
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int? check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != null)
                    {
                        return (int)check;
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 1;
                }
            }
        }
        #endregion
        #region LogInLog
        public List<DataVal> SelectParameter(string stert, string end, string user)
        {
            List<DataVal> Data = new List<DataVal>();
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress + "allow user variables=true;"))
            {
                if (user == "전체 조회")
                {
                    user_str = "where";
                }
                else user_str = "where MemberId =" + "'" + user + "'" + " and";

                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandText = "select * from member_log ml " +
                                      user_str +
                                      " date_format(LoginLogTime, '%Y-%m-%d') >= " + "'" + stert + "'" +
                                      " and date_format(LoginLogTime, '%Y-%m-%d') <= " + "'" + end + "'";
                    cmd.Connection = conn;
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        DataVal Myval = new DataVal();

                        Myval.No = rdr[0].ToString();
                        Myval.User = rdr[1].ToString();
                        Myval.LogTime = rdr[2].ToString();
                        Myval.InOut = rdr[3].ToString();
                        Myval.IP = rdr[4].ToString();
                        Data.Add(Myval);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Data;
        }
        #endregion
    }
}