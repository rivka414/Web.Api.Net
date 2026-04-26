using System;
using Microsoft.AspNetCore.Mvc;
using TipatCholAPI;
using TipatCholAPI.Controllers;
using TipatCholAPI.Entities;
using Xunit;

namespace unitTest
{
    public class BabiesControllerTests
    {
        private readonly DataContext _context;
        private readonly BabiesController _controller;

        public BabiesControllerTests()
        {
            _context = new DataContext();
            _controller = new BabiesController(_context);
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
        public void Add_ValidBaby_ReturnsCreatedAtAction()
        {
            var baby = new Baby
            {
                FirstName = "Noa",
                LastName = "Levi",
                DateOfBirth = DateTime.Now,
                Status = "פעיל"
            };

            var result = _controller.Add(baby);
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }
    }
}
