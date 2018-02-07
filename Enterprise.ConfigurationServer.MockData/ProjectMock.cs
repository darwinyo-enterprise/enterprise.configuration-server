using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.Constants.NetStandard;
using Enterprise.MockData.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.MockData
{
    public class ProjectMock
    {
        public IEnumerable<Project> GetProject()
        {
            return new List<Project>
            {
                new Project
                {
                    ID=IDMock.P_AuthorizationServerID,
                    ProjectName=ProjectNames.AuthorizationServer,
                    ProjectVersion="0.0.0",
                    Description="Responsible for Authenticate, Authorized, Manage User Info, and Manage All Apps Auth."
                },
                new Project
                {
                    ID=IDMock.P_ConfigurationServerID,
                    ProjectName=ProjectNames.ConfigurationServer,
                    ProjectVersion="0.0.0",
                    Description="Responsible for Manage Config setting for All Apps."
                },
                new Project
                {
                    ID=IDMock.P_LoggingServerID,
                    ProjectName=ProjectNames.LoggingServer,
                    ProjectVersion="0.0.0",
                    Description="Responsible for Log All Event within All Apps."
                },
                new Project
                {
                    ID=IDMock.P_ECommerceID,
                    ProjectName=ProjectNames.ECommerce,
                    ProjectVersion="0.0.0",
                    Description="Enterprise Level E-Commerce Platform."
                }
            };
        }
    }
}
