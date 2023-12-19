using AssoSw.Lesson7.WpfConsumingAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AssoSw.Lesson7.WpfConsumingAPI.Service
{
    public static class APIRequestor
    {
        private static readonly HttpClient _httpClient;

        static APIRequestor()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("http://localhost:5164/");
        }

        public static string Token { get; private set; }

        public static async Task<bool> LoginAsync(AuthRequestDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponseDTO>();
                if (!string.IsNullOrEmpty(authResponse.Token))
                {
                    Token = authResponse.Token;
                    return true;
                }
            }
            return false;
        }

        public static async Task<List<Customer>> GetCustomersAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/customers");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var customers = await response.Content.ReadFromJsonAsync<List<Customer>>();
                return customers;
            }
            return null;
        }
    }
}
