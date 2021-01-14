namespace MvcCodeFastProject_Alamgir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mg3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicineCategory",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineItems",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(storeType: "image"),
                        EntryDate = c.DateTime(nullable: false, storeType: "date"),
                        Quantity = c.Long(nullable: false),
                        MedicineCategoryID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MedicineCategory", t => t.MedicineCategoryID, cascadeDelete: true)
                .Index(t => t.MedicineCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineItems", "MedicineCategoryID", "dbo.MedicineCategory");
            DropIndex("dbo.MedicineItems", new[] { "MedicineCategoryID" });
            DropTable("dbo.MedicineItems");
            DropTable("dbo.MedicineCategory");
        }
    }
}
