using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BLL.Interfaces;
using BLL.Models;

namespace BLL.DTOs
{
    public class CartDTO
    {
       public int GameId { get; set; }

        [DisplayName("Game Title")]
        public string Title { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        public int UserId { get; set; }

        public List<string> Developers { get; set; }

        public string Publisher { get; set; }

    }
}
