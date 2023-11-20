using RazorMVC.Interfaces;
using RazorMVC.Models;
using Newtonsoft.Json;

namespace RazorMVC.Clients
{
    public class StudentClient(HttpClient httpClient, ILogger<StudentClient> logger) : IStudentClient
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<StudentClient> _logger = logger;

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
