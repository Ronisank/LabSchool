using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolWebApi.Models
{
    public class Aluno : Pessoa
    {
        [Required]
        [Column("SituacaoMatricula")]
        public string? Situacao { get; set; }        
        [Required]
        public float Nota { get; set; }
        [Required]
        [Column("QtdAtendimentos")]
        public int Atendimentos { get; set; }
    }
}
