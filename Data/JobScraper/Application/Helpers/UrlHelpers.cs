using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class UrlHelpers
    {
        public static string ProcessUrl(string url)
		{
            if (url.StartsWith("//"))
			{
                url = url.Substring(2);
			}
            return url;
		}
    }
}
