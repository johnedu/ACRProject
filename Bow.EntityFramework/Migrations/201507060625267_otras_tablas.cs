namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otras_tablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bow.locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        latitude = c.String(nullable: false, maxLength: 100),
                        longitude = c.String(nullable: false, maxLength: 100),
                        distance = c.String(nullable: false, maxLength: 100),
                        description = c.String(nullable: false),
                        name = c.String(nullable: false, maxLength: 1000),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "bow.news",
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
            
            CreateTable(
                "bow.diagnostic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 1000),
                        type = c.String(),
                        advice = c.String(),
                        image = c.String(),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "bow.reporttype",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "bow.slider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "bow.driver",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        plate = c.String(),
                        type = c.String(),
                        company = c.String(),
                        observation = c.String(),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("bow.driver");
            DropTable("bow.slider");
            DropTable("bow.reporttype");
            DropTable("bow.diagnostic");
            DropTable("bow.news");
            DropTable("bow.locations");
        }
    }
}
