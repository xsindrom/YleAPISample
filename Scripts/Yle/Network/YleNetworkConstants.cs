using System.Collections;
using System.Collections.Generic;

namespace Yle.Network
{
    public class YleNetworkConstants
    {
        public const string PATH_PROGRAM_ITEMS  = "https://external.api.yle.fi/v1/programs/items.json?";
        public const string PATH_PROGRAM_ITEM   = "https://external.api.yle.fi/v1/programs/items/{0}.json?";

        /// <summary>
        /// Image format. Consider using string.Format();
        /// {0} - id
        /// {1} - format
        /// </summary>
        public const string PATH_PROGRAM_IMAGE = "http://images.cdn.yle.fi/image/upload/{0}.{1}";
        /// <summary>
        /// Image format. Consider using string.Format(); 
        /// {0} - width
        /// {1} - height
        /// {2} - id
        /// {3} - format (jpg, png, gif)
        /// </summary>
        public const string PATH_PROGRAM_IMAGE_WITH_TRANSFORMATION = "http://images.cdn.yle.fi/image/upload/w_{0},h_{1},c_fit/{2}.{3}";
    }
}