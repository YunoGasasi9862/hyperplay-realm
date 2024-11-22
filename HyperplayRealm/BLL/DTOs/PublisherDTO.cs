using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BLL.DTOs
{
    public class PublisherDTO
    {
        public int PublisherId { get; set; }

        [Required]
        public required string Name { get; set; }

        public static Expression<Func<Publisher, PublisherDTO>> FromEntity => entity => new PublisherDTO
        {
            PublisherId = entity.PublisherId,
            Name = entity.Name
        };


        public Publisher MapTo()
        {
            return new Publisher() { PublisherId = this.PublisherId, Name = this.Name };
        }
    }
}
