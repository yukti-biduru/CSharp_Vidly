namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNamesToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set Name='Pay As You Go' WHERE Id=1");
            Sql("UPDATE MembershipTypes set Name='Monthly' WHERE Id=2");
            Sql("UPDATE MembershipTypes set Name='Quaterly' WHERE Id=3");
            Sql("UPDATE MembershipTypes set Name='Annual' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
