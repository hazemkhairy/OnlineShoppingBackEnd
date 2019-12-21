namespace OSBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedColumnsConstrintInItem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Items", "Descripition", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Descripition", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
