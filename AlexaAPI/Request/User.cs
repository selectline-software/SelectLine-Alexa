namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;

    using Newtonsoft.Json;

    public class User
    {
        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("accessToken")]
        public String AccessToken { get; set; }
    }
}