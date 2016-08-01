namespace HelpingHand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        street = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zip = c.Int(nullable: false),
                        email = c.String(),
                        UserID = c.Int(nullable: false),
                        rating = c.Int(nullable: false),
                        status = c.String(),
                        registrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DriverModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                        UserID = c.Int(nullable: false),
                        geoTag = c.Int(nullable: false),
                        rating = c.Int(nullable: false),
                        status = c.String(),
                        rangePreference = c.Int(nullable: false),
                        registrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        payment = c.Single(nullable: false),
                        fee = c.Single(nullable: false),
                        orderDetails = c.String(),
                        timeFrame = c.DateTime(nullable: false),
                        CustomerID_ID = c.Int(),
                        DestLocation_ID = c.Int(),
                        DriverID_ID = c.Int(),
                        startLocation_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerModels", t => t.CustomerID_ID)
                .ForeignKey("dbo.CustomerModels", t => t.DestLocation_ID)
                .ForeignKey("dbo.DriverModels", t => t.DriverID_ID)
                .ForeignKey("dbo.DriverModels", t => t.startLocation_ID)
                .Index(t => t.CustomerID_ID)
                .Index(t => t.DestLocation_ID)
                .Index(t => t.DriverID_ID)
                .Index(t => t.startLocation_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderModels", "startLocation_ID", "dbo.DriverModels");
            DropForeignKey("dbo.OrderModels", "DriverID_ID", "dbo.DriverModels");
            DropForeignKey("dbo.OrderModels", "DestLocation_ID", "dbo.CustomerModels");
            DropForeignKey("dbo.OrderModels", "CustomerID_ID", "dbo.CustomerModels");
            DropIndex("dbo.OrderModels", new[] { "startLocation_ID" });
            DropIndex("dbo.OrderModels", new[] { "DriverID_ID" });
            DropIndex("dbo.OrderModels", new[] { "DestLocation_ID" });
            DropIndex("dbo.OrderModels", new[] { "CustomerID_ID" });
            DropTable("dbo.OrderModels");
            DropTable("dbo.DriverModels");
            DropTable("dbo.CustomerModels");
        }
    }
}
