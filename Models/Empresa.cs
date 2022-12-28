
using System.ComponentModel.DataAnnotations;

namespace EmpresaApp.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(22,ErrorMessage ="Maximum 200 characters only.")]
        public string Nome { get; set; }
        public string Cep { get; set; }
        public int NumeroResidencial { get; set; }
        public string ComplementoEndereco { get; set; }
        public string Telefone { get; set; }
        public IList<Funcionario> Funcionarios { get; set; }
    }
}