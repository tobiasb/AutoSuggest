using System;

namespace AutoSuggest
{
    internal class PrefixTree
    {
        private PrefixTreeNode _root;

        public PrefixTree()
        {
            Clear();   
        }
            
        public void Clear()
        {
            _root = new PrefixTreeNode(null, "", false);
        }

        public void Append(string word)
        {
            _root.Append(word);
        }

        public PrefixTreeNode Find(string prefix)
        {
            if (_root == null)
                return null;

            if (prefix == string.Empty)
                return _root;

            return _root.Find(prefix);
        }
    }
}

