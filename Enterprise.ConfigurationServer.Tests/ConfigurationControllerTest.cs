using Enterprise.Fixtures.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Enterprise.ConfigurationServer.Tests
{
    [CollectionDefinition("Configuration Test Collection")]
    public class ConfigurationControllerTest : ICollectionFixture<AuthorizationServiceFixture>, ICollectionFixture<ConfigurationServiceFixture>, ICollectionFixture<ConfigurationDBContextFixture>
    {
    }
}
