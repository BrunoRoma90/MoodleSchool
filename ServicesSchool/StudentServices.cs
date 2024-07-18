using Project.ModelsSchool;
using Project.RepositorySchool;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project.ServicesSchool
{
    public class StudentServices : IStudentServices
    {
        private IStudentRepository _studentRepository = new StudentRepository();
        private IAddressServices _addressServices = new AddressServices();
        private ISubjectServices _subjectServices = new SubjectServices();
        private ILectureServices _lectureServices = new LectureServices();


        #region
        //public Student GetStudentsById(int id)
        //{
        //    DataTable dt = _studentRepository.GetStudentById(id);
        //    DataRow dr = dt.Rows[0];

        //    int addressId;
        //    Address address = new Address();
        //    if (dr["addressId"] != DBNull.Value)
        //    {
        //        addressId = Convert.ToInt32(dr["addressId"]);
        //        address = _addressServices.GetAddressById(addressId);
        //    }

        //    Student student = new Student
        //    {
        //        StudentID = id,
        //        FirstName = dr["firstName"].ToString(),
        //        MiddleName = dr["middleName"].ToString(),
        //        LastName = dr["lastName"].ToString(),
        //        BirthDate = Convert.ToDateTime(dr["birthdate"].ToString()),
        //        Email = dr["email"].ToString(),
        //        PhoneNumber = dr["phoneNumber"].ToString(),
        //        UserName = dr["username"].ToString(),
        //        Password = dr["password"].ToString(),
        //        Address = new Address
        //        {
        //            Street = address.Street,
        //            Number = address.Number,
        //            PostalCode = address.PostalCode,
        //            Locale = address.Locale
        //        },
        //    };
        //    return student;
        //}
        #endregion

        public Student GetStudentsById(int id)
        {
            DataTable dt = _studentRepository.GetStudentById(id);

            if (dt.Rows.Count == 0)
            {
                // Lidar com o caso em que o estudante não é encontrado
                return null;
            }

            DataRow dr = dt.Rows[0];

            Address address = null;
            if (dr["addressId"] != DBNull.Value)
            {
                int addressId = Convert.ToInt32(dr["addressId"]);
                address = _addressServices.GetAddressById(addressId);
            }

            Student student = new Student
            {
                StudentID = id,
                FirstName = dr["firstName"].ToString(),
                MiddleName = dr["middleName"].ToString(),
                LastName = dr["lastName"].ToString(),
                BirthDate = Convert.ToDateTime(dr["birthdate"]),
                Email = dr["email"].ToString(),
                PhoneNumber = dr["phoneNumber"].ToString(),
                UserName = dr["username"].ToString(),
                Password = dr["password"].ToString(),
                Address = address
            };

            return student;
        }


        public List<Student> GetAllStudents()
        {
            List<Student> lStudents = new List<Student>();

            try
            {
                int addressId;

                DataTable dt = new DataTable();
                dt = _studentRepository.GetAllStudents();
                foreach (DataRow dr in dt.Rows)
                {

                    Address address = new Address();
                    if (dr["addressId"] != DBNull.Value)
                    {
                        addressId = Convert.ToInt32(dr["addressId"]);
                        address = _addressServices.GetAddressById(addressId);
                    }




                    Student student = new Student
                    {
                        StudentID = Convert.ToInt32(dr["id"]),
                        FirstName = dr["firstName"].ToString(),
                        MiddleName = dr["middleName"].ToString(),
                        LastName = dr["lastName"].ToString(),
                        BirthDate = Convert.ToDateTime(dr["birthdate"]),
                        Email = dr["email"].ToString(),
                        PhoneNumber = dr["phoneNumber"].ToString(),
                        UserName = dr["username"].ToString(),
                        Password = dr["password"].ToString(),
                        Address = address
                    };
                    lStudents.Add(student);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Is not Working");
            }
            return lStudents;

        }

        public Boolean InsertNewStudent(Student newStudent)
        {
            bool inserted = false;

            try
            {
                int addressId = _addressServices.InsertNewAddress(newStudent.Address);
                newStudent.Address.AddressId = addressId;
                
                _studentRepository.InsertNewStudent(newStudent);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public List<Subject> GetSubjectsBySudentId(int studentId)
        {
            List<Subject> subjects = new List<Subject>();

            try
            {
                DataTable dt = _studentRepository.GetSubjectByStudentId(studentId);
                foreach (DataRow dr in dt.Rows)
                {
                    int subjectId = Convert.ToInt32(dr["subjectId"]);
                    Subject subject = _subjectServices.GetSubjectById(subjectId);
                    if (subject != null)
                    {
                        subjects.Add(subject);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return subjects;
        }


        public List<Lecture> GetLectureBySudentId(int studentId)
        {
            List<Lecture> lectures = new List<Lecture>();

            try
            {
                DataTable dt = _studentRepository.GetLectureByStudentId(studentId);
                foreach (DataRow dr in dt.Rows)
                {
                    int classId = Convert.ToInt32(dr["classId"]);
                    Lecture lecture = _lectureServices.GetLectureById(classId);
                    if (lecture != null)
                    {
                        lectures.Add(lecture);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return lectures;
        }


        public Student LoginStudent(string username, string password)
        {


            DataTable dt = _studentRepository.GetStudentsByCredentials(username, password);


            foreach (DataRow row in dt.Rows)
            {
                Student authenticatedStudent = new Student
                {
                    StudentID = Convert.ToInt32(row["id"]),
                    UserName = row["username"].ToString(),
                };
                return authenticatedStudent;
            }
            return null;


        }





    }
}
