namespace WebowaPomocStrona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZajeciaIZadaniaSecondTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zadanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temat = c.String(),
                        Informacje = c.String(),
                        IdZajec = c.Int(nullable: false),
                        Termin = c.DateTime(),
                        DataDodania = c.DateTime(nullable: false),
                        CzyZrobione = c.Boolean(nullable: false),
                        Zajecia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zajecias", t => t.Zajecia_Id)
                .Index(t => t.Zajecia_Id);
            
            CreateTable(
                "dbo.Zajecias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zadanies", "Zajecia_Id", "dbo.Zajecias");
            DropIndex("dbo.Zadanies", new[] { "Zajecia_Id" });
            DropTable("dbo.Zajecias");
            DropTable("dbo.Zadanies");
        }
    }
}
