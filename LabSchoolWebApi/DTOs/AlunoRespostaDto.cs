using System.ComponentModel.DataAnnotations;

namespace LabSchoolWebApi.DTOs
{
    public class AlunoRespostaDto
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Telefone { get; set; }
        [Required]
        public string? DataNascimento { get; set; }
        [Required]
        public long CPF { get; set; }
        [Required]
        public string? Situacao { get; set; }
        [Required]
        public float Nota { get; set; }
        [Required]
        public int Atendimentos { get; set; }
    }
}
