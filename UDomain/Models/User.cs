using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UDomain.Models
{
    public class User:Entity
    {
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Code { get; set; }

        public int? RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}