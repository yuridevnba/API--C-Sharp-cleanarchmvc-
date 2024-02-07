using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Reflection.Emit;

namespace CleanArchMvc.Infra.Data.Context
{
    //precisou instalar os pacotes ; coresqlserver,tools,Design
    public class ApplicationDbContext : DbContext // interagir com o bd por meio da Entity Framework Core
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            // contexto é applicationDbContext
            //construtor da classe,
            // quando registrar o contexto como serviço, vai definir as opções do contexto usando DbContextOptions 
            // vai informar o provedor do bd e a string d conexao.
            : base(options)//base DbContext e passa as opções para ele.
        { }

        
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Dados> Dados { get; set; }

       
        protected override void OnModelCreating(ModelBuilder builder) // chamado durante a criação do modelo de 
            //bd e vai permitir configurar a forma como as entidades são mapeadas para tabelas, definir restrições.
        {
            base.OnModelCreating(builder);
            //builder.Entity<Category>().ToTable("Categories", schema: "dbo");
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            // aplicar configurações de category e products presentes na assembly.

            //ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            // vai correr o arquivo de contexto e vai ver as entidades, as entidades herdam dessa interface, 
            // IEntityTypeConfiguration ele vai entender que essa configuração foi definida para essa tabela<>.
            // builder.ApplyConfiguration(new CategoryConfiguration()); teria que fazer isso para todos.
        }

    }
    }


