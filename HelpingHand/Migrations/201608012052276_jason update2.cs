namespace HelpingHand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jasonupdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "zip", c => c.Int());
            AlterColumn("dbo.CustomerModels", "UserID", c => c.String());
            AlterColumn("dbo.CustomerModels", "rating", c => c.Int());
            AlterColumn("dbo.DriverModels", "UserID", c => c.String());
            AlterColumn("dbo.DriverModels", "geoTag", c => c.Int());
            AlterColumn("dbo.DriverModels", "rating", c => c.Int());
            AlterColumn("dbo.DriverModels", "rangePreference", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DriverModels", "rangePreference", c => c.Int(nullable: false));
            AlterColumn("dbo.DriverModels", "rating", c => c.Int(nullable: false));
            AlterColumn("dbo.DriverModels", "geoTag", c => c.Int(nullable: false));
            AlterColumn("dbo.DriverModels", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerModels", "rating", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerModels", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerModels", "zip", c => c.Int(nullable: false));
        }
    }
}
