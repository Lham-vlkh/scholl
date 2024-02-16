using shcool.Context;
using shcool.Models.Student;
using shcool.Models.Teacher;
using shcool.Repositories.Interfaces;

namespace shcool.Repositories.Implimention
{
    public class TeahcerRepository : ITeacher
    {
        private Database _context;
        public TeahcerRepository()
        {
            _context = new Database();
        }

        public bool CreateTeacher(string name, string family, string Melicode, string phone, string Htadris)
        {
            TeacherInfo create = new TeacherInfo()
            {
                Name = name,
                Family = family,
                Phone = phone,
                Htadris = Htadris,
                Melicode = Melicode,
            };
            _context.Teachers.Add(create);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTeacher(int id)
        {
            TeacherInfo delete = GetTeacherID(id);
            _context.Teachers.Remove(delete);
            _context.SaveChanges();
            return true;
        }

        public List<TeacherInfo> GetTeacher()
        {
            return _context.Teachers.ToList();
        }

        public TeacherInfo GetTeacherID(int id)
        {
            return _context.Teachers.FirstOrDefault(F => F.Id == id);
        }

        public bool UpdateTeacher(int id, string name, string family, string Melicode, string phone, string Htadris)
        {
            TeacherInfo update = GetTeacherID(id);
            update.Name = name;
            update.Family = family;
            update.Melicode = Melicode;
            update.Phone = phone;
            update.Htadris = Htadris;


            _context.Teachers.Update(update);
            _context.SaveChanges();
            return true;
        }
    }
}
