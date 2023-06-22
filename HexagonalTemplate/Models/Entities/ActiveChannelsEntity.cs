using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HexagonalTemplate.Models.Entities
{
    public class ActiveChannelsEntity
    {
        [Key]
        public int ActiveChannelsId { get; set; }
        public bool WebPush { get; set; } = false;
        public bool Email { get; set; } = false;
        public bool Sms { get; set; } = false; 
    }
}
