
using System.ComponentModel.DataAnnotations;

namespace EmpresaApp.Models
{
    public class Empresa
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}