namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentAddingMovieFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Rents", "MovieID");
            AddForeignKey("dbo.Rents", "MovieID", "dbo.Movies", "MovieID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "MovieID", "dbo.Movies");
            DropIndex("dbo.Rents", new[] { "MovieID" });
        }
    }
}
