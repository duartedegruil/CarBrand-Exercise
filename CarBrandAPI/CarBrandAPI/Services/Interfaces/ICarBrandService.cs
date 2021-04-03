using CarBrandAPI.DTO;
using System.Threading.Tasks;

namespace CarBrandAPI.Services.Interfaces
{
    public interface ICarBrandService
    {
        Task<CarBrandDTO> CreateCarBrandAsync(CarBrandDTO dto);
        Task<CarBrandDTO> GetCarBrandByNameAsync(string name);
    }
}
