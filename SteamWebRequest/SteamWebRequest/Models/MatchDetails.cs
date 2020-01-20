﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SteamWebRequest.Models
{
    public sealed class MatchDetails
    {
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Duration { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        [JsonProperty("pre_game_duration")]
        public TimeSpan PreGameDuration { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        [JsonProperty("first_blood_time")]
        public TimeSpan FirstBloodTime { get; set; }

        [JsonConverter(typeof(MapStateConverter))]
        [JsonProperty("tower_status_radiant")]
        public TowerStatus TowerStatusRadiant { get; set; }

        [JsonConverter(typeof(MapStateConverter))]
        [JsonProperty("tower_status_dire")]
        public TowerStatus TowerStatusDire { get; set; }

        [JsonConverter(typeof(MapStateConverter))]
        [JsonProperty("barracks_status_radiant")]
        public BarracksStatus BarracksStatusRadiant { get; set; }

        [JsonConverter(typeof(MapStateConverter))]
        [JsonProperty("barracks_status_dire")]
        public BarracksStatus BarracksStatusDire { get; set; }

        [JsonProperty("match_id")]
        public ulong MatchId { get; set; }

        [JsonProperty("match_seq_num")]
        public ulong MatchSequenceNum { get; set; }

        public List<Player> Players { get; set; }

        [JsonProperty("radiant_win")]
        public bool RadiantWin { get; set; }
        public bool DireWin { get => !this.RadiantWin; }

        [JsonProperty("human_players")]
        public byte HumanPlayers { get; set; }

        [JsonProperty("lobby_type")]
        public byte LobbyType { get; set; }

        [JsonProperty("League_id")]
        public byte LeagueId { get; set; }

        [JsonProperty("game_mode")]
        public byte GameMode { get; set; }

        [JsonProperty("radiant_score")]
        public ushort RadiantScore { get; set; }

        [JsonProperty("dire_score")]
        public ushort DireScore { get; set; }
    }

}