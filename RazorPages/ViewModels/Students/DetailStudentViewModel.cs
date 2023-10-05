namespace RazorPages.ViewModels.Students
{
    public class DetailStudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
    }
}
