namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;

    using Newtonsoft.Json;

    public class SkillRequest
    {
        [JsonProperty("version")]
        public String Version { get; set; }

        [JsonProperty("session")]
        public Session Session { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }
    }
}