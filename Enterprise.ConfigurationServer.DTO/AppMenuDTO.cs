using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DTO
{
    /// <summary>
    /// Used In Front end As Menu Or Child Menu.
    /// If Used As Menu Then Select All Menu where has no Category.
    /// Otherwise select by Category
    /// </summary>
    public class AppMenuDTO
    {
        public string MenuTitle { get; set; }
        public string MenuHref { get; set; }
        public string MenuIcon { get; set; }
        public int? MenuNotification { get; set; }
        public string[] PermittedRoles { get; set; }
    }
}
