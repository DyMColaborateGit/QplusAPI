using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Configuration;

public class scp_UsuariosRolesConfiguration : IEntityTypeConfiguration<scp_UsuariosRolesEntities>
{
    public void Configure(EntityTypeBuilder<scp_UsuariosRolesEntities> builder)
    {
        builder.ToTable("scp_UsuariosRoles").
        HasKey(p => new { p.UserId, p.RoleId });

        builder.HasOne(p => p.Usuariobj)
        .WithMany(p => p.scp_UsuariosRoles)
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Roleobj)
        .WithMany(p => p.scp_UsuariosRoles)
        .HasForeignKey(p => p.RoleId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
