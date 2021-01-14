namespace MvcCodeFastProject_Alamgir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mg5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InternDoctors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.InternDoctors", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.InternDoctors", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.InternDoctors", "ContactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Medicines", "MedicineName", c => c.String(nullable: false));
            AlterColumn("dbo.Nurses", "NurseName", c => c.String(nullable: false));
            AlterColumn("dbo.Nurses", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Nurses", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Nurses", "ContactNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nurses", "ContactNo", c => c.String());
            AlterColumn("dbo.Nurses", "Email", c => c.String());
            AlterColumn("dbo.Nurses", "Address", c => c.String());
            AlterColumn("dbo.Nurses", "NurseName", c => c.String());
            AlterColumn("dbo.Medicines", "MedicineName", c => c.String());
            AlterColumn("dbo.InternDoctors", "ContactNo", c => c.String());
            AlterColumn("dbo.InternDoctors", "Email", c => c.String());
            AlterColumn("dbo.InternDoctors", "Address", c => c.String());
            AlterColumn("dbo.InternDoctors", "Name", c => c.String());
        }
    }
}
