namespace MvcCodeFastProject_Alamgir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mg6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicineItems", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicineItems", "Description", c => c.String());
        }
    }
}
