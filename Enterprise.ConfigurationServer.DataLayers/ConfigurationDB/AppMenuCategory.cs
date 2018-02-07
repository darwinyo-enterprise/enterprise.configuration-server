using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DataLayers.ConfigurationDB
{
    public class AppMenuCategory
    {
        public AppMenuCategory()
        {

        }
        public Guid ID { get; set; }
        public string MenuCategory { get; set; }

        public int MenuCategoryOrder { get; set; }

        public Guid IntegratedAppID { get; set; }
        public IntegratedApp IntegratedApp { get; set; }

        /// <summary>
        /// Admin Layout or Core Layout.
        /// If Null Then Its General.
        /// </summary>
        public Guid? AppMenuLayoutID { get; set; }
        public AppMenuLayout AppMenuLayout { get; set; }

        public ICollection<MenuPermittedRole> MenuPermittedRole { get; set; }
        public ICollection<AppMenu> AppMenus { get; set; }
    }
}
