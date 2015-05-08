namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabla_entidad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bow.entidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Descripcion = c.String(nullable: false, maxLength: 1000),
                        DimensionId = c.Int(nullable: false),
                        EstadoActiva = c.Boolean(nullable: false),
                        FechaCreacion = c.String(),
                        UsuarioIdCreacion = c.Int(nullable: false),
                        FechaModificacion = c.String(),
                        UsuarioIdModificacion = c.Int(),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("bow.dimension", t => t.DimensionId)
                .Index(t => t.DimensionId);
            
            AlterColumn("bow.pregunta_frecuente", "UsuarioIdModificacion", c => c.Int());
            AlterColumn("bow.pregunta", "UsuarioIdModificacion", c => c.Int());
            AlterColumn("bow.respuesta", "UsuarioIdModificacion", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("bow.entidad", "DimensionId", "bow.dimension");
            DropIndex("bow.entidad", new[] { "DimensionId" });
            AlterColumn("bow.respuesta", "UsuarioIdModificacion", c => c.Int(nullable: false));
            AlterColumn("bow.pregunta", "UsuarioIdModificacion", c => c.Int(nullable: false));
            AlterColumn("bow.pregunta_frecuente", "UsuarioIdModificacion", c => c.Int(nullable: false));
            DropTable("bow.entidad");
        }
    }
}
