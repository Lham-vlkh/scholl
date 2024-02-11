using Microsoft.EntityFrameworkCore;
using shcool.Context;
using shcool.Models.Student;
using shcool.Repositories.Interfaces;

namespace shcool.Repositories.Implimention
{
    public class StudentRepository : IStudent
    {
        private Database _context;
        public StudentRepository()
        {
            _context = new Database();
        }

        public bool CreateStudent(string name, string family, int age, string phone, string email)
        {
            StudentInfo create = new StudentInfo()
            {
                Name = name,
                Family = family,
                Age = age,
                Email = email,
                Phone = phone,
            };
            _context.Students.Add(create);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            StudentInfo delete = GetStudentID(id);
            _context.Students.Remove(delete);
            _context.SaveChanges();
            return true;
        }

        public List<StudentInfo> GetStudentAsync()
        {
            return _context.Students.ToList();
        }

        public StudentInfo GetStudentID(int id) => _context.Students.FirstOrDefault(e => e.ID == id);

        public bool UpdateStudent(int id, string name, string family, int age, string phone, string email)
        {
            StudentInfo update = GetStudentID(id);

            update.Name = name;
            update.Family = family;
            update.Age = age;
            update.Phone = phone;
            update.Email = email;


            _context.Students.Update(update);
            _context.SaveChanges();
            return true;
        }
    }
}
