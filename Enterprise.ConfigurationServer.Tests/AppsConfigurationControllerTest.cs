using Enterprise.Abstract.NetStandard;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.ConfigurationServer.DTO;
using Enterprise.ConfigurationServer.MockData;
using Enterprise.Constants.NetStandard;
using Enterprise.Fixtures.NetStandard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Enterprise.ConfigurationServer.Tests
{
    [Collection("Configuration Test Collection")]
    public class AppsConfigurationControllerTest : BaseTest
    {
        #region Fields
        private readonly ConfigurationServiceFixture _configurationServiceFixture;
        private readonly AuthorizationServiceFixture _authorizationServiceFixture;

        private ApplicationConfigurationMock _applicationConfigurationMock;

        private const string clientID = ClientIDs.configurationserver_testclient;
        private const string secret = ClientSecrets.configurationserver_testclient;
        private const string scope = ConfigurationServerScopes.full_access;
        private string accessToken;
        #endregion
        public AppsConfigurationControllerTest(AuthorizationServiceFixture authorizationServiceFixture, ConfigurationServiceFixture configurationServiceFixture)
        {
            _authorizationServiceFixture = authorizationServiceFixture;
            _configurationServiceFixture = configurationServiceFixture;

            StartUp();
        }

        #region Overrides
        public override void InitVariables()
        {
            accessToken = _authorizationServiceFixture.AuthorizationService.CreateAccessTokenAsync(clientID, secret, scope).Result;
        }
        public override void InitMockData()
        {
            _applicationConfigurationMock = new ApplicationConfigurationMock();
        }
        #endregion

        [Fact]
        public async Task Get_WhenNoParameterPassed_GetAllConfigurationDTO()
        {
            // Action
            var result = (List<AppsConfigurationDTO>)await _configurationServiceFixture.ConfigurationService.GetAllConfigurationDTOAsync(accessToken);
            Assert.NotEmpty(result);

            var expectedList = (List<ApplicationConfiguration>)_applicationConfigurationMock.GetApplicationConfiguration();

            Assert.Equal(result[0].Key, expectedList[0].Key);
            Assert.Equal(result[0].Values, expectedList[0].Values);
        }
        [Fact]
        public async Task Put_WhenParameterPassedCorrectly_UpdateSuccessfully()
        {
            var items = await _configurationServiceFixture.ConfigurationService.GetAllConfigurationDTOAsync(accessToken);

            var item = ((List<AppsConfigurationDTO>)items)[0];

            // Store Before Changed
            string ItemId = item.ID.ToString();
            string ItemKey = item.Key;
            string ItemValue = item.Values;

            // Change Item
            string ChangedItemValue = ItemValue + "Tests";

            // Action
            await _configurationServiceFixture.ConfigurationService.UpdateConfigurationAsync(ItemId, ChangedItemValue, accessToken);

            // Reselect
            items = await _configurationServiceFixture.ConfigurationService.GetAllConfigurationDTOAsync(accessToken);

            var actual = items.Where(x => x.ID == new Guid(ItemId)).SingleOrDefault();

            // Assert
            Assert.Equal(ChangedItemValue, actual.Values);

            // Rollback
            await _configurationServiceFixture.ConfigurationService.UpdateConfigurationAsync(ItemId, ItemValue, accessToken);

            // Make Sure Rollback Successful
            items = await _configurationServiceFixture.ConfigurationService.GetAllConfigurationDTOAsync(accessToken);

            actual = items.Where(x => x.ID == new Guid(ItemId)).SingleOrDefault();

            Assert.Equal(ItemValue, actual.Values);
        }

        [Fact]
        public async Task Put_WhenIDParameterPassedInvalid_ThrowItemNotFound()
        {
            // Store Before Changed
            string ItemId = Guid.NewGuid().ToString();

            // Change Item
            string ChangedItemValue = "Tests";

            // Action & Assert
            string expectedMessage = JsonConvert.SerializeObject(new { error = ExceptionMessage.ITEM_NOT_FOUND });
            var response = await _configurationServiceFixture.ConfigurationService.UpdateConfigurationAsync(ItemId, ChangedItemValue, accessToken);

            Assert.Equal(expectedMessage, response.Content.ReadAsStringAsync().Result);
        }
        [Fact]
        public async Task Put_WhenValueParameterPassedNull_ThrowArgumentCantNull()
        {
            var items = await _configurationServiceFixture.ConfigurationService.GetAllConfigurationDTOAsync(accessToken);

            var item = ((List<AppsConfigurationDTO>)items)[0];

            // Store Before Changed
            string ItemId = item.ID.ToString();

            // Action & Assert
            string expectedMessage = JsonConvert.SerializeObject(new { error = ExceptionMessage.CONFIGURATION_VALUE_CANT_BE_NULL });
            var response = await _configurationServiceFixture.ConfigurationService.UpdateConfigurationAsync(ItemId, null, accessToken);

            Assert.Equal(expectedMessage, response.Content.ReadAsStringAsync().Result);
        }
        [Fact]
        public async Task Put_WhenValueParameterPassedEqualExistingValue_ThrowNoChangesToUpdate()
        {
            var items = await _configurationServiceFixture.ConfigurationService.GetAllConfigurationDTOAsync(accessToken);

            var item = ((List<AppsConfigurationDTO>)items)[0];

            // Store Before Changed
            string ItemId = item.ID.ToString();

            // Action & Assert
            string expectedMessage = JsonConvert.SerializeObject(new { error = ExceptionMessage.NO_CHANGES_TO_UPDATE });
            var response = await _configurationServiceFixture.ConfigurationService.UpdateConfigurationAsync(ItemId, item.Values, accessToken);

            Assert.Equal(expectedMessage, response.Content.ReadAsStringAsync().Result);
        }
    }
}
