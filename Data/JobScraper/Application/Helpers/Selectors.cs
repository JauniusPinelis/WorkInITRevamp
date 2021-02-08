using Domain.Helpers;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Linq;

namespace Application.Helpers
{
    public class Selectors
    {
        private static string SelectValue(HtmlNode node, string tag)
        {
            try
            {
                var valueNode = node.CssSelect(tag);
                if (valueNode.Any())
                {
                    var value = valueNode.First();
                    return value.InnerText;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                //Work around for now...
                return "";
            }
        }

        public static string SelectName(HtmlNode node, string tag)
        {
            return SelectValue(node, tag);
        }

        public static string SelectCompany(HtmlNode node, string tag)
        {
            return SelectValue(node, tag);
        }

        public static string SelectLogoUrl(HtmlNode node, string tag)
        {
            try
            {
                var valueNode = node.CssSelect(tag);
                if (valueNode.Any())
                {
                    var value = valueNode.First();
                    var url = value.Attributes["src"].Value;

                    return UrlHelpers.ProcessUrl(url);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                //Work around for now...
                return "";
            }
        }

        public static string SelectUrl(HtmlNode node, string tag)
        {
            try
            {
                var valueNode = node.CssSelect(tag);
                if (valueNode.Any())
                {
                    var value = valueNode.First();
                    var url = value.Attributes["href"].Value;

                    return UrlHelpers.ProcessUrl(url);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                //Work around for now...
                return "";
            }
        }

    }
}
