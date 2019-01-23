using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class SharedAlbumOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether the shared album allows collaborators (users who have joined
        /// the album) to add media items to it. Defaults to false.
        /// </summary>
        [JsonProperty(PropertyName = "isCollaborative")]
        public bool IsCollaborative { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the shared album allows the owner and the collaborators
        /// (users who have joined the album) to add comments to the album. Defaults to false.
        /// </summary>
        [JsonProperty(PropertyName = "isCommentable")]
        public bool IsCommentable { get; set; }
    }
}
