namespace Model
{
    public class Member
    {
        private string _MemberId;
        public Member()
        {
            MemberAccess MA = new MemberAccess();
            MemberAccess = MA;
        }
        //멤버 권한
        public MemberAccess MemberAccess { get; set; }
        // 멤버 아이디 
        public string Memberid
        {
            get
            {
                return this.MemberAccess.Memberid;
            }
            set
            {
                _MemberId = value;
                this.MemberAccess.Memberid = _MemberId;
            }
        }
        //멤버 고유번호
        public int MemberNo { get; set; }
        // 멤버 비밀번호 
        public string Memberpw { get; set; }
        // 직급 명 
        public string Rankname { get; set; }
        // 멤버 번호 
        public string Membernumber { get; set; }
        // 멤버 명 
        public string Membername { get; set; }
        public string MemberAddress { get; set; }
        public string MemberBirth { get; set; }
        public string MemberJoinDate { get; set; }
        public string MemberETC { get; set; }
    }
}