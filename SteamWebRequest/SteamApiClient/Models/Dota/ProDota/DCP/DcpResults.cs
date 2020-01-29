﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SteamApiClient.Models.Dota
{
    public class DcpResults
    {
        [JsonProperty("league_id")]
        public uint LeagueId { get; set; }

        public uint Standing { get; set; }

        public uint Points { get; set; }

        public double Earnings { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}