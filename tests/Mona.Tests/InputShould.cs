using System;
using Xunit;
using FluentAssertions;
using System.IO;

namespace Mona
{
    public class InputShould
    {
        [Fact]
        public void ForData()
        {
            var input = Input.For(new Uri("data:,yada"));
            input.Length.Should().Be(4);
        }
        
    }
}
