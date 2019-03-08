using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Phramd.Utility
{
    public class PhotoController : Controller
    {
            [HttpPost]
            public void OnPostGooglePhotos(string email)
            {
                using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
                {
                    if (Program.UserDetails.UserID != 0)
                    {
                        SqlCommand addGPhoto = new SqlCommand
                        {
                            Connection = myConn
                        };
                        myConn.Open();

                        addGPhoto.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                        addGPhoto.Parameters.AddWithValue("@GPhoto", email);

                        addGPhoto.CommandText = ("[spAddGPhotoAccount]");
                        addGPhoto.CommandType = System.Data.CommandType.StoredProcedure;

                        var result = addGPhoto.ExecuteScalar();

                        if (result != null)
                        {
                            result = Program.UserDetails.GPhoto;
                            Program.UserDetails.PhotoChanges(Program.UserDetails.UserID);
                            GooglePhotos.GooglePhotosClientIntegrationTests GooglePhotos =
                                new GooglePhotos.GooglePhotosClientIntegrationTests();
                            GooglePhotos.Test_ListAlbums_GetFirstAlbum();
                            GooglePhotos.ListAlbumContent();
                        }

                        myConn.Close();
                    }
                }
            }
        }
    }
