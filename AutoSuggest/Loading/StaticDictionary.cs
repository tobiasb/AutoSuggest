using System;
using System.Collections.Generic;

namespace AutoSuggest
{
	internal class StaticDictionary : ILoadDictionary
	{
		public IEnumerable<string> LoadWords()
		{
			return new List<string>{ 
				"A", "Afloat"
			};
		}
	}
}

