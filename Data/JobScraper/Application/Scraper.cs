﻿using Application.Interfaces;
using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Application
{
    public class Scraper : IScraper
    {
		private readonly ScrapingBrowser _browser;

		public Scraper()
		{
			_browser = new ScrapingBrowser();
			_browser.Encoding = Encoding.UTF8;
		}

		public HtmlNode GetHtml(string url)
		{
			WebPage homePage = _browser.NavigateToPage(new Uri(url));

			return homePage.Html;
		}

		public Image GetImage(string url)
		{
			using (System.Net.WebClient webClient = new System.Net.WebClient())
			{
				using (Stream stream = webClient.OpenRead(url))
				{
					return Image.FromStream(stream);
				}
			}
		}
	}
}
