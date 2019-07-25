namespace LambdaSLAPI.AlexaAPI.Response
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class ResponseBody
    {
        [JsonProperty("outputSpeech", NullValueHandling = NullValueHandling.Ignore)]
        public IOutputSpeech OutputSpeech { get; set; }

        [JsonProperty("card", NullValueHandling = NullValueHandling.Ignore)]
        public ICard Card { get; set; }

        [JsonProperty("reprompt", NullValueHandling = NullValueHandling.Ignore)]
        public Reprompt Reprompt { get; set; }

        [JsonProperty("shouldEndSession")]
        public Boolean ShouldEndSession { get; set; }

        [JsonProperty("directives", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IDirective> Directives { get; set; } = new List<IDirective>();
    }
}