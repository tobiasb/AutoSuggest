using System;
using System.Collections.Generic;
using System.IO;

namespace AutoSuggest
{
    internal class FileSourceDictionary : ILoadDictionary
    {
        private string _fileName;

        public FileSourceDictionary(string fileName)
        {
            _fileName = fileName;   
        }

        public IEnumerable<string> LoadWords()
        {
            return File.ReadAllLines(_fileName);
        }
    }
}

