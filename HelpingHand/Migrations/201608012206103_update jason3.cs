namespace HelpingHand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatejason3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DriverModels", "street", c => c.String());
            AddColumn("dbo.DriverModels", "city", c => c.String());
            AddColumn("dbo.DriverModels", "state", c => c.String());
            AddColumn("dbo.DriverModels", "zip", c => c.Int());
            AddColumn("dbo.DriverModels", "driverslicense", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DriverModels", "driverslicense");
            DropColumn("dbo.DriverModels", "zip");
            DropColumn("dbo.DriverModels", "state");
            DropColumn("dbo.DriverModels", "city");
            DropColumn("dbo.DriverModels", "street");
        }
    }
}
