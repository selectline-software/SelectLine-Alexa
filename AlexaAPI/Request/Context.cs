namespace LambdaSLAPI.AlexaAPI.Request
{
    using Newtonsoft.Json;

    public class Context
    {
        [JsonProperty("System")]
        public SystemObject System { get; set; }
    }
}