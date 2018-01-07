using System;
using Xunit;
using FluentAssertions;

namespace Mona
{
    public class ProvideShould
    {
        [Fact]
        public void Default()
        {
            var input = Provide.Default();
            input.Buffer.Length.Should().Be(0);
            input.Uri.Should().BeNull();
        }

        // [Fact]
        // public void Single()
        // {
        //     var result = Provide.Single(uri, out var input);
        //     result.Should().BeTrue();
        //     {

        //     }
        //     var input = Provide.Default();
        //     input.Buffer.Length.Should().Be(0);
        //     input.Uri.Should().BeNull();
        // }
    }
}
