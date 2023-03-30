using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolWebApi.Models
{
    public class Pedagogo : Pessoa
    {
        [Column("QtdAtendimentos")]
        public int Atendimentos { get; set; } = 0;
    }
}
