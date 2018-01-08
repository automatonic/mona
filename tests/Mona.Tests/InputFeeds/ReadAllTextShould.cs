using System;
using Xunit;
using FluentAssertions;
using System.IO;

namespace Mona.InputFeeds
{
    public class ReadAllTextShould
    {
        [Fact]
        public void TryGetSingle()
        {
            using (var textReader = new StringReader("yada"))
            {
                var feed = new ReadAllText(new Uri("a://yada"), textReader, null);
                feed.TryGetFirst(out var input).Should().BeTrue();
                input.Memory.Length.Should().Be(4);
            }
        }

    }
}
