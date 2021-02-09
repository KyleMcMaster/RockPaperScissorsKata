using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Net.Http;
using Xunit;

namespace RockPaperScissors.Functions.Tests
{
    public class GameTriggerTests
    {
        [Fact]
        public async void Run_AssertsSomeCondition()
        {
            var trigger = new GameTrigger();

            Assert.NotNull(trigger);
        }
    }
}
