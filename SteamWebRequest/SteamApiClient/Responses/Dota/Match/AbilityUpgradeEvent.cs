﻿using System;

namespace SteamApi.Responses.Dota
{
    [Serializable]
    public sealed class AbilityUpgradeEvent
    {
        public uint Time { get; set; }
        public uint Ability { get; set; }
        public uint Level { get; set; }
    }
}
