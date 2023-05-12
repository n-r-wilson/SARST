namespace SARST_DEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableServices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                        title = c.String(),
                        description = c.String(),
                        date_effective = c.DateTime(nullable: false),
                        date_discontinued = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DisciplinaryActions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                        stay_id = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        notes = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProvidedServices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        service_id = c.Int(nullable: false),
                        stay_id = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Residents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        last_name = c.String(),
                        date_of_birth = c.DateTime(nullable: false),
                        sex = c.Int(nullable: false),
                        gender = c.Int(nullable: false),
                        pronouns = c.Int(nullable: false),
                        distinguishing_features = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ResidentStays",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        resident_id = c.Int(nullable: false),
                        dateTime_in = c.DateTime(nullable: false),
                        dateTime_out = c.DateTime(nullable: false),
                        provider_id = c.Int(nullable: false),
                        events = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SARSTUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                        username = c.String(),
                        password = c.String(),
                        email_address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SARSTUsers");
            DropTable("dbo.ResidentStays");
            DropTable("dbo.Residents");
            DropTable("dbo.ProvidedServices");
            DropTable("dbo.DisciplinaryActions");
            DropTable("dbo.AvailableServices");
        }
    }
}
