namespace HelpingHand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carlos : DbMigration
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderModels", "startLocation_ID", "dbo.DriverModels");
            DropForeignKey("dbo.OrderModels", "DriverID_ID", "dbo.DriverModels");
            DropForeignKey("dbo.OrderModels", "DestLocation_ID", "dbo.CustomerModels");
            DropForeignKey("dbo.OrderModels", "CustomerID_ID", "dbo.CustomerModels");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderModels", new[] { "startLocation_ID" });
            DropIndex("dbo.OrderModels", new[] { "DriverID_ID" });
            DropIndex("dbo.OrderModels", new[] { "DestLocation_ID" });
            DropIndex("dbo.OrderModels", new[] { "CustomerID_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderModels");
            DropTable("dbo.DriverModels");
            DropTable("dbo.CustomerModels");
        }
    }
}
