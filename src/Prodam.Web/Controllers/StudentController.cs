using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Prodam.Core.Entities;
using Prodam.Core.Interfaces;

using Prodam.Web.ViewModels;

namespace Prodam.Web.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        public StudentController(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            this._studentRepository = studentRepository;
            this._classRepository = classRepository;
        }


        public async Task<IActionResult> Index()
        {
            var students = await this._studentRepository.GetStudentsWithClass();
            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Classes"] = await this._classRepository.FindAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel student)
        {
            var studentModel = new Student
            {
                Id = Guid.NewGuid(),
                Name = student.Name,
                ClassId = student.ClassId
            };

            if (ModelState.IsValid)
            {
                await this._studentRepository.Add(studentModel);
                await this._classRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Classes"] = await this._classRepository.FindAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
