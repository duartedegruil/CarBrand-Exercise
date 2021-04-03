using CarBrandAPI.DTO;
using CarBrandAPI.Services.Interfaces;
using CarBrandAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarBrandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        private readonly ICarBrandService _carBrandService;
        private readonly ILogger<CarBrandController> _logger;

        public CarBrandController(ICarBrandService carBrandService, ILogger<CarBrandController> logger)
        {
            _carBrandService = carBrandService;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint to get CarBrand by name.
        /// GET api/<CarBrandController>/5
        /// </summary>
        /// <param name="name">The CarBrand name.</param>
        /// <returns>The CarBrand.</returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCarBrandByName([FromRoute] string name)
        {
            CarBrandDTO output;
            try
            {
                output = await _carBrandService.GetCarBrandByNameAsync(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(output);
        }

        /// <summary>
        /// Endpoint to create CarBrand.
        /// POST api/<CarBrandController>
        /// </summary>
        /// <param name="carBrand">The CarBrand.</param>
        /// <returns>Success/Error message.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCarBrand([FromBody] CarBrandDTO carBrand)
        {
            CarBrandDTO output;
            try
            {
                output = await _carBrandService.CreateCarBrandAsync(carBrand);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Created(string.Format(Constants.CarBrandSuccessfullyCreated, output.Name), output.Id);
        }
    }
}
