using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {

        // quando apliar a migração vai seguir essa configuração.
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(t => t.Id); // chave primária da tabelad
            /*builder.Property(p => p.Name).HasMaxLength(100).IsRequired();*/// obrigatorio e o tamanho, nullable = false.


            // popular a tabela pessoa.
            builder.HasData(
                new Pessoa(1, "Ana@gmail.com"),
                new Pessoa(2, "Yuri@gmail.com"),
                new Pessoa(3, "Julio@gmail.com")
                );

        }
    }
}
