namespace WebowaPomocStrona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToZajeciaAndZadania : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zadanies", "IdUzytkownika", c => c.String());
            AddColumn("dbo.Zajecias", "IdUzytkownika", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zajecias", "IdUzytkownika");
            DropColumn("dbo.Zadanies", "IdUzytkownika");
        }
    }
}
