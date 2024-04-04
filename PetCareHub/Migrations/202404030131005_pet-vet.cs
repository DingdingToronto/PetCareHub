namespace PetCareHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class petvet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "VeteranID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "VeteranID");
            AddForeignKey("dbo.Pets", "VeteranID", "dbo.Veterans", "VeteranId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "VeteranID", "dbo.Veterans");
            DropIndex("dbo.Pets", new[] { "VeteranID" });
            DropColumn("dbo.Pets", "VeteranID");
        }
    }
}
