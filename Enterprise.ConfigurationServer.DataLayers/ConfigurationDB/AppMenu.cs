using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DataLayers.ConfigurationDB
{
    public class AppMenu
    {
        public AppMenu()
        {

        }
        public Guid ID { get; set; }
        
        public string MenuTitle { get; set; }
        public string MenuHref { get; set; }
        public string MenuIcon { get; set; }

        public int MenuOrder { get; set; }
        public bool MainMenu { get; set; }

        /// <summary>
        /// Admin Layout or Core Layout
        /// If Null Then its general.
        /// </summary>
        public Guid? AppMenuLayoutID { get; set; }
        public AppMenuLayout AppMenuLayout { get; set; }

        /// <summary>
        /// If zero then No Notification
        /// </summary>
        public int MenuNotification { get; set; }

        /// <summary>
        /// Nullable If Null Means Top Menu.
        /// Foreign Key Of App Menu Category
        /// </summary>
        public Guid? AppMenuCategoryID { get; set; }
        public AppMenuCategory AppMenuCategory { get; set; }
        
        /// <summary>
        /// Which Application Menu Belongs to
        /// </summary>
        public Guid IntegratedAppID { get; set; }
        public IntegratedApp IntegratedApp { get; set; }

        public ICollection<MenuPermittedRole> MenuPermittedRoles { get; set; }
    }
}
