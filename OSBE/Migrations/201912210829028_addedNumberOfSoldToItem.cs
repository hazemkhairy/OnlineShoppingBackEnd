namespace OSBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNumberOfSoldToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "NumberOfSold", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "NumberOfSold");
        }
    }
}
