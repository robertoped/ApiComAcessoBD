using ApiComAcessoBD.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComAcessoBD.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        public DbSet<PessoaEndereco> PessoaEndereco { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>()
                .HasOne<PessoaFisica>(x => x.PessoaFisica)//Ligação com apenas um objeto
                .WithOne()//Configura um para um
                .HasForeignKey<PessoaFisica>(x => x.IdPessoa);//Informa qual é a chave estrangeria

            modelBuilder.Entity<Pessoa>()
                .HasOne<PessoaJuridica>(x => x.PessoaJuridica)
                .WithOne()
                .HasForeignKey<PessoaJuridica>(x => x.IdPessoa);

            modelBuilder.Entity<Pessoa>()
                .HasMany(x => x.PessoaTelefones)//Ligação com uma coleção de objeto do tipo Pessoa Telefone
                .WithOne()//Configura um para muitos
                .HasForeignKey(x => x.IdPessoa);//Informa qual é a chave estrangeria

            modelBuilder.Entity<Pessoa>()
                .HasMany(x => x.PessoaEnderecos)//Ligação com uma coleção de objeto do tipo Pessoa Telefone
                .WithOne()//Configura um para muitos
                .HasForeignKey(x => x.IdPessoa);//Informa qual é a chave estrangeria
        }
    }
}
