namespace Model
{
	public class MemberAccess
	{
		// 멤버 아이디 
		public string Memberid { get; set; }
		// 마지막 비밀번호 
		public string Memberlastpw { get; set; }
		// 권한 명 
		public string Authorityname { get; set; }
		public string AuthorityLocation { get; set; }
		// 마지막로그인시간 
		public string Memberlpct { get; set; }
		// 비밀번호 횟수 
		public int Memberpwfailcnt { get; set; }
		// LogInLog Time
		public string MemberLogInLogTime { get; set; }
		// LogInLog Data
		public string MemberLogData { get; set; }
	}
}
