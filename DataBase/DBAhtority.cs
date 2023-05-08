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
	public class DBAthority
	{
		private DBMain _DBMain;
		public DBAthority(DBMain dBMain)
		{
			_DBMain = dBMain;
		}
		public bool GetAuthority(string AuthorityName, string Location)
		{
			bool result = false;
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = " SELECT EXISTS( " +
								  " SELECT ai.AuthorityName, ai.AuthorityLocation FROM member_access AS ma " +
								  " LEFT JOIN authority_item AS ai ON ai.AuthorityName = ma.AuthorityName " +
								  " WHERE ai.AuthorityName = @Authorityname AND ai.AuthorityLocation = @AuthorityLocation) AS success ";

				cmd.Parameters.Add("@Authorityname", MySqlDbType.VarChar, 50, "Authorityname");
				cmd.Parameters.Add("@AuthorityLocation", MySqlDbType.VarChar, 50, "AuthorityLocation");

				cmd.Parameters["@Authorityname"].Value = AuthorityName;
				cmd.Parameters["@AuthorityLocation"].Value = Location;

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

		public void DeleteAuthority(List<MemberAccess> DeleteList)
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
					cmd.Parameters.Add("@AuthorityName", MySqlDbType.VarChar, 50, "AuthorityName");
					cmd.Parameters.Add("@AuthorityLocation", MySqlDbType.VarChar, 50, "AuthorityLocation");
					foreach (MemberAccess MA in DeleteList)
					{
						cmd.CommandText = "DELETE FROM authority_item WHERE AuthorityName = @AuthorityName AND AuthorityLocation = @AuthorityLocation";

						cmd.Parameters["@AuthorityName"].Value = MA.Authorityname;
						cmd.Parameters["@AuthorityLocation"].Value = MA.AuthorityLocation;
						cmd.Connection = conn;

						if (conn.State == ConnectionState.Open) conn.Close();
						conn.Open();

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
			}//using
		}

		public List<string> GetAuthority()
		{
			List<string> list = new List<string>();
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT def_authority_main.AuthorityName FROM def_authority_main";
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

		public void InsertAuthority(List<MemberAccess> insertList)
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
					cmd.Parameters.Add("@AuthorityName", MySqlDbType.VarChar, 50, "AuthorityName");
					cmd.Parameters.Add("@AuthorityLocation", MySqlDbType.VarChar, 50, "AuthorityLocation");

					foreach (MemberAccess MA in insertList)
					{
						cmd.CommandText = "INSERT INTO authority_item(AuthorityName, AuthorityLocation) SELECT @AuthorityName, @AuthorityLocation " +
										  "FROM DUAL WHERE NOT EXISTS(SELECT * FROM authority_item WHERE AuthorityName = @AuthorityName " +
										  "AND AuthorityLocation = @AuthorityLocation)";

						cmd.Parameters["@AuthorityName"].Value = MA.Authorityname;
						cmd.Parameters["@AuthorityLocation"].Value = MA.AuthorityLocation;

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

		public List<MemberAccess> GetAuthorityList()
		{
			List<MemberAccess> MA = new List<MemberAccess>();

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
						cmd.CommandText = " SELECT def_authority_main.AuthorityName, " +
										  " GROUP_CONCAT(DISTINCT authority_item.AuthorityLocation SEPARATOR ', ') " +
										  " FROM def_authority_main LEFT JOIN authority_item " +
										  " ON def_authority_main.AuthorityName = authority_item.AuthorityName " +
										  " GROUP BY def_authority_main.AuthorityName";

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							MemberAccess ma = new MemberAccess();

							ma.Authorityname = rdr[0].ToString();
							ma.AuthorityLocation = rdr[1].ToString();

							MA.Add(ma);
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
			return MA;
		}

		/// <summary>
		/// 아이디 유무 확인 retrun Member
		/// </summary>
		/// <param name="id"> 확인할 ID </param>
		/// <returns></returns>
		public Member MemberExists(string memberId)
		{
			Member member = new Member();

			if (MemberExistsBool(memberId))
			{
				using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
				{
					MySqlCommand cmd = new MySqlCommand();

					cmd.CommandText = " SELECT m.memberId, ma.memberPwFailCnt, ma.memberLPCT, ma.Authorityname, m.Rankname, m.membername FROM " +
									  " member AS m LEFT JOIN member_access AS ma " +
									  " ON m.memberId = ma.memberId " +
									  " WHERE m.memberId = @memberId ";

					cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
					cmd.Parameters["@memberId"].Value = memberId;
					try
					{
						cmd.Connection = conn;
						conn.Open();

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							//로그인에 사용
							member.Memberid = rdr[0].ToString();
							member.MemberAccess.Memberpwfailcnt = (int)rdr[1];
							member.MemberAccess.Memberlpct = rdr[2].ToString();
							//로그 정보에 이용할 애기들
							member.MemberAccess.Authorityname = rdr[3].ToString();
							member.Rankname = rdr[4].ToString();
							member.Membername = rdr[5].ToString();

						}

					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						member = null;
					}
				}
			}
			return member;
		}/// <summary>
		 /// 아이디 유무 확인 retrun Member
		 /// </summary>
		 /// <param name="id"> 확인할 ID </param>
		 /// <returns></returns>
		public bool MemberExistsBool(string memberId)
		{
			bool result = false;
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "select EXISTS (SELECT * FROM Member WHERE memberId = @memberId) as success";

				cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
				cmd.Parameters["@memberId"].Value = memberId;
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

		public Member LastPwCheck(Member member)
		{
			if (MemberExistsBool(member.Memberid))
			{
				using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
				{
					MySqlCommand cmd = new MySqlCommand();

					cmd.CommandText = "SELECT AES_DECRYPT(UNHEX(memberPw), 'K') AS memberPw " +
									"FROM Member WHERE memberId = @memberId ";
					//SELECT cast(AES_DECRYPT(UNHEX(memberPw), 'K') as char(100)) FROM member where MemberId='admin' 복호화
					cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
					cmd.Parameters["@memberId"].Value = member.Memberid;
					try
					{
						cmd.Connection = conn;
						conn.Open();

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							//비밀번호 체크
							member.Memberpw = Encoding.Default.GetString((byte[])rdr[0]);
						}

					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						member = null;
					}
				}
			}
			return member;
		}

		public void UserPwChange(Member member)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "UPDATE member SET " +
								  "Memberpw = hex(AES_ENCRYPT(@Memberpw, 'K')) " +
								  "WHERE memberId = @memberId ";

				cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
				cmd.Parameters.Add("@Memberpw", MySqlDbType.VarChar, 50, "Memberpw");

				cmd.Parameters["@memberId"].Value = member.Memberid;
				cmd.Parameters["@Memberpw"].Value = member.Memberpw;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}

		public void LastPwSave(Member member, string lastpw)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "UPDATE member_access SET " +
								  "memberLastpw = hex(AES_ENCRYPT(@memberLastpw, @Key)), memberLPCT = NOW() " +
								  "WHERE Memberid = @Memberid ";

				cmd.Parameters.Add("@Memberid", MySqlDbType.VarChar, 50, "Memberid");
				cmd.Parameters.Add("@memberLastpw", MySqlDbType.VarChar, 50, "memberLastpw");
				cmd.Parameters.Add("@Key", MySqlDbType.VarChar, 50, "Key");

				cmd.Parameters["@Memberid"].Value = member.Memberid;
				cmd.Parameters["@memberLastpw"].Value = lastpw;
				cmd.Parameters["@Key"].Value = "K";

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// 아이디 비밀번호 확인
		/// </summary>
		/// <param name="id"> 확인할 ID </param>
		/// <param name="pw"> 확인할 PW </param>
		/// <returns></returns>
		public bool LoginCheck(string id, string pw)
		{
			bool result = false;
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT EXISTS (SELECT * FROM Member WHERE memberId = @memberId AND binary memberPw = hex(AES_ENCRYPT(@memberPw, 'K'))) as success";

				cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
				cmd.Parameters.Add("@memberPw", MySqlDbType.VarChar, 50, "memberPw");

				cmd.Parameters["@memberId"].Value = id;
				cmd.Parameters["@memberPw"].Value = pw;

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
		/// <summary>
		/// 비밀번호 틀렸을때 카운트값 올라가기
		/// </summary>
		/// <param name="member"></param>
		/// <param name="Check"></param>
		public void SetCnt(Member member, bool Check)
		{
			int value = 1;

			if (!Check) value = member.MemberAccess.Memberpwfailcnt + 1;
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "UPDATE member_access SET " +
								  "memberPwFailCnt = @memberPwFailCnt " +
								  "WHERE  memberId = @memberId ";

				cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
				cmd.Parameters.Add("@memberPwFailCnt", MySqlDbType.VarChar, 50, "memberPwFailCnt");
				cmd.Parameters["@memberId"].Value = member.Memberid;
				cmd.Parameters["@memberPwFailCnt"].Value = value;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}
		/// <summary>
		/// 계정 비활성화
		/// </summary>
		/// <param name="id"> 비활성화 할 ID </param>
		public void MemberAuthorityChange(string id)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "UPDATE member_Access SET"
								+ " authorityName = 'Disable'"
								+ " WHERE memberId = @memberId;";

				cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
				cmd.Parameters["@memberId"].Value = id;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}
		/// <summary>
		/// 접속 이력 관리
		/// </summary>
		/// <param name="id"> 로그기록될 ID </param>
		/// <param name="type"> 로그 기록명 </param>
		public void LoginLogListAdd(string id, string type)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "INSERT INTO member_log " +
									"(member_log.LoginLogTime, member_log.memberId, member_log.LogData) " +
									"VALUES(NOW(), @memberId, @type);";

				cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
				cmd.Parameters.Add("@type", MySqlDbType.VarChar, 50, "type");
				cmd.Parameters["@memberId"].Value = id;
				cmd.Parameters["@type"].Value = type;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}
		/// <summary>
		/// 권한 접근 가능 유무
		/// </summary>
		/// <param name="authorityLocation"> 위치값 </param>
		/// <param name="authorityName"> 사용자 권한 </param>
		/// <returns></returns>
		public bool CheckAuthority(string authorityLocation, string authorityName)
		{
			bool result = false;
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = "SELECT EXISTS(SELECT * FROM authority_item " +
									"			    WHERE " +
									"			    authority_item.authorityName = @authorityName AND " +
									"			    authority_item.authorityLocation = @authorityLocation) AS success ";

				cmd.Parameters.Add("@authorityLocation", MySqlDbType.VarChar, 50, "authorityLocation");
				cmd.Parameters.Add("@authorityName", MySqlDbType.VarChar, 50, "authorityName");
				cmd.Parameters["@authorityLocation"].Value = authorityLocation;
				cmd.Parameters["@authorityName"].Value = authorityName;

				try
				{
					cmd.Connection = conn;
					conn.Open();

					MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						if ((int)rdr[0] == 0) result = false;
						else result = true;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return result;
		}



		//가입 insert
		/// <summary>
		/// Insert Member
		/// </summary>
		/// <param name="member"></param>
		public void InsertMember(Member member)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "INSERT INTO MEMBER(memberId, memberPw, rankname, memberName, MemberNumber) "
				   + "VALUES(@memberId, hex(AES_ENCRYPT(@memberPw, @key)), @rankname, @memberName, @MemberNumber)";

				cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
				cmd.Parameters.Add("@memberPw", MySqlDbType.VarChar, 50, "memberPw");
				cmd.Parameters.Add("@key", MySqlDbType.VarChar, 50, "key");
				cmd.Parameters.Add("@rankname", MySqlDbType.VarChar, 50, "rankname");
				cmd.Parameters.Add("@memberName", MySqlDbType.VarChar, 50, "memberName");
				cmd.Parameters.Add("@MemberNumber", MySqlDbType.VarChar, 50, "MemberNumber");

				cmd.Parameters["@memberId"].Value = member.Memberid;
				cmd.Parameters["@memberPw"].Value = member.Memberpw;
				cmd.Parameters["@key"].Value = 'K';
				cmd.Parameters["@rankname"].Value = member.Rankname;
				cmd.Parameters["@memberName"].Value = member.Membername;
				cmd.Parameters["@MemberNumber"].Value = member.Membernumber;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
		}
		/// <summary>
		///  Insert Member_Access
		/// </summary>
		/// <param name="member"></param>
		public void InsertMember_Access(Member member)
		{
			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandType = CommandType.Text;

				cmd.CommandText = "INSERT INTO member_access(memberId, memberLastpw, authorityName, memberLPCT) "
				   + "VALUES(@memberId, hex(AES_ENCRYPT(@memberPw, @key)), @authorityName, @memberLPCT)";

				cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
				cmd.Parameters.Add("@memberPw", MySqlDbType.VarChar, 50, "memberPw");
				cmd.Parameters.Add("@key", MySqlDbType.VarChar, 50, "key");
				cmd.Parameters.Add("@authorityName", MySqlDbType.VarChar, 50, "authorityName");
				cmd.Parameters.Add("@memberLPCT", MySqlDbType.VarChar, 50, "memberLPCT");

				cmd.Parameters["@memberId"].Value = member.Memberid;
				cmd.Parameters["@memberPw"].Value = member.Memberpw;
				cmd.Parameters["@key"].Value = 'K';
				cmd.Parameters["@authorityName"].Value = member.MemberAccess.Authorityname;
				cmd.Parameters["@memberLPCT"].Value = member.MemberAccess.Memberlpct;

				cmd.Connection = conn;

				if (conn.State == ConnectionState.Open) conn.Close();
				conn.Open();

				cmd.ExecuteNonQuery();
			}
			InsertMember(member);
			LoginLogListAdd(member.Memberid, "SignUp");
		}
		public List<Member> FindLog(Member Log)
		{
			List<Member> MA = new List<Member>();

			using (MySqlConnection conn = new MySqlConnection(_DBMain.ServerAddress))
			{

				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = " SELECT EXISTS(SELECT * FROM member_log WHERE memberid = 'admin' ORDER BY loginlogtime DESC LIMIT 1 ) AS success ";

				try
				{
					cmd.Connection = conn;
					conn.Open();
					int check = Convert.ToInt32(cmd.ExecuteScalar());

					if (check != 0)
					{
						cmd.CommandText = " SELECT * FROM member_log WHERE memberid = @memberId ORDER BY loginlogtime DESC LIMIT 1 ";

						cmd.Parameters.Add("@memberId", MySqlDbType.VarChar, 50, "memberId");
						cmd.Parameters["@memberId"].Value = Log.Memberid;

						cmd.Connection = conn;

						MySqlDataReader rdr = cmd.ExecuteReader();

						while (rdr.Read())
						{
							Log.Memberid = rdr[1].ToString();
							Log.MemberAccess.MemberLogInLogTime = rdr[2].ToString();
							Log.MemberAccess.MemberLogData = rdr[3].ToString();

							MA.Add(Log);
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
			return MA;
		}
	}
}
