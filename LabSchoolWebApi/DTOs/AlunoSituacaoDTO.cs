using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolWebApi.DTOs
{
    public class AlunoSituacaoDTO
    {
        [Column("SituacaoMatricula")]
        public string? Situacao { get; set; }
    }
}
