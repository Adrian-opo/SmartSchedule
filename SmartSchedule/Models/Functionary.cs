using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchedule.Models
{
    [Table("functionary")]
    public class Functionary
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("siape")]
        public string Siape { get; set; }
    }
}
