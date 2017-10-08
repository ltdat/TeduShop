namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategories", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategories", "Status");
            DropColumn("dbo.PostCategories", "MetaDescription");
            DropColumn("dbo.PostCategories", "MetaKeyword");
            DropColumn("dbo.PostCategories", "UpdatedDate");
            DropColumn("dbo.PostCategories", "UpdatedBy");
            DropColumn("dbo.PostCategories", "CreatedDate");
            DropColumn("dbo.PostCategories", "CreatedBy");
        }
    }
}
