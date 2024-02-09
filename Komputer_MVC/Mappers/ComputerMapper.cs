using Data.Entities;
using Komputer_MVC.Models;
using Microsoft.AspNetCore.Routing.Internal;

namespace Komputer_MVC.Mappers
{
    public class ComputerMapper
    {
        public static Computer FromEntity(ComputerEntity entity)
        {
            return new Computer()
            {
                ComputerId = entity.ComputerId,
                Name = entity.Name,
                Processor = entity.Processor,
                Memory = entity.Memory,
                HardDrive = entity.HardDrive,
                GraphicsCard = entity.GraphicsCard,
                ProductionDate = entity.ProductionDate,
                TypeId = entity.TypeId,
                Type = entity.Type
            };
        }

        public static ComputerEntity ToEntity(Computer model)
        {
            return new ComputerEntity()
            {
                ComputerId = model.ComputerId,
                Name = model.Name,
                Processor = model.Processor,
                Memory = model.Memory,
                HardDrive = model.HardDrive,
                GraphicsCard = model.GraphicsCard,
                ProductionDate = model.ProductionDate,
                TypeId = model.TypeId,
                Type = model.Type
            };
        }
    }
}
