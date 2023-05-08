using DataBase;
using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
	public class DocumentCtrl
	{
		DBMain database = DBMain.Instance;

		public DocumentCtrl(){}

		public void SetData()
		{
			OrderDrafts = GetOrderDarfts();
		}
		public List<OrderDraft> OrderDrafts { get; set; }

		#region 발주서
		public List<OrderDraft> GetOrderDarfts()
		{
			List<OrderDraft> list = new List<OrderDraft>();
			list = database.DBNotice.GetOrderDarfts();

			if(list != null)
				foreach (OrderDraft od in list) od.OrderDraftLists = database.DBNotice.OrderDraftLists(od.Orderdraftno);

			return list;
		}

		public void InsertOrderDraft(OrderDraft od)
		{
			int no = database.DBNotice.InsertOrderDraft(od);
			database.DBNotice.InsertOrderDraftList(od.OrderDraftLists, no - 1);
		}

		public void UpdateOrderDraftList(OrderDraft od)
		{
			database.DBNotice.DeleteOrderDraftList(od.Orderdraftno);
			database.DBNotice.InsertOrderDraftList(od.OrderDraftLists, od.Orderdraftno);
		}
		#endregion
	}
}
