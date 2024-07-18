using Project.ModelsSchool;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using RepositorySchool;

namespace Project.RepositorySchool
{
    public class SubjectRepository : ISubjectRepository
    {
        //private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString();
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();
        public DataTable GetSubjectById(int id)
        {
            DataTable dt = new DataTable();



            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Subject Where id = @subjectId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    //cmd.Parameters.AddWithValue("@addressId", id);
                    cmd.Parameters.Add("@subjectId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }
        public DataTable GetAllSubjects()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Subject";

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
        public void InsertNewSubject(Subject subject)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Subject(SubjectName, SubjectDescription) VALUES(@subjectName, @subjectDescription); " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@subjectName", SqlDbType.NVarChar).Value = subject.SubjectName;
                    cmd.Parameters.Add("@subjectDescription", SqlDbType.NVarChar).Value = subject.SubjectDescription;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }

            }
           
        }
        public void UpdateSubject(Subject subject)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Subject SET SubjectName= @subjectName, SubjectDescription= @subjectDescription WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = subject.SubjectId;
                    cmd.Parameters.Add("@subjectName", SqlDbType.NVarChar).Value = subject.SubjectName;
                    cmd.Parameters.Add("@subjectDescription", SqlDbType.NVarChar).Value = subject.SubjectDescription;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }

        }



        public void RegisterStudentInSubject(int studentId, int subjectId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO SubjectStudent (StudentId, SubjectId) VALUES (@studentId, @subjectId)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;
                    cmd.Parameters.Add("@subjectId", SqlDbType.Int).Value = subjectId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void RegisterTeacherInSubject(int teacherId, int subjectId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO SubjectTeacher (TeacherId, SubjectId) VALUES (@teacherId, @subjectId)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@teacherId", SqlDbType.Int).Value = teacherId;
                    cmd.Parameters.Add("@subjectId", SqlDbType.Int).Value = subjectId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
