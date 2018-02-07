using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.MockData.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.MockData
{
    public class AppMenuCategoryMock
    {
        public IEnumerable<AppMenuCategory> GetAppMenuCategory()
        {
            return new List<AppMenuCategory>
            {
                new AppMenuCategory
                {
                      ID=IDMock.MC_ECommerce_WebClient_GetAssistanceID,
                      AppMenuLayoutID=null,
                      MenuCategoryOrder=1,
                      IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                      MenuCategory="Get Assistance"
                },
                new AppMenuCategory
                {
                      ID=IDMock.MC_ECommerce_WebClient_ManageCategoriesID,
                      AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                      IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                      MenuCategoryOrder=1,
                      MenuCategory="Manage Categories"
                },
                new AppMenuCategory
                {
                      ID=IDMock.MC_ECommerce_WebClient_ManageInventoryID,
                      AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                      IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                      MenuCategoryOrder=2,
                      MenuCategory="Manage Inventories"
                },
                new AppMenuCategory
                {
                      ID=IDMock.MC_ECommerce_WebClient_ManageManufacturerID,
                      AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                      IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                      MenuCategoryOrder=3,
                      MenuCategory="Manage Manufacturers"
                },
                new AppMenuCategory
                {
                      ID=IDMock.MC_ECommerce_WebClient_ManageProductsID,
                      AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                      IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                      MenuCategoryOrder=4,
                      MenuCategory="Manage Products"
                },
            };
        }
    }
}
