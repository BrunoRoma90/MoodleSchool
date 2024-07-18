namespace Project.ModelsSchool
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public DateTime BirthDate { get; set; }
        public string Email { get; set; }


        public string PhoneNumber { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }

        public Person() { }
        public Person(int personId, string firstName, string middleName, string lastName, int age, DateTime birthDate, string email, string phoneNumber, string userName, string password, Address address)
        {
            PersonId = personId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Age = age;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
            UserName = userName;
            Password = password;
            Address = address;
        }
    }
}