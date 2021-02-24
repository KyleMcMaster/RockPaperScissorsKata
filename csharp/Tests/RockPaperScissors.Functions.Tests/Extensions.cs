using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace RockPaperScissors.Functions.Tests
{
    public static class Extensions
    {
        public static HttpRequestMessage AsHttpRequestMessage<T>(this T body, Action<HttpRequestMessage> additionalConfiguration = null)
        {
            var requestMessage = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(body)),
                Method = HttpMethod.Post
            };
            additionalConfiguration?.Invoke(requestMessage);
            return requestMessage;
        }
    }
}
