﻿using Xunit;

namespace Client.Dota
{
    public class GetMatchDetails_Tests : ApiTests
    {
        /// <summary>
        /// Setup
        /// </summary>
        public GetMatchDetails_Tests(ClientFixture fixture) : base(fixture) { }


        [Theory]
        [InlineData(5215439388)]
        [InlineData(5214286157)]
        [InlineData(5214240197)]
        [InlineData(5211180398)]
        [InlineData(5202107556)]
        [InlineData(5200756005)]
        public void ValidMatchIds_ReturnsCorrectMatches(ulong matchId)
        {
            var details = DotaApiClient.GetMatchDetailsAsync(matchId)
                .Result;
            SleepAfterSendingRequest();

            Assert.Equal(matchId, details.MatchId);
        }


        [Fact]
        public void GetRealTimeMatchStats_LiveGamesAvailable_RealTimeMatchStats()
        {
            var result = DotaApiClient.GetTopLiveGamesAsync().Result;
            SleepAfterSendingRequest();
            foreach (var liveGame in result)
            {
                var matchStats = DotaApiClient.GetRealtimeMatchStatsAsync(liveGame.ServerSteamId.ToString())
                    .Result;
                SleepAfterSendingRequest();

                Assert.NotNull(matchStats);
            }
        }
    }
}
