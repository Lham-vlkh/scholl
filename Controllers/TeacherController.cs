using Microsoft.AspNetCore.Mvc;
using shcool.Models.Student;
using shcool.Models.Teacher;
using shcool.Repositories.Implimention;
using shcool.Repositories.Interfaces;

namespace shcool.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacher _TeacherRepository;

        public TeacherController()
        {
            _TeacherRepository = new TeahcerRepository();
        }


        public IActionResult Index()
        {
            List<TeacherInfo> showList = _TeacherRepository.GetTeacher();

            return View(showList);
        }
        [HttpPost]
        public IActionResult Index(string name, string family, string Melicode, string phone, string Htadris)
        {
            bool result = _TeacherRepository.CreateTeacher(name, family, Melicode, phone, Htadris);
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
            TeacherInfo update = _TeacherRepository.GetTeacherID(id);
            if (update != null)
            {

                return View(update);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Edit(int id, string name, string family, string Melicode, string phone, string Htadris)
        {
            var result = _TeacherRepository.UpdateTeacher(id, name, family, Melicode, phone, Htadris);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TeacherInfo update = new TeacherInfo()
                {
                    Name = name,
                    Family = family,
                    Melicode = Melicode,
                    Phone = phone,
                    Htadris = Htadris
                };
                return View(update);
            }
        }
        public IActionResult Remove(int id)
        {
            _TeacherRepository.DeleteTeacher(id);
                return RedirectToAction("Index");
        }
        public IActionResult Teacher()
        {
            return View();
        }
    }
}
