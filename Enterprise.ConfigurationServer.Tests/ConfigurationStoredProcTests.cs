using Enterprise.Abstract.NetStandard;
using Enterprise.ConfigurationServer.Interfaces.ConfigurationDB;
using Enterprise.ConfigurationServer.MockData;
using Enterprise.Constants.NetStandard;
using Enterprise.Fixtures.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Enterprise.ConfigurationServer.Tests
{
    [Collection("Configuration Test Collection")]
    public class ConfigurationStoredProcTests : BaseTest
    {
        #region Fields
        private readonly ConfigurationDBContextFixture _configurationDBContextFixture;

        private AppMenuMock _appMenuMock;
        #endregion

        #region Overrides
        public override void InitMockData()
        {
            _appMenuMock = new AppMenuMock();

        }
        #endregion
        /// <summary>
        /// This Tests Directly Call Library rather than call services.
        /// so this test doesnt need authorization.
        /// </summary>
        /// <param name="configurationServiceFixture"></param>
        public ConfigurationStoredProcTests(ConfigurationDBContextFixture configurationDBContextFixture)
        {
            _configurationDBContextFixture = configurationDBContextFixture;
            
            StartUp();
        }

        [Fact]
        public async Task ReturnStringArr_WhenStoredProcCalledAndThatMenuHasRolesDefined()
        {
            var select = _configurationDBContextFixture.ConfigurationDBContext.AppMenus.ToList();

            var permittedRoles = _configurationDBContextFixture.ConfigurationDBContext.MenuPermittedRoles.ToList();
            
            var firstAppMenuThatHasPermittedRole = select.Where(x => x.MenuPermittedRoles != null).FirstOrDefault();
            var roles = _configurationDBContextFixture.ConfigurationDBContext.GetAllAppMenuRoleByMenuID(firstAppMenuThatHasPermittedRole.ID);

            Assert.NotEmpty(roles);
        }
        [Fact]
        public async Task ReturnStringArrEmpty_WhenStoredProcCalledAndThatMenuNoRolesDefined()
        {
            var appMenus = _appMenuMock.GetAppMenu();

            var firstAppMenuThatNoPermittedRole = appMenus.Where(x => x.MenuPermittedRoles == null).FirstOrDefault();
            var roles = _configurationDBContextFixture.ConfigurationDBContext.GetAllAppMenuRoleByMenuID(firstAppMenuThatNoPermittedRole.ID);

            Assert.Empty(roles);
        }
    }
}
