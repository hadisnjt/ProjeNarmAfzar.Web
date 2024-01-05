

namespace ProjeNarmAfzar.Application.Utilities.ExtensionMethods
{
    public static class UrlExtensions
    {
        public static string FIxUrlForTitle(this string title)
        {
            return title.Replace(' ', '-');
        }
    }
}
