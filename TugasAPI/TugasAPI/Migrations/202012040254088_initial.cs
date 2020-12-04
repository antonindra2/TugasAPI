namespace TugasAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeptId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: false)
                .Index(t => t.DeptId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LevelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "LevelId", "dbo.Levels");
            DropIndex("dbo.Employees", new[] { "LevelId" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropTable("dbo.Levels");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
