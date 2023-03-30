using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolWebApi.Models
{
    public class Professor : Pessoa
    {
        public string? Estado { get; set; }
        public string? Experiencia { get; set; }
        [Column("FormacaoAcademica")]
        public string? Formacao { get; set; }
    }
}
