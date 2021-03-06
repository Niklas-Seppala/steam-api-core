﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SteamApi.Responses.Dota
{
    /// <summary>
    /// Short version of dota 2 match
    /// </summary>
    [Serializable]
    public sealed class MatchShort
    {
        /// <summary>
        /// Skill bracket for the match.
        /// (-1) ->  Not defined
        /// 0    ->  Any
        /// 1    ->  Normal
        /// 2    ->  High
        /// 3    ->  Very High
        /// </summary>
        public int SkillLevel { get; set; } = -1;

        /// <summary>
        /// Match Id
        /// </summary>
        [JsonProperty("match_id")]
        public ulong Id { get; set; }

        /// <summary>
        /// Match sequence number
        /// </summary>
        [JsonProperty("match_seq_num")]
        public ulong SequenceNumber { get; set; }

        /// <summary>
        /// Unixtimestamp of the match start time
        /// </summary>
        [JsonProperty("start_time")]
        public ulong StartTime { get; set; }

        /// <summary>
        /// Type of the lobby
        /// </summary>
        [JsonProperty("lobby_type")]
        public uint LobbyType { get; set; }

        /// <summary>
        /// Radiant team id
        /// </summary>
        [JsonProperty("radiant_team_id")]
        public uint RadiantTeamId { get; set; }

        /// <summary>
        /// Dire team id
        /// </summary>
        [JsonProperty("dire_team_id")]
        public uint DireTeamId { get; set; }

        /// <summary>
        /// List of the human players in the match
        /// </summary>
        public IReadOnlyList<PlayerShort> Players { get; set; }
    }
}
