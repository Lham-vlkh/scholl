using shcool.Models.Student;

namespace shcool.Repositories.Interfaces
{
    public interface IStudent
    {
        List<StudentInfo> GetStudentAsync();
        bool CreateStudent(string name, string family, int age, string phone, string email);
        StudentInfo GetStudentID(int id);
        bool DeleteStudent(int id);
        bool UpdateStudent(int id, string name, string family, int age, string phone, string email);
    }
}
