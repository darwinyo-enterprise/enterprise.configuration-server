using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.Constants.NetStandard;
using Enterprise.MockData.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.MockData
{
    public class IntegratedAppsMock
    {
        public IEnumerable<IntegratedApp> GetIntegratedApp()
        {
            return new List<IntegratedApp>
            {
                new IntegratedApp
                {
                    ID=IDMock.IA_ConfigurationServerID,
                    ProjectID=IDMock.P_ConfigurationServerID,
                    ApplicationName=ApplicationNames.ConfigurationServer,
                    ApplicationURL="https://localhost:44309/",
                    Integrated=true,
                    CoreFeature=true
                },
                new IntegratedApp
                {
                    ID=IDMock.IA_LoggingServerID,
                    ProjectID=IDMock.P_LoggingServerID,
                    ApplicationName=ApplicationNames.LoggingServer,
                    ApplicationURL="https://localhost:44387/",
                    Integrated=true,
                    CoreFeature=true
                },
                new IntegratedApp
                {
                    ID=IDMock.IA_AuthorizationServerID,
                    ProjectID=IDMock.P_AuthorizationServerID,
                    ApplicationName=ApplicationNames.AuthorizationServer,
                    ApplicationURL="https://localhost:44375/",
                    Integrated=true,
                    CoreFeature=true
                },
                new IntegratedApp
                {
                    ID=IDMock.IA_ECommerce_ResourceServerID,
                    ProjectID=IDMock.P_ECommerceID,
                    ApplicationName=ApplicationNames.ECommerce_ResourceServer,
                    ApplicationURL="https://localhost:44310/",
                    Integrated=true,
                    CoreFeature=false
                },
                new IntegratedApp
                {
                    ID=IDMock.IA_ECommerce_WebClientID,
                    ProjectID=IDMock.P_ECommerceID,
                    ApplicationName=ApplicationNames.ECommerce_WebClient,
                    ApplicationURL="http://localhost:4200/",
                    Integrated=true,
                    CoreFeature=false
                },
            };
        }
    }
}
