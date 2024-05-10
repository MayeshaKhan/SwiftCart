namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_token : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenString = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        ExpireTime = c.DateTime(nullable: false),
                        UserRole = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tokens");
        }
    }
}
