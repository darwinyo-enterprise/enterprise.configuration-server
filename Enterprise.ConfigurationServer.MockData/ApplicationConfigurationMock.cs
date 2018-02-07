using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.MockData.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.MockData
{
    public class ApplicationConfigurationMock
    {
        public IEnumerable<ApplicationConfiguration> GetApplicationConfiguration()
        {
            return new List<ApplicationConfiguration>
            {
                new ApplicationConfiguration
                {
                    IntegratedAppID=IDMock.IA_AuthorizationServerID,
                    ID=Guid.NewGuid(),
                    Key="Private Key",
                    Values="P@ssw0rd"
                },
                new ApplicationConfiguration
                {
                    IntegratedAppID=IDMock.IA_ConfigurationServerID,
                    ID=Guid.NewGuid(),
                    Key="Private Key",
                    Values="P@ssw0rd"
                },
                new ApplicationConfiguration
                {
                    IntegratedAppID=IDMock.IA_ECommerce_ResourceServerID,
                    ID=Guid.NewGuid(),
                    Key="Private Key",
                    Values="P@ssw0rd"
                },
                new ApplicationConfiguration
                {
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    ID=Guid.NewGuid(),
                    Key="Private Key",
                    Values="P@ssw0rd"
                },
                new ApplicationConfiguration
                {
                    IntegratedAppID=IDMock.IA_LoggingServerID,
                    ID=Guid.NewGuid(),
                    Key="Private Key",
                    Values="P@ssw0rd"
                },
            };
        }
    }
}
