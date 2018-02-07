using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DataLayers.ConfigurationDB
{
    public class MenuPermittedRole
    {
        public MenuPermittedRole()
        {

        }
        public Guid ID { get; set; }

        public Guid? AppMenuCategoryID { get; set; }
        public AppMenuCategory AppMenuCategory { get; set; }
        /// <summary>
        /// Foreign Key Of App Menu
        /// </summary>
        public Guid? AppMenuID { get; set; }
        public AppMenu AppMenu { get; set; }

        /// <summary>
        /// Foreign Key Of ApplicationRole Identity.
        /// </summary>
        public Guid ApplicationRolesID { get; set; }
    }
}
