namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Session
    {
        [JsonProperty("new")]
        public Boolean New { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("sessionId")]
        public String SessionId { get; set; }

        [JsonProperty("attributes")]
        public Dictionary<String, Object> Attributes { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }
    }
}