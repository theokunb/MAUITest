using System.Text;

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

            for(int i = wholePart.Length - 1, count = 0; i >= 0; i--, count++)
            {
                if (count % 3 == 0)
                    result.Insert(0, ' ');
                result.Insert(0, wholePart[i]);
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
