using System;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace AutoSuggest.Samples.Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var fileName = Path.Combine(GetAssemblyDirectory(), "english.txt");
            ISuggestWords suggester = SuggesterBuilder.Build(fileName);

            var suggestedWords = suggester.Suggest("access");

            foreach(var word in suggestedWords)
                System.Console.WriteLine(word);
        }

        private static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
