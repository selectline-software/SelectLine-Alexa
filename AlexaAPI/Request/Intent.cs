namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Intent
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("confirmationStatus")]
        public String ConfirmationStatus { get; set; }

        [JsonProperty("slots")]
        public Dictionary<String, Slot> Slots { get; set; }
    }
}