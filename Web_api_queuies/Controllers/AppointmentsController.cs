using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Clean.Core.Entities;
using Clean.Core.DTOs;
using Clean.Service.Services;
using Web_api_queuies.Model;

namespace TipatCholAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;
        private readonly IMapper _mapper;

        public AppointmentsController(AppointmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AppointmentDTO>>(list));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> GetById(int id)
        {
            var a = await _service.GetByIdAsync(id);
            if (a == null) return NotFound();
            return Ok(_mapper.Map<AppointmentDTO>(a));
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDTO>> Add(AppointmentPostModel model)
        {
            var appointment = _mapper.Map<Appointment>(model);
            await _service.AddAsync(appointment);
            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, _mapper.Map<AppointmentDTO>(appointment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AppointmentPostModel model)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();

            var updated = _mapper.Map<Appointment>(model);
            await _service.UpdateAsync(id, updated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}