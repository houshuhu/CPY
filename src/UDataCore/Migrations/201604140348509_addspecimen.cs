namespace UDataCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspecimen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specimen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specimen");
        }
    }
}
