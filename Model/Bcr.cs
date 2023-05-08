using System;
using System.IO.Ports;

namespace Model
{
	public class Bcr
	{
		private String _PortName;
		private Parity _Parity;
		private int _BaudRate;
		private int _DataBits;
		private StopBits _StopBits;
		private String _MachineName;
		public string MachineName
		{
			get { return _MachineName; }
			set { _MachineName = value; }
		}
		public string PortName
		{
			get { return _PortName; }
			set { _PortName = value; }
		}
		public Parity Parity
		{
			get { return _Parity; }
			set { _Parity = value; }
		}
		public int BaudRate
		{
			get { return _BaudRate; }
			set { _BaudRate = value; }
		}
		public int DataBits
		{
			get { return _DataBits; }
			set { _DataBits = value; }
		}
		public StopBits StopBits
		{
			get { return _StopBits; }
			set { _StopBits = value; }
		}
	}
}
