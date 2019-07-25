namespace LambdaSLAPI.AlexaAPI.Response
{
    using System;

    using Newtonsoft.Json;

    public class CardImage
    {
        [JsonProperty("smallImageUrl")]
        public String SmallImageUrl { get; set; }

        [JsonProperty("largeImageUrl")]
        public String LargeImageUrl { get; set; }
    }
}