using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBase;
using Model;
using System.Threading.Tasks;

namespace Controller
{
    public class AuthorityC
    {
        private DBMain dataBase = DBMain.Instance;
        private List<MemberAccess> _MA;

        public AuthorityC()
        {
        }
        public List<MemberAccess> MemberAccess
        {
            get { return _MA; }
            set { _MA = value; }
        }
        public void GetAuthorityList()
        {
            List<MemberAccess> MA = new List<MemberAccess>();
            _MA = dataBase.DBAthority.GetAuthorityList();

            if (MA is null)
                _MA = new List<MemberAccess>();
        }
        public bool GetAuthority(string AuthorityName, string Location)
        {
            return dataBase.DBAthority.GetAuthority(AuthorityName, Location);
        }
        public List<MemberAccess> AuthorityCheck()
        {
            return dataBase.DBMember.AuthorityCheck();
        }
        public List<MemberAccess> AuthorityCheck2()
        {
            return dataBase.DBMember.AuthorityCheck2();
        }
        public void InDelAuthority(List<MemberAccess> InsertList, List<MemberAccess> DeleteList)
        {
            dataBase.DBAthority.InsertAuthority(InsertList);
            dataBase.DBAthority.DeleteAuthority(DeleteList);

        }
    }
}
