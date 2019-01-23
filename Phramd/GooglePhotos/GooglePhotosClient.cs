using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class GooglePhotosClient
    {
        private const string ListAlbumsUrl = "https://photoslibrary.googleapis.com/v1/albums?pageSize=" +
            "{pageSize}&pageToken={pageToken}&excludeNonAppCreatedData={excludeNonAppCreatedData}";

        private const string GetAlbumUrl = "https://photoslibrary.googleapis.com/v1/albums/{albumId}";

        private readonly GooglePhotosClientSettings clientSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePhotosClient"/> class.
        /// </summary>
        /// <param name="clientSettings">Client settings with required objects to perform API calls.</param>
        public GooglePhotosClient(GooglePhotosClientSettings clientSettings)
        {
            this.clientSettings = clientSettings;
        }

        public ListAlbumsResponse ListAlbums(
            int pageSize = 20,
            string pageToken = "",
            bool excludeNonAppCreatedData = false)
        {
            // Prepare request
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                ListAlbumsUrl
                    .Replace("{pageSize}", pageSize.ToString())
                    .Replace("{pageToken}", pageToken.ToString())
                    .Replace("{excludeNonAppCreatedData}", excludeNonAppCreatedData.ToString()));
            request.Headers.Authorization =
                GetAuthenticationHeaderValue(this.clientSettings.UserCredential.Token.AccessToken);

            // Execute request
            HttpResponseMessage response = this.clientSettings.HttpClient.SendAsync(request).Result;

            // Analyze response
            string body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ListAlbumsResponse>(body);
        }

        /// <summary>
        /// Returns the album based on the specified 'albumId'. The 'albumId' should be the ID of an album owned by the
        /// user or a shared album that the user has joined.
        /// </summary>
        /// <param name="albumId">Identifier of the album to be requested.</param>
        /// <returns>An <see cref="Album"/> object.</returns>
        public Album GetAlbum(string albumId)
        {
            // Prepare request
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                GetAlbumUrl.Replace("{albumId}", albumId));
            request.Headers.Authorization =
                GetAuthenticationHeaderValue(this.clientSettings.UserCredential.Token.AccessToken);

            // Execute request
            HttpResponseMessage response = this.clientSettings.HttpClient.SendAsync(request).Result;

            // Analyze response
            string body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Album>(body);
        }

        private static AuthenticationHeaderValue GetAuthenticationHeaderValue(string accessToken)
        {
            return new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}