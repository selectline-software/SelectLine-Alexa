namespace LambdaSLAPI.AlexaAPI.Response
{
    using System;

    using Newtonsoft.Json;

    public class SimpleCard : ICard
    {
        [JsonRequired]
        [JsonProperty("type")]
        public String Type => "Simple";

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("content")]
        public String Content { get; set; }
    }
}