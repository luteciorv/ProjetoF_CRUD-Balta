using Microsoft.AspNetCore.Mvc;
using RazorMVC.Extensions;
using RazorMVC.Interfaces;
using RazorMVC.ViewModels.Students;

namespace RazorMVC.Controllers
{
    public class StudentsController(IStudentClient client) : Controller
    {
        private readonly IStudentClient _client = client;

        public async Task<IActionResult> Index()
        {
            var students = await _client.GetAsync();

            if (students is null || students.Count == 0) return View(new List<ReadStudentViewModel>());
            return View(students.Select(s => s.MapToReadViewModel()));
        }
    }
}
