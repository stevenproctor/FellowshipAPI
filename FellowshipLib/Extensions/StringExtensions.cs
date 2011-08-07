using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FellowshipLib.Extensions
{
	public static class StringExtensions
	{
		public static string SafeTrim(this string s)
		{
			if (s == null)
				return string.Empty;
			return s.Trim();
		}
	}
}
