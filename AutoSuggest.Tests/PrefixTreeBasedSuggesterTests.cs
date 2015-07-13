using System;
using NUnit.Framework;
using FluentAssertions;

namespace AutoSuggest.Tests
{
    [TestFixture]
    public class PrefixTreeBasedSuggesterTests : SuggesterBaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Suggestor = new PrefixTreeBasedSuggester();
        }
    }
}

