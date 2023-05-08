using DataBase;
using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class NoticeCtrl
    {
        private DBMain dataBase = DBMain.Instance;

        public NoticeCtrl() 
        {

        }
        #region 공지사항
        public List<Notice> GetNotices()
        {
            return dataBase.DBNotice.GetNotices();
        }
        public List<string[]> GetNoticesSys()
        {
            return dataBase.DBNotice.GetNoticesSys();
        }
        public void ModifyNotice(Notice _Noti)
        {
            dataBase.DBNotice.ModifyNotice(_Noti);
        }
        public void AddNotice(Notice _Noti)
        {
            dataBase.DBNotice.AddNotice(_Noti);
        }
        public void AddNoticeSys(string Type, string Title, string Content)
        {
            dataBase.DBNotice.AddNoticeSys(Type, Title, Content);
        }
        public void DelNotice(Notice _Noti)
        {
            dataBase.DBNotice.DelNotice(_Noti);
        }
        public List<Notice> NoticesSearch(string result, string value)
        {
            return dataBase.DBNotice.NoticesSearch(result, value);
        }
        public List<string> NoticeSysTitleList()
        {
            return dataBase.DBNotice.NoticeSysTitleList();
        }
        public Int64 GetSelectTime(DateTime value1, DateTime value2)
        {
            List<Int64> list = dataBase.DBNotice.GetSelectTime(value1, value2);

            Int64 result = 0;

            foreach (Int64 i in list)
            {
                result += i;
            }
            if (result != 0)
                result = result / list.Count;

            return result;
        }
        public double GetTotalCount(DateTime value1, DateTime value2)
        {
            //TimeSpan DateDiff = value2 - value1;
            //int LabelCount = dataBase.DBNotice.GetTotalCount(value1, value2);
            //if (DateDiff.Hours > 1)
            //{
            //    int TotalLabelCount = LabelCount / DateDiff.Hours;
            //
            //    return TotalLabelCount;
            //}
            //else return dataBase.DBNotice.GetTotalCount(value1, value2);
            return dataBase.DBNotice.GetTotalCount(value1, value2) * 2;
        }
        public double GetBadCount(DateTime value1, DateTime value2)
        {
            return dataBase.DBNotice.GetBadCount(value1, value2);
            //TimeSpan DateDiff = value2 - value1;
            //if (DateDiff.Hours > 1)
            //{
            //    int LabelCount = dataBase.DBNotice.GetBadCount(value1, value2);
            //    int TotalLabelCount = LabelCount / DateDiff.Hours;
            //
            //    return TotalLabelCount;
            //}
            //return dataBase.DBNotice.GetBadCount(value1, value2);
        }
        public bool NoticeCheck(string MachineName, string Time)
        {
            return dataBase.DBNotice.NoticeCheck(MachineName, Time);
        }
        #endregion
        #region KPI
        public List<int[]> GetOperationHour()
        {
            return dataBase.DBNotice.GetOperationHour();
        }
        public int GetRunningTime(DateTime value1, DateTime value2)
        {
            Int32 _SumRunningTime = dataBase.DBNotice.GetSelectOperationgTime(value1, value2);  //총 데이터 수집 Sum
            int _MachineCnt = dataBase.DBNotice.GetSelectOperationgTimeMachineCnt();

            int result = _SumRunningTime / _MachineCnt;
            TimeSpan DateDff = value2 - value1;  //da
            int _days = DateDff.Days + 1;
            result = result / _days;
            return result;
        }
        #endregion
        #region LogInLog
        public List<DataVal> SelectParameter(String A, String B, String C)
        {
            return dataBase.DBNotice.SelectParameter(A, B, C);
        }
        public void InsertLog(String MemberId, String Type)
        {
            dataBase.DBAthority.LoginLogListAdd(MemberId, Type);
        }
        #endregion
    }
}