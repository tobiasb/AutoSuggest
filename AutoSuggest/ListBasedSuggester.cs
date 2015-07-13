using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSuggest
{
	internal class ListBasedSuggester : ISuggestWords
	{
		private readonly List<string> _words;

		public ListBasedSuggester()
		{

			_words = new List<string>();
		}

		public void Populate(IEnumerable<string> source)
		{
			_words.Clear ();
			_words.AddRange (source);
		}

		public IEnumerable<string> Suggest(string prefix, int? maxWords = null)
		{
			var result = new List<string>();
			foreach (string word in _words) 
			{
				if(word.StartsWith(prefix))
				{
					result.Add(word);
				}
			}

			return result.Take(maxWords.HasValue ? maxWords.Value : int.MaxValue)
				         .ToList();
		}
	}
}

