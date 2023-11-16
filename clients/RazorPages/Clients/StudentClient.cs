using RazorPages.Interfaces;
using RazorPages.Models;
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

        public async Task<IReadOnlyCollection<Student>> GetAsync()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<IReadOnlyCollection<Student>>(apiResponse) ?? Array.Empty<Student>();
                return students.ToList();
            }

            _logger.LogError($"Não foi possível recuperar os alunos cadastrados. Código da resposta: {response.StatusCode}");
            return Array.Empty<Student>();
        }
    }
}
