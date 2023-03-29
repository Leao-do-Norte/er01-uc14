using Microsoft.EntityFrameworkCore; // importação necessária para implementar o 'DbContext'
using Microsoft.Identity.Client;
using Chapter.Models; // importação necessária para o 'DbSet'

namespace Chapter.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext() 
        { 
        }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base (options)
        { 
        }

        // método para configurar o banco de dados:
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured) // verificar se não está configurado
            {
                // cada provedor tem sua sintaxe p/ especificação
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-IOTL2GO2\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true");
                // Data Source disponível em: SSMS > Pesquisador de Objetos > 1ª Opção (botão direito) > Propiedaoes > Name
            }
        }

        // DbSet representa as entidades que serão utilizadas nas operções de leitura, criação, deleção e atualização (GET, POST, PUT, DELETE)) 
        public DbSet<Livro> Livros { get; set; }
    }
}
