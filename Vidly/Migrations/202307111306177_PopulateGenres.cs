namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into Genres (Name) VALUES ('Action')");
            Sql("INSERT into Genres (Name) VALUES ('Comedy')");
            Sql("INSERT into Genres (Name) VALUES ('Thriller')");
            Sql("INSERT into Genres (Name) VALUES ('Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
