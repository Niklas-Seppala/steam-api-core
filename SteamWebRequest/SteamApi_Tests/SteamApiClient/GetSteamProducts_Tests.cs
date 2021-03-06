﻿using Xunit;
using SteamApi;

namespace Client.Steam
{
    public class GetSteamProducts_Tests : ApiTests
    {
        /// <summary>
        /// Setup
        /// </summary>
        public GetSteamProducts_Tests(ClientFixture fixture) : base(fixture) {}


        /// <summary>
        /// Test case for all products requested. Method should return all
        /// products wrapped into ApiResponse object.
        /// </summary>
        [Fact]
        public void CallSizeAll_ReturnsNoProducts()
        {
            var response = SteamApiClient.GetSteamProductsAsync(IncludeProducts.GameProducs, callSize: ProductCallSize.All)
                .Result;

            Assert.True(response.Contents.Count > (int)ProductCallSize.Max);
        }


        /// <summary>
        /// Test case where product call size is defined.
        /// Mehtod should return correct amount of products
        /// wrapped into ApiResponse object.
        /// </summary>
        /// <param name="callSize">product call size</param>
        [Theory]
        [InlineData(ProductCallSize.Large)]
        [InlineData(ProductCallSize.Medium)]
        [InlineData(ProductCallSize.Max)]
        [InlineData(ProductCallSize.Small)]
        public void CallSizeDefined_ReturnsCorrectAmountOfProducs(ProductCallSize callSize)
        {
            var response = SteamApiClient.GetSteamProductsAsync(IncludeProducts.Games, callSize: callSize)
                .Result;
            SleepAfterSendingRequest();

            Assert.True((int)callSize >= response.Contents.Count);
        }


        /// <summary>
        /// Test case for IncludeProducts enum used as a set. Method should return
        /// both DLCs and Games wrapped into ApiResponse object.
        /// </summary>
        [Fact]
        public void ProductTypeUsedAsSet_ReturnsRequestedSteamProducts()
        {
            var response1 = SteamApiClient.GetSteamProductsAsync(IncludeProducts.GameProducs)
                .Result;
            SleepAfterSendingRequest();
            var response2 = SteamApiClient.GetSteamProductsAsync(IncludeProducts.DLC | IncludeProducts.Games)
                .Result;
            SleepAfterSendingRequest();

            for (int i = 0; i < response1.Contents.Count; i++)
            {
                Assert.True(response1.Contents[i].AppId == response2.Contents[i].AppId);
            }

        }


        /// <summary>
        /// Test case for all multiple product types included in the reqeust.
        /// Method should return requested products wrapped
        /// into ApiResponse object.
        /// </summary>
        /// <param name="products">product type</param>
        [Theory]
        [InlineData(IncludeProducts.All)]
        [InlineData(IncludeProducts.GameProducs)]
        [InlineData(IncludeProducts.Media)]
        public void MultipleProductTypes_ReturnsRequestedSteamProducts(IncludeProducts products)
        {
            var response = SteamApiClient.GetSteamProductsAsync(products)
                .Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(response.Contents);
            Assert.All(response.Contents, product => {
                Assert.True(product.AppId != 0);
                Assert.True(product.LastModified != 0);
            });
        }


        /// <summary>
        /// Test case for all single product types included in the reqeust.
        /// Method should return all requested products wrapped into
        /// ApiResponse object
        /// </summary>
        /// <param name="products">product type</param>
        [Theory]
        [InlineData(IncludeProducts.DLC)]
        [InlineData(IncludeProducts.Games)]
        [InlineData(IncludeProducts.Harware)]
        [InlineData(IncludeProducts.Software)]
        [InlineData(IncludeProducts.Videos)]
        public void SingleProductType_ReturnsRequestedSteamProducts(IncludeProducts products)
        {
            var response = SteamApiClient.GetSteamProductsAsync(products)
                .Result;
            SleepAfterSendingRequest();

            Assert.NotEmpty(response.Contents);
            Assert.All(response.Contents, product => {
                Assert.True(product.AppId != 0);
                Assert.True(product.LastModified != 0);
            });
        }
    }
}
