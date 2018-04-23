using System;
using System.Text.RegularExpressions;

namespace FINT.Model.Resource
{
    public class Link
    {
        public Link()
        {
        }

        private Link(string verdi)
        {
            href = verdi;
        }

        public string href { get; }

        public static Link with(string verdi)
        {
            return new Link(verdi);
        }

        public static Link with(Type placeholderClass, string[] pathElements)
        {
            return with(placeholderClass, string.Join("/", pathElements));
        }

        private static Link with(Type placeholderClass, string path)
        {
            var placeholder = getHrefPlaceholder(placeholderClass);
            var regex = new Regex("^/");
            path = regex.Replace(path, "", 1);

            return new Link($"${{{placeholder}}}/{path}");
        }

        private static string getHrefPlaceholder(Type placeholderClass)
        {
            var regex1 = new Regex("^FINT\\.Model(\\.Resource)?\\.");
            var regex2 = new Regex("Resource$");

            var replace1 = regex1.Replace(placeholderClass.FullName, "", 1);
            var replace2 = regex2.Replace(replace1, "", 1);

            return replace2.ToLower();
        }
    }
}