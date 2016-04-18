using System.ComponentModel.DataAnnotations;

namespace UDomain.Models
{
    public class Role:Entity
    {
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Code { get; set; }
    }
}