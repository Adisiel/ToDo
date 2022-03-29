using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tarefa");

            builder.HasKey(t => t.Id)
                .HasName("pk_tarefa");

            builder.HasIndex(t => t.CategoriaId)
                .HasDatabaseName("idx_tarefa_categoria");

            builder.HasOne(t => t.Categoria)
                .WithMany()
                .HasForeignKey(t => t.CategoriaId)
                .HasConstraintName("fk_tarefa_categoria")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .HasColumnOrder(1);

            builder.Property(t => t.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(t => t.Prioridade)
                .HasColumnName("prioridade")
                .HasConversion<string>()
                .HasColumnOrder(4);

            builder.Property(t => t.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .HasColumnOrder(5);

            builder.Property(t => t.DataCriacao)
                .HasColumnName("data_criacao")
                .HasColumnType("datetime")
                .HasColumnOrder(6)
                .IsRequired();

            builder.Property(t => t.DataEntrega)
                .HasColumnName("data_entrega")
                .HasColumnType("datetime")
                .HasColumnOrder(7)
                .IsRequired();

            builder.Property(t => t.CategoriaId)
                .HasColumnName("categoria_id")
                .HasColumnType("int")
                .HasColumnOrder(8);
        }
    }
}
