using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HexagonalTemplate.Models.Entities
{
    public class AppEntity
    {
        [Key]
        public int AppId { get; set; }
        public string AppName { get; set; }
    }
}

