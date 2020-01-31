﻿using Newtonsoft.Json;

namespace SteamApiClient.Models.Dota
{
    public class Attribute
    {
        [JsonProperty("b")]
        public int Base { get; set; }

        [JsonProperty("g")]
        public float Gain { get; set; }
    }
}