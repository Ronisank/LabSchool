using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolWebApi.Models
{
    public class Pessoa
    {
        [Key]
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataNascimento { get; set; }
        public long CPF { get; set; }
    }
}
