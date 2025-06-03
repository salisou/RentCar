using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RentCar.Application.Features.Mediator.Commands.TestimonialCommands;
using RentCar.WebApi.Controllers;

namespace RentCar.Test
{
    public class TestimonialsControllerTest
    {
        private readonly TestimonialsController _controller;
        private readonly Mock<IMediator> _mediatorMock;

        public TestimonialsControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            // Setup del mock per restituire un risultato fittizio
            _mediatorMock.Setup(m => m.Send(It.IsAny<object>(), default))
                         .ReturnsAsync(new object()); // Sostituisci con il tipo di ritorno reale se necessario

            _controller = new TestimonialsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetTestimonials_ShouldReturnOkResult()
        {
            // Act
            var result = await _controller.GetTestimonials();
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task PostTesttimonial()
        {
            // Arrange
            var command = new CreateTestimonialCommand
            {
                Name = "Test User",
                Content = "This is a test testimonial.",
                ImageUrl = "http://example.com/image.jpg"
            };
            // Act
            var result = await _controller.CreateTestimonial(command);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task UpdateTestimonial()
        {
            // Arrange
            var command = new UpdateTestimonialCommand
            {
                TestimonialId = 1,
                Name = "Updated User",
                Content = "This is an updated testimonial.",
                ImageUrl = "http://example.com/updated_image.jpg"
            };
            // Act
            var result = await _controller.UpdateTestimonial(command);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteTestimonial()
        {
            // Arrange
            int testimonialId = 1; // Supponiamo che il Testimonial con ID 1 esista
            // Act
            var result = await _controller.DeleteTestimonial(testimonialId);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        //[Fact]
        //public async Task GetTestimonialById_ReturnsOk_WhenFound()
        //{
        //    // Arrange
        //    int id = 1;
        //    var expectedResult = new
        //    {
        //        Id = id,
        //        Name = "Test User",
        //        Content = "This is a test testimonial.",
        //        ImageUrl = "http://example.com/image.jpg"
        //    };


        //    // Act
        //    var result = await _controller.GetTestimonialById(id);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.Equal(expectedResult, okResult.Value);
        //}
    }
}
