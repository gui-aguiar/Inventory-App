using Moq;
using InventoryTracker.Models;
using InventoryTracker.Services;
using InventoryTracker.Contracts;
using InventoryTracker.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryTracker.Tests.Services
{
    public class ComputerServiceTests
    {
        private readonly Mock<IRepository<Computer>> _repositoryMock;
        private readonly Mock<IRepository<ComputerManufacturer>> _manufacturerRepositoryMock;
        private readonly Mock<IComputerStatusService> _statusServiceMock;
        private readonly Mock<IComputerUserService> _userServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ComputerService _computerService;        

        public ComputerServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Computer>>();
            _manufacturerRepositoryMock = new Mock<IRepository<ComputerManufacturer>>();
            _statusServiceMock = new Mock<IComputerStatusService>();
            _userServiceMock = new Mock<IComputerUserService>();
            _mapperMock = new Mock<IMapper>();

            _computerService = new ComputerService(
                _repositoryMock.Object,
                _manufacturerRepositoryMock.Object,
                _statusServiceMock.Object,
                _userServiceMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task AddAsync_Should_Add_Computer_And_Set_Status()
        {
            // Arrange
            var saveComputerDto = new SaveComputerDto
            {
                ManufacturerId = 1,
                SerialNumber = "ABC123",
                Specifications = "16GB RAM, 512GB SSD",
                ImageUrl = "http://example.com/image.jpg",
                PurchaseDate = DateTime.UtcNow,
                WarrantyExpirationDate = DateTime.UtcNow.AddYears(1)
            };

            var computer = new Computer
            {
                Id = 1,
                ComputerManufacturerId = saveComputerDto.ManufacturerId,
                SerialNumber = saveComputerDto.SerialNumber,
                Specifications = saveComputerDto.Specifications,
                ImageUrl = saveComputerDto.ImageUrl,
                PurchaseDate = saveComputerDto.PurchaseDate,
                WarrantyExpirationDate = saveComputerDto.WarrantyExpirationDate
            };

            var manufacturer = new ComputerManufacturer
            {
                Id = saveComputerDto.ManufacturerId,
                Name = "Mock Manufacturer",
                SerialRegex = "^[A-Z0-9]+$"
            };

            // Configura o mock do repositório de fabricantes para retornar um fabricante válido
            _manufacturerRepositoryMock
                .Setup(m => m.GetByIdAsync(saveComputerDto.ManufacturerId))
                .ReturnsAsync(manufacturer);

            // Configura o AutoMapper
            _mapperMock.Setup(m => m.Map<Computer>(saveComputerDto)).Returns(computer);

            _statusServiceMock.Setup(s => s.AssignNewStatus(It.IsAny<Computer>(), (int)Status.New));
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Computer>())).Returns(Task.CompletedTask);

            // Act
            await _computerService.AddAsync(saveComputerDto);

            // Assert
            _manufacturerRepositoryMock.Verify(m => m.GetByIdAsync(saveComputerDto.ManufacturerId), Times.AtLeastOnce);
            _mapperMock.Verify(m => m.Map<Computer>(saveComputerDto), Times.Once);
            _statusServiceMock.Verify(s => s.AssignNewStatus(It.Is<Computer>(c => c.SerialNumber == "ABC123"), (int)Status.New), Times.Once);
            _repositoryMock.Verify(r => r.AddAsync(It.Is<Computer>(c => c.SerialNumber == "ABC123")), Times.Once);
        }

      /*  [Fact]
        public async Task GetByIdAsync_Should_Return_ComputerDto_When_Computer_Exists()
        {
            // Arrange
            var computerId = 1;
            var computer = new Computer
            {
                Id = computerId,
                ComputerManufacturerId = 1,
                SerialNumber = "ABC123",
                Specifications = "16GB RAM, 512GB SSD",
                ImageUrl = "http://example.com/image.jpg",
                PurchaseDate = DateTime.UtcNow,
                WarrantyExpirationDate = DateTime.UtcNow.AddYears(1)
            };

            var computerDto = new ComputerDto
            {
                Id = computerId,
                ManufacturerId = computer.ComputerManufacturerId,
                SerialNumber = computer.SerialNumber,
                Specifications = computer.Specifications,
                ImageUrl = computer.ImageUrl,
                PurchaseDate = computer.PurchaseDate,
                WarrantyExpirationDate = computer.WarrantyExpirationDate
            };
            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(new List<Computer>
                {
                    computer                   
                }.AsQueryable());

            _mapperMock
                .Setup(m => m.Map<ComputerDto>(computer))
                .Returns(computerDto);

            // Act
            var result = await _computerService.GetByIdAsync(computerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(computerDto.Id, result.Id);
            Assert.Equal(computerDto.SerialNumber, result.SerialNumber);

            _repositoryMock.Verify(r => r.GetAll(), Times.Once);
            _mapperMock.Verify(m => m.Map<ComputerDto>(computer), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Throw_KeyNotFoundException_When_Computer_Does_Not_Exist()
        {
            // Arrange
            var computerId = 1;

            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(Enumerable.Empty<Computer>().AsQueryable());

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _computerService.GetByIdAsync(computerId));

            _repositoryMock.Verify(r => r.GetAll(), Times.Once);
        }*/

     /*   [Fact]
        public async Task DeleteAsync_Should_Delete_Computer_When_Computer_Exists()
        {
            // Arrange
            var computerId = 1;
            var computer = new Computer
            {
                Id = computerId,
                ComputerManufacturerId = 1,
                SerialNumber = "ABC123",
                Specifications = "16GB RAM, 512GB SSD"
            };

            // Simula a coleção retornada pelo GetAll
            _repositoryMock
                .Setup(r => r.GetByIdAsync(computerId))
                .ReturnsAsync(computer);

            _repositoryMock
                .Setup(r => r.DeleteAsync(It.IsAny<Computer>()))
                .Returns(Task.CompletedTask);

            // Act
            await _computerService.DeleteAsync(computerId);

            // Assert
            _repositoryMock.Verify(r => r.DeleteAsync(It.Is<Computer>(c => c.Id == computerId)), Times.Once);
        }*/


      /*  [Fact]
        public async Task DeleteAsync_Should_Throw_KeyNotFoundException_When_Computer_Does_Not_Exist()
        {
            // Arrange
            var computerId = 1;  // como que isso aqui esta indo parar no validate?
            
            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(new List<Computer>
                {
                    // Caso precise de dados específicos, adicione aqui.
                }.AsQueryable());

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _computerService.DeleteAsync(computerId));

            _repositoryMock.Verify(r => r.GetAll(), Times.Once);
        }*/

    }
}
