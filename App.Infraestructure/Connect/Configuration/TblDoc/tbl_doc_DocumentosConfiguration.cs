using App.Infraestructure.Connect.Entities.TblDoc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblDoc
{
    public class tbl_doc_DocumentosConfiguration : IEntityTypeConfiguration<tbl_doc_DocumentosEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_doc_DocumentosEntities> builder)
        {
            builder.ToTable("tbl_doc_Documentos")
                .HasKey(p => new { p.DocumentoId });

            builder.Property(p => p.DocumentoId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.NombreDoc)
                .HasColumnName("nombre_doc")
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(p => p.InIdSistema)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Consecutivo)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.CodigoDoc)
                .HasColumnName("codigo_doc")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(p => p.IdTipo)
                .HasColumnName("id_tipo")
                .IsRequired()
                .HasColumnType("int");

            //builder.Property(p => p.ProcesoDoc)
            //    .HasColumnName("proceso_doc")
            //    .IsRequired()
            //    .HasColumnType("int");

            builder.HasOne(p => p.ProcesosObj)
                .WithMany(p => p.TBL_Doc_Documentos)
                .HasForeignKey(p => p.proceso_doc)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.IdProducto)
                .HasColumnName("id_producto")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.FechaEmision)
                .HasColumnName("fecha_emision")
                .IsRequired()
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaActualizacion)
                .HasColumnName("fecha_actualizacion")
                .HasColumnType("Datetime");

            builder.Property(p => p.NumeroActualizacion)
                .HasColumnName("numero_actualizacion")
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("char");

            builder.Property(p => p.ElaboradoPor)
                .HasColumnName("elaborado_por")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.RevisadoPor)
                .HasColumnName("revisado_por")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.AprobadoPor)
                .HasColumnName("aprobado_por")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.BCumple)
                .HasColumnType("bit");

            builder.Property(p => p.Responsable)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.DocumentoIdPadre)
                .HasColumnType("int");

            builder.Property(p => p.UrlFormato)
                .HasColumnName("url_formato")
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Historial)
                .HasColumnType("text");

            builder.Property(p => p.FechaFlujoIni)
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaFlujoFin)
                .HasColumnType("Datetime");

            builder.Property(p => p.InDiasRetraso)
                .HasColumnType("int");

            builder.Property(p => p.NivelSeguridad)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(p => p.FechaCreacion)
                .IsRequired()
                .HasColumnType("Datetime");

            builder.Property(p => p.UsuarioModificacion)
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("Datetime");

            builder.Property(p => p.IdArea)
                .HasColumnName("id_area")
                .HasColumnType("int");

            builder.Property(p => p.EstadoCarga)
                .HasColumnType("bit");

            builder.Property(p => p.RazonObsoleto)
               .HasMaxLength(int.MaxValue)
               .HasColumnType("nvarchar(MAX)");

            builder.Property(p => p.FechaEnvioObsoleto)
                .HasColumnType("Datetime");

            builder.Property(p => p.UsuarioEnvioObsoleto)
                .HasColumnType("bigint");

            builder.Property(p => p.FechaDevolucionVigente)
                .HasColumnType("Datetime");

            builder.Property(p => p.UsuarioDevolucionVigente)
                .HasColumnType("bigint");

        }
    }
}
