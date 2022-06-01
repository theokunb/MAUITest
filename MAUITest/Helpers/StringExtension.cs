using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITest.Helpers
{
    public static class StringExtension
    {

        public static string CurrencyFormat(this string text)
        {
            string[] parts = text.Split('.');

            if(parts.Length ==0)
                return string.Empty;
            var wholePart = parts[0];
            StringBuilder result = new StringBuilder();

            int appenderSpaces = 0;
            for(int i = 0; i < wholePart.Length ; i++)
            {
                result.Append(wholePart[i]);
                if (i > 0 && i % 3 == 0)
                {
                    result.Insert(i - 2 + appenderSpaces++, " ");
                }
            }
            if (parts.Length > 1)
            {
                result.Append(".");
                result.Append(parts[1]);
            }

            return result.ToString();
        }
    }
}
