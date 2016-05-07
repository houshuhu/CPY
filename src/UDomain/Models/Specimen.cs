using System.ComponentModel.DataAnnotations.Schema;

namespace UDomain.Models
{
    [Table("Specimen")]
    public class Specimen:Entity
    {
        public string SNo { get; set; }
    }
}