using Enterprise.Abstract.NetStandard;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.ConfigurationServer.MockData;
using Enterprise.Constants.NetStandard;
using Enterprise.Fixtures.NetStandard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Enterprise.ConfigurationServer.Tests
{
    [Collection("Configuration Test Collection")]
    public class URLConfigurationControllerTest : BaseTest
    {
        public URLConfigurationControllerTest(AuthorizationServiceFixture authorizationServiceFixture, ConfigurationServiceFixture configurationServiceFixture)
        {
            _authorizationServiceFixture = authorizationServiceFixture;
            _configurationServiceFixture = configurationServiceFixture;
            StartUp();
        }
        #region Fields
        private readonly ConfigurationServiceFixture _configurationServiceFixture;
        private readonly AuthorizationServiceFixture _authorizationServiceFixture;

        private IntegratedAppsMock _integratedAppsMock;

        private const string clientID = ClientIDs.configurationserver_testclient;
        private const string secret = ClientSecrets.configurationserver_testclient;
        private const string scope = ConfigurationServerScopes.full_access;
        private string accessToken;
        #endregion

        #region Overrides
        public override void InitVariables()
        {
            accessToken = _authorizationServiceFixture.AuthorizationService.CreateAccessTokenAsync(clientID, secret, scope).Result;
        }
        public override void InitMockData()
        {
            _integratedAppsMock = new IntegratedAppsMock();
        }
        #endregion

        [Fact]
        public async Task Get_WhenNoParameterPassed_GetAllUrlsConfiguration()
        {
            // Action
            var result = (List<IntegratedApp>)await _configurationServiceFixture.ConfigurationService.GetAllURLConfigurationAsync(accessToken);
            Assert.NotEmpty(result);

            var expectedList = (List<IntegratedApp>)_integratedAppsMock.GetIntegratedApp();

            Assert.Equal(result[0].ApplicationURL, expectedList[0].ApplicationURL);
            Assert.Equal(result[0].Integrated, expectedList[0].Integrated);
            Assert.Equal(result[0].ApplicationName, expectedList[0].ApplicationName);
        }
        [Fact]
        public async Task Put_WhenParameterPassedCorrectly_UpdateSuccessfully()
        {
            // Action
            var result = ((List<IntegratedApp>)await _configurationServiceFixture.ConfigurationService.GetAllURLConfigurationAsync(accessToken));
            var item = result.First();

            string ItemURL = item.ApplicationURL;
            string ItemId = item.ID.ToString();
            bool ItemIntegrated = item.Integrated;

            string itemURLChanged = ItemURL + "Changed";

            item.ApplicationURL = itemURLChanged;

            // Action
            await _configurationServiceFixture.ConfigurationService.UpdateURLConfigurationAsync(ItemId, item, accessToken);

            result = (List<IntegratedApp>)await _configurationServiceFixture.ConfigurationService.GetAllURLConfigurationAsync(accessToken);
            item = result.Where(x => x.ID == new Guid(ItemId)).First();

            // Assert
            Assert.Equal(itemURLChanged, item.ApplicationURL);
            Assert.Equal(ItemIntegrated, item.Integrated);

            // Rollback
            item.ApplicationURL = ItemURL;
            await _configurationServiceFixture.ConfigurationService.UpdateURLConfigurationAsync(ItemId, item, accessToken);

            // Make Sure Rollback Successful
            result = (List<IntegratedApp>)await _configurationServiceFixture.ConfigurationService.GetAllURLConfigurationAsync(accessToken);

            item = result.Where(x => x.ID == new Guid(ItemId)).SingleOrDefault();

            Assert.Equal(ItemURL, item.ApplicationURL);
            Assert.Equal(ItemIntegrated, item.Integrated);
        }
        [Fact]
        public async Task Put_WhenIdParameterInvalid_ThrowItemNotFound()
        {
            string ItemId = Guid.NewGuid().ToString();

            var item = new IntegratedApp();

            // Action & Assert
            string expectedMessage = JsonConvert.SerializeObject(new { error = ExceptionMessage.ITEM_NOT_FOUND });
            var response = await _configurationServiceFixture.ConfigurationService.UpdateURLConfigurationAsync(ItemId, item, accessToken);

            Assert.Equal(expectedMessage, response.Content.ReadAsStringAsync().Result);
        }
        [Fact]
        public async Task Put_WhenValueParameterInvalid_ThrowArgumentCantBeNull()
        {
            // Action
            var result = ((List<IntegratedApp>)await _configurationServiceFixture.ConfigurationService.GetAllURLConfigurationAsync(accessToken));
            var item = result.First();

            string ItemId = item.ID.ToString();

            // Action & Assert
            string expectedMessage = JsonConvert.SerializeObject(new { error = ExceptionMessage.URL_CONFIGURATION_VALUE_CANT_BE_NULL });
            var response = await _configurationServiceFixture.ConfigurationService.UpdateURLConfigurationAsync(ItemId, null, accessToken);

            Assert.Equal(expectedMessage, response.Content.ReadAsStringAsync().Result);
        }
        [Fact]
        public async Task Put_WhenValueParameterInvalid_ThrowNoChangesToUpdate()
        {
            // Action
            var result = ((List<IntegratedApp>)await _configurationServiceFixture.ConfigurationService.GetAllURLConfigurationAsync(accessToken));
            var item = result.First();

            string ItemId = item.ID.ToString();

            // Action & Assert
            string expectedMessage = JsonConvert.SerializeObject(new { error = ExceptionMessage.NO_CHANGES_TO_UPDATE });
            var response = await _configurationServiceFixture.ConfigurationService.UpdateURLConfigurationAsync(ItemId, item, accessToken);

            Assert.Equal(expectedMessage, response.Content.ReadAsStringAsync().Result);
        }
    }
}
