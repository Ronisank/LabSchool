using System.ComponentModel.DataAnnotations;

namespace LabSchoolWebApi.DTOs
{
    public class PedagogoRespostaDTO
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string DataNascimento { get; set; }
        public long CPF { get; set; }
        public int Atendimentos { get; set; } = 0;
    }
}
