namespace WebowaPomocStrona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZajeciaIdRemovedFromZadanie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Zadanies", "IdZajec");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zadanies", "IdZajec", c => c.Int(nullable: false));
        }
    }
}
