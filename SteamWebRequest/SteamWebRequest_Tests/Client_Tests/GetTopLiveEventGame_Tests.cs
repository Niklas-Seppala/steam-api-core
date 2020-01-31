﻿using SteamApiClient.Dota;
using Xunit;

namespace SWR.Client_Tests
{
    public class GetTopLiveEventGame_Tests : SteamHttpClient_Tests
    {
        [Fact]
        public void DefaultParams_ReturnsTopLiveEventGames()
        {
            var topEventGames = _client.GetTopLiveEventGamesAsync()
                .Result;

            Assert.NotNull(topEventGames);
            Assert.NotEmpty(topEventGames);
        }
    }
}