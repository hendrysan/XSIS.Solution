using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XSIS.Contexts;
using XSIS.Models.Entities;
using XSIS.Services.Implements;
using XSIS.Services.Interfaces;
using XSIS.WebApi.Controllers;

namespace XSIS.UnitTests
{
    public class MovieUnitTest
    {
        private readonly MovieController _controller;
        private readonly IMovie _service;
        private readonly DatabaseContext _context;



        public MovieUnitTest()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var dbOption = new DbContextOptionsBuilder<DatabaseContext>().Options;

            _context = new DatabaseContext(dbOption, configuration);
            _service = new MovieRepository(_context);
            _controller = new MovieController(_service);
        }

        [Fact]
        public async Task Post_WhenCalled_ReturnsOkResultAsync()
        {
            // Arrange
            var movie = new Movie()
            {
                Id = 1,
                Title = "Pengabdi Setan 2 Comunion",
                Description = "dalah sebuah film horor Indonesia tahun 2022 yang disutradarai dan ditulis oleh Joko Anwar sebagai sekuel dari film tahun 2017, Pengabdi Setan.",
                Rating = 7,
                Image = string.Empty,
                Created_at = Convert.ToDateTime("2022-08-01 10:56:31"),
                Updated_at = Convert.ToDateTime("2022-08-13 09:30:23")
                
            };

            // Act
            var result = await _controller.Create(movie);
            var okResult = result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            
        }

        [Fact]
        public async Task GetAll_WhenCalled_ReturnsOkResultAsync()
        {
            // Act
            var result = await _controller.GetAll();//
            var okResult = result as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            
        }

        [Fact]
        public async Task GetById_WhenCalled_ReturnsOkResultAsync()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _controller.GetById(id);
            var okResult = result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            
        }

        [Fact]
        public async Task Patch_WhenCalled_ReturnsOkResultAsync()
        {
            // Arrange
            var id = 1;
            var movie = new Movie()
            {
                Id = 1,
                Title = "Pengabdi Setan 2 Comunion UPDATE",
                Description = "dalah sebuah film horor Indonesia tahun 2022 yang disutradarai dan ditulis oleh Joko Anwar sebagai sekuel dari film tahun 2017, Pengabdi Setan. UPDATE",
                Rating = 7,
                Image = string.Empty,
                Created_at = Convert.ToDateTime("2022-08-01 10:56:31"),
                Updated_at = Convert.ToDateTime("2022-08-13 09:30:23")

            };

            // Act
            var result = await _controller.Update(movie, id);
            var okResult = result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);

            
            
        }

        [Fact]
        public async Task Delete_WhenCalled_ReturnsOkResultAsync()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _controller.Delete(id);
            var okResult = result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            
        }
    }
}