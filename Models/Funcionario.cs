using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaApp.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cargo Cargo { get; set; }
        public decimal Salario { get; set; }
        [ForeignKey("EmpresaId")]
        public int EmpresaId   {get; set;}
        public Empresa Empresa   {get; set;}
        
    }
}