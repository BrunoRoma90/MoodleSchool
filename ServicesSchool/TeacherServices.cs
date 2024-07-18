using Project.ModelsSchool;
using Project.RepositorySchool;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ServicesSchool
{
    public class TeacherServices : ITeacherServices
    {
        private ITeacherRepository _teacherRepository = new TeacherRepository();
        private IAddressServices _addressServices = new AddressServices();
        private ISubjectServices _subjectServices = new SubjectServices();
        private ILectureServices _lectureServices = new LectureServices();

        public Teacher GetTeacherById(int id)
        {
            DataTable dt = _teacherRepository.GetTeacherById(id);

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

            Teacher teacher = new Teacher
            {
                TeacherId = id,
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

            return teacher;
        }
        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> lTeacher = new List<Teacher>();

            try
            {
                int addressId;

                DataTable dt = new DataTable();
                dt = _teacherRepository.GetAllTeachers();
                foreach (DataRow dr in dt.Rows)
                {

                    Address address = new Address();
                    if (dr["addressId"] != DBNull.Value)
                    {
                        addressId = Convert.ToInt32(dr["addressId"]);
                        address = _addressServices.GetAddressById(addressId);
                    }




                    Teacher teacher = new Teacher
                    {
                        TeacherId = Convert.ToInt32(dr["id"]),
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
                    lTeacher.Add(teacher);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Is not Working");
            }
            return lTeacher;

        }

        public Boolean InsertNewTeacher(Teacher newTeacher)
        {
            bool inserted = false;

            try
            {
                int addressId = _addressServices.InsertNewAddress(newTeacher.Address);
                newTeacher.Address.AddressId = addressId;
                _teacherRepository.InsertNewTeacher(newTeacher);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public List<Subject> GetSubjectsByTeacherId(int teacherId)
        {
            List<Subject> subjects = new List<Subject>();

            try
            {
                DataTable dt = _teacherRepository.GetSubjectByTeacherId(teacherId);
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



        public List<Lecture> GetLecturesByTeacherId(int teacherId)
        {
            List<Lecture> lectures = new List<Lecture>();

            try
            {
                DataTable dt = _teacherRepository.GetLectureByTeacherId(teacherId);
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



        public Teacher LoginTeacher(string username, string password)
        {


            DataTable dt = _teacherRepository.GetTeachersByCredentials(username, password);


            foreach (DataRow row in dt.Rows)
            {
                Teacher authenticatedTeacher = new Teacher
                {
                    TeacherId = Convert.ToInt32(row["id"]),
                    UserName = row["username"].ToString(),
                };
                return authenticatedTeacher;
            }
            return null;


        }


    }
}
