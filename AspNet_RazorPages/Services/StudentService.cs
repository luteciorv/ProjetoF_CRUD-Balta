using AspNet_RazorPages.Entities;
using AspNet_RazorPages.Extensions;
using AspNet_RazorPages.Interfaces.Repositories;
using AspNet_RazorPages.Interfaces.Services;
using AspNet_RazorPages.ViewModels.Students;

namespace AspNet_RazorPages.Services
{
    public class StudentService : IStudentService
    {
        public readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyCollection<DetailStudentViewModel>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(s => s.MapToDetailViewModel()).ToArray();
        }

        public async Task<DetailStudentViewModel?> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(s => s.Id == id);
            return student?.MapToDetailViewModel();
        }

        public async Task CreateAsync(CreateStudentViewModel viewModel)
        {
            var student = viewModel.MapToEntity();

            await _repository.AddAsync(student);
            await _repository.SaveAsync();
        }

        public async Task EditAsync(EditStudentViewModel viewModel)
        {
            var student = viewModel.MapToEntity();

            _repository.Update(student);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(s => s.Id == id);
            if (student is null) return;

            _repository.Delete(student);
            await _repository.SaveAsync();
        }
    }
}
