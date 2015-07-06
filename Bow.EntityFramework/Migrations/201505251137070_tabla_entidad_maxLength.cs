namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabla_entidad_maxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("bow.pregunta_frecuente", "Pregunta", c => c.String(nullable: false));
            AlterColumn("bow.pregunta_frecuente", "Respuesta", c => c.String(nullable: false));
            AlterColumn("bow.pregunta", "Texto", c => c.String(nullable: false));
            AlterColumn("bow.pregunta", "Pista", c => c.String(nullable: false));
            AlterColumn("bow.entidad", "Nombre", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("bow.entidad", "Descripcion", c => c.String(nullable: false));
            AlterColumn("bow.puntaje", "Respuesta", c => c.String(nullable: false));
            AlterColumn("bow.usuario", "Nombre", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("bow.mensaje", "Titulo", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("bow.mensaje", "Contenido", c => c.String(nullable: false));
            AlterColumn("bow.tipo", "Nombre", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("bow.respuesta", "Texto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("bow.respuesta", "Texto", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("bow.tipo", "Nombre", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("bow.mensaje", "Contenido", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("bow.mensaje", "Titulo", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("bow.usuario", "Nombre", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("bow.puntaje", "Respuesta", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("bow.entidad", "Descripcion", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("bow.entidad", "Nombre", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("bow.pregunta", "Pista", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("bow.pregunta", "Texto", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("bow.pregunta_frecuente", "Respuesta", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("bow.pregunta_frecuente", "Pregunta", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
