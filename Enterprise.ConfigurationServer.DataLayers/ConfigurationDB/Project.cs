using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.DataLayers.ConfigurationDB
{
    public class Project
    {
        public Guid ID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Project Version.
        /// All Libraries that used to build this project will have unified version number.
        /// Except Shared Libraries, Those will grow as time goes.
        /// </summary>
        public string ProjectVersion { get; set; }

        public ICollection<IntegratedApp> IntegratedApps { get; set; }
    }
}
