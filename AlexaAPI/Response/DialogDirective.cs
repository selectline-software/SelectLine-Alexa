namespace LambdaSLAPI.AlexaAPI.Response
{
    using System;

    using Newtonsoft.Json;

    public class DialogDirective : IDirective
    {
        [JsonProperty("type")]
        public String Type { get; set; }
    }
}