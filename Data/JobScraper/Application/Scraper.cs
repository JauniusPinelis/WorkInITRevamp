using Application.Interfaces;
using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Http;
using System.Net;

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

        public byte[] GetImage(string url)
		{
            Stream stream = null;
            byte[] buf;

            try
            {
                url = url.Replace("https", "http");

                if (!url.StartsWith("http"))
                {
                    return null;
                }

                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        public byte[] GetImage2(string url)
        {
            url = url.Replace("https", "http");
            
            if (!url.StartsWith("http"))
			{
                return null;
			}

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex )
            {
                return null;
            }

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {

                // if the remote file was found, download it
                using (Stream inputStream = response.GetResponseStream()) 
                {
                
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        
                    } while (bytesRead != 0);

                    return buffer;
                }

            }
            else
                return null;
        }


    }
}
