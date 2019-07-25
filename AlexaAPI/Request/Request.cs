namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;

    using Newtonsoft.Json;

    public class Request
    {
        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("requestId")]
        public String RequestId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("locale")]
        public String Locale { get; set; }

        [JsonProperty("intent")]
        public Intent Intent { get; set; }

        [JsonProperty("updatedintent")]
        public Intent UpdatedIntent { get; set; }

        [JsonProperty("reason")]
        public String Reason { get; set; }

        [JsonProperty("dialogState")]
        public String DialogState { get; set; }
    }
}