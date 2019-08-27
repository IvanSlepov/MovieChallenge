namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        RentID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rents");
        }
    }
}
