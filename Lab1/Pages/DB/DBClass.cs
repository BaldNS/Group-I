using GroceryInventory.Pages.DB;
using Lab1.Pages.DataClasses;
using Lab2.Pages.DataClasses;
using Lab3.Pages;
using System.Data;
using System.Data.SqlClient;

namespace Lab1.Pages.DB
{
    public class DBClass
    {
        // Connection object at the Class level
        public static SqlConnection Lab1DBConnection = new SqlConnection();
        public static SqlConnection AuthDBConnection = new SqlConnection();

        // Connection string
        private static readonly String Lab1DBConnString = "Server=Localhost;Database=Lab3;Trusted_Connection=True";
        private static readonly String? AuthDBConnString = "Server=Localhost;Database=AUTH;Trusted_Connection=True";


        // method that reads data from meetings table
        public static SqlDataReader MeetingsReader()
        {
            SqlCommand cmdMeetingsRead = new SqlCommand("SELECT * FROM Meetings", Lab1DBConnection);
            Lab1DBConnection.Open();

            SqlDataReader tempReader = cmdMeetingsRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader SingleMeetingReader(int PersonID)
        {
            // Sql Command 
            // Set its properties
            // Open a connection 
            // Issue the Query
            // Capture the results and return them 
            SqlCommand cmdMeetingRead = new SqlCommand("SELECT * FROM Meetings WHERE PersonID = " + PersonID, Lab1DBConnection);
            Lab1DBConnection.Open();

            SqlDataReader tempReader = cmdMeetingRead.ExecuteReader();

            return tempReader;
        }

        // method to update meeting table
        public static void UpdateMeeting(Meetings m)
        {
            String sqlQuery = "UPDATE Meetings SET ";
            sqlQuery += "FirstName='" + m.FirstName + "',";
            sqlQuery += "LastName='" + m.LastName + "',";
            sqlQuery += "Professor='" + m.Professor + "',";
            sqlQuery += "DateTime='" + m.DateandTime + "',";
            sqlQuery += "Purpose='" + m.Purpose + "')";

            SqlCommand cmdMeetingRead = new SqlCommand(sqlQuery, Lab1DBConnection);
            Lab1DBConnection.Open();
            cmdMeetingRead.ExecuteNonQuery();
        }

        public static int LoginQuery(string loginQuery)
        {
            // This method expects to receive an SQL SELECT
            // query that uses the COUNT command.

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = Lab1DBConnection;
            cmdLogin.Connection.ConnectionString = Lab1DBConnString;
            cmdLogin.CommandText = loginQuery;
            cmdLogin.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            int rowCount = (int)cmdLogin.ExecuteScalar();

            return rowCount;
        }

        //method to insert user data into sql meeting table 
        public static void InsertMeeting(Meetings m)
        {
            String sqlQuery = "INSERT INTO Meetings (FirstName, LastName, Professor, DateandTime, Purpose, StudentCredID, FacultyCredID) VALUES (";
            sqlQuery += "'" + m.FirstName + "',";
            sqlQuery += "'" + m.LastName + "',";
            sqlQuery += "'" + m.Professor + "',";
            sqlQuery += "'" + m.DateandTime + "',";
            sqlQuery += "'" + m.Purpose + "',";
            sqlQuery += "'" + m.StudentCredID + "',";
            sqlQuery += "'" + m.FacultyCredID + "')";

            SqlCommand cmdMeetingRead = new SqlCommand();
            cmdMeetingRead.Connection = Lab1DBConnection;
            cmdMeetingRead.Connection.ConnectionString = Lab1DBConnString;
            cmdMeetingRead.CommandText = sqlQuery;
            Lab1DBConnection.Open();
            cmdMeetingRead.ExecuteNonQuery();
        }

        public static int GeneralScalarQuery(string sqlQuery)
        {
            SqlCommand cmdGeneral = new SqlCommand();
            cmdGeneral.Connection = Lab1DBConnection;
            cmdGeneral.Connection.ConnectionString = Lab1DBConnString;
            cmdGeneral.CommandText = sqlQuery;
            Lab1DBConnection.Open();
            int rowCount = (int)cmdGeneral.ExecuteScalar();
            Lab1DBConnection.Close();
            return rowCount;
        }

        public static int GeneralScalarQueryAuth(string sqlQuery)
        {
            SqlCommand cmdGeneral = new SqlCommand();
            cmdGeneral.Connection = AuthDBConnection;
            cmdGeneral.Connection.ConnectionString = AuthDBConnString;
            cmdGeneral.CommandText = sqlQuery;
            AuthDBConnection.Open();
            int rowCount = (int)cmdGeneral.ExecuteScalar();
            AuthDBConnection.Close();
            return rowCount;
        }

        public static int CheckDuplicate(int StudentID, int OfficeHourID)
        {
            String sqlCount = "Select Count(*) From Queue Where StudentID = '" + StudentID + "' AND OfficeHourID = '" + OfficeHourID + "'";
            int count = (int)DBClass.GeneralScalarQuery(sqlCount);
            return count;
        }
        public static void InsertCheckIn(Queue q)
        {
            String sqlQuery = "INSERT INTO Queue (StudentID, OfficeHourID) VALUES (";
            sqlQuery += q.StudentID + ",";
            sqlQuery += q.OfficeHourID + ")";

            SqlCommand cmdMeetingRead = new SqlCommand();
            cmdMeetingRead.Connection = Lab1DBConnection;
            cmdMeetingRead.Connection.ConnectionString = Lab1DBConnString;
            cmdMeetingRead.CommandText = sqlQuery;
            Lab1DBConnection.Open();
            cmdMeetingRead.ExecuteNonQuery();
        }
        // method that reads data from faculty table
        public static SqlDataReader FacultyReader()
        {
            SqlCommand cmdMeetingsRead = new SqlCommand("SELECT * FROM Faculty", Lab1DBConnection);
            cmdMeetingsRead.Connection.ConnectionString = Lab1DBConnString;
            Lab1DBConnection.Open();

            SqlDataReader tempReader = cmdMeetingsRead.ExecuteReader();

            return tempReader;

        }

        // method that reads data from student table
        public static SqlDataReader StudentReader()
        {
            SqlCommand cmdMeetingsRead = new SqlCommand("SELECT * FROM Student", Lab1DBConnection);
            cmdMeetingsRead.Connection.ConnectionString = Lab1DBConnString;
            Lab1DBConnection.Open();

            SqlDataReader tempReader = cmdMeetingsRead.ExecuteReader();

            return tempReader;
        }

        // method that reads data from class table
        public static SqlDataReader ClassReader()
        {
            SqlCommand cmdMeetingsRead = new SqlCommand("SELECT * FROM Class", Lab1DBConnection);
            cmdMeetingsRead.Connection.ConnectionString = Lab1DBConnString;
            Lab1DBConnection.Open();

            SqlDataReader tempReader = cmdMeetingsRead.ExecuteReader();

            return tempReader;
        }

        // method that reads data from officehourse table
        public static SqlDataReader OfficeHoursReader()
        {
            SqlCommand cmdMeetingsRead = new SqlCommand("SELECT * FROM Faculty", Lab1DBConnection);
            cmdMeetingsRead.Connection.ConnectionString = Lab1DBConnString;
            Lab1DBConnection.Open();

            SqlDataReader tempReader = cmdMeetingsRead.ExecuteReader();

            return tempReader;
        }

        // method that reads data from schedule table
        public static SqlDataReader ScheduleReader()
        {
            SqlCommand cmdMeetingsRead = new SqlCommand("SELECT * FROM Faculty", Lab1DBConnection);
            cmdMeetingsRead.Connection.ConnectionString = Lab1DBConnString;
            Lab1DBConnection.Open();

            SqlDataReader tempReader = cmdMeetingsRead.ExecuteReader();

            return tempReader;
        }
        public static SqlDataReader GeneralReaderQuery(string sqlQuery)
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = Lab1DBConnection;
            cmdProductRead.Connection.ConnectionString = Lab1DBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open();
            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;

        }

        public static SqlDataReader ProfessorReader()
        {
            SqlCommand cmdProfessorRead = new SqlCommand();
            cmdProfessorRead.Connection = Lab1DBConnection;
            cmdProfessorRead.Connection.ConnectionString = Lab1DBConnString;
            cmdProfessorRead.CommandText = "Select * From Faculty";
            cmdProfessorRead.Connection.Open();

            SqlDataReader tempReader = cmdProfessorRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader SingleSignUpRead(int MeetingID)
        {
            SqlCommand cmdRead = new SqlCommand();
            cmdRead.Connection = Lab1DBConnection;
            cmdRead.Connection.ConnectionString = Lab1DBConnString;
            cmdRead.CommandText = "Select * From Meetings Where MeetingID = " + MeetingID;
            cmdRead.Connection.Open();
            SqlDataReader tempReader = cmdRead.ExecuteReader();

            return tempReader;
        }

        public static void UpdateSignUp(Meetings m)
        {
            string query = "UPDATE Meetings SET FirstName = '" + m.FirstName + "', ";
            query += "LastName = '" + m.LastName + "', ";
            query += "Professor = '" + m.Professor + "', ";
            query += "DateandTime = '" + m.DateandTime + "', ";
            query += "Purpose = '" + m.Purpose + "', ";
            query += "StudentCredID = " + m.StudentCredID + ", ";
            query += "FacultyCredID = " + m.FacultyCredID + " ";
            query += "WHERE MeetingID = " + m.MeetingID;

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = Lab1DBConnection;
            cmdUpdate.Connection.ConnectionString = Lab1DBConnString;
            cmdUpdate.CommandText = query;
            cmdUpdate.Connection.Open();
            cmdUpdate.ExecuteNonQuery();
        }

        public static void CreateHashedUser(string Username, string Password, int PersonType)
        {
            string AccountType = "";
            if (PersonType == 0)
            {
                AccountType = "student";
            }
            else if (PersonType == 1)
            {
                AccountType = "faculty";
            }

            string loginQuery =
                "INSERT INTO HashedCredentials (Username,Password,AccountType) values (@Username, @Password, @AccountType)";

            SqlCommand cmdHashedLogin = new SqlCommand();
            cmdHashedLogin.Connection = AuthDBConnection;
            cmdHashedLogin.Connection.ConnectionString = AuthDBConnString;

            cmdHashedLogin.CommandText = loginQuery;
            cmdHashedLogin.Parameters.AddWithValue("@Username", Username);
            cmdHashedLogin.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));
            cmdHashedLogin.Parameters.AddWithValue("@AccountType", AccountType);

            cmdHashedLogin.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            cmdHashedLogin.ExecuteNonQuery();

        }

        public static bool HashedParameterLogin(string Username, string Password, int PersonType)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = AuthDBConnection;
            cmdLogin.Connection.ConnectionString = AuthDBConnString;

            cmdLogin.CommandText = "sp_Lab3Login";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@Password", Password);
            cmdLogin.Parameters.AddWithValue("@PersonType", PersonType);

            cmdLogin.Connection.Open();

            SqlDataReader hashReader = cmdLogin.ExecuteReader();
            if (hashReader.Read())
            {
                string correctHash = hashReader["Password"].ToString();

                if (PasswordHash.ValidatePassword(Password, correctHash))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool userExists (string Username)
        {
            String sqlCount = "Select Count(*) From HashedCredentials Where Username = '" + Username + "'";
            int count = (int)DBClass.GeneralScalarQueryAuth(sqlCount);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public static void AddStudent(string FirstName, string LastName, int ID, string Username)
        {
            string sqlQuery = "INSERT INTO StudentCredentials (Username) VALUES (@Username); " + " " +
                "INSERT INTO Student (FirstName, LastName, CredentialID) VALUES (@FirstName, @LastName," + ID + ");";

            SqlCommand cmdMeetingRead = new SqlCommand();
            cmdMeetingRead.Connection = Lab1DBConnection;
            cmdMeetingRead.Connection.ConnectionString = Lab1DBConnString;
            cmdMeetingRead.CommandText = sqlQuery;
            cmdMeetingRead.Parameters.AddWithValue("@Username", Username);
            cmdMeetingRead.Parameters.AddWithValue("@FirstName", FirstName);
            cmdMeetingRead.Parameters.AddWithValue("@LastName", LastName);
            Lab1DBConnection.Open();
            cmdMeetingRead.ExecuteNonQuery();
        }

        public static void AddFaculty(string FirstName, string LastName, int ID, string Username)
        {
            string Professor = FirstName + " " + LastName;
            string sqlQuery = "INSERT INTO FacultyCredentials (Username) VALUES (@Username); " + " " +
                "INSERT INTO Faculty (Professor, CredentialID) VALUES (@Professor," + ID + " );";
                
            SqlCommand cmdMeetingRead = new SqlCommand();
            cmdMeetingRead.Connection = Lab1DBConnection;
            cmdMeetingRead.Connection.ConnectionString = Lab1DBConnString;
            cmdMeetingRead.CommandText = sqlQuery;
            cmdMeetingRead.Parameters.AddWithValue("@Username", Username);
            cmdMeetingRead.Parameters.AddWithValue("@Professor", Professor);
            Lab1DBConnection.Open();
            cmdMeetingRead.ExecuteNonQuery();
        }

        public static SqlDataReader SearchProfessor(string Professor) 
        {

            string sqlQuery = "SELECT Professor, ClassName, OfficeRoom, OfficeDate, OfficeTime " +
                            "FROM Faculty JOIN Class ON Faculty.ProfessorID = Class.ProfessorID " +
                            "JOIN OfficeHour ON Faculty.ProfessorID = OfficeHour.ProfessorID " +
                            "WHERE Professor LIKE '%' + @ProfessorName + '%'";

            SqlCommand cmdMeetingRead = new SqlCommand();
            cmdMeetingRead.Connection = Lab1DBConnection;
            cmdMeetingRead.Connection.ConnectionString = Lab1DBConnString;
            cmdMeetingRead.CommandText = sqlQuery;
            cmdMeetingRead.Parameters.AddWithValue("@ProfessorName", Professor);
            Lab1DBConnection.Open();
            SqlDataReader readData = cmdMeetingRead.ExecuteReader();

            return readData;
        }
    }
}