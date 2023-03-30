using System.ComponentModel.DataAnnotations;

namespace LabSchoolWebApi.DTOs
{
    public class ProfessorRespostaDTO
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataNascimento { get; set; }
        public long CPF { get; set; }
        public string? Formacao { get; set; }
        public string? Experiencia { get; set; }
        public string? Estado { get; set; }
        
        
    }
}
