using System.Net;

namespace registration.Services
{
    public class SubjectClient
    {
        private readonly HttpClient _http;

        public SubjectClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> IsSubjectExist(int subjectId)
        {
            var response = await _http.GetAsync($"/api/subjects/{subjectId}");
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
