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
    public class DBMember
    {
        private DBMain _DBMain;
        public DBMember(DBMain dBMain)
        {
            _DBMain = dBMain;
        }
        public Member SearchOneData(int no)
        {


            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM member";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT  MemberNo, MemberName, MemberId " +
                                          "FROM Member  WHERE MemberNo = @MemberNo";

                        cmd.Parameters.Add("@MemberNo", MySqlDbType.Int32, 11, "MemberNo");
                        cmd.Parameters["@MemberNo"].Value = no;

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Member member = new Member();

                            member.MemberNo = (int)rdr[0];
                            member.Membername = rdr[1].ToString();
                            member.Memberid = rdr[2].ToString();

                            return member;
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
            return null;

        }
        public List<Member> GetMember()
        {
            List<Member> members = new List<Member>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM Member";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT M.MemberNo, M.MemberName, M.MemberId, M.MemberNumber, M.RankName, M.MemberAddress, " +
                                          " M.MemberBirth, M.MemberJoinDate, M.MemberETC, MA.AuthorityName " +
                                          " FROM Member AS M LEFT JOIN member_access AS MA ON MA.MemberId = M.memberId ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Member member = new Member();

                            member.MemberNo = (int)rdr[0];
                            member.Membername = rdr[1].ToString();
                            member.Memberid = rdr[2].ToString();
                            member.Membernumber = rdr[3].ToString();
                            member.Rankname = rdr[4].ToString();
                            member.MemberAddress = rdr[5].ToString();
                            member.MemberBirth = rdr[6].ToString();
                            member.MemberJoinDate = rdr[7].ToString();
                            member.MemberETC = rdr[8].ToString();
                            member.MemberAccess.Authorityname = rdr[9].ToString();
                            members.Add(member);
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
            return members;
        }
        public List<MemberAccess> AuthorityCheck()
        {
            List<MemberAccess> MemberA = new List<MemberAccess>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM def_authority_list";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT * FROM def_authority_list ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            MemberAccess members = new MemberAccess();

                            members.AuthorityLocation = rdr[0].ToString();

                            MemberA.Add(members);
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
            return MemberA;
        }
        public List<MemberAccess> AuthorityCheck2()
        {
            List<MemberAccess> MemberA = new List<MemberAccess>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM authority_item";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = " SELECT authority_item.AuthorityName, def_authority_list.AuthorityLocation " +
                                          " FROM authority_item RIGHT JOIN def_authority_list " +
                                          " ON authority_item.AuthorityLocation = def_authority_list.AuthorityLocation ";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            MemberAccess members = new MemberAccess();

                            members.Authorityname = rdr[0].ToString();
                            members.AuthorityLocation = rdr[1].ToString();

                            MemberA.Add(members);
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
            return MemberA;
        }

        public List<Member> SearchData(string result, string str)
        {
            List<Member> members = new List<Member>();

            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT count(*) FROM member";

                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int check = Convert.ToInt32(cmd.ExecuteScalar());

                    if (check != 0)
                    {
                        cmd.CommandText = "SELECT  M.MemberNo, M.MemberName, M.MemberID, M.MemberNumber, M.RankName, M.MemberAddress, M.MemberBirth, M.MemberJoinDate, M.MemberETC, MA.AuthorityName " +
                                          "FROM Member AS M LEFT JOIN member_access AS MA ON MA.MemberId = M.memberId WHERE " + result + " LIKE " + "'%" + str + "%'";

                        cmd.Connection = conn;

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Member member = new Member();

                            member.MemberNo = (int)rdr[0];
                            member.Membername = rdr[1].ToString();
                            member.Memberid = rdr[2].ToString();
                            member.Membernumber = rdr[3].ToString();
                            member.Rankname = rdr[4].ToString();
                            member.MemberAddress = rdr[5].ToString();
                            member.MemberBirth = rdr[6].ToString();
                            member.MemberJoinDate = rdr[7].ToString();
                            member.MemberETC = rdr[8].ToString();
                            member.MemberAccess.Authorityname = rdr[9].ToString();

                            members.Add(member);
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
            return members;
        }

        public void UpdateMember(Member member)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE member M INNER JOIN member_access MA ON M.MemberId = MA.MemberId SET M.RankName = @RankName, " +
                                  "M.memberNumber = @memberNumber, M.memberName = @memberName, MA.AuthorityName = @AuthorityName, " +
                                  "M.MemberAddress = @MemberAddress, M.MemberBirth = @MemberBirth, M.MemberJoinDate = @MemberJoinDate, M.MemberETC = @MemberETC,  " +
                                  "MA.MemberPwFailCnt = @MemberPwFailCnt WHERE M.memberId = @memberId";

                cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
                cmd.Parameters.Add("@RankName", MySqlDbType.VarChar, 50, "RankName");
                cmd.Parameters.Add("@MemberETC", MySqlDbType.VarChar, 50, "MemberETC");
                cmd.Parameters.Add("@MemberJoinDate", MySqlDbType.VarChar, 50, "MemberJoinDate");
                cmd.Parameters.Add("@MemberBirth", MySqlDbType.VarChar, 50, "MemberBirth");
                cmd.Parameters.Add("@MemberAddress", MySqlDbType.VarChar, 50, "MemberAddress");
                cmd.Parameters.Add("@memberNumber", MySqlDbType.VarChar, 50, "memberNumber");
                cmd.Parameters.Add("@memberName", MySqlDbType.VarChar, 50, "memberName");
                cmd.Parameters.Add("@AuthorityName", MySqlDbType.VarChar, 50, "AuthorityName");
                cmd.Parameters.Add("@MemberPwFailCnt", MySqlDbType.VarChar, 50, "MemberPwFailCnt");

                cmd.Parameters["@memberId"].Value = member.Memberid;
                cmd.Parameters["@RankName"].Value = member.Rankname;
                cmd.Parameters["@MemberAddress"].Value = member.MemberAddress;
                cmd.Parameters["@MemberBirth"].Value = member.MemberBirth;
                cmd.Parameters["@MemberJoinDate"].Value = member.MemberJoinDate;
                cmd.Parameters["@MemberETC"].Value = member.MemberETC;
                cmd.Parameters["@memberNumber"].Value = member.Membernumber;
                cmd.Parameters["@memberName"].Value = member.Membername;
                cmd.Parameters["@AuthorityName"].Value = member.MemberAccess.Authorityname;
                cmd.Parameters["@MemberPwFailCnt"].Value = member.MemberAccess.Memberpwfailcnt;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public void RefreshCount(Member member)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " UPDATE member_access SET MemberPwFailCnt = @MemberPwFailCnt " +
                                  " WHERE memberId = @memberId";

                cmd.Parameters.Add("@MemberPwFailCnt", MySqlDbType.VarChar, 50, "MemberPwFailCnt");
                cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");

                cmd.Parameters["@MemberPwFailCnt"].Value = member.MemberAccess.Memberpwfailcnt;
                cmd.Parameters["@memberId"].Value = member.Memberid;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public void DeleteMember(string memberId)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM Member WHERE memberId = @memberId";
                cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
                cmd.Parameters["@memberId"].Value = memberId;

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

        public Member InsertMember(Member member)
        {
            using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO MEMBER(Membername, Rankname, Memberid, Membernumber) "
                   + "VALUES(@Membername, @Rankname, @Memberid, @Membernumber)";


                cmd.Parameters.Add("@Membername", MySqlDbType.VarChar, 50, "Membername");
                cmd.Parameters.Add("@Rankname", MySqlDbType.VarChar, 50, "Rankname");
                cmd.Parameters.Add("@Memberid", MySqlDbType.VarChar, 50, "Memberid");
                cmd.Parameters.Add("@Membernumber", MySqlDbType.VarChar, 50, "Membernumber");

                cmd.Parameters["@Membername"].Value = member.Membername;
                cmd.Parameters["@Rankname"].Value = member.Rankname;
                cmd.Parameters["@Memberid"].Value = member.Memberid;
                cmd.Parameters["@Membernumber"].Value = member.Membernumber;

                cmd.Connection = conn;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                cmd.ExecuteNonQuery();


                return member;

            }//using
        }
    }
}