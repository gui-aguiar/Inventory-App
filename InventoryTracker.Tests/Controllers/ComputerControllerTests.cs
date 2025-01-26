using InventoryTracker.Dtos;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using InventoryTracker.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InventoryTracker.Tests.Controllers
{
    public class ComputerControllerTests
    {
        private readonly Mock<IComputerService> _computerServiceMock;
        private readonly ComputerController _computerController;

        public ComputerControllerTests()
        {
            _computerServiceMock = new Mock<IComputerService>();
            _computerController = new ComputerController(_computerServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_Should_Return_PagedResponse_When_Data_Exists()
        {
            // Arrange
            var computers = new List<ComputerDto>
            {
                new ComputerDto { Id = 1, ManufacturerId = 1, SerialNumber = "ABC123", Specifications = "Specs 1" },
                new ComputerDto { Id = 2, ManufacturerId = 2, SerialNumber = "XYZ789", Specifications = "Specs 2" }
            };

            var paginationMetadata = new PaginationMetadata
            {
                TotalItems = 2,
                PageSize = 10,
                CurrentPage = 1,
                TotalPages = 1
            };

            _computerServiceMock
                .Setup(s => s.GetAllAsync(0, 10))
                .ReturnsAsync((computers, paginationMetadata));

            // Act
            var result = await _computerController.GetAll(0, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // Verifica se é HTTP 200
            var response = Assert.IsType<PagedResponse<ComputerDto>>(okResult.Value); // Verifica o tipo do retorno
            Assert.Equal(2, response.Data.Count()); // Verifica o número de itens retornados
            _computerServiceMock.Verify(s => s.GetAllAsync(0, 10), Times.Once); // Verifica que o serviço foi chamado
        }
        [Fact]
        public async Task GetById_Should_Return_Computer_When_Computer_Exists()
        {
            // Arrange
            var computerId = 1;
            var computerDto = new ComputerDto
            {
                Id = computerId,
                ManufacturerId = 1,
                SerialNumber = "ABC123",
                Specifications = "Specs"
            };

            _computerServiceMock
                .Setup(s => s.GetByIdAsync(computerId))
                .ReturnsAsync(computerDto);

            // Act
            var result = await _computerController.GetById(computerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // Verifica se é HTTP 200
            var response = Assert.IsType<ComputerDto>(okResult.Value); // Verifica o tipo do retorno
            Assert.Equal(computerId, response.Id); // Verifica o ID retornado
            _computerServiceMock.Verify(s => s.GetByIdAsync(computerId), Times.Once); // Verifica que o serviço foi chamado
        }

        [Fact]
        public async Task GetById_Should_Return_NotFound_When_Computer_Does_Not_Exist()
        {
            var computerId = 1;

            _computerServiceMock
                .Setup(s => s.GetByIdAsync(computerId))
                .ThrowsAsync(new KeyNotFoundException($"Computer with ID '{computerId}' not found."));

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _computerController.GetById(computerId));

            _computerServiceMock.Verify(s => s.GetByIdAsync(computerId), Times.Once);
        }

        [Fact]
        public async Task Add_Should_Return_CreatedAtAction_When_Computer_Is_Added()
        {
            // Arrange
            var saveComputerDto = new SaveComputerDto
            {
                ManufacturerId = 1,
                SerialNumber = "ABC123",
                Specifications = "Specs",
                PurchaseDate = DateTime.UtcNow,
                WarrantyExpirationDate = DateTime.UtcNow.AddYears(1)
            };

            var computerDto = new ComputerDto
            {
                Id = 1,
                ManufacturerId = saveComputerDto.ManufacturerId,
                SerialNumber = saveComputerDto.SerialNumber,
                Specifications = saveComputerDto.Specifications,
                PurchaseDate = saveComputerDto.PurchaseDate,
                WarrantyExpirationDate = saveComputerDto.WarrantyExpirationDate
            };

            _computerServiceMock
                .Setup(s => s.AddAsync(saveComputerDto))
                .ReturnsAsync(computerDto);

            // Act
            var result = await _computerController.Add(saveComputerDto);

            // Assert
            var createdAtResult = Assert.IsType<CreatedAtActionResult>(result); // Verifica se é HTTP 201
            Assert.Equal(nameof(_computerController.GetById), createdAtResult.ActionName); // Verifica a ação de redirecionamento
            var response = Assert.IsType<ComputerDto>(createdAtResult.Value); // Verifica o tipo do retorno
            Assert.Equal(computerDto.Id, response.Id); // Verifica o ID retornado
            _computerServiceMock.Verify(s => s.AddAsync(saveComputerDto), Times.Once); // Verifica que o serviço foi chamado
        }

        [Fact]
        public async Task Update_Should_Return_NoContent_When_Computer_Is_Updated()
        {
            // Arrange
            var computerId = 1;
            var saveComputerDto = new SaveComputerDto
            {
                ManufacturerId = 1,
                SerialNumber = "ABC123",
                Specifications = "Specs",
                PurchaseDate = DateTime.UtcNow,
                WarrantyExpirationDate = DateTime.UtcNow.AddYears(1)
            };

            _computerServiceMock
                .Setup(s => s.UpdateAsync(computerId, saveComputerDto))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _computerController.Update(computerId, saveComputerDto);

            // Assert
            Assert.IsType<NoContentResult>(result); // Verifica se é HTTP 204
            _computerServiceMock.Verify(s => s.UpdateAsync(computerId, saveComputerDto), Times.Once); // Verifica que o serviço foi chamado
        }

        [Fact]
        public async Task Delete_Should_Return_NoContent_When_Computer_Is_Deleted()
        {
            // Arrange
            var computerId = 1;

            // Mock do serviço para simular comportamento esperado
            _computerServiceMock
                .Setup(s => s.DeleteAsync(computerId))
                .Returns(Task.CompletedTask);

            var controller = new ComputerController(_computerServiceMock.Object);

            // Act
            var result = await controller.Delete(computerId);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _computerServiceMock.Verify(s => s.DeleteAsync(computerId), Times.Once);
        }

    }
}
