using System;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infra.Mapping;

public class ImportacaoCNABMap : IEntityTypeConfiguration<ImportacaoCNAB>
{
    public void Configure(EntityTypeBuilder<ImportacaoCNAB> builder)
    {
        builder.ToTable("Importacoes");
        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.DataImportacao)
            .IsRequired()
            .HasColumnName("data_importacao");

        builder.Property(x => x.Tipo)
            .IsRequired()
            .HasColumnName("tipo");

        builder.Property(x => x.Data)
            .IsRequired()
            .HasColumnName("data");

        builder.Property(x => x.Valor)
            .IsRequired()
            .HasColumnName("valor");

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasColumnName("cpf");

        builder.Property(x => x.Cartao)
           .IsRequired()
           .HasColumnName("cartao");

        builder.Property(x => x.Hora)
           .IsRequired()
           .HasColumnName("hora");

        builder.Property(x => x.RepresentanteLoja)
           .IsRequired()
           .HasColumnName("representante_loja");

        builder.Property(x => x.Loja)
           .IsRequired()
           .HasColumnName("loja");
    }
}

