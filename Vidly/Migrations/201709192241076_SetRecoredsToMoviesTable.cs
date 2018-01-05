namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetRecoredsToMoviesTable2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (GenreId,Name,DateAdded,ReleaseDate,NumberInStock) VALUES (1,'Hangover',CAST('2015-12-1' AS DATETIME),CAST('2009-11-06' AS DATETIME),5)");
            Sql("INSERT INTO Movies (GenreId,Name,DateAdded,ReleaseDate,NumberInStock) VALUES (2,'Die Hard',CAST('1999-01-01' AS DATETIME),CAST('2016-11-06' AS DATETIME),2)");
            Sql("INSERT INTO Movies (GenreId,Name,DateAdded,ReleaseDate,NumberInStock) VALUES (2,'The Terminator',CAST('2001-01-01' AS DATETIME),CAST('2015-04-10' AS DATETIME),4)");
            Sql("INSERT INTO Movies (GenreId,Name,DateAdded,ReleaseDate,NumberInStock) VALUES (3,'Toy Story',CAST('1996-06-10' AS DATETIME),CAST('2003-04-10' AS DATETIME),1)");
            Sql("INSERT INTO Movies (GenreId,Name,DateAdded,ReleaseDate,NumberInStock) VALUES (4,'Titanic',CAST('1992-09-22' AS DATETIME),CAST('2003-10-06' AS DATETIME),10)");
        }
        
        public override void Down()
        {
        }
    }
}
