namespace WebowaPomocStrona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedZajeciaIdToZadanie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Zadanies", "Zajecia_Id", "dbo.Zajecias");
            DropIndex("dbo.Zadanies", new[] { "Zajecia_Id" });
            RenameColumn(table: "dbo.Zadanies", name: "Zajecia_Id", newName: "ZajeciaId");
            AlterColumn("dbo.Zadanies", "ZajeciaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Zadanies", "ZajeciaId");
            AddForeignKey("dbo.Zadanies", "ZajeciaId", "dbo.Zajecias", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zadanies", "ZajeciaId", "dbo.Zajecias");
            DropIndex("dbo.Zadanies", new[] { "ZajeciaId" });
            AlterColumn("dbo.Zadanies", "ZajeciaId", c => c.Int());
            RenameColumn(table: "dbo.Zadanies", name: "ZajeciaId", newName: "Zajecia_Id");
            CreateIndex("dbo.Zadanies", "Zajecia_Id");
            AddForeignKey("dbo.Zadanies", "Zajecia_Id", "dbo.Zajecias", "Id");
        }
    }
}
