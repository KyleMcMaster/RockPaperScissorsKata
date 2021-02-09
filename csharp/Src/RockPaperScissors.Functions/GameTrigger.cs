using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Linq;
using System;

namespace RockPaperScissors.Functions
{
    public class GameTrigger
    {
        [FunctionName("Game")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            string queryparams = req.RequestUri.Query;

            if (!queryparams.Contains("move="))
            {
                throw new Exception("Oh no!");
            }

            string move = queryparams.Split("=").LastOrDefault();

            log.LogInformation($"Player's move: {move}");
        }
    }
}
