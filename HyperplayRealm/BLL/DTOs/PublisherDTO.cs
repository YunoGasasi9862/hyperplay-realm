using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class PublisherDTO : IMapper<Publisher>
    {
        public int PublisherId { get; set; }

        [Required]
        public required string Name { get; set; }
        public void MapFrom(Publisher entity)
        {
            PublisherId = entity.PublisherId;

            Name = entity.Name;
        }

        public Publisher MapTo()
        {
            throw new NotImplementedException();
        }
    }
}
