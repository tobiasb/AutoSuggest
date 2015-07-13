using System;

namespace AutoSuggest
{
    public class SuggesterBuilder
    {
        public static ISuggestWords Build(string fileSource)
        {
            return Build(new FileSourceDictionary(fileSource));
        }

        public static ISuggestWords Build(ILoadDictionary loader)
        {
            var suggester = new PrefixTreeBasedSuggester();

            suggester.Populate(loader.LoadWords());

            return suggester;
        }
    }
}

