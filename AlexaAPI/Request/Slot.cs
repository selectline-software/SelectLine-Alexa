namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;

    using Newtonsoft.Json;

    public class Slot
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("value")]
        public String Value { get; set; }
    }
}