using Domain.Helpers;
using FluentAssertions;
using System;
using Xunit;

namespace ApplicationTests
{
    public class ExtensionTests
	{
		[Fact]
		public void ExtractSalary_GivenEmptyString_ReturnsNulls()
		{
			var (min, max) = SalaryHelpers.ExtractSalary("");

			min.Should().BeNull();
			max.Should().BeNull();
		}

		[Fact]
		public void ExtractSalary_GivenMinAndMax_ReturnsMinAndMax()
		{
			var (min, max) = SalaryHelpers.ExtractSalary("Mėnesinis atlygis (bruto): Nuo 3500.00 iki 5800.00 EUR");

			min.Should().Be(3500);
			max.Should().Be(5800);
		}
	}
}
