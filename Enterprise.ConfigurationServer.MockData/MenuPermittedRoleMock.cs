using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.MockData.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.MockData
{
    public class MenuPermittedRoleMock
    {
        public IEnumerable<MenuPermittedRole> GetMenuPermittedRole()
        {
            return new List<MenuPermittedRole>
            {
                // Admin Area By Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_AdminArea_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_AdminAreaID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // Admin Area By E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_AdminArea_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_AdminAreaID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },

                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageCategories_EnterpriseAdmin,
                    AppMenuID=null,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageCategoriesID
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageCategories_ECommerceAdmin,
                    AppMenuID=null,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageCategoriesID
                },

                 // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageInventory_EnterpriseAdmin,
                    AppMenuID=null,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageInventoryID
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageInventory_ECommerceAdmin,
                    AppMenuID=null,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageInventoryID
                },

                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageManufacturer_EnterpriseAdmin,
                    AppMenuID=null,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageManufacturerID
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageManufacturer_ECommerceAdmin,
                    AppMenuID=null,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageManufacturerID
                },
                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageProducts_EnterpriseAdmin,
                    AppMenuID=null,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageProductsID
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageProducts_ECommerceAdmin,
                    AppMenuID=null,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageProductsID
                },

                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageCategories_AddCategories_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageCategories_AddCategoriesID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageCategories_AddCategories_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageCategories_AddCategoriesID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },

                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageCategories_ListCategories_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageCategories_ListCategoriesID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageCategories_ListCategories_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageCategories_ListCategoriesID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },

                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageInventory_AddInventory_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageInventory_AddInventoryID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageInventory_AddInventory_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageInventory_AddInventoryID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },
                
                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageInventory_ListInventory_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageInventory_ListInventoryID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageInventory_ListInventory_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageInventory_ListInventoryID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },

                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageManufacturer_AddManufacturer_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageManufacturer_AddManufacturerID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageManufacturer_AddManufacturer_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageManufacturer_AddManufacturerID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },
                
                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageManufacturer_ListManufacturer_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageManufacturer_ListManufacturerID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageManufacturer_ListManufacturer_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageManufacturer_ListManufacturerID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },

                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageProducts_AddProducts_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageProducts_AddProductsID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageProducts_AddProducts_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageProducts_AddProductsID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },

                // Enterprise Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageProducts_ListProducts_EnterpriseAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageProducts_ListProductsID,
                    ApplicationRolesID=IDMock.R_Enterprise_Admin,
                    AppMenuCategoryID=null
                },

                // E-Commerce Admin Role
                new MenuPermittedRole
                {
                    ID=IDMock.MPR_ECommerce_WebClient_ManageProducts_ListProducts_ECommerceAdmin,
                    AppMenuID=IDMock.M_ECommerce_WebClient_ManageProducts_ListProductsID,
                    ApplicationRolesID=IDMock.R_ECommerce_Admin,
                    AppMenuCategoryID=null
                },
            };
        }
    }
}
