using System;
using NUnit.Framework;
using FluentAssertions;

namespace AutoSuggest.Tests
{
    [TestFixture]
    public class ListBasedSuggesterTests : SuggesterBaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Suggestor = new ListBasedSuggester();
        }
    }
}

