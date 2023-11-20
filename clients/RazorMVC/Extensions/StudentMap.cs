using RazorMVC.Models;
using RazorMVC.ViewModels.Students;

namespace RazorMVC.Extensions;

public static class StudentMap
{
    public static ReadStudentViewModel MapToReadViewModel(this Student model) =>
        new(model.Id, model.Name, model.Email, model.CreatedAt, model.Subscriptions.Select(s => s.MapToReadViewModel()).ToArray());
}
