using Microsoft.AspNetCore.Mvc;
using Week7WithADO.Models.Appointment;
using Week7WithADO.Services;

namespace Week7WithADO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var data = await _service.GetAppointments();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var data = await _service.GetAppointmentById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentModel model)
        {
            var id = await _service.CreateAppointment(model);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = id }, model);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentModel model)
        {
            var result = await _service.UpdateAppointment(model);

            if (!result)
                return NotFound();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await _service.DeleteAppointment(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
        [HttpGet("by-doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(int doctorId)
        {
            var data = await _service.GetAppointmentsByDoctor(doctorId);

            if (data == null || !data.Any())
                return NotFound();

            return Ok(data);
        }
    }
}
