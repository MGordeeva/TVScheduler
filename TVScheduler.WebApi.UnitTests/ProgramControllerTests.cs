using Microsoft.AspNetCore.Mvc;
using Moq;
using TVScheduler.Business.Interfaces;
using TVScheduler.DataAccess.Dto;
using TVScheduler.WebApi.Controllers;
using TVScheduler.WebApi.Models;

using Program = TVScheduler.DataAccess.Dto.Program;

namespace TVScheduler.WebApi.UnitTests
{
    public class ProgramControllerTests
    {
        private readonly Mock<IProgramService> programServiceMock;
        private readonly Mock<IChannelService> channelServiceMock;
        private readonly ProgramController controller;

        public ProgramControllerTests()
        {
            programServiceMock = new Mock<IProgramService>();
            channelServiceMock = new Mock<IChannelService>();
            controller = new ProgramController(programServiceMock.Object, channelServiceMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkObjectResult_WithPrograms()
        {
            // Arrange
            var channelId = 1;
            var startTime = DateTime.Now.AddDays(-1);
            var endTime = DateTime.Now.AddDays(1);
            var programs = CreateTestProgramList();
            programServiceMock.Setup(ps => ps.GetProgramsByChannelAsync(channelId, startTime, endTime))
                              .ReturnsAsync(programs);
            var channelServiceMock = new Mock<IChannelService>();


            // Act
            var result = await controller.Get(channelId, startTime, endTime) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            programServiceMock.Verify(ps => ps.GetProgramsByChannelAsync(channelId, startTime, endTime), Times.Once);
            Assert.Equal(result.Value, programs);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetById_ReturnsOkObjectResult_WithProgram()
        {
            // Arrange
            var channelId = 1;
            var programId = 123;
            var program = new Program
            {
                Name = "program name",
                Id = programId,
                Description = "program description",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
            };
            programServiceMock.Setup(ps => ps.GetProgramByIdAsync(channelId, programId))
                              .ReturnsAsync(program);
            var channelServiceMock = new Mock<IChannelService>();
            var controller = new ProgramController(programServiceMock.Object, channelServiceMock.Object);

            // Act
            var result = await controller.GetById(channelId, programId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            programServiceMock.Verify(ps => ps.GetProgramByIdAsync(channelId, programId), Times.Once);
            Assert.Equal(result.Value, program);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Create_WithValidChannel_ReturnsOkObjectResult_WithMessage()
        {
            // Arrange
            var channelId = 1;
            var createProgramRequest = new CreateProgramRequest { Name = "name" };
            channelServiceMock.Setup(cs => cs.GetChannelByIdAsync(channelId))
                              .ReturnsAsync(new Channel { Name = "name" });

            // Act
            var result = await controller.Create(channelId, createProgramRequest) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            channelServiceMock.Verify(cs => cs.GetChannelByIdAsync(channelId), Times.Once);
            programServiceMock.Verify(ps => ps.CreateProgramAsync(channelId, createProgramRequest), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Create_WithInvalidChannel_ReturnsBadRequestResult_WithErrorMessage()
        {
            // Arrange
            var channelId = 1;
            var createProgramRequest = new CreateProgramRequest { Name = "name" };
            channelServiceMock.Setup(cs => cs.GetChannelByIdAsync(channelId))
                              .ReturnsAsync((Channel)null);

            // Act
            var result = await controller.Create(channelId, createProgramRequest) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            channelServiceMock.Verify(cs => cs.GetChannelByIdAsync(channelId), Times.Once);
            programServiceMock.Verify(ps => ps.CreateProgramAsync(It.IsAny<int>(), It.IsAny<CreateProgramRequest>()), Times.Never);
            Assert.Equal($"Channel with id {channelId} does not exist", result.Value);
        }

        [Fact]
        public async Task Delete_ReturnsOkObjectResult_WithMessage()
        {
            // Arrange
            var channelId = 1;
            var programId = 123;

            // Act
            var result = await controller.Delete(channelId, programId) as OkObjectResult;

            // Assert
            programServiceMock.Verify(ps => ps.DeleteProgramAsync(channelId, programId), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        private IList<Program> CreateTestProgramList()
        {
            return new List<Program>{
            new Program
            {
                Name = "program name",
                Id = 1,
                Description = "program description",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
            },
            new Program
            {
                Name = "program name 2",
                Id = 2,
                Description = "program description",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(3),
            }};
        }
    }
}