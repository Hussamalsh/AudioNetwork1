using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioNetwork1.Configurations
{
    /// <summary>
    /// This represents the settings entity from the configurations.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// get and set the AudioNetworkApiUrl to be used later to get tracks or composers
        /// </summary>
        public string AudioNetworkApiUrl { get; set; }
    }
}
