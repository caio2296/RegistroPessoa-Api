using Microsoft.EntityFrameworkCore;
using RegistroPessoa.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPessoa.Persistence.Contexto
{
    public class PessoaContextDb: DbContext
    {
        public PessoaContextDb(DbContextOptions<PessoaContextDb> options): base(options)
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>();
        }

    }
}
