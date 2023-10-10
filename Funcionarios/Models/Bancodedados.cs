using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Funcionarios.Models
{
    public class Bancodedados : DbContext

    {
        public DbSet<Lista> Listas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id = AULAMVC1.mssql.somee.com; packet size = 4096; user id = joaovictorap_SQLLogin_1; pwd = JOAO2202; data source = AULAMVC1.mssql.somee.com; persist security info = False; initial catalog = AULAMVC1");
        }

    }
}
