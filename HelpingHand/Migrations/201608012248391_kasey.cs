namespace HelpingHand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kasey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "UserID", c => c.String());
            AlterColumn("dbo.DriverModels", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DriverModels", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerModels", "UserID", c => c.Int(nullable: false));
        }
    }
}
