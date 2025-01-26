using AutoMapper;
using InventoryTracker.Dtos;
using InventoryTracker.Models;
using System.Xml.Serialization;

namespace InventoryTracker.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeia SaveComputerDto -> Computer (para criação/atualização)
            CreateMap<SaveComputerDto, Computer>()
                .ForMember(dest => dest.ComputerManufacturerId, opt => opt.MapFrom(src => src.ManufacturerId));

            // Mapeia Computer -> ComputerDto (para leitura)
            CreateMap<Computer, ComputerDto>()
                .ForMember(dest => dest.ManufacturerId, opt => opt.MapFrom(src => src.ComputerManufacturerId))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src =>
                        src.ComputerStatuses != null && src.ComputerStatuses.Any()
                            ? src.ComputerStatuses.OrderBy(cs => cs.AssignDate).Last().ComputerStatusId
                            : 0))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src =>
                    src.Users != null && src.Users.Any(u => u.AssignEndDate == null)
                        ? src.Users.Last(u => u.AssignEndDate == null).UserId
                        : (int?)null));
        }           
    }
}