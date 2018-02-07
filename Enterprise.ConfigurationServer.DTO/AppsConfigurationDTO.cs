using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DTO
{
    public class AppsConfigurationDTO
    {
        public Guid ID { get; set; }
        public string ApplicationName { get; set; }
        public string Key { get; set; }
        public string Values { get; set; }
        public bool Integrated { get; set; }
    }
}
