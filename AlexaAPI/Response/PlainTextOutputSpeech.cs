namespace LambdaSLAPI.AlexaAPI.Response
{
    using System;

    using Newtonsoft.Json;

    public class PlainTextOutputSpeech : IOutputSpeech
    {
        [JsonProperty("type")]
        [JsonRequired]
        public String Type => "PlainText";

        [JsonRequired]
        [JsonProperty("text")]
        public String Text { get; set; }
    }
}