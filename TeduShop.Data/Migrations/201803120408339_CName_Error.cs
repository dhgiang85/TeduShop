namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CName_Error : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Error", newName: "Errors");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Errors", newName: "Error");
        }
    }
}
