using DatiCondivi.Dtos;

namespace Web.Services
{
    public interface IStudentiService
    {
        Task<bool> CreateStudenteAsync(StudenteDto dto);
        Task<bool> DeleteStudenteAsync(int id);
        Task<IQueryable<StudenteDto>> GetStudentiAsync();
        Task<bool> UpdateStudenteAsync(int id, StudenteDto dto);
    }
}
