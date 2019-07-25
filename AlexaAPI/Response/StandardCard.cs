namespace LambdaSLAPI.AlexaAPI.Response
{
    using System;

    using Newtonsoft.Json;

    public class StandardCard : ICard
    {
        [JsonRequired]
        [JsonProperty("type")]
        public String Type => "Standard";

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("text")]
        public String text { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public CardImage Image { get; set; }
    }
}