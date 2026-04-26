using Microsoft.AspNetCore.Mvc;
using TipatCholAPI;
using TipatCholAPI.Controllers;
using TipatCholAPI.Entities;
using Xunit;

namespace unitTest
{
    public class NursesControllerTests
    {
        private readonly DataContext _context;
        private readonly NursesController _controller;

        public NursesControllerTests()
        {
            _context = new DataContext();
            _controller = new NursesController(_context);
        }

        [Fact]
        public void GetAll_ReturnsOk()
        {
            var result = _controller.GetAll();
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetById_NotExistingId_ReturnsNotFound()
        {
            var result = _controller.GetById(999);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Add_ValidNurse_ReturnsCreatedAtAction()
        {
            var nurse = new Nurse
            {
                FirstName = "Dana",
                LastName = "Cohen",
                Role = "אחות",
                Status = "פעילה"
            };

            var result = _controller.Add(nurse);
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }
    }
}
