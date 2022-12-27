
using EmpresaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpresaApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Empresa> Empresas {get;set;}
        public DbSet<Transaction> Transactions { get; set; }
    
    }
}