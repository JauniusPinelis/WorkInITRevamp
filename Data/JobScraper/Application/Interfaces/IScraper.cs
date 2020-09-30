using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Application.Interfaces
{
    public interface IScraper
    {
        HtmlNode GetHtml(string url);

        byte[] GetImage(string url);
    }
}
