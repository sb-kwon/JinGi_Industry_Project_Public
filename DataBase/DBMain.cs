using System;
using System.Data;
using Model;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataBase
{
	public class DBMain
	{
		private string _ServerAddress = /*"server=localhost;user=root;database=jg;password=root;" +
                                        "port = 3306;" +
                                        "CharSet = utf8;";*/
        "server=118.41.44.246;user=root;database=jg;password=root;" +
        "port = 3308;" +
        "CharSet = utf8;";

        private static readonly Lazy<DBMain> _instance = new Lazy<DBMain>(() => new DBMain());
		public static DBMain Instance { get { return _instance.Value; } }

		private DBAthority _DBAthority;
		private DBDefaultValue _DBDefaultValue;
		private DBMember _DBMember;
		private DBMachine _DBMachine;
		private DBCustomer _DBCustomer;
		private DBMonitor _DBMonitor;
		private DBRepair _DBRepair;
		private DBMaterials _DBMaterials;
		private DBProcess _DBProcess;
		private DBOperatingRate _DBRate;
		private DBNonOperating _DBNon;
		private DBFacilityRate _DBFacility;
		private DBKpi _DBKpi;
		private DBNotice _DBNotice;
		private DBMain()
		{
			DBAthority = new DBAthority(this);
			DBDefaultValue = new DBDefaultValue(this);
			DBMember = new DBMember(this);
			DBMachine = new DBMachine(this);
			DBCustomer = new DBCustomer(this);
			DBMonitor = new DBMonitor(this);
			DBRepair = new DBRepair(this);
			DBMaterials = new DBMaterials(this);
			DBProcess = new DBProcess(this);
			DBRate = new DBOperatingRate(this);
			DBFacility = new DBFacilityRate(this);
			DBNonOperating = new DBNonOperating(this);
			DBKpi = new DBKpi(this);
			DBNotice = new DBNotice(this);
		}

		//---------------------------------------------
		//Getter And Setter
		//---------------------------------------------

		public string ServerAddress
		{
			get { return _ServerAddress; }
			set { _ServerAddress = value; }
		}
		public DBAthority DBAthority
		{
			get { return _DBAthority; }
			set { _DBAthority = value; }
		}
		public DBMember DBMember
		{
			get { return _DBMember; }
			set { _DBMember = value; }
		}
		public DBMachine DBMachine
		{
			get { return _DBMachine; }
			set { _DBMachine = value; }
		}
		public DBDefaultValue DBDefaultValue
		{
			get { return _DBDefaultValue; }
			set { _DBDefaultValue = value; }
		}
		public DBCustomer DBCustomer
		{
			get { return _DBCustomer; }
			set { _DBCustomer = value; }
		}
		public DBMonitor DBMonitor
		{
			get { return _DBMonitor; }
			set { _DBMonitor = value; }
		}
		public DBRepair DBRepair
		{
			get { return _DBRepair; }
			set { _DBRepair = value; }
		}
		public DBMaterials DBMaterials
		{
			get { return _DBMaterials; }
			set { _DBMaterials = value; }
		}
		public DBProcess DBProcess
		{
			get { return _DBProcess; }
			set { _DBProcess = value; }
		}
		public DBOperatingRate DBRate
		{
			get { return _DBRate; }
			set { _DBRate = value; }
		}
		public DBFacilityRate DBFacility
		{
			get { return _DBFacility; }
			set { _DBFacility = value; }
		}
		public DBNonOperating DBNonOperating
		{
			get { return _DBNon; }
			set { _DBNon = value; }
		}
		public DBKpi DBKpi
		{
			get { return _DBKpi; }
			set { _DBKpi = value; }
		}
		public DBNotice DBNotice
		{
			get { return _DBNotice; }
			set { _DBNotice = value; }
		}
	}
}
