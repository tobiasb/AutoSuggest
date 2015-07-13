using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSuggest
{
    internal class PrefixTreeBasedSuggester : ISuggestWords
    {
        private PrefixTree _tree;

        public PrefixTreeBasedSuggester()
        {
            _tree = new PrefixTree();
        }

        public void Populate(IEnumerable<string> source)
        {
            _tree.Clear();

            foreach(string word in source)
            {
                _tree.Append(word);
            }
        }

        public IEnumerable<string> Suggest(string prefix, int? maxWords = null)
        {
            var node = _tree.Find(prefix);

            if (node == null)
                return Enumerable.Empty<string>();

            var nodes = new List<PrefixTreeNode>{ node };
            nodes.AddRange(node.GetDescendants());


            return nodes.Where(n => n.IsWord)
                        .Take(maxWords.HasValue ? maxWords.Value : int.MaxValue)
                        .Select(n => n.BuildWord());
        }
    }
}

