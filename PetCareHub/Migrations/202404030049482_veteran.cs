namespace PetCareHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class veteran : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Veterans",
                c => new
                    {
                        VeteranId = c.Int(nullable: false, identity: true),
                        VeteranName = c.String(),
                        VeteranPlace = c.String(),
                    })
                .PrimaryKey(t => t.VeteranId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Veterans");
        }
    }
}
