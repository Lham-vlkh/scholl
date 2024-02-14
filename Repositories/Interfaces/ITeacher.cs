using shcool.Models.Teacher;

namespace shcool.Repositories.Interfaces
{
    public interface ITeacher
    {
        List<TeacherInfo> GetTeacher();
        bool CreateTeacher(string name, string family, string Melicode, string phone, string Htadris);
        TeacherInfo GetTeacherID(int id);
        bool DeleteTeacher(int id);
        bool UpdateTeacher(int id, string name, string family, string Melicode, string phone, string Htadris);
    }
}
