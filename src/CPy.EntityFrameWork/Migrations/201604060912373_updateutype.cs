namespace CPy.EntityFrameWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateutype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SysUser", "UType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SysUser", "UType", c => c.Int(nullable: false));
        }
    }
}
