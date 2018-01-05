namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordsToMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,Genre,DateAdded,NumberInStock) VALUES ('Hangover','Comedy',CAST('2009-11-06' AS DATETIME),5)");
            Sql("INSERT INTO Movies (Name,Genre,DateAdded,NumberInStock) VALUES ('Die Hard','Action',CAST('1999-03-11' AS DATETIME),2)");
            Sql("INSERT INTO Movies (Name,Genre,DateAdded,NumberInStock) VALUES ('The Terminator','Action',CAST('1996-12-01' AS DATETIME),3)");
            Sql("INSERT INTO Movies (Name,Genre,DateAdded,NumberInStock) VALUES ('Toy Story','Family',CAST('1999-10-06' AS DATETIME),5)");
            Sql("INSERT INTO Movies (Name,Genre,DateAdded,NumberInStock) VALUES ('Titanic','Romance',CAST('1990-02-09' AS DATETIME),10)");
        }
        
        public override void Down()
        {
        }
    }
}
