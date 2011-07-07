using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FellowshipLib
{
	public class Communications : List<Communication>
	{
	}

	public class Communication
	{
		public string CommunicationGeneralType { get; set; }
		public string CommunicationValue { get; set; }
		public bool Listed { get; set; }
		public string LastUpdatedDate { get; set; }
		public CommunicationType CommunicationType { get; set; }
	}
}
