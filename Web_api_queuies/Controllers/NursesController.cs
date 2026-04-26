using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Clean.Core.Entities;
using Clean.Core.DTOs;
using Clean.Service.Services;
using Web_api_queuies.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TipatCholAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NursesController : ControllerBase
    {
        private readonly NurseService _service;
        private readonly IMapper _mapper;

        public NursesController(NurseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NurseDTO>>> GetAll()
        {
            var nurses = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<NurseDTO>>(nurses));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NurseDTO>> GetById(int id)
        {
            var n = await _service.GetByIdAsync(id);
            if (n == null) return NotFound();
            return Ok(_mapper.Map<NurseDTO>(n));
        }

        [HttpPost]
        public async Task<ActionResult<NurseDTO>> Add(NursePostModel model)
        {
            var nurse = _mapper.Map<Nurse>(model);
            await _service.AddAsync(nurse);
            return CreatedAtAction(nameof(GetById), new { id = nurse.Id }, _mapper.Map<NurseDTO>(nurse));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NursePostModel model)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();

            await _service.UpdateAsync(id, _mapper.Map<Nurse>(model));
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();

            await _service.UpdateStatusAsync(id, status);
            return NoContent();
        }
    }
}