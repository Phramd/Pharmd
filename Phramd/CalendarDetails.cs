using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd
{
    public class CalendarDetails
    {
        public string email { get; set; }
        public int UserID { get; set; }
        public bool isAddUser { get; set; }
        public string Gmail { get; set; }
        public string Apple { get; set; }
        public string Microsoft { get; set; }
        public int cartID { get; set; }

        public List<CalendarDetails> LoadEmail()
        {
            var listOfEmails = new List<CalendarDetails>();
            UserID = Program.UserDetails.UserID;
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                SqlCommand returnEmail = new SqlCommand();
                returnEmail.Connection = myConn;
                myConn.Open();

                returnEmail.Parameters.AddWithValue("@UserID", UserID);

                returnEmail.CommandText = ("[spAddUser]");
                returnEmail.CommandType = System.Data.CommandType.StoredProcedure;

                var theCartID = returnEmail.ExecuteScalar();

                if (theCartID != null)
                {
                    cartID = Convert.ToInt16(theCartID);
                }

                /*string sql = "SELECT Gmail, Apple, Microsoft FROM CalendarModel";
                using (var command = new SqlCommand(sql, myConn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if(Program.UserDetails.UserID == UserID) {
                            while (reader.Read())
                            {
                                var calEmails = new CalendarDetails();
                                calEmails.Gmail = reader["Gmail"].ToString();
                                calEmails.Apple = reader["Apple"].ToString();
                                calEmails.Microsoft = reader["Microsoft"].ToString();

                                listOfEmails.Add(calEmails);
                            }
                        }
                        
                    }
                }*/
            }

            return listOfEmails;
        }
    }
}

