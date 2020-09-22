using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class TagHelpers
    {

        public static IEnumerable<Tag> ExtractTags(string html, IEnumerable<Tag> tags)
		{
            var extractedTags = new List<Tag>();
            foreach(var tag in tags)
			{
                if (html.Contains(tag.Name)){
                    extractedTags.Add(tag);
				}
			}

            return extractedTags;
		}
    }
}
