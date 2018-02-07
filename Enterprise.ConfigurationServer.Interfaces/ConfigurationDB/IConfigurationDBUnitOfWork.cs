using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.Interfaces.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.Interfaces.ConfigurationDB
{
    public interface IConfigurationDBUnitOfWork : IUnitOfWork
    {
        ConfigurationDBContext ConfigurationDBContext { get; }
        IApplicationConfigurationRepository ApplicationConfigurationRepository { get; }
        IIntegratedAppRepository IntegratedAppRepository { get; }
        IAppMenuRepository AppMenuRepository { get; }
        IAppMenuCategoryRepository AppMenuCategoryRepository { get; }
        IMenuPermittedRoleRepository MenuPermittedRoleRepository { get; }
        IProjectRepository ProjectRepository { get; }
    }
}
