﻿using Newtonsoft.Json;
using System;

namespace SteamApi.Responses.Dota
{
    /// <summary>
    /// Live league team
    /// </summary>
    [Serializable]
    public sealed class LiveLeagueMatchTeam
    {
        /// <summary>
        /// Name of the team
        /// </summary>
        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        /// <summary>
        /// Team id
        /// </summary>
        [JsonProperty("team_id")]
        public uint TeamId { get; set; }

        /// <summary>
        /// Team logo id
        /// </summary>
        [JsonProperty("team_logo")]
        public ulong TeamLogo { get; set; }

        /// <summary>
        /// Is team complete
        /// </summary>
        public bool Complete { get; set; }
    }
}
