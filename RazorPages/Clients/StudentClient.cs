using RazorPages.Interfaces;
using RazorPages.Models;
using RazorPages.ViewModels.Students;
using Newtonsoft.Json;

namespace RazorPages.Clients
{
    public class StudentClient : IStudentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StudentClient> _logger;

        public StudentClient(HttpClient httpClient, ILogger<StudentClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Student>?> GetAsync()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IReadOnlyCollection<Student>>(apiResponse);
            }

            _logger.LogError($"Não foi possível recuperar todos os alunos. Código da resposta: {response.StatusCode}");
            return Array.Empty<Student>();
        }

        public Task<DetailStudentViewModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync(CreateStudentInputModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(EditStudentInputModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
