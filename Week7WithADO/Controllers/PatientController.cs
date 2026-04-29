using Microsoft.AspNetCore.Mvc;
using Week7WithADO.Models;
using Week7WithADO.Services;

namespace Week7WithADO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController: ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var data = await _service.GetPatients();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _service.GetPatientById(id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient(CreatePatientModel model)
        {
            var id = await _service.CreatePatient(model);

            return CreatedAtAction(nameof(GetPatientById), new { id = id }, model);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePatient(UpdatePatientModel model)
        {
            var result = await _service.UpdatePatient(model);

            if (!result)
                return NotFound();

            return NoContent(); // 204
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _service.DeletePatient(id);

            if (!result)
                return NotFound();

            return NoContent(); // 204
        }
        [HttpGet("with-appointments")]
        public async Task<IActionResult> GetPatientsWithAppointments()
        {
            var data = await _service.GetPatientsWithAppointments();
            return Ok(data);
        }
        [HttpGet("without-appointments")]
        public async Task<IActionResult> GetPatientsWithoutAppointments()
        {
            var data = await _service.GetPatientsWithoutAppointments();
            return Ok(data);
        }
        
    }
}
