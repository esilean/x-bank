using System.ComponentModel.DataAnnotations.Schema;

namespace ZupBank.Data.Data.Models
{
    [Table("PERSONS")]
    public class PersonModel
    {
        [Column("CODIGO")]
        public int Id { get; set; }

        [Column("NOME")]
        public string Name { get; set; }

        [Column("GENERO")]
        public string Gender { get; set; }

        [Column("MES")]
        public string BirthdayMonth { get; set; }
    }
}
