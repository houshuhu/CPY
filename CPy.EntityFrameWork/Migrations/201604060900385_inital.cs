namespace CPy.EntityFrameWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysFunction",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FUrl = c.String(maxLength: 50),
                        FNo = c.String(maxLength: 20),
                        FName = c.String(maxLength: 50),
                        SysModuleId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysModule", t => t.SysModuleId, cascadeDelete: true)
                .Index(t => t.SysModuleId);
            
            CreateTable(
                "dbo.SysModule",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MNo = c.String(maxLength: 20),
                        MName = c.String(maxLength: 30),
                        Description = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RName = c.String(maxLength: 20),
                        RNo = c.String(maxLength: 20),
                        Description = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UName = c.String(maxLength: 20),
                        UPassWord = c.String(maxLength: 50),
                        UNo = c.String(maxLength: 20),
                        URealName = c.String(maxLength: 20),
                        UIDCard = c.String(maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysRoleSysFunctions",
                c => new
                    {
                        SysRoleId = c.Guid(nullable: false),
                        SysFunctionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SysRoleId, t.SysFunctionId })
                .ForeignKey("dbo.SysRole", t => t.SysRoleId, cascadeDelete: true)
                .ForeignKey("dbo.SysFunction", t => t.SysFunctionId, cascadeDelete: true)
                .Index(t => t.SysRoleId)
                .Index(t => t.SysFunctionId);
            
            CreateTable(
                "dbo.SysUserSysRoles",
                c => new
                    {
                        SysUserId = c.Guid(nullable: false),
                        SysRoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SysUserId, t.SysRoleId })
                .ForeignKey("dbo.SysUser", t => t.SysUserId, cascadeDelete: true)
                .ForeignKey("dbo.SysRole", t => t.SysRoleId, cascadeDelete: true)
                .Index(t => t.SysUserId)
                .Index(t => t.SysRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysUserSysRoles", "SysRoleId", "dbo.SysRole");
            DropForeignKey("dbo.SysUserSysRoles", "SysUserId", "dbo.SysUser");
            DropForeignKey("dbo.SysRoleSysFunctions", "SysFunctionId", "dbo.SysFunction");
            DropForeignKey("dbo.SysRoleSysFunctions", "SysRoleId", "dbo.SysRole");
            DropForeignKey("dbo.SysFunction", "SysModuleId", "dbo.SysModule");
            DropIndex("dbo.SysUserSysRoles", new[] { "SysRoleId" });
            DropIndex("dbo.SysUserSysRoles", new[] { "SysUserId" });
            DropIndex("dbo.SysRoleSysFunctions", new[] { "SysFunctionId" });
            DropIndex("dbo.SysRoleSysFunctions", new[] { "SysRoleId" });
            DropIndex("dbo.SysFunction", new[] { "SysModuleId" });
            DropTable("dbo.SysUserSysRoles");
            DropTable("dbo.SysRoleSysFunctions");
            DropTable("dbo.SysUser");
            DropTable("dbo.SysRole");
            DropTable("dbo.SysModule");
            DropTable("dbo.SysFunction");
        }
    }
}
