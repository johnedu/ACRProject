namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabla_faqs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("bow.pregunta_frecuente", "text", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("bow.pregunta_frecuente", "answer", c => c.String(nullable: false));
            AddColumn("bow.pregunta_frecuente", "published_at", c => c.DateTime(nullable: false));
            AddColumn("bow.pregunta_frecuente", "url", c => c.String());
            DropColumn("bow.pregunta_frecuente", "Pregunta");
            DropColumn("bow.pregunta_frecuente", "Respuesta");
        }
        
        public override void Down()
        {
            AddColumn("bow.pregunta_frecuente", "Respuesta", c => c.String(nullable: false, maxLength: 300));
            AddColumn("bow.pregunta_frecuente", "Pregunta", c => c.String(nullable: false, maxLength: 200));
            DropColumn("bow.pregunta_frecuente", "url");
            DropColumn("bow.pregunta_frecuente", "published_at");
            DropColumn("bow.pregunta_frecuente", "answer");
            DropColumn("bow.pregunta_frecuente", "text");
        }
    }
}
