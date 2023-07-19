using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HexagonalTemplate.Models.Entities
{
    public class AppUserTeamEntity
    {
        [ForeignKey(nameof(App))]
        public int AppId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public DateTime InicialDate { get; set; } = DateTime.Now;
        public bool Active { get; set; }
        public AppEntity App { get; set; }
        public UserEntity User { get; set; }
    }
}
