namespace OSBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePaymentTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PaymentTypes (Name)VALUES('Cash')");
            Sql("INSERT INTO PaymentTypes (Name)VALUES('Visa')");
            Sql("INSERT INTO PaymentTypes (Name)VALUES('PayPal')");
        }
        
        public override void Down()
        {
        }
    }
}
