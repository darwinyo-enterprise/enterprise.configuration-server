using Enterprise.Abstract.NetStandard;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.ConfigurationServer.Interfaces.ConfigurationDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.ConfigurationServer.UnitOfWork
{
    public class ConfigurationDBUnitOfWork : BaseDispose, IConfigurationDBUnitOfWork
    {
        private readonly ConfigurationDBContext _configurationDBContext;
        private readonly IApplicationConfigurationRepository _applicationConfigurationRepository;
        private readonly IIntegratedAppRepository _integratedAppRepository;
        private readonly IAppMenuRepository _appMenuRepository;
        private readonly IAppMenuCategoryRepository _appMenuCategoryRepository;
        private readonly IMenuPermittedRoleRepository _menuPermittedRoleRepository;
        private readonly IProjectRepository _projectRepository;

        public ConfigurationDBUnitOfWork(
            ConfigurationDBContext configurationDBContext,
            IApplicationConfigurationRepository applicationConfigurationRepository,
            IIntegratedAppRepository integratedAppRepository,
            IAppMenuRepository appMenuRepository,
            IAppMenuCategoryRepository appMenuCategoryRepository,
            IMenuPermittedRoleRepository menuPermittedRoleRepository,
            IProjectRepository projectRepository)
        {
            _configurationDBContext = configurationDBContext;
            _applicationConfigurationRepository = applicationConfigurationRepository;
            _integratedAppRepository = integratedAppRepository;
            _appMenuRepository = appMenuRepository;
            _appMenuCategoryRepository = appMenuCategoryRepository;
            _menuPermittedRoleRepository = menuPermittedRoleRepository;
            _projectRepository = projectRepository;
        }

        public ConfigurationDBContext ConfigurationDBContext => _configurationDBContext;

        public IApplicationConfigurationRepository ApplicationConfigurationRepository => _applicationConfigurationRepository;

        public IIntegratedAppRepository IntegratedAppRepository => _integratedAppRepository;

        public IAppMenuRepository AppMenuRepository => _appMenuRepository;

        public IAppMenuCategoryRepository AppMenuCategoryRepository => _appMenuCategoryRepository;

        public IMenuPermittedRoleRepository MenuPermittedRoleRepository => _menuPermittedRoleRepository;

        public IProjectRepository ProjectRepository => _projectRepository;

        public override void Dispose()
        {
            this.Dispose(_configurationDBContext);
        }

        public async Task SaveAsync()
        {
            await _configurationDBContext.SaveChangesAsync();
        }
    }
}
