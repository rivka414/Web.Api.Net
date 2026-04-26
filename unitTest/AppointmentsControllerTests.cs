using System;
using Microsoft.AspNetCore.Mvc;
using TipatCholAPI;
using TipatCholAPI.Controllers;
using TipatCholAPI.Entities;
using Xunit;

namespace unitTest
{
    public class AppointmentsControllerTests
    {
        private readonly DataContext _context;
        private readonly AppointmentsController _controller;

        public AppointmentsControllerTests()
        {
            _context = new DataContext();
            _controller = new AppointmentsController(_context);
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
        public void Add_ValidAppointment_ReturnsCreatedAtAction()
        {
            var appointment = new Appointment
            {
                BabyId = 1,
                NurseId = 1,
                Date = DateTime.Now,
                Status = "חדש",
                Notes = "בדיקה"
            };

            var result = _controller.Add(appointment);
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }
    }
}
