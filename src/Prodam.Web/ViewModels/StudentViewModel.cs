using Prodam.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Prodam.Web.ViewModels
{
    public class StudentViewModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid ClassId { get; set; }

        public Class Class { get; set; }

    }
}
