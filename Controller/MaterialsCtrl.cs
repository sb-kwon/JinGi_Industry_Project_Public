using DataBase;
using Model;
using Model.Material;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Controller
{
	public class MaterialsCtrl
	{
		private DBMain _Database = DBMain.Instance;
		#region GetterSetter
		private List<Materials> _Materials;
		public List<Materials> Materials
		{
			get
			{
				return _Materials;
			}
			set
			{
				_Materials = value;
			}
		}
		private List<string> _Locations;
		public List<string> Locations
		{
			get
			{
				return _Locations;
			}
			set
			{
				_Locations = value;
			}
		}
		private List<string> _Types;
		public List<string> Types
		{
			get
			{
				return _Types;
			}
			set
			{
				_Types = value;
			}
		}
		private List<MaterialsSemi> _Semis;
		public List<MaterialsSemi> Semis
		{
			get
			{
				return SemisMaterials(_Semis);
			}
			set
			{
				_Semis = value;

			}
		}
		private List<MaterialsSemi> SemisMaterials(List<MaterialsSemi> list)
		{
			if (list != null)
			{
				foreach (MaterialsSemi ms in list)
				{
					ms.Materialssemivalue2 = _Database.DBMaterials.GetSemiMaterials(ms.Materialssemivalue);
				}
			}
			return list;
		}

		public List<String[]> Material_Action { get; set; }
		// 0	번호
		// 1	날짜
		// 2	거래처
		// 3	타입(입고, 출고)
		// 4	위치
		// 5	자재번호
		// 6	자재명
		// 7	변경 수량
		// 8	현재 수량
		// 9	단가
		// 10	비고
		#endregion
		public MaterialsCtrl()
		{
			SetMaterials();
		}

		#region SetDate
		public void SetMaterials()
		{
			Materials = _Database.DBMaterials.GetMaterials();
			Locations = _Database.DBMaterials.GetLocations();
			Types = _Database.DBMaterials.GetTypes();
			Material_Action = _Database.DBMaterials.GetMaterial_Actions();
			Semis = _Database.DBMaterials.GetSemis();
		}

		public bool InsertData(string dateType, string text)
		{
			bool check = _Database.DBMaterials.InsertDefData(dateType, text);
			SetMaterials();

			return check;
		}

		public List<string[]> Material_Action_Location()
		{
			return _Database.DBMaterials.Material_Action_Location();
		}

		public bool UpdateData(string dateType, string text1, string text2)
		{
			bool check = _Database.DBMaterials.UpdateData(dateType, text1, text2);
			SetMaterials();
			return check;
		}

		public void DeleteData(string dateType, string text)
		{
			_Database.DBMaterials.DeleteData(dateType, text);
			SetMaterials();
		}

		public bool FindMaterialName(string materialsName)
		{
			return _Database.DBMaterials.FindMaterialName(materialsName);
		}

		public bool WarehousingUseCheck(int no, string location, int cnt)
		{
			return _Database.DBMaterials.WarehousingUseCheck(no, location, cnt);
		}

		public void InsertMaterial(Materials mtr, bool check)
		{
			int no = _Database.DBMaterials.InsertMaterial(mtr, check);
			//materials_site 에 미지정으로 추가 할것

			if (no != 0)
			{
				_Database.DBMaterials.InsertOrUpdateSiteData(no, null, mtr.MaterialsCount);
				_Database.DBMaterials.InsertMaterialsAction(mtr, no);
				_Database.DBMaterials.MaterialsWearingUpdate(mtr, no);
			}
		}

		public void Realsing(int no, string locaion, int count, string memo)
		{
			Materials_Action ma = new Materials_Action();

			ma.WarehousingDate = DateTime.Now;
			ma.WarehousingType = "출고";
			ma.MaterialsLocation = locaion;
			ma.ProductNo = no;
			ma.WarehousingCount = count * -1;  //
			ma.WarehousingMemo = memo;

			//창고 물건 빼고 총수량 빼고 출고 이력  

			Materials mtr = new Materials();
			mtr.MaterialsNo = no;
			mtr.MaterialsCount = count * -1;

			_Database.DBMaterials.insertIOWarehousing(ma);  //입출고 내역
			_Database.DBMaterials.MaterialsRealsingUpdate(mtr, no); //기존 자재 총 수량, 평균 단가 변경

			_Database.DBMaterials.InsertOrUpdateSiteData(no, locaion, count * -1);
		}

		public List<string[]> GetAssemble(int productNo)
		{
			List<string[]> result1 = new List<string[]>();
			List<string[]> result2 = new List<string[]>();
			List<string[]> result = new List<string[]>();
			result1 = _Database.DBMaterials.GetAssembleSemi(productNo, true);
			result2 = _Database.DBMaterials.GetAssembleSemi(productNo, false);

			if (result1 != null)
				result.AddRange(result1);
			if (result2 != null)
				result.AddRange(result2);

			return result;
		}

		public void SiteMove(string no, string start, string end, int cnt)
		{
			Materials_Action ma = new Materials_Action();

			ma.WarehousingDate = DateTime.Now;
			ma.WarehousingType = "이동";
			ma.MaterialsLocation = end;
			ma.ProductNo = Convert.ToInt32(no);
			ma.WarehousingCount = cnt;
			ma.WarehousingPrice = _Database.DBMaterials.GetPriceAvg(ma.ProductNo);  //평균 단가
			ma.WarehousingMemo = start + "(-" + cnt + ")";
			ma.WarehousingCustomer = "사내 이동";


			//옮길 자재 번호, 시작위치, 도착위치, 옮길 수량
			_Database.DBMaterials.GetPriceAvg(ma.ProductNo);  //평균 단가
			_Database.DBMaterials.insertIOWarehousing(ma);  //입출고 내역

			_Database.DBMaterials.InsertOrUpdateSiteData(Convert.ToInt32(no), start, cnt * -1);
			_Database.DBMaterials.InsertOrUpdateSiteData(Convert.ToInt32(no), end, cnt);
		}

		public List<string[]> GetMaterialList(int productNo)
		{
			return _Database.DBMaterials.GetMaterialList(productNo);
		}

		public List<MaterialsSemi> GetProductList(int productNo)
		{

			return SemisMaterials(_Database.DBMaterials.GetProductList(productNo));
		}

		//입고 함수
		public void Warehousing(int no, string locaion, int count, int price, string memo, string customer)
		{
			//insert
			Materials_Action ma = new Materials_Action();

			//null 변환 가능한거 위치 널이면 미지정, 숫자 0이면 평균값,
			ma.WarehousingDate = DateTime.Now;

			string str = "";
			if (customer.Length == 0) str = null;
			else str = customer;
			ma.WarehousingCustomer = str;
			ma.WarehousingType = "입고";
			ma.MaterialsLocation = locaion;
			ma.ProductNo = no;
			ma.WarehousingCount = count;

			ma.WarehousingMemo = memo;

			str = "";
			int pri = 0;
			if (price == 0)
			{
				pri = _Database.DBMaterials.GetPriceAvg(no);
				str = "(입고가 미입력으로 평균가격 입력)";

			}
			else pri = price;
			ma.WarehousingPrice = pri;
			ma.WarehousingMemo = memo + str;
			Materials mtr = new Materials();
			mtr.MaterialsCount = ma.WarehousingCount;
			mtr.MaterialsPrice = ma.WarehousingPrice;
			_Database.DBMaterials.insertIOWarehousing(ma);  //입출고 내역
			_Database.DBMaterials.MaterialsWearingUpdate(mtr, no); //기존 자재 총 수량, 평균 단가 변경
			_Database.DBMaterials.InsertOrUpdateSiteData(no, locaion, count);



		}

		public void UpdateMaterials(Materials materials)
		{
			_Database.DBMaterials.UpdateMaterials(materials);
		}
		public void DeleteMaterial(int materialsNo)
		{
			_Database.DBMaterials.DeleteMaterial(materialsNo);
		}
		public List<string[]> GetOrderByMaterialsLocation(int materialsNo)
		{
			return _Database.DBMaterials.GetOrderByMaterialsLocation(materialsNo);
		}
		#endregion
		public bool FindSemiName(string materialsseminame)
		{
			return _Database.DBMaterials.FindSemiName(materialsseminame);
		}

		public void InsertSemi(MaterialsSemi ms)
		{
			_Database.DBMaterials.InsertSemi(ms);
			SetMaterials();
		}

		public List<Materials> WarehousingUseCheck(List<Materials_Of_Product> list)
		{
			List<string[]> semiItem = new List<string[]>();
			Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
			foreach (Materials_Of_Product mop in list)
			{
				if (mop.mopB)
				{
					//반 제품일때 자재 꺼내서 수량 확인
					foreach (MaterialsSemi ms in Semis)
					{

						if (ms.Materialssemino == mop.mopNo)
						{
							foreach (string[] str in ms.Materialssemivalue2)
							{
								if (keyValuePairs.ContainsKey(Convert.ToInt32(str[0].ToString())))
								{
									keyValuePairs[Convert.ToInt32(str[0].ToString())] += Convert.ToInt32(RetunSemiCnt(str[1].ToString()));
								}
								else
								{
									keyValuePairs.Add(Convert.ToInt32(str[0].ToString()),
										Convert.ToInt32(RetunSemiCnt(str[1].ToString())));
								}
							}
						}
					}
				}
				else
				{
					//자재 일때
					if (keyValuePairs.ContainsKey(Convert.ToInt32(mop.mopNo)))
					{
						keyValuePairs[mop.mopNo] += mop.mopCnt;
					}
					else
					{
						keyValuePairs.Add(Convert.ToInt32(mop.mopNo),
							Convert.ToInt32(mop.mopCnt));
					}
				}
			}
			return GetMaterialOfCnt(keyValuePairs);
		}
		private List<Materials> GetMaterialOfCnt(Dictionary<int, int> keyValuePairs)
		{
			List<Materials> list = new List<Materials>();
			foreach (KeyValuePair<int, int> item in keyValuePairs)
			{
				Materials materials = _Database.DBMaterials.GetMaterialsData(item.Key);
				materials.MaterialsCount = item.Value;
				list.Add(materials);
			}

			return list;
		}
		public string RetunSemiCnt(string value)
		{
			char sp1 = '(';
			char sp2 = ')';

			string[] stringArr1 = value.Split(sp1);
			string[] stringArr2 = stringArr1[1].Split(sp2);



			return stringArr2[0];
		}

		public void DeleteSemi(string value)
		{
			//_Database.DBMaterials.DeleteSemi(value);
		}

		public void UpdateSemi(MaterialsSemi materialsSemi)
		{
			_Database.DBMaterials.UpdateSemi(materialsSemi);
			SetMaterials();
		}

		public void SetMOP(List<Materials_Of_Product> list)
		{
			foreach (Materials_Of_Product mop in list)
			{
				if (_Database.DBMaterials.mopChek(mop))
				{
					//update
					_Database.DBMaterials.mopUpdate(mop);
				}
				else
				{
					//insert
					_Database.DBMaterials.mopInsert(mop);
				}
			}
		}

		public void mopDelete(Materials_Of_Product mop)
		{
			_Database.DBMaterials.mopDelete(mop);
		}
	}
}
