using Microsoft.AspNetCore.Mvc;

using Prodam.Core.Entities;
using Prodam.Core.Interfaces;
using Prodam.Web.ViewModels;

namespace Prodam.Web.Controllers
{
    public class ClassesController : Controller
    {

        private readonly IClassRepository _classRepository;
        private readonly IProfessorRepository _profRepository;


        public ClassesController(IClassRepository classRepository, IProfessorRepository profRepository)
        {
            this._classRepository = classRepository;
            this._profRepository = profRepository;

        }

        public async Task<IActionResult> Index()
        {
            var classes = await this._classRepository.GetClassesWithProfessor();
            return View(classes);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Professores"] = await this._profRepository.FindAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassViewModel classes)
        {
            var classModel = new Class
            {
                Id = Guid.NewGuid(),
                Number = classes.Number,
                ProfessorId = classes.ProfessorId,
                SchoolSubject = classes.SchoolSubject
            };

            if (ModelState.IsValid)
            {
                await this._classRepository.Add(classModel);
                await this._classRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index), classes);
            }

            return View(classes);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty) return NotFound();

            var oldClass = await this._classRepository.FindById(id);
            if (oldClass == null) return NotFound();

            ViewData["Professores"] = await this._profRepository.FindAll();

            var classViewModel = new ClassViewModel
            {
                Number = oldClass.Number,
                SchoolSubject = oldClass.SchoolSubject,
                ProfessorId = oldClass.ProfessorId,
                Professor = await this._profRepository.FindById(oldClass.ProfessorId)
            };

            return View(classViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Class model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {

                if (id == Guid.Empty) return NotFound();
                if (id != model.Id) return NotFound();

                var oldClass = await this._classRepository.FindById(id);
                if (oldClass == null) return NotFound();

                oldClass.Number = model.Number;
                oldClass.SchoolSubject = model.SchoolSubject;
                oldClass.ProfessorId = model.ProfessorId;

                await this._classRepository.Update(oldClass);
                await this._classRepository.SaveChangesAsync();

                var classViewModel = new ClassViewModel
                {
                    Number = model.Number,
                    SchoolSubject = model.SchoolSubject,
                    ProfessorId=model.ProfessorId
                };

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao editar o classe.");
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return NotFound();
            var classModel = await this._classRepository.FindById(id);
            if (classModel == null) return NotFound();
            return View(classModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var classModel = await this._classRepository.FindById(id);
            await this._classRepository.Delete(id);
            await this._classRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
