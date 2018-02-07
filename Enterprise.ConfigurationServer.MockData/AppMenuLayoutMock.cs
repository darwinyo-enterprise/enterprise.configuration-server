using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.MockData.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.MockData
{
    public class AppMenuLayoutMock
    {
        public IEnumerable<AppMenuLayout> GetAppMenuLayout()
        {
            return new List<AppMenuLayout>
            {
                new AppMenuLayout
                {
                    ID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    LayoutName="E-Commerce.WebClient.AdminLayout",
                    Description="E-Commerce Web Client Admin Layout Scope Menu"
                }
            };
        }
    }
}
