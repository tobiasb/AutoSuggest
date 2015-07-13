using System;
using NUnit.Framework;
using FluentAssertions;

namespace AutoSuggest.Tests
{
    [TestFixture]
    public abstract class SuggesterBaseTest
    {
        protected ISuggestWords Suggestor;

        [Test]
        public void should_suggest_subset_of_words()
        {
            Suggestor.Populate(new []{"A", "AA", "AAA", "AAB"});

            var result = Suggestor.Suggest("AA");

            result.Should().Contain("AA");
            result.Should().Contain("AAA");
            result.Should().Contain("AAB");
        }

        [Test]
        public void should_suggest_maximum_number_of_words()
        {
            Suggestor.Populate(new []{"A", "AA", "AAA", "AAB"});

            var result = Suggestor.Suggest("AA", 2);

            result.Should().Contain("AA");
            result.Should().Contain("AAA");
            result.Should().NotContain("AAB");
        }

        [Test]
        public void should_suggest_all_words()
        {
            var allWords = new []{ "A", "AA", "AAA", "AAB" };
            Suggestor.Populate(allWords);

            var result = Suggestor.Suggest("");

            result.Should().Contain(allWords);
        }

        [Test]
        public void should_suggest_nothing_if_nothing_matches()
        {
            Suggestor.Populate(new []{"A", "AA", "AAB"});

            var result = Suggestor.Suggest("Z");

            result.Should().BeEmpty();
        }

        [Test]
        public void should_not_suggest_non_words()
        {
            Suggestor.Populate(new []{"A", "AA", "AAAA", "AAAB"});

            var result = Suggestor.Suggest("AA");

            result.Should().NotContain("AAA");
        }
    }
}

