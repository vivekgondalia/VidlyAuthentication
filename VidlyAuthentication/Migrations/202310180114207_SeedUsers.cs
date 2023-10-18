namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'665f3bc0-fc20-4921-bdcd-ba59c36446e8', N'guest@vidly.com', 0, N'AL7fELnFLjXJlKzxNb5eeZOnhg0aktOGddU+Ny3H5I2PELFKyPE6Y8hbJY3OJ0AlqA==', N'55a31268-2ae5-40ff-8606-1cafbbc3e3c0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9624e001-3011-4024-92e1-55f0f70e5171', N'vivekgondalia@gmail.com', 0, N'AEg7XGxHUFNSjqHzAjXtvRmsdoOYT7BE47x4MzzpAdmG2tWaAfQqcy24Iu4Dyj+OFw==', N'66a091da-a3d3-4c01-8a6f-886ef173a14a', NULL, 0, 0, NULL, 1, 0, N'vivekgondalia@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9e33279e-a2df-41b5-afa6-0c9f44d87351', N'admin@vidly.com', 0, N'AAwmfgaR9PPIb0EJx3RpRN1hsGsl+cYT0H8d6POohiZbxPkYB2lzHzEbOfb7+ZOtIg==', N'3d5a4220-6253-4257-b232-ed9d0f99551e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7f4fe414-b5e8-4fa7-b546-cb2aeca01b25', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9e33279e-a2df-41b5-afa6-0c9f44d87351', N'7f4fe414-b5e8-4fa7-b546-cb2aeca01b25')

");
        }
        
        public override void Down()
        {

        }
    }
}
