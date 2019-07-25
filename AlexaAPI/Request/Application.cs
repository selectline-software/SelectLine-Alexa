namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;

    using Newtonsoft.Json;

    public class Application
    {
        [JsonProperty("applicationID")]
        public String ApplicationId { get; set; }
    }
}