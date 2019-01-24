using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Phramd.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Program.UserDetails.isAddUser = true;
            Program.Calendar.isAddCalendar = true;
        }

        public void OnPostLogin(string username, string password)
        {
            Program.UserDetails.CheckID(username, password);
            Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
            Program.UserDetails.PhotoChanges(Program.UserDetails.UserID);
            if (Program.UserDetails.GPhoto != null)
            {
                
            }
        }

        public void OnPostLogout()
        {
            Program.UserDetails.UserID = 0;
        }

        public void OnPostNewUser(string username, string email, string password)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                int userID = 0;
                SqlCommand addUser = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                addUser.Parameters.AddWithValue("@username", username);
                addUser.Parameters.AddWithValue("@email", email);
                addUser.Parameters.AddWithValue("@password", password);

                addUser.CommandText = ("[spAddUser]");
                addUser.CommandType = System.Data.CommandType.StoredProcedure;

                var result = addUser.ExecuteScalar();
                if (result != null)
                {
                    userID = Convert.ToInt32(result);
                }
                myConn.Close();
            }
        }

        public void OnPostCalendarGmail(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0 && Program.Calendar.isAddCalendar != false)
                {
                    SqlCommand addCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    addCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    addCal.Parameters.AddWithValue("@gmail", email);                    

                    addCal.CommandText = ("[spAddCalEmailGmail]");
                    addCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = addCal.ExecuteScalar();

                    if (result != null)
                    {
                        email = Program.CalendarDetails.Gmail;
                        Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
                        Program.Calendar.CalendarSetUp();
                    }

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarApple(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0 && Program.Calendar.isAddCalendar != false)
                {
                    SqlCommand addCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    addCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    addCal.Parameters.AddWithValue("@apple", email);

                    addCal.CommandText = ("[spAddCalEmailApple]");
                    addCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = addCal.ExecuteScalar();

                    if (result != null)
                    {
                        email = Program.CalendarDetails.Apple;
                        Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
                    }

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarMicro(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0 && Program.Calendar.isAddCalendar != false)
                {
                    SqlCommand addCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    addCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    addCal.Parameters.AddWithValue("@microsoft", email);

                    addCal.CommandText = ("[spAddCalEmailMicro]");
                    addCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = addCal.ExecuteScalar();

                    if (result != null)
                    {
                        email = Program.CalendarDetails.Microsoft;
                        Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
                    }

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarRemoveGmail(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    removeCal.Parameters.AddWithValue("@email", Program.UserDetails.emails);

                    removeCal.CommandText = ("[spRemoveCalEmail]");
                    removeCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeCal.ExecuteScalar();

                    if (result == null)
                    {
                        Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
                    }
                    
                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarRemoveApple(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    removeCal.Parameters.AddWithValue("@email", Program.UserDetails.emailsA);

                    removeCal.CommandText = ("[spRemoveCalEmail]");
                    removeCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeCal.ExecuteScalar();

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarRemoveMicro(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    removeCal.Parameters.AddWithValue("@email", Program.UserDetails.emailsM);

                    removeCal.CommandText = ("[spRemoveCalEmail]");
                    removeCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeCal.ExecuteScalar();

                    myConn.Close();
                }
            }
        }

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
                    }

                    myConn.Close();
                }
            }
        }

        
    }
}


   

