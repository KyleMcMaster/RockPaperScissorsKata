using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PPT.Core.HttpClientUtilities;

namespace RockPaperScissors.Functions
{
    public class GameTrigger
    {
        public string[] MOVES = new string[] { "ROCK", "PAPER", "SCISSORS" };

        [FunctionName("Game")]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            GameRequest request = null;
            try
            {
                string requestBody = await req.Content.ReadAsStringAsync();
                request = JsonConvert.DeserializeObject<GameRequest>(requestBody);
            }
            catch (Exception exception)
            {
                log.LogError(exception, $"Invalid {nameof(GameRequest)}: {exception.Message}");
                return JsonResponseBuilder.BuildResponse(HttpStatusCode.BadRequest, string.Empty);
            }

            if (!MOVES.Contains(request.Move))
            {
                JsonResponseBuilder.BuildResponse(HttpStatusCode.BadRequest, string.Empty);
            }

            var random = new Random();

            int rnd = random.Next(0, 2);
            var opponentsMove = MOVES[rnd];

            var response = new GameResponse
            {
                PlayersMove = request.Move,
                OpponentsMove = opponentsMove,
                Result = "TIE"
            };

            return JsonResponseBuilder.BuildResponse(HttpStatusCode.OK, response);
        }
    }

    public class GameRequest
    {
        public string Move { get; set; }
    }

    public class GameResponse
    {
        public string PlayersMove { get; set; }
        public string OpponentsMove { get; set; }
        public string Result { get; set; }
    }
}
