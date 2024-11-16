using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class PublisherDTO : IMapper<Publisher, PublisherDTO>
    {
        public int PublisherId { get; set; }

        [Required]
        public required string Name { get; set; }
        public PublisherDTO MapFrom(Publisher entity)
        {
            PublisherId = entity.PublisherId;

            Name = entity.Name;

            return this;
        }

        public Publisher MapTo()
        {
            return new Publisher() { PublisherId = this.PublisherId, Name = this.Name };
        }
    }
}
