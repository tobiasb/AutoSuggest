using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSuggest
{
    internal class PrefixTreeNode
    {
        public bool IsWord { get; private set; }
        public PrefixTreeNode Parent { get; private set; }
        public string Prefix { get; private set;}
        public List<PrefixTreeNode> Nodes { get; private set; }

        public PrefixTreeNode(PrefixTreeNode parent, string prefix, bool isWord)
        {
            Parent = parent;
            Nodes = new List<PrefixTreeNode>();
            Prefix = prefix;
            IsWord = isWord;
        }

        public void Append(string word)
        {
            if(word.Length == 0){ return; }

            var node = Nodes.SingleOrDefault(n => word.StartsWith(n.Prefix));

            if(node == null)
            {
                node = new PrefixTreeNode(this, word.Substring(0, 1), word.Length == 1);
                Nodes.Add(node);
            }

            node.Append(word.Substring(1));
        }

        public PrefixTreeNode Find(string prefix)
        {
            var currentWord = BuildWord();
            if (prefix.StartsWith(currentWord))
            {
                foreach(var node in Nodes)
                {
                    var foundNode = node.Find(prefix);

                    if (foundNode != null)
                        return foundNode;
                }

                if (Prefix == string.Empty)
                    return null;
                
                return this;
            }
                
            return null;
        }

        public string BuildWord()
        {
            if(Parent == null)
                return "";

            return Parent.BuildWord() + Prefix;
        }

        public IEnumerable<PrefixTreeNode> GetDescendants()
        {
            var list = new List<PrefixTreeNode>();

            foreach(var node in Nodes)
            {
                list.Add(node);
                list.AddRange(node.GetDescendants());
            }

            return list;
        }
    }
}

