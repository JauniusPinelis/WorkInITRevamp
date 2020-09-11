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
		public static string SelectName(HtmlNode node, string selectTag)
		{
			var salaryNode = node.CssSelect(selectTag);
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

		public static string SelectCompany(HtmlNode node, string selectTag)
		{
			var companyNode = node.CssSelect(selectTag);
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
