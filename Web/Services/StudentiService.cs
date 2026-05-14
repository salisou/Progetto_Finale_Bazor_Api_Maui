using DatiCondivi.Dtos;
using DatiCondivisi.Models;
using System.Net.Http.Json; // Aggiunto per PostAsJsonAsync, GetFromJsonAsync, ecc.

namespace Web.Services
{
    public class StudentiService : IStudentiService
    {
        private readonly HttpClient _httpClient;

        public StudentiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateStudenteAsync(StudenteDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Studenti", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteStudenteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Studenti/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IQueryable<StudenteDto>> GetStudentiAsync()
        {
            var lista = await _httpClient.GetFromJsonAsync<List<StudenteDto>>("api/Studenti")
                          ?? new List<StudenteDto>(); 

            return lista.AsQueryable(); 
        }

        public async Task<bool> UpdateStudenteAsync(int id, StudenteDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Studenti/{id}", dto);
            return response.IsSuccessStatusCode;
        }
    }
}