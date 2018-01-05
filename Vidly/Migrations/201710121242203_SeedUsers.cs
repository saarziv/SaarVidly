namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'12f4771c-1621-483c-850c-0f2b53e28818', N'Guest@vidly.com', 0, N'AO1c7D7zJGDlC0tXOfoIRVtHkOuLU8Wdqe59rljterWuZFjoYyTNz4QcC0AKOwO2aQ==', N'b2c8651f-8c86-435e-bdb0-60a4ec2dedda', NULL, 0, 0, NULL, 1, 0, N'Guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ff4b7ed0-f4a0-4e60-b21e-77dd4b9ebcdb', N'admin@vidly.com', 0, N'ANXfdOpNLLNiGgFlTNwqNcd6XD2lKM0fFWF2ZMHmzrOSsa40MRn1WZZZJJyChnkchg==', N'0652e2fa-71e9-4f04-bb4d-79fcb83ccd4e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5073e6c4-3e94-436b-bfde-475bab43d67a', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ff4b7ed0-f4a0-4e60-b21e-77dd4b9ebcdb', N'5073e6c4-3e94-436b-bfde-475bab43d67a')

");
        }
        
        public override void Down()
        {
        }
    }
}
