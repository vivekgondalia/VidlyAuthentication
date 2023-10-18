namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES (1, 'Action')");
            Sql("INSERT INTO Genres VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres VALUES (3, 'Family')");
            Sql("INSERT INTO Genres VALUES (4, 'Horror')");
            Sql("INSERT INTO Genres VALUES (5, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
