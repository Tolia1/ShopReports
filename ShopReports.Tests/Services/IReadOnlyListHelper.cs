using System.Text;

namespace ShopReports.Tests.Services
{
    public static class IReadOnlyListHelper
    {
        public static string ConvertToString(this IReadOnlyList<object> records)
        {
            var builder = new StringBuilder();
            foreach (var line in records)
            {
                builder.AppendLine(line.ToString());
            }

            return builder.ToString();
        }
    }
}
