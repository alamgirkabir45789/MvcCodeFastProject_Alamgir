namespace MvcCodeFastProject_Alamgir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicines", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Medicines", "PurchageDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicines", "PurchageDate");
            DropColumn("dbo.Medicines", "Price");
        }
    }
}
