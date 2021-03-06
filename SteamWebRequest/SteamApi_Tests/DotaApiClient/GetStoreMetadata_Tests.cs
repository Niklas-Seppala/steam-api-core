﻿using SteamApi;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Client.Dota
{
    /// <summary>
    /// Test class for dota 2 api client's GetStoreMetadata method.
    /// </summary>
    public class GetStoreMetadata_Tests : ApiTests
    {
        /// <summary>
        /// Setup.
        /// </summary>
        public GetStoreMetadata_Tests(ClientFixture fixture) : base(fixture) { }


        /// <summary>
        /// Test case for request method being cancelled by CancellationToken.
        /// Method should return failed ApiResponse object that contains thrown
        /// cancellation exception.
        /// </summary>
        [Fact]
        public async Task MethodGotCancelled_RequestFails()
        {
            CancellationTokenSource source = new CancellationTokenSource();

            // Start task to be cancelled
            var task = Task.Run(async () =>
            {
                return await DotaApiClient.GetStoreMetadataAsync(cToken: source.Token);
            });

            // Cancel method
            source.Cancel();

            var response = await task;
            SleepAfterSendingRequest();

            AssertRequestWasCancelled(response);
            Assert.Null(response.Contents);
        }


        /// <summary>
        /// Test case for invalid API interface being provided.
        /// Method should return failed ApiResponse object where exception
        /// that caused failure is stored.
        /// </summary>
        [Fact]
        public void InvalidApiInterface_RequestFails()
        {
            var response = DotaApiClient.GetStoreMetadataAsync(apiInterface: "IDota_2_Heroe")
                .Result;
            SleepAfterSendingRequest();

            AssertRequestFailed(response);
            Assert.Null(response.Contents);
        }


        /// <summary>
        /// Test case for invalid API method version being provided.
        /// Method should return failed ApiResponse object where exception
        /// that caused failure is stored.
        /// </summary>
        [Fact]
        public void InvalidMethodVersion_RequestFails()
        {
            var response = DotaApiClient.GetStoreMetadataAsync(version: "v1.2.3")
                .Result;
            SleepAfterSendingRequest();

            AssertRequestFailed(response);
            Assert.Null(response.Contents);
        }


        [Fact]
        public void GetStoreMetadata_DefaultParams_ReturnsStoreMetaData()
        {
            var response = DotaApiClient.GetStoreMetadataAsync()
                .Result;
            SleepAfterSendingRequest();

            AssertRequestWasSuccessful(response);
            Assert.NotNull(response.Contents);
            Assert.NotNull(response.Contents.DropDownData);
            Assert.NotNull(response.Contents.Filters);
            Assert.NotNull(response.Contents.HomePageData);
            Assert.NotNull(response.Contents.PlayerClassData);
            Assert.NotNull(response.Contents.Sorting);
            Assert.NotNull(response.Contents.Tabs);
        }
    }
}
