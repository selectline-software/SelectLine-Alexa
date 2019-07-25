namespace LambdaSLAPI.AlexaAPI.Response
{
    using Newtonsoft.Json;

    public class Reprompt
    {
        [JsonProperty("outputSpeech", NullValueHandling = NullValueHandling.Ignore)]
        public IOutputSpeech OutputSpeech { get; set; }
    }
}