using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNet_RazorPages.Entities
{
    public class Student
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [StringLength(80, ErrorMessage = "O campo 'Nome' deve conter até 80 caracteres")]
        [MinLength(5, ErrorMessage = "O campo 'Nome' deve conter no mínimo 5 caracteres")]
        [DisplayName("Nome Completo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail informado inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public List<Subscription> Subscriptions { get; set; } = new();
    }
}
