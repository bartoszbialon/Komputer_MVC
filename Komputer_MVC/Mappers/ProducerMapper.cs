using Data.Entities;
using Komputer_MVC.Models;

namespace Komputer_MVC.Mappers
{
    public class ProducerMapper
    {
        public static Producer FromEntity(ProducerEntity entity)
        {
            return new Producer()
            {
                ProducerId = entity.ProducerId,
                Name = entity.Name,
                OriginCountry = entity.OriginCountry,
                FoundationYear = entity.FoundationYear,
                Description = entity.Description,
                Street = entity.Street,
                City = entity.City,
                PostalCode = entity.PostalCode,
                Region = entity.Region
            };
        }

        public static ProducerEntity ToEntity(Producer model)
        {
            return new ProducerEntity()
            {
                ProducerId = model.ProducerId,
                Name = model.Name,
                OriginCountry = model.OriginCountry,
                FoundationYear = model.FoundationYear,
                Description = model.Description,
                Street = model.Street,
                City = model.City,
                PostalCode = model.PostalCode,
                Region = model.Region
            };
        }
    }
}
