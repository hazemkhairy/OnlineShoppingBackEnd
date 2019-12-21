namespace OSBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_total_cost_to_order_class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalCost");
        }
    }
}
