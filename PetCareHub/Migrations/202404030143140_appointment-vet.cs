namespace PetCareHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmentvet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        AppointmentTitle = c.String(),
                        AppointmentDescription = c.String(),
                        AppointmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentID);
            
            CreateTable(
                "dbo.AppointmentVeterans",
                c => new
                    {
                        Appointment_AppointmentID = c.Int(nullable: false),
                        Veteran_VeteranId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Appointment_AppointmentID, t.Veteran_VeteranId })
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentID, cascadeDelete: true)
                .ForeignKey("dbo.Veterans", t => t.Veteran_VeteranId, cascadeDelete: true)
                .Index(t => t.Appointment_AppointmentID)
                .Index(t => t.Veteran_VeteranId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentVeterans", "Veteran_VeteranId", "dbo.Veterans");
            DropForeignKey("dbo.AppointmentVeterans", "Appointment_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.AppointmentVeterans", new[] { "Veteran_VeteranId" });
            DropIndex("dbo.AppointmentVeterans", new[] { "Appointment_AppointmentID" });
            DropTable("dbo.AppointmentVeterans");
            DropTable("dbo.Appointments");
        }
    }
}
