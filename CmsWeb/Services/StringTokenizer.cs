using CmsData;
using System.Collections.Generic;

namespace CmsWeb.Services
{
    public class StringTokenizer
    {
        public string TokenizeString(string input, Dictionary<string, string> tokens)
        {
            string output = input;

            foreach (var key in tokens.Keys)
            {
                output = output.Replace(key, tokens[key]);
            }

            return output;
        }

        public string TokenizeContent(string templateName, Dictionary<string, string> tokens)
        {
            var contentString = DbUtil.Db.Content(templateName).Body;
            return TokenizeString(contentString, tokens);
        }
    }
}
