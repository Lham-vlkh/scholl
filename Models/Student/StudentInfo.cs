using shcool.Models.Person;

namespace shcool.Models.Student
{
    public class StudentInfo : InfoPerson
    {

        public int ID { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

    }
}
