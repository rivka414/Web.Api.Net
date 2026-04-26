using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Clean.Core.Entities;
using Clean.Core.DTOs;
using Clean.Service.Services;
using Web_api_queuies.Model;
using Microsoft.AspNetCore.Authorization;

namespace TipatCholAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BabiesController : ControllerBase
    {
        private readonly BabyService _service;
        private readonly IMapper _mapper;

        public BabiesController(BabyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BabyDTO>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BabyDTO>>(list));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BabyDTO>> GetById(int id)
        {
            var b = await _service.GetByIdAsync(id);
            if (b == null) return NotFound();
            return Ok(_mapper.Map<BabyDTO>(b));
        }

        [HttpPost]
        public async Task<ActionResult<BabyDTO>> Add(BabyPostModel model)
        {
            var baby = _mapper.Map<Baby>(model);
            await _service.AddAsync(baby);
            return CreatedAtAction(nameof(GetById), new { id = baby.Id }, _mapper.Map<BabyDTO>(baby));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BabyPostModel model)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();
            await _service.UpdateAsync(id, _mapper.Map<Baby>(model));
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