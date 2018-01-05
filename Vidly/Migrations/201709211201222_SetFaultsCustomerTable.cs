namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetFaultsCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("Delete Customers WHERE id=2");
        }
        
        public override void Down()
        {
        }
    }
}
