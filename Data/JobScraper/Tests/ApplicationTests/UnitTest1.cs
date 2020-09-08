using FluentAssertions;
using System;
using Xunit;

namespace ApplicationTests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			true.Should().BeTrue();
		}
	}
}
