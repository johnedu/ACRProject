namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campo_estado_tablas_faqs_pregunta : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "bow.puntaje", name: "Usuariod", newName: "UsuarioId");
            RenameIndex(table: "bow.puntaje", name: "IX_Usuariod", newName: "IX_UsuarioId");
            AddColumn("bow.pregunta_frecuente", "EstadoActiva", c => c.Boolean(nullable: false));
            AddColumn("bow.pregunta", "EstadoActiva", c => c.Boolean(nullable: false));
            AlterColumn("bow.usuario", "Coda", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("bow.usuario", "Coda", c => c.String(nullable: false, maxLength: 200));
            DropColumn("bow.pregunta", "EstadoActiva");
            DropColumn("bow.pregunta_frecuente", "EstadoActiva");
            RenameIndex(table: "bow.puntaje", name: "IX_UsuarioId", newName: "IX_Usuariod");
            RenameColumn(table: "bow.puntaje", name: "UsuarioId", newName: "Usuariod");
        }
    }
}
