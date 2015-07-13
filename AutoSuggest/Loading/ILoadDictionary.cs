using System;
using System.Collections.Generic;

namespace AutoSuggest
{
	public interface ILoadDictionary
	{
		IEnumerable<string> LoadWords();
	}
}

