using Application.Helpers;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests
{
    public class SelectorTests
    {
		private HtmlNode _html;

		public SelectorTests()
		{
			var path = Directory.GetCurrentDirectory() + "\\Data\\CvBankasPost.txt";

			var decodedData = WebUtility.HtmlDecode(File.ReadAllText(path));

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(decodedData);
			HtmlNodeCollection nodes = doc.DocumentNode.ChildNodes;

			_html = nodes.First();

		}

		[Fact]
		public void SelectCompany_GivenHtmlNode_GetsCompanyName()
		{
			Selectors.SelectCompany(node, )
		}

	}
}
