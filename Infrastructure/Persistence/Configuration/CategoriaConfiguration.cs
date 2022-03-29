using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(c => c.Id)
                .HasName("pk_categoria");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .HasColumnOrder(1);

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(c => c.Cor)
                .HasColumnName("cor")
                .HasColumnType("varchar")
                .HasMaxLength(7)
                .HasColumnOrder(3)
                .IsRequired();
        }
    }
}
