using Enterprise.Abstract.NetStandard;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.ConfigurationServer.Interfaces.ConfigurationDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.Repository.ConfigurationDB
{
    public class IntegratedAppRepository : BaseRepository<IntegratedApp, ConfigurationDBContext>, IIntegratedAppRepository
    {
        public IntegratedAppRepository(ConfigurationDBContext context) : base(context)
        {
        }
    }
    public class ApplicationConfigurationRepository : BaseRepository<ApplicationConfiguration, ConfigurationDBContext>, IApplicationConfigurationRepository
    {
        public ApplicationConfigurationRepository(ConfigurationDBContext context) : base(context)
        {
        }
    }
    public class AppMenuRepository : BaseRepository<AppMenu, ConfigurationDBContext>, IAppMenuRepository
    {
        public AppMenuRepository(ConfigurationDBContext context) : base(context)
        {
        }
    }
    public class AppMenuCategoryRepository : BaseRepository<AppMenuCategory, ConfigurationDBContext>, IAppMenuCategoryRepository
    {
        public AppMenuCategoryRepository(ConfigurationDBContext context) : base(context)
        {
        }
    }
    public class MenuPermittedRoleRepository : BaseRepository<MenuPermittedRole, ConfigurationDBContext>, IMenuPermittedRoleRepository
    {
        public MenuPermittedRoleRepository(ConfigurationDBContext context) : base(context)
        {
        }
    }

    public class ProjectRepository : BaseRepository<Project, ConfigurationDBContext>, IProjectRepository
    {
        public ProjectRepository(ConfigurationDBContext context) : base(context)
        {
        }
    }
}
