namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a95a8dcb-3949-4ae8-9aad-a66fa0b76d3d', N'admin1@vidly.com', 0, N'AGZrb7tVf51R7c7a9G0NlbtLBIXwTdBTEdVjeHmyr3fxFkRbySv6L2XY/wC39qyhSQ==', N'79aa8f71-a9a7-453a-970f-f1ced9b3c35a', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de2ecdd0-5d29-4afe-8200-ca45c1f46a71', N'guest@vidly.com', 0, N'AAYi1etqTbSRIs98jGJQNjOm5QoBPOxgmtUzi5ISFa47TxsCIjnV7xj7l88nZFLqtQ==', N'f1895b85-feaf-433e-b419-cd78feabcec7', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0d25ddaa-b338-4a23-974d-43577f1417c3', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a95a8dcb-3949-4ae8-9aad-a66fa0b76d3d', N'0d25ddaa-b338-4a23-974d-43577f1417c3')
                ");
        }

        public override void Down()
        {
        }
    }
}
