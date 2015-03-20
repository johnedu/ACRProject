namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabla_faqs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bow.pregunta_frecuente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pregunta = c.String(nullable: false, maxLength: 200),
                        Respuesta = c.String(nullable: false, maxLength: 300),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("bow.pregunta_frecuente");
        }
    }
}
