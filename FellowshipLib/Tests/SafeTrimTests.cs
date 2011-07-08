using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using FellowshipLib.Extensions;

namespace FellowshipLib.Tests.Extensions
{
	[TestFixture]
	public class SafeTrimTests
	{
		[TestCase(null, "")]
		[TestCase("", "")]
		[TestCase("    ", "")]
		[TestCase("1234", "1234")]
		[TestCase("1234  ", "1234")]
		[TestCase("   1234", "1234")]
		[TestCase("   1234  ", "1234")]
		public void WhenSafeTrimIsCalledOnAString_TheStringShouldBeTrimmed(string orig, string expected)
		{
			orig.SafeTrim().Should().Be(expected);
		}
	}
}
