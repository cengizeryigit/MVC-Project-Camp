namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "ContentValue", c => c.String(maxLength: 1001));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "ContentValue", c => c.String(maxLength: 1000));
        }
    }
}
