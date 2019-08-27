namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentAddingUserFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Rents", "UserID");
            AddForeignKey("dbo.Rents", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "UserID", "dbo.Users");
            DropIndex("dbo.Rents", new[] { "UserID" });
        }
    }
}
