using System.Net;

namespace registration.Services
{
    public class StudentClient
    {
        private readonly HttpClient _http;

        public StudentClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> IsStudentExist(int studentId)
        {
            var response = await _http.GetAsync($"/api/students/{studentId}");
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
