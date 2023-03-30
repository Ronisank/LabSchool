using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace LabSchoolWebApi.DTOs
{
    public class AtendimentoRequisicaoDto
    {
        
        [Required]
        public int CodigoAluno { get; set; }
        [Required]
        public int CodigoPedagogo { get; set; }
    }
}
