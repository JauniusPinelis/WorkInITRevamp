using Domain.Models;
using System.Collections.Generic;

namespace Domain.Helpers
{
    public static class TagHelpers
    {

        public static IEnumerable<Tag> ExtractTags(string html, IEnumerable<Tag> tags)
        {
            var extractedTags = new List<Tag>();
            foreach (var tag in tags)
            {
                if (html.Contains(tag.Name))
                {
                    extractedTags.Add(tag);
                }
            }

            return extractedTags;
        }
    }
}
