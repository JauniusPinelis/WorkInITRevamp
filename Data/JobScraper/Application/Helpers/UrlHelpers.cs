using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class UrlHelpers
    {
        public static String ConvertImageURLToBase64(Byte[] imageData)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.Append(Convert.ToBase64String(imageData, 0, imageData.Length));

            return _sb.ToString();
        }

        public static string ProcessUrl(string url)
		{
            if (url.StartsWith("//"))
			{
                url = url.Substring(2);
			}
            if (url.StartsWith("www"))
            {
                url = "https://" + url;
            }
            if (url.StartsWith("files"))
			{
                url = "http://www." + url;
			}

            return url;
		}

        public static string ExtractFileExtension(string url)
		{
            var urlParts = url.Split('.');
            if (urlParts.Length > 1)
			{
                return urlParts.Last();
			}

            return null;
		}
    }
}
