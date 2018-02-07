using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise.ConfigurationServer.Interfaces.ConfigurationDB;
using Enterprise.Constants.NetStandard;
using Enterprise.Enums.NetStandard;
using Enterprise.Interfaces.NetStandard.Services;
using Enterprise.Models.NetStandard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Enterprise.Extension.NetStandard;
using Enterprise.ConfigurationServer.DTO;
using Enterprise.ActionResults.NetStandard;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.ConfigurationServer.Controllers
{
    [Route("api/[controller]")]
    public class AppsMenuController : Controller
    {
        private readonly IConfigurationDBUnitOfWork _configurationDBUnitOfWork;
        #region Template
        private readonly ILoggingServices _loggingServices;
        private readonly LogModel logModel;
        private readonly UserScopesModel userScopesModel;
        #endregion

        public AppsMenuController(IConfigurationDBUnitOfWork configurationDBUnitOfWork, ILoggingServices loggingServices)
        {
            _configurationDBUnitOfWork = configurationDBUnitOfWork;

            #region Template
            _loggingServices = loggingServices;

            logModel = new LogModel();
            userScopesModel = new UserScopesModel(HttpContext);
            logModel.SetModel(userScopesModel.Subject.ToString(), userScopesModel.Name, nameof(AppsMenuController), ApplicationNames.ConfigurationServer, LogTypeEnum.Info);
            #endregion
        }
        // GET: api/<controller>
        [HttpGet]
        public string[] Get()
        {
            return _configurationDBUnitOfWork.ConfigurationDBContext.GetAllAppMenuRoleByMenuID(new Guid("a722f486-926a-47f7-9699-c35f31858b92"));
        }

        /// <summary>
        /// Get All Application Menu By Application ID.
        /// Direct menu, where has no parent category, General Menu.
        /// Wont be Restricted, All Menu Controlled By Front End.
        /// </summary>
        /// <param name="id">
        /// app id
        /// </param>
        /// <returns>
        /// AppMenuDTO used in front end
        /// </returns>
        // GET api/<controller>/5
        [HttpGet("app-menu/{id}")]
        public async Task<IActionResult> GetAppMenuAsync(string id, bool? mainMenu)
        {
            IEnumerable<AppMenuDTO> appMenuDTO = null;
            try
            {
                logModel.LogMessage = "Front End Application Request Apps Menu by Application ID : " + id;
                await _loggingServices.LogAsync(logModel);

                // Request App Menu That Has Same App ID And Doesnt have Category
                var filteredMenu = await _configurationDBUnitOfWork.AppMenuRepository
                    .FindByAsync(x => x.IntegratedAppID.ToString() == id && x.AppMenuCategoryID == null && x.AppMenuLayout == null);

                // Filter If MainMenu Defined
                if (mainMenu.HasValue)
                {
                    filteredMenu = filteredMenu.Where(x => x.MainMenu == mainMenu);
                }

                // Process The Data Model And Ordering
                appMenuDTO = filteredMenu
                    .OrderBy(x => x.MenuOrder)
                    .Select(x => new AppMenuDTO
                    {
                        MenuTitle = x.MenuTitle,
                        MenuHref = x.MenuHref,
                        MenuIcon = x.MenuIcon,
                        MenuNotification = x.MenuNotification,
                        PermittedRoles = _configurationDBUnitOfWork.ConfigurationDBContext.GetAllAppMenuRoleByMenuID(x.ID)
                    }).ToList();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(appMenuDTO);
        }

        /// <summary>
        /// Used To Get All Category With Sub Menu for Front end, General Menu.
        /// </summary>
        /// <param name="id">
        /// App ID
        /// </param>
        /// <returns></returns>
        [HttpGet("menu-category/{id}")]
        public async Task<IActionResult> GetAppCategoryMenuAsync(string id)
        {
            IEnumerable<AppCategoryMenuDTO> categoryMenuDTO = null;
            try
            {
                // Logging
                logModel.LogMessage = "Front End Application Request Apps Category Menu by ID : " + id;
                await _loggingServices.LogAsync(logModel);

                // Filter Category Menu
                var filteredCategoryMenus = await _configurationDBUnitOfWork.AppMenuCategoryRepository.FindByAsync(x => x.IntegratedAppID.ToString() == id && x.AppMenuLayout == null);

                // Model Creation and ordering
                categoryMenuDTO = filteredCategoryMenus
                    .OrderBy(x => x.MenuCategoryOrder)
                    .Select(x =>
                    {
                        // Select All Menu Belongs this category
                        x.AppMenus = (ICollection<AppMenu>)_configurationDBUnitOfWork.AppMenuRepository.FindByAsync(y => y.AppMenuCategoryID == x.ID).Result;

                        return new AppCategoryMenuDTO
                        {
                            MenuCategory = x.MenuCategory,
                            MenuChild = x.AppMenus.Select(y => new AppMenuDTO
                            {
                                MenuTitle = y.MenuTitle,
                                MenuHref = y.MenuHref,
                                MenuIcon = y.MenuIcon,
                                MenuNotification = y.MenuNotification,
                                PermittedRoles = _configurationDBUnitOfWork.ConfigurationDBContext.GetAllAppMenuRoleByMenuID(y.ID)
                            }).ToArray(),
                            PermittedRoles = _configurationDBUnitOfWork.ConfigurationDBContext.GetAllAppCategoryMenuRoleByCategoryMenuID(x.ID)
                        };
                    }).ToList();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(categoryMenuDTO);
        }

        /// <summary>
        /// Get All Application Menu By Application ID.
        /// Direct menu, where has no parent category, By Layout Menu.
        /// Wont be Restricted, All Menu Controlled By Front End.
        /// </summary>
        /// <param name="id">
        /// layout id
        /// </param>
        /// <returns>
        /// AppMenuDTO used in front end
        /// </returns>
        // GET api/<controller>/5
        [HttpGet("app-menu/layout-id/{id}")]
        public async Task<IActionResult> GetAppMenuByLayoutIDAsync(string id)
        {
            IEnumerable<AppMenuDTO> appMenuDTO = null;
            try
            {
                logModel.LogMessage = "Front End Application Request Apps Menu by Layout ID : " + id;
                await _loggingServices.LogAsync(logModel);

                // Request App Menu That Has Same App ID And Doesnt have Category
                var filteredMenu = await _configurationDBUnitOfWork.AppMenuRepository
                    .FindByAsync(x => x.AppMenuCategory == null && x.AppMenuLayoutID == new Guid(id));

                // Process The Data Model
                appMenuDTO = filteredMenu
                    .OrderBy(x => x.MenuOrder)
                    .Select(x => new AppMenuDTO
                    {
                        MenuTitle = x.MenuTitle,
                        MenuHref = x.MenuHref,
                        MenuIcon = x.MenuIcon,
                        MenuNotification = x.MenuNotification,
                        PermittedRoles = _configurationDBUnitOfWork.ConfigurationDBContext.GetAllAppMenuRoleByMenuID(x.ID)
                    }).ToList();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(appMenuDTO);
        }

        /// <summary>
        /// Used To Get All Category With Sub Menu for Front end, By Layout Menu.
        /// </summary>
        /// <param name="id">
        /// Layout ID
        /// </param>
        /// <returns></returns>
        [HttpGet("menu-category/layout-id/{id}")]
        public async Task<IActionResult> GetAppCategoryMenuByLayoutIDAsync(string id)
        {
            IEnumerable<AppCategoryMenuDTO> categoryMenuDTO = null;
            try
            {
                // Logging
                logModel.LogMessage = "Front End Application Request Apps Category Menu by Layout ID : " + id;
                await _loggingServices.LogAsync(logModel);

                // Filter Category Menu
                var filteredCategoryMenus = await _configurationDBUnitOfWork.AppMenuCategoryRepository.FindByAsync(x => x.AppMenuLayoutID == new Guid(id));

                // Model Creation
                categoryMenuDTO = filteredCategoryMenus
                    .OrderBy(x => x.MenuCategoryOrder)
                    .Select(x =>
                    {
                        // Select All Menu Belongs this category
                        x.AppMenus = (ICollection<AppMenu>)_configurationDBUnitOfWork.AppMenuRepository.FindByAsync(y => y.AppMenuCategoryID == x.ID).Result;

                        return new AppCategoryMenuDTO
                        {
                            MenuCategory = x.MenuCategory,
                            MenuChild = x.AppMenus.Select(y => new AppMenuDTO
                            {
                                MenuTitle = y.MenuTitle,
                                MenuHref = y.MenuHref,
                                MenuIcon = y.MenuIcon,
                                MenuNotification = y.MenuNotification,
                                PermittedRoles = _configurationDBUnitOfWork.ConfigurationDBContext.GetAllAppMenuRoleByMenuID(y.ID)
                            }).ToArray(),
                            PermittedRoles = _configurationDBUnitOfWork.ConfigurationDBContext.GetAllAppCategoryMenuRoleByCategoryMenuID(x.ID)
                        };
                    }).ToList();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(categoryMenuDTO);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
