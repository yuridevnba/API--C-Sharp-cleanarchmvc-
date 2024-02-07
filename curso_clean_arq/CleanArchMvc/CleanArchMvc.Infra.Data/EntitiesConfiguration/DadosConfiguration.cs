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
    public class DadosConfiguration : IEntityTypeConfiguration<Dados>
    {
        public void Configure(EntityTypeBuilder<Dados> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.InicialMae).HasMaxLength(200).IsRequired();

            /*builder.Property(p => p.Nascimento).HasPrecision(10, 2);*/// precisão (10) e casa decimais (2)

            //relacionamentos um para muitos, uma categoria tem muitos produtos.
            object value = builder.HasOne(e => e.Pessoas)
                .WithMany(e => e.Dados)
                .HasForeignKey(e => e.PessoaId); // pessoaId é chave estrangeira que vai gerar na tabela dados.
        }
    }
}
