namespace LambdaSLAPI.AlexaAPI.Response
{
    using System;

    using Newtonsoft.Json;

    public class SsmlOutputSpeech : IOutputSpeech
    {
        [JsonRequired]
        [JsonProperty("type")]
        public String Type => "SSML";

        [JsonRequired]
        [JsonProperty("ssml")]
        public String Ssml { get; set; }
    }
}