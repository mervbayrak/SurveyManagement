using System.Text.RegularExpressions;

namespace SurveyManagement.Application.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ToKebabCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return Regex.Replace(value, "(?<!^)([A-Z])", "-$1").ToLower();
        }
    }
}
