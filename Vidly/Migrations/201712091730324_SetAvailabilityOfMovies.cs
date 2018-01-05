namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetAvailabilityOfMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE movies SET Availability = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
