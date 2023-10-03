using System.ComponentModel;

namespace AspNet_RazorPages.ViewModels.Students
{
    public class DeleteStudentViewModel
    {
        public DeleteStudentViewModel(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        [DisplayName("Código")]
        public int Id { get; private set; }

        [DisplayName("Nome Completo")]
        public string Name { get; private set; }

        [DisplayName("E-mail")]
        public string Email { get; private set; }
    }    
}
