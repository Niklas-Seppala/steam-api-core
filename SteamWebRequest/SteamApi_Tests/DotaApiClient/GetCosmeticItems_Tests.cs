﻿using System;
using Xunit;

namespace Client.Dota
{
    public class GetCosmeticItems_Tests : ApiTests
    {
        /// <summary>
        /// Setup
        /// </summary>
        public GetCosmeticItems_Tests(ClientFixture fixture) : base(fixture) { }

        [Fact]
        public void GetCosmeticRaritiesAsync_DefaultParams_ReturnsRarities()
        {
            var rarities = DotaApiClient.GetCosmeticRaritiesAsync()
                .Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(rarities);
            Assert.All(rarities, rarity =>
            {
                Assert.NotEmpty(rarity.LocalizedName);
                Assert.NotEmpty(rarity.Name);
                Assert.NotEmpty(rarity.Color);
                Assert.NotEqual((uint)0, rarity.Id);
            });
        }


        [Theory]
        [InlineData("fi",
            new string[] {
                "Yleinen", "Tavaton", "Harvinainen", "Myyttinen",
                "Tarunhohtoinen", "Muinainen", "Kuolematon", "Salatieteellinen"
            })]
        [InlineData("de",
            new string[] {
                "Gewöhnlich", "Ungewöhnlich", "Rare", "Mythical",
                "Legendär", "Ancient", "Immortal", "Arkana"
            })]
        [InlineData("fr",
            new string[] {
                "Commun", "Peu commun", "Rare", "Mythique",
                "Légendaire", "Ancien", "Immortel", "Arcane"
            })]
        public void GetCosmeticRaritiesAsync_LanguageProvided_ReturnsLocalizedRarities(string lang,
            string[] locNames)
        {
            var rarities = DotaApiClient.GetCosmeticRaritiesAsync(lang: lang)
                .Result;
            SleepAfterSendingRequest();

            foreach (string item in locNames)
            {
                Assert.Contains(rarities, rarity => rarity.LocalizedName == item);
            }
        }


        [Theory]
        [InlineData(6666)]
        [InlineData(5613)]
        [InlineData(5614)]
        [InlineData(5615)]
        public void GetItemCreators_ItemDefsWithCreatorsProvided_ReturnsItemCreators(uint itemDef)
        {
            var creators = DotaApiClient.GetItemCreatorsAsync(itemDef).Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(creators);
        }


        [Theory]
        [InlineData(418)]
        [InlineData(419)]
        [InlineData(420)]
        [InlineData(421)]
        public void GetItemCreators_ItemDefsWithNoCreatorsProvided_ReturnsEmptyCreators(uint itemDef)
        {
            var creators = DotaApiClient.GetItemCreatorsAsync(itemDef).Result;
            SleepAfterSendingRequest();

            Assert.Empty(creators);
        }


        [Theory]
        [InlineData("infinite_waves_shoulder")]
        [InlineData("arms_of_the_onyx_crucible_weapon")]
        [InlineData("dark_artistry_hair_model")]
        [InlineData("hollow_ripper")]
        [InlineData("the_rogue_omen_sword")]
        public void GetItemIconPath_ItemDefProvided_ReturnsCDNPath(string itemDef)
        {
            string iconPath = DotaApiClient.GetItemIconPathAsync(itemDef)
                .Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(iconPath);
            Assert.StartsWith("icons/econ", iconPath);
        }


        [Theory]
        [InlineData("infinite_waves_shoulder", 0)]
        [InlineData("arms_of_the_onyx_crucible_weapon", 1)]
        [InlineData("hollow_ripper", 3)]
        [InlineData("the_rogue_omen_sword", 1)]
        public void GetItemIconPath_ItemDefAndSizeProvided_ReturnsCDNPath(string itemDef,
            byte iconType)
        {
            string iconPath = DotaApiClient.GetItemIconPathAsync(itemDef, iconType: iconType)
                .Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(iconPath);
            Assert.StartsWith("icons/econ", iconPath);
        }


        [Fact]
        public void GetItemIconPath_ItemDefAndInvalidTypeProvided_ThrowsException()
        {
            Assert.Throws<AggregateException>(() =>
            {
                string iconPath = DotaApiClient.GetItemIconPathAsync("dark_artistry_hair_model",
                    iconType: 2)
                .Result;
            });
            SleepAfterSendingRequest();
        }


        [Theory]
        [InlineData(76561198107435620, 1)]
        [InlineData(76561198038389598, 20)]
        [InlineData(76561198038389598, 8)]
        [InlineData(76561198038389598, 88)]
        public void GetEquipedPlayerItems_ValidPlayerId_ReturnsPlayersEquipedItems(ulong id,
            byte heroId)
        {
            var items = DotaApiClient.GetEquipedPlayerItemsAsync(id, heroId).Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(items);
        }


        [Fact]
        public void GetEquipedPlayerItems_PrivateAccount_Returns()
        {
            var items = DotaApiClient.GetEquipedPlayerItemsAsync(76561198059119066, 1).Result;
            SleepAfterSendingRequest();

            Assert.Empty(items);
        }


        [Theory]
        [InlineData(76561198107435620)]
        [InlineData(76561198038389598)]
        public void GetPlayerItems_ValidPlayerId_ReturnsPlayersItems(ulong id)
        {
            var items = DotaApiClient.GetPlayerItemsAsync(id)
                .Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(items.Items);
            foreach (var item in items.Items)
            {
                Assert.NotEqual((ulong)0, item.Id);
            }
        }


        [Fact]
        public void GetPlayerItems_PrivateInventory_ReturnsWithStatus15()
        {
            var items = DotaApiClient.GetPlayerItemsAsync(76561198059119066)
                .Result;
            SleepAfterSendingRequest();
            Assert.Equal((uint)15, items.Status);
        }


        [Fact]
        public void GetSchemaUr_DefaultParams_ReturnsSchemaUrl()
        {
            string schema = DotaApiClient.GetSchemaUrlAsync()
                .Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(schema);
        }


        [Fact]
        public void GetStoreMetadata_DefaultParams_ReturnsStoreMetaData()
        {
            var metaData = DotaApiClient.GetStoreMetadataAsync()
                .Result;
            SleepAfterSendingRequest();

            Assert.NotNull(metaData.DropDownData);
            Assert.NotNull(metaData.Filters);
            Assert.NotNull(metaData.HomePageData);
            Assert.NotNull(metaData.PlayerClassData);
            Assert.NotNull(metaData.Sorting);
            Assert.NotNull(metaData.Tabs);
        }
    }
}
