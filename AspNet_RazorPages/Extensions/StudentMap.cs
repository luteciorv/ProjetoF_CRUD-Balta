using AspNet_RazorPages.Entities;
using AspNet_RazorPages.ViewModels.Students;

namespace AspNet_RazorPages.Extensions
{
    public static class StudentMap
    {
        public static Student MapToEntity(this CreateStudentViewModel viewModel) =>
            new()
            {
                Name = viewModel.Name,
                Email = viewModel.Email
            };

        public static Student MapToEntity(this EditStudentViewModel viewModel) =>
           new()
           {
               Id = viewModel.Id,
               Name = viewModel.Name,
               Email = viewModel.Email
           };

        public static ReadStudentViewModel MapToReadViewModel(this DetailStudentViewModel viewModel) =>
           new(viewModel.Id, viewModel.Name, viewModel.Email);

        public static DetailStudentViewModel MapToDetailViewModel(this Student entity) =>
          new(entity.Id, entity.Name, entity.Email);

        public static EditStudentViewModel MapToEditViewModel(this DetailStudentViewModel viewModel) =>
            new()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Email = viewModel.Email,
            };
    }
}
