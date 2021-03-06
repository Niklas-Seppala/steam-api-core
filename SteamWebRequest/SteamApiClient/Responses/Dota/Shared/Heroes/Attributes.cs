﻿using Newtonsoft.Json;
using System;

namespace SteamApi.Responses.Dota
{
    /// <summary>
    /// Collection of Dota 2 hero's base attributes
    /// </summary>
    [Serializable]
    public sealed class Attributes
    {
        /// <summary>
        /// Hero's strength attribute data
        /// </summary>
        [JsonProperty("str")]
        public Attribute Strength { get; set; }

        /// <summary>
        /// Hero's intelligence attribute data
        /// </summary>
        [JsonProperty("int")]
        public Attribute Intelligence { get; set; }

        /// <summary>
        /// Hero's agility attribute data
        /// </summary>
        [JsonProperty("agi")]
        public Attribute Agility { get; set; }

        /// <summary>
        /// Hero's base movement speed
        /// </summary>
        [JsonProperty("ms")]
        public uint MovementSpeed { get; set; }

        /// <summary>
        /// Hero's base armor amount
        /// </summary>
        [JsonProperty("armor")]
        public double Armor { get; set; }

        /// <summary>
        /// hero's base damage
        /// </summary>
        [JsonProperty("dmg")]
        public Damage Damage { get; set; }
    }
}
