using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shcool.Models.Student;
using shcool.Repositories.Implimention;
using shcool.Repositories.Interfaces;

namespace sholl.Controllers
{
    public class HomeController : Controller
    {
        private IStudent _StudentRepository;

        public HomeController()
        {
            _StudentRepository = new StudentRepository();
        }

        public IActionResult Index()
        {
          
            List<StudentInfo> showList = _StudentRepository.GetStudentAsync();

            return View(showList);
        }

        [HttpPost]
        public IActionResult Index(string name, string family, int age, string phone, string email)
        {
            bool result = _StudentRepository.CreateStudent(name, family, age, phone, email);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            StudentInfo update = _StudentRepository.GetStudentID(id);
          if(update != null)
            {

            return View(update);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Edit(int id, string name, string family, int age, string phone, string email)
        {
            var result = _StudentRepository.UpdateStudent(id, name, family, age, phone, email);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                StudentInfo update = new StudentInfo()
                {
                    Name = name,
                    Family = family,
                    Age = age,
                    Phone = phone,
                    Email = email
                };
                return View(update);
            }
        }
        public IActionResult Remove(int id)
        {
            _StudentRepository.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        public IActionResult Teacher()
        {
            return View();
        }

    }
}
