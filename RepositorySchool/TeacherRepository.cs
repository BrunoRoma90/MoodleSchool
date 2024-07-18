using Project.ModelsSchool;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using RepositorySchool;

namespace Project.RepositorySchool
{
    public class TeacherRepository : ITeacherRepository
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString();


        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();
        public DataTable GetTeacherById(int id)
        {
            DataTable dt = new DataTable();



            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Teacher Where id = @teacherId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    //cmd.Parameters.AddWithValue("@addressId", id);
                    cmd.Parameters.Add("@teacherId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }

        public DataTable GetAllTeachers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Teacher";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                }
            }

            return dt;
        }

        public void InsertNewTeacher(Teacher teacher)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Teacher(FirstName, MiddleName, LastName, Age, Email, Birthdate, PhoneNumber, UserName, Password, AddressId , Salary) VALUES(@firstName, @middleName, @lastName, @age, @email, @birthdate, @phoneNumber, @userName, @password, @addressId, @salary)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = teacher.FirstName;
                    cmd.Parameters.Add("@middleName", SqlDbType.NVarChar).Value = teacher.MiddleName;
                    cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = teacher.LastName;
                    cmd.Parameters.Add("@age", SqlDbType.Int).Value = teacher.Age;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = teacher.Email;
                    cmd.Parameters.Add("@birthdate", SqlDbType.DateTime2).Value = teacher.BirthDate;
                    cmd.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = teacher.PhoneNumber;
                    cmd.Parameters.Add("@userName", SqlDbType.NVarChar).Value = teacher.UserName;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = teacher.Password;
                    cmd.Parameters.Add("@addressId", SqlDbType.Int).Value = teacher.Address.AddressId;
                    cmd.Parameters.Add("@salary", SqlDbType.Decimal).Value = teacher.Salary;                    
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetSubjectByTeacherId(int teacherId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM SubjectTeacher WHERE teacherId = @teacherId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@teacherId", SqlDbType.Int).Value = teacherId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }



        public DataTable GetLectureByTeacherId(int teacherId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM ClassTeacher WHERE teacherId = @teacherId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@teacherId", SqlDbType.Int).Value = teacherId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }




        public DataTable GetTeachersByCredentials(string username, string password)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Teacher WHERE username = @username AND password = @password";

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




        public DataTable GetTeacherByEmail(string email)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Teacher WHERE email = @email";

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

        public DataTable GetTeacherByUsername(string username)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Teacher WHERE username = @username";

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
