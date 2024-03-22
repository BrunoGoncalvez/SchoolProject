using Prodam.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Prodam.Web.ViewModels
{
    public class ClassViewModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string SchoolSubject { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public List<Student> Students { get; set; }

    }
}
