using FluentAssertions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NSubstitute;
using System.Net;
using Xunit;

namespace RockPaperScissors.Functions.Tests
{
    public class GameTriggerTests
    {
        [Fact]
        public async void Run_AssertsSomeCondition()
        {
            var logger = Substitute.For<ILogger>();
            var trigger = new GameTrigger();

            var request = new GameRequest
            {
                Move = "ROCK"
            };

            var response = await trigger.Run(request.AsHttpRequestMessage(), logger);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string responseBody = await response.Content.ReadAsStringAsync();
            var gameState = JsonConvert.DeserializeObject<GameResponse>(responseBody);

            gameState.PlayersMove.Should().Be(request.Move);
        }
    }
}
