using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shcool.Models;
using shcool.Models.Student;
using shcool.Repositories.Implimention;
using shcool.Repositories.Interfaces;
using sholl.Models;
using System.Diagnostics;

namespace sholl.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return View(update);
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
                    ID = id,
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



        //using tow model
        public IActionResult Create()
        {
            var viewModel = new GetTowModels();
            {
                StudentInfo student = new StudentInfo();
                StudentInfo studentList = new StudentInfo();

            }

            return View(viewModel);
        }
    }
}
