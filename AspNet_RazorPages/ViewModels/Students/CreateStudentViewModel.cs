using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AspNet_RazorPages.ViewModels.Students
{
    public class CreateStudentViewModel
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [StringLength(80, ErrorMessage = "O campo 'Nome' deve conter até 80 caracteres")]
        [MinLength(5, ErrorMessage = "O campo 'Nome' deve conter no mínimo 5 caracteres")]
        [DisplayName("Nome Completo")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail informado inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;
    }
       
}
