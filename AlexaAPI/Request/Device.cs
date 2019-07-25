namespace LambdaSLAPI.AlexaAPI.Request
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Device
    {
        [JsonProperty("supportedInterfaces")]
        public Dictionary<String, Object> SupportedInterfaces { get; set; }

        [JsonProperty("deviceId")]
        public String DeviceID { get; set; }
    }
}