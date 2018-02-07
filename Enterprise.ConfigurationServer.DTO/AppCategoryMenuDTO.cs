using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DTO
{
    /// <summary>
    /// Used In Frontend As Menu Category
    /// </summary>
    public class AppCategoryMenuDTO
    {
        public string MenuCategory { get; set; }
        public AppMenuDTO[] MenuChild { get; set; }
        public string[] PermittedRoles { get; set; }
    }
}
