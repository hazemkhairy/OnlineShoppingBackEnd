namespace OSBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified_total_cost_data_type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalCost", c => c.Int(nullable: false));
        }
    }
}
