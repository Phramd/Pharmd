using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class ShareInfo
    {
        /// <summary>
        /// Gets or sets the options that control the sharing of an album.
        /// </summary>
        [JsonProperty(PropertyName = "sharedAlbumOptions")]
        public SharedAlbumOptions SharedAlbumOptions { get; set; }

        /// <summary>
        /// Gets or sets a link to the album that's now shared on the Google Photos website and app. Anyone with the
        /// link can access this shared album and see all of the items present in the album.
        /// </summary>
        [JsonProperty(PropertyName = "shareableUrl")]
        public string ShareableUrl { get; set; }

        /// <summary>
        /// Gets or sets a token that can be used by other users to join this shared album via the API.
        /// </summary>
        [JsonProperty(PropertyName = "shareToken")]
        public string ShareToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has joined the album. This is always true for the
        /// owner of the shared album.
        /// </summary>
        [JsonProperty(PropertyName = "isJoined")]
        public bool IsJoined { get; set; }
    }
}
