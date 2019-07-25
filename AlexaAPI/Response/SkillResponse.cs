namespace LambdaSLAPI.AlexaAPI.Response
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class SkillResponse
    {
        [JsonProperty("version")]
        public String Version { get; set; }

        [JsonProperty("sessionAttributes", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<String, Object> SessionAttributes { get; set; }

        [JsonProperty("response")]
        public ResponseBody Response { get; set; }
    }
}