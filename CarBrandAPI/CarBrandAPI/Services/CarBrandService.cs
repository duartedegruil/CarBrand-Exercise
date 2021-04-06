using AutoMapper;
using CarBrandAPI.Data;
using CarBrandAPI.DTO;
using CarBrandAPI.Models;
using CarBrandAPI.Services.Interfaces;
using CarBrandAPI.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CarBrandAPI.Services
{
    public class CarBrandService : ICarBrandService
    {
        private readonly IMapper _mapper;
        private readonly CarBrandContext _dbContext;

        public CarBrandService(IMapper mapper, CarBrandContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Create CarBrand instance in database.
        /// </summary>
        /// <param name="carBrandDTO">The CarBrand instance to create.</param>
        /// <returns></returns>
        public async Task<CarBrandDTO> CreateCarBrandAsync(CarBrandDTO carBrandDTO)
        {
            if (carBrandDTO == null)
            {
                throw new ArgumentNullException(Constants.NoInformationPassedToCreateCarBrand);
            }

            // Validate if CarBrand name already exists in the database
            bool wasCarBrandCreated = await _dbContext.CarBrands.FirstOrDefaultAsync(e => e.Name == carBrandDTO.Name) != null;
            if (wasCarBrandCreated)
            {
                throw new Exception(string.Format(Constants.CarBrandAlreadyExists, carBrandDTO.Name));
            }

            CarBrand carBrand = _mapper.Map<CarBrand>(carBrandDTO);

            carBrand = _dbContext.Set<CarBrand>().Add(carBrand).Entity;
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CarBrandDTO>(carBrand);
        }

        /// <summary>
        /// Get CarBrand by name.
        /// </summary>
        /// <param name="name">The CarBrand name.</param>
        /// <returns></returns>
        public async Task<CarBrandDTO> GetCarBrandByNameAsync(string name)
        {
            if (name.IsNullOrWhiteSpace())
            {
                throw new ArgumentException(Constants.NoNameSpecifiedForCarBrand);
            }

            CarBrand carBrand = await _dbContext.CarBrands.FirstOrDefaultAsync(e => e.Name == name);

            CarBrandDTO carBrandDTO = _mapper.Map<CarBrandDTO>(carBrand);

            if (carBrandDTO == null)
            {
                throw new ArgumentException(string.Format(Constants.CarBrandNotFound, name));
            }

            return carBrandDTO;
        }
    }
}
