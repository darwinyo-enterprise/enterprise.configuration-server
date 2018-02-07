using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DataLayers.ConfigurationDB
{
    public class IntegratedApp
    {
        public IntegratedApp()
        {

        }
        public Guid ID { get; set; }

        public string ApplicationName { get; set; }
        public string ApplicationURL { get; set; }
        public bool Integrated { get; set; }
        /// <summary>
        /// Can Updated If CoreFeature, Read Only
        /// </summary>
        public bool CoreFeature { get; set; }
        
        /// <summary>
        /// E-Commerce, Procurement, ConfigurationServer,etc...
        /// It's Not Per Apps, But Per Solutions
        /// </summary>
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }

        public ICollection<AppMenuCategory> AppMenuCategories { get; set; }

        public ICollection<AppMenu> AppMenus { get; set; }
        
        public ICollection<ApplicationConfiguration> ApplicationConfigurations { get; set; }
    }
}
