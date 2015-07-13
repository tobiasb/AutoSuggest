using System;
using System.Collections.Generic;

namespace AutoSuggest
{
	public interface ISuggestWords
	{
		void Populate(IEnumerable<string> source);
		IEnumerable<string> Suggest(string prefix, int? maxWords = null);
	}
}

