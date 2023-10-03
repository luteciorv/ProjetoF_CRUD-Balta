using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNet_RazorPages.Entities
{
    public class Subscription
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Título' é obrigatório")]
        [StringLength(80, ErrorMessage = "O campo 'Título' deve conter até 80 caracteres")]
        [MinLength(5, ErrorMessage = "O campo 'Título' deve conter pelo menos 5 caracteres")]
        [DisplayName("Título")]
        public string Title { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Início")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Término")]
        public DateTime EndDate { get; set; }

        [DisplayName("Aluno")]
        [Required(ErrorMessage = "O campo 'Aluno' é obrigatório")]
        public int StudentId { get; set; }

        public Student? Student { get; set; }
    }
}
