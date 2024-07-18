using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Project.ModelsSchool;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using RepositorySchool;

namespace Project.RepositorySchool
{
    public class StudentRepository : IStudentRepository
    {
        //private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString();
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();
        public DataTable GetStudentById(int id)
        {
            DataTable dt = new DataTable();



            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Student Where id = @studentId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    //cmd.Parameters.AddWithValue("@addressId", id);
                    cmd.Parameters.Add("@studentId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }

        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();



            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Student";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }

        public void InsertNewStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Student(FirstName, MiddleName, LastName, Age, Email, Birthdate, PhoneNumber, UserName, Password, AddressId) VALUES(@firstName, @middleName, @lastName, @age, @email, @birthdate, @phoneNumber, @userName, @password, @addressId)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = student.FirstName;
                    cmd.Parameters.Add("@middleName", SqlDbType.NVarChar).Value = student.MiddleName;
                    cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = student.LastName;
                    cmd.Parameters.Add("@age", SqlDbType.Int).Value = student.Age;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = student.Email;
                    cmd.Parameters.Add("@birthdate", SqlDbType.DateTime2).Value = student.BirthDate;
                    cmd.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = student.PhoneNumber;
                    cmd.Parameters.Add("@userName", SqlDbType.NVarChar).Value = student.UserName;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = student.Password;
                    cmd.Parameters.Add("@addressId", SqlDbType.Int).Value = student.Address.AddressId;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public DataTable GetSubjectByStudentId(int studentId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM SubjectStudent WHERE studentId = @studentId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public DataTable GetLectureByStudentId(int studentId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM ClassStudent WHERE studentId = @studentId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public DataTable GetStudentsByCredentials(string username, string password)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Student WHERE username = @username AND password = @password";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);



                }
            }
            return dt;


        }


        public DataTable GetStudentByEmail(string email)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Student WHERE email = @email";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetStudentByUsername(string username)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Student WHERE username = @username";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
