using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class ListAlbumsResponse
    {
        /// <summary>
        /// Gets or sets the list of albums shown in the Albums tab of the user's Google Photos app.
        /// </summary>
        [JsonProperty(PropertyName = "albums")]
        public IEnumerable<Album> Albums { get; set; }

        /// <summary>
        /// Gets or sets the token to use to get the next set of albums. Populated if there are more albums to retrieve
        /// for this request.
        /// </summary>
        [JsonProperty(PropertyName = "nextPageToken")]
        public string NextPageToken { get; set; }
    }
}

