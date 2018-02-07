using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DataLayers.ConfigurationDB
{
    public class ApplicationConfiguration
    {
        public ApplicationConfiguration()
        {

        }
        public Guid ID { get; set; }
        public string Key { get; set; }
        public string Values { get; set; }


        public Guid IntegratedAppID { get; set; }
        public IntegratedApp IntegratedApp { get; set; }
    }
}
