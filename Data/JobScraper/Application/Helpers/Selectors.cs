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
		public static string SelectName(HtmlNode node, string tag)
		{
			var salaryNode = node.CssSelect(tag);
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

		public static string SelectCompany(HtmlNode node, string tag)
		{
			try
			{
				var companyNode = node.CssSelect(tag);
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
			catch(Exception ex)
			{
				//Work around for now...
				return "";
			}
		}

		public static string SelectUrl(HtmlNode node, string tag)
		{
			try
			{
				var companyNode = node.CssSelect(tag);
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
			catch (Exception ex)
			{
				//Work around for now...
				return "";
			}
		}

	}
}
