namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabla_cases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bow.cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 1000),
                        description = c.String(nullable: false),
                        published_at = c.DateTime(nullable: false),
                        url = c.String(),
                        image = c.String(),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("bow.cases");
        }
    }
}
