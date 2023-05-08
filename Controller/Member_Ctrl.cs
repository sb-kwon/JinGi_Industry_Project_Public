using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Model;

namespace Controller
{
    public class Member_Ctrl
    {
        //Locat Value
        //----------------------------------------------------------
        DBMain database = DBMain.Instance;
        private Member _MMB;
        private List<Member> _LMMB;

        //----------------------------------------------------------
        //init
        //----------------------------------------------------------
        public Member_Ctrl()
        {
        }
        public Member Member
        {
            get { return _MMB; }
            set { _MMB = value; }
        }
        public List<Member> Members
        {
            get { return _LMMB; }
            set { _LMMB = value; }
        }
        public void GetMember()
        {
            List<Member> members = new List<Member>();
            _LMMB = database.DBMember.GetMember();

            if (members is null)
                _LMMB = new List<Member>();
        }

        public void DeleteMembere(string memberId)
        {
            database.DBMember.DeleteMember(memberId);
        }
        public void InsertMember(Member member)
        {

            //= member.Membername;
            //= member.Rankname;
            //= member.Memberid;
            //= member.Membernumber;
            database.DBMember.InsertMember(member);

        }
        public void UpdateMember(Member member)
        {
            database.DBMember.UpdateMember(member);
        }
        public void RefreshCount(Member member)
        {
            database.DBMember.RefreshCount(member);
        }
        public List<Member> SearchData(string result, string str)
        {
            return database.DBMember.SearchData(result, str);
        }
        public Member FindMember(int no)
        {
            return database.DBMember.SearchOneData(no);
        }
    }
}