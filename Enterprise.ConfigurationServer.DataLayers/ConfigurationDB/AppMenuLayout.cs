using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DataLayers.ConfigurationDB
{
    public class AppMenuLayout
    {
        public AppMenuLayout()
        {

        }
        public Guid ID { get; set; }
        public string LayoutName { get; set; }
        public string Description { get; set; }

        public ICollection<AppMenu> AppMenus { get; set; }
        public ICollection<AppMenuCategory> AppMenuCategories { get; set; }
    }
}
