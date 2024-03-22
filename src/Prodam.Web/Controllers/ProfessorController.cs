using Microsoft.AspNetCore.Mvc;

using Prodam.Core.Entities;
using Prodam.Core.Interfaces;
using Prodam.Web.ViewModels;

namespace Prodam.Web.Controllers
{
    public class ProfessorController : Controller
    {

        private readonly IProfessorRepository _profRepository;

        public ProfessorController(IProfessorRepository profRepository)
        {
            this._profRepository = profRepository;
        }


        public async Task<ActionResult> Index()
        {
            return View(await this._profRepository.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessorViewModel professor)
        {

            var newProf = new Professor
            {
                Id = Guid.NewGuid(),
                Name = professor.Name,
                LastName = professor.LastName
            };

            if (ModelState.IsValid)
            {
                await this._profRepository.Add(newProf);
                return RedirectToAction(nameof(Index));
            }

            return View(professor);
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            if(id == Guid.Empty) return NotFound();

            var professor = await this._profRepository.FindById(id);
            if (professor == null) return NotFound();

            var profViewModel = new ProfessorViewModel
            {
                Name = professor.Name,
                LastName = professor.LastName
            };

            return View(profViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Professor newProfessor)
        {

            if (!ModelState.IsValid)
                return View(newProfessor);

            try
            {

                if (id == Guid.Empty) return NotFound();
                if (id != newProfessor.Id) return NotFound();

                var oldProfessor = await this._profRepository.FindById(id);
                if (oldProfessor == null) return NotFound();

                oldProfessor.Name = newProfessor.Name;
                oldProfessor.LastName = newProfessor.LastName;

                await this._profRepository.Update(oldProfessor);
                await this._profRepository.SaveChangesAsync();

                var profViewModel = new ProfessorViewModel
                {
                    Name = newProfessor.Name,
                    LastName = newProfessor.LastName
                };

                return RedirectToAction("Index");

            }
            catch(Exception ex) 
            {
                return StatusCode(500, "Ocorreu um erro ao editar o professor.");
            }

         
        }


        public async Task<IActionResult> Delete(Guid id)
        {

            if (id == Guid.Empty) return NotFound();
            var professor = await this._profRepository.FindById(id);
            if (professor == null) return NotFound();
            return View(professor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var professor = await this._profRepository.FindById(id);
            await this._profRepository.Delete(id);
            await this._profRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
