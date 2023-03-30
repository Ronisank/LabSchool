using System.ComponentModel.DataAnnotations;

namespace LabSchoolWebApi.DTOs
{
    public class AlunoDTO
    {
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Telefone { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string? DataNascimento { get; set; }
        [Required]
        public long CPF { get; set; }
        [Required]
        public string? Situacao { get; set; }
        [Required]
        public float Nota { get; set; }

    }
}
