namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;

    using Newtonsoft.Json;

    public class SystemObject
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("device")]
        public Device Device { get; set; }

        [JsonProperty("apiEndpoint")]
        public String ApiEndpoint { get; set; }
    }
}