using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using System.Security.Claims;
using Project.ModelsSchool;
using RepositorySchool;

namespace Project.RepositorySchool
{
    public class LectureRepository : ILectureRepository
    {
        //private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString();

        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();
        public DataTable GetLectureById(int id)
        {
            DataTable dt = new DataTable();



            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Class Where id = @classId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    //cmd.Parameters.AddWithValue("@addressId", id);
                    cmd.Parameters.Add("@classId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }


        public DataTable GetAllLectures()
        {
            DataTable dt = new DataTable();



            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Class";

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



        public void InsertNewLecture(Lecture lecture)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Class(StartTime, EndTime, SubjectId, ClassName) VALUES( @startTime, @endTime, @subjectId, @className)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values                    
                    cmd.Parameters.Add("@startTime", SqlDbType.DateTime2).Value = lecture.StartTime;
                    cmd.Parameters.Add("@endTime", SqlDbType.DateTime2).Value = lecture.EndTime;
                    cmd.Parameters.Add("@subjectId", SqlDbType.Int).Value = lecture.ClassSubject.SubjectId;
                    cmd.Parameters.Add("@className", SqlDbType.NVarChar).Value = lecture.ClassName;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateLecture(Lecture lecture)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Class SET startTime= @startTime, endTime= @endTime, subjectId= @subjectId, className= @className WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = lecture.ClassId;
                    cmd.Parameters.Add("@startTime", SqlDbType.DateTime2).Value = lecture.StartTime;
                    cmd.Parameters.Add("@endTime", SqlDbType.DateTime2).Value = lecture.EndTime;
                    cmd.Parameters.Add("@subjectId", SqlDbType.Int).Value = lecture.ClassSubject.SubjectId;
                    cmd.Parameters.Add("@className", SqlDbType.NVarChar).Value = lecture.ClassName;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }

        }



        public void RegisterStudentInLecture(int studentId, int classId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO ClassStudent (StudentId, ClassId) VALUES (@studentId, @classId)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;
                    cmd.Parameters.Add("@classId", SqlDbType.Int).Value = classId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void RegisterTeacherInLecture(int teacherId, int classId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO ClassTeacher (TeacherId, ClassId) VALUES (@teacherId, @classId)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@teacherId", SqlDbType.Int).Value = teacherId;
                    cmd.Parameters.Add("@classId", SqlDbType.Int).Value = classId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public int LastLectureId()
        {
            int lectureId = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT IDENT_CURRENT('Class');";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    lectureId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return lectureId;
            }



        }

    }
}
