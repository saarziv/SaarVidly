namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAvailabilityToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Availability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Availability");
        }
    }
}
