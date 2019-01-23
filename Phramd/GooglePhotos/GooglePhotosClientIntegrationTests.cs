﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Xunit;

namespace Phramd.GooglePhotos
{
    public class GooglePhotosClientIntegrationTests
    {
        private readonly GooglePhotosClient googlePhotosClient;

        public GooglePhotosClientIntegrationTests()
        {
            HttpClient httpClient = new HttpClient();
            UserCredential userCredential;
            using (var stream = new FileStream("credentialsPhoto.json", FileMode.Open, FileAccess.Read))
            {
                userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { "https://www.googleapis.com/auth/photoslibrary.readonly" },
                    Program.UserDetails.emails,
                    CancellationToken.None).Result;
            }

            userCredential.RefreshTokenAsync(CancellationToken.None).Wait();
            GooglePhotosClientSettings clientSettings = new GooglePhotosClientSettings(httpClient, userCredential);
            this.googlePhotosClient = new GooglePhotosClient(clientSettings);
        }

        [Fact]
        public void Test_ListAlbums_GetFirstAlbum()
        {
            ListAlbumsResponse listAlbumsResponse = this.googlePhotosClient.ListAlbums();

            foreach (Album album in listAlbumsResponse.Albums)
            {
                Album singleAlbum = this.googlePhotosClient.GetAlbum(album.Id);

                break;
            }
        }
    }
}

