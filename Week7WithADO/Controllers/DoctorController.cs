using Microsoft.AspNetCore.Mvc;
using Week7WithADO.Models.Doctor;
using Week7WithADO.Services;

namespace Week7WithADO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var data = await _service.GetDoctors();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _service.GetDoctorById(id);

            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorModel model)
        {
            var id = await _service.CreateDoctor(model);

            return CreatedAtAction(nameof(GetDoctorById), new { id = id }, model);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorModel model)
        {
            var result = await _service.UpdateDoctor(model);

            if (!result)
                return NotFound();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _service.DeleteDoctor(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
