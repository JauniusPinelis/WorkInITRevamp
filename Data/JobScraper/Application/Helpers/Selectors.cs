using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Helpers
{
	public class Selectors
	{
		public static string SelectName(HtmlNode node)
		{
			var salaryNode = node.CssSelect("span.salary-blue");
			if (salaryNode.Any())
			{
				var salaryInfo = salaryNode.First();
				return salaryInfo.InnerText;
			}
			else
			{
				return "";
			}
		}

		public static string SelectCompany(HtmlNode node)
		{
			var companyNode = node.CssSelect("a[itemprop=name]");
			if (companyNode.Any())
			{
				var companyInfo = companyNode.First();
				return companyInfo.InnerText;
			}
			else
			{
				return "";
			}
			
		}

	}
}
