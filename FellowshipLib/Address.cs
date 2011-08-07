using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FellowshipLib
{
	public class Address
	{
		public string Id { get; set; }
		public string AddressType { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Address3 { get; set; }
		public string City { get; set; }
		public string County { get; set; }
		public string Country { get; set; }
		public string StateOrProvence { get; set; }
		public string AddressDate { get; set; }
		public string AddressVerifiedDate { get; set; }
		public string AddressComment { get; set; }
	}
}
