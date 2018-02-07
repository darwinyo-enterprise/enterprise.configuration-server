using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.Interfaces.ConfigurationDB
{
    public interface IIntegratedAppRepository : IRepository<IntegratedApp> { }
    public interface IApplicationConfigurationRepository : IRepository<ApplicationConfiguration> { }
    public interface IAppMenuRepository : IRepository<AppMenu> { }
    public interface IAppMenuCategoryRepository : IRepository<AppMenuCategory> { }
    public interface IMenuPermittedRoleRepository : IRepository<MenuPermittedRole> { }
    public interface IProjectRepository : IRepository<Project> { }
}
