namespace Bow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas_usuario_mensaje_pregunta_respuesta_tipo_puntaje_dimension_juego : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bow.juego",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "bow.pregunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false, maxLength: 300),
                        JuegoId = c.Int(nullable: false),
                        DimensionId = c.Int(nullable: false),
                        Nivel = c.String(nullable: false, maxLength: 1),
                        Pista = c.String(nullable: false, maxLength: 300),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("bow.dimension", t => t.DimensionId)
                .ForeignKey("bow.juego", t => t.JuegoId)
                .Index(t => t.JuegoId)
                .Index(t => t.DimensionId);
            
            CreateTable(
                "bow.dimension",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "bow.puntaje",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuariod = c.Int(nullable: false),
                        PreguntaId = c.Int(nullable: false),
                        PuntajeValor = c.Int(nullable: false),
                        Respuesta = c.String(nullable: false, maxLength: 300),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("bow.usuario", t => t.Usuariod)
                .ForeignKey("bow.pregunta", t => t.PreguntaId)
                .Index(t => t.Usuariod)
                .Index(t => t.PreguntaId);
            
            CreateTable(
                "bow.usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coda = c.String(nullable: false, maxLength: 200),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        TipoId = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("bow.tipo", t => t.TipoId)
                .Index(t => t.TipoId);
            
            CreateTable(
                "bow.mensaje",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioEmisorId = c.Int(nullable: false),
                        UsuarioReceptorId = c.Int(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 200),
                        Contenido = c.String(nullable: false, maxLength: 1000),
                        FueLeido = c.Boolean(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("bow.usuario", t => t.UsuarioEmisorId)
                .ForeignKey("bow.usuario", t => t.UsuarioReceptorId)
                .Index(t => t.UsuarioEmisorId)
                .Index(t => t.UsuarioReceptorId);
            
            CreateTable(
                "bow.tipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "bow.respuesta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false, maxLength: 200),
                        Comodin50_50 = c.Boolean(nullable: false),
                        RespuestaVerdadera = c.Boolean(nullable: false),
                        PreguntaId = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("bow.pregunta", t => t.PreguntaId)
                .Index(t => t.PreguntaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("bow.pregunta", "JuegoId", "bow.juego");
            DropForeignKey("bow.respuesta", "PreguntaId", "bow.pregunta");
            DropForeignKey("bow.puntaje", "PreguntaId", "bow.pregunta");
            DropForeignKey("bow.usuario", "TipoId", "bow.tipo");
            DropForeignKey("bow.puntaje", "Usuariod", "bow.usuario");
            DropForeignKey("bow.mensaje", "UsuarioReceptorId", "bow.usuario");
            DropForeignKey("bow.mensaje", "UsuarioEmisorId", "bow.usuario");
            DropForeignKey("bow.pregunta", "DimensionId", "bow.dimension");
            DropIndex("bow.respuesta", new[] { "PreguntaId" });
            DropIndex("bow.mensaje", new[] { "UsuarioReceptorId" });
            DropIndex("bow.mensaje", new[] { "UsuarioEmisorId" });
            DropIndex("bow.usuario", new[] { "TipoId" });
            DropIndex("bow.puntaje", new[] { "PreguntaId" });
            DropIndex("bow.puntaje", new[] { "Usuariod" });
            DropIndex("bow.pregunta", new[] { "DimensionId" });
            DropIndex("bow.pregunta", new[] { "JuegoId" });
            DropTable("bow.respuesta");
            DropTable("bow.tipo");
            DropTable("bow.mensaje");
            DropTable("bow.usuario");
            DropTable("bow.puntaje");
            DropTable("bow.dimension");
            DropTable("bow.pregunta");
            DropTable("bow.juego");
        }
    }
}
