using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.MockData.NetStandard;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.MockData
{
    public class AppMenuMock
    {
        public IEnumerable<AppMenu> GetAppMenu()
        {
            return new List<AppMenu>
            {
#region Main Menu
                 new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_HomeID,
                    AppMenuCategoryID=null,
                    AppMenuLayoutID=null,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    MenuHref=@"/home",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuOrder=1,
                    MainMenu=true,
                    MenuTitle="Home"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_OurServicesID,
                    AppMenuCategoryID=null,
                    AppMenuLayoutID=null,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    MenuHref=@"/our-services",
                    MenuIcon="home",
                    MenuOrder=2,
                    MainMenu=true,
                    MenuNotification=0,
                    MenuTitle="Our Services"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_AboutUsID,
                    AppMenuCategoryID=null,
                    AppMenuLayoutID=null,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    MenuHref=@"/about-us",
                    MenuOrder=3,
                    MainMenu=true,
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="About Us"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ContactUsID,
                    AppMenuCategoryID=null,
                    AppMenuLayoutID=null,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    MenuHref=@"/contact-us",
                    MenuOrder=4,
                    MainMenu=true,
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Contact Us"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_CareersID,
                    AppMenuCategoryID=null,
                    AppMenuLayoutID=null,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    MenuHref=@"/careers",
                    MenuOrder=5,
                    MainMenu=false,
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Careers"
                },
                #endregion

#region Not Main Menu
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_InvestorRelationsID,
                    AppMenuCategoryID=null,
                    AppMenuLayoutID=null,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    MenuHref=@"/investor-relations",
                    MenuOrder=6,
                    MainMenu=false,
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Investor Relations"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_AdminAreaID,
                    AppMenuCategoryID=null,
                    AppMenuLayoutID=null,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    MenuOrder=7,
                    MainMenu=false,
                    MenuHref=@"/admin",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Admin Area"
                },
	#endregion
                
#region Get Assistance
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_GetAssistance_OrdersID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_GetAssistanceID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=null,
                    MenuOrder=1,
                    MainMenu=false,
                    MenuHref=@"/get-assistance/orders",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Orders"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_GetAssistance_ProductsID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_GetAssistanceID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=null,
                    MenuOrder=2,
                    MainMenu=false,
                    MenuHref=@"/get-assistance/products",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Products"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_GetAssistance_ShippingsID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_GetAssistanceID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=null,
                    MenuOrder=3,
                    MainMenu=false,
                    MenuHref=@"/get-assistance/shippings",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Shippings"
                },
                #endregion

#region Admin Layout Menu
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_DashboardID,
                    AppMenuCategoryID=null,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    MenuOrder=1,
                    MainMenu=false,
                    MenuHref=@"/admin/dashboard",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Dashboard"
                },
	#endregion

                #region Manage Categories
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ManageCategories_AddCategoriesID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageCategoriesID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    MenuOrder=1,
                    MainMenu=false,
                    MenuHref=@"/admin/manage-category/add",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Add Category"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ManageCategories_ListCategoriesID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageCategoriesID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                     MenuOrder=2,
                    MainMenu=false,
                    MenuHref=@"/admin/manage-category/list",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="List Categories"
                },
                #endregion

#region Manage Inventory
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ManageInventory_AddInventoryID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageInventoryID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    MenuOrder=1,
                    MainMenu=false,
                    MenuHref=@"/admin/manage-inventory/add",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Add Inventory"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ManageInventory_ListInventoryID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageInventoryID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    MenuOrder=2,
                    MainMenu=false,
                    MenuHref=@"/admin/manage-inventory/list",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="List Inventories"
                },
                #endregion

#region Manage Manufacturer
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ManageManufacturer_AddManufacturerID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageManufacturerID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    MenuOrder=1,
                    MainMenu=false,
                    MenuHref=@"/admin/manage-manufacturer/add",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Add Manufacturer"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ManageManufacturer_ListManufacturerID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageManufacturerID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    MenuOrder=2,
                    MainMenu=false,
                    MenuHref=@"/admin/manage-manufacturer/list",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="List Manufacturers"
                },
                #endregion

#region ManageProduct
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ManageProducts_AddProductsID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageProductsID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    MenuOrder=1,
                    MainMenu=false,
                    MenuHref=@"/admin/manage-product/add",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="Add Product"
                },
                new AppMenu
                {
                    ID=IDMock.M_ECommerce_WebClient_ManageProducts_ListProductsID,
                    AppMenuCategoryID=IDMock.MC_ECommerce_WebClient_ManageProductsID,
                    IntegratedAppID=IDMock.IA_ECommerce_WebClientID,
                    AppMenuLayoutID=IDMock.ML_ECommerce_WebClient_AdminLayoutID,
                    MenuOrder=2,
                    MainMenu=false,
                    MenuHref=@"/admin/manage-product/list",
                    MenuIcon="home",
                    MenuNotification=0,
                    MenuTitle="List Products"
                },
	#endregion
                
            };
        }
    }
}
