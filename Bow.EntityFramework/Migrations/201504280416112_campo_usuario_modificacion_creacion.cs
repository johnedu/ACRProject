namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campo_usuario_modificacion_creacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("bow.pregunta_frecuente", "FechaCreacion", c => c.String());
            AddColumn("bow.pregunta_frecuente", "UsuarioIdCreacion", c => c.Int(nullable: false));
            AddColumn("bow.pregunta_frecuente", "FechaModificacion", c => c.String());
            AddColumn("bow.pregunta_frecuente", "UsuarioIdModificacion", c => c.Int(nullable: false));
            AddColumn("bow.pregunta", "FechaCreacion", c => c.String());
            AddColumn("bow.pregunta", "UsuarioIdCreacion", c => c.Int(nullable: false));
            AddColumn("bow.pregunta", "FechaModificacion", c => c.String());
            AddColumn("bow.pregunta", "UsuarioIdModificacion", c => c.Int(nullable: false));
            AddColumn("bow.respuesta", "EstadoActiva", c => c.Boolean(nullable: false));
            AddColumn("bow.respuesta", "FechaCreacion", c => c.String());
            AddColumn("bow.respuesta", "UsuarioIdCreacion", c => c.Int(nullable: false));
            AddColumn("bow.respuesta", "FechaModificacion", c => c.String());
            AddColumn("bow.respuesta", "UsuarioIdModificacion", c => c.Int(nullable: false));
            AlterColumn("bow.usuario", "Nombre", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("bow.usuario", "Nombre", c => c.String(nullable: false, maxLength: 200));
            DropColumn("bow.respuesta", "UsuarioIdModificacion");
            DropColumn("bow.respuesta", "FechaModificacion");
            DropColumn("bow.respuesta", "UsuarioIdCreacion");
            DropColumn("bow.respuesta", "FechaCreacion");
            DropColumn("bow.respuesta", "EstadoActiva");
            DropColumn("bow.pregunta", "UsuarioIdModificacion");
            DropColumn("bow.pregunta", "FechaModificacion");
            DropColumn("bow.pregunta", "UsuarioIdCreacion");
            DropColumn("bow.pregunta", "FechaCreacion");
            DropColumn("bow.pregunta_frecuente", "UsuarioIdModificacion");
            DropColumn("bow.pregunta_frecuente", "FechaModificacion");
            DropColumn("bow.pregunta_frecuente", "UsuarioIdCreacion");
            DropColumn("bow.pregunta_frecuente", "FechaCreacion");
        }
    }
}
