using InventoryTracker.Contracts;
using InventoryTracker.Models;

namespace InventoryTracker.Services
{
    public interface IComputerService : IService<Computer>
    {
        // Adiciona métodos específicos relacionados à lógica de negócio de computadores

        /// <summary>
        /// Valida se o fabricante é válido com base no ID.
        /// </summary>
        /// <param name="manufacturerId">ID do fabricante.</param>
        /// <returns>True se o fabricante for válido, false caso contrário.</returns>
        Task<bool> IsManufacturerValidAsync(int manufacturerId);

        /// <summary>
        /// Valida o número de série do computador com base no fabricante.
        /// </summary>
        /// <param name="computer">Objeto computador a ser validado.</param>
        void ValidateSerialNumber(Computer computer);
    }
}
