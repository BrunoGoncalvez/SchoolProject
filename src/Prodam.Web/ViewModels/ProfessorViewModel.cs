using System.ComponentModel.DataAnnotations;

namespace Prodam.Web.ViewModels
{
    public class ProfessorViewModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string LastName { get; set; }

    }
}
