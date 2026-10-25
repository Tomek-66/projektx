using back_projektx.Consts;
using back_projektx.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace back_projektx.Database
{
    public static class InitializeDatabase
    {
        public static void Initialize()
        {
            try
            {
                using (var db = new AppDb())
                {
                    db.Database.Migrate();

                    _insertUserType(db);
                    _insertUsers(db);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Błąd inicjalizacji danych: " + ex.Message);
            }
        }

        private static void _insertUserType(AppDb db)
        {
            if (!db.UserType.Any())
            {
                var superAdmin = new UserTypeEntity()
                {
                    Id = UserTypeConst.SuperAdmin,
                    Type = "SuperAdmin"
                };
                db.UserType.Add(superAdmin);

                var admin = new UserTypeEntity()
                {
                    Id = UserTypeConst.Admin,
                    Type = "Admin"
                };
                db.UserType.Add(admin);

                var user = new UserTypeEntity()
                {
                    Id = UserTypeConst.User,
                    Type = "User"
                };
                db.UserType.Add(user);

                var quest = new UserTypeEntity()
                {
                    Id = UserTypeConst.Quest,
                    Type = "Quest"
                };
                db.UserType.Add(quest);

                db.SaveChanges();
            }
        }

        private static void _insertUsers(AppDb db)
        {
            if (!db.User.Any())
            {
                var superAdmin = new UserEntity()
                {
                    IdType = UserTypeConst.SuperAdmin,
                    Nick = "Tomek",
                    Password = "123",
                    BirthdateTicks = null,
                    Height = null,
                    Weight = null,
                    Sex = "M",
                    ImageCount = 0,
                    Img64 = null,
                    IsActive = true,
                    LevelCount = 1,
                    LoginDateTicks = null,
                    Note = "To ja",
                    Money = 0,
                    Phone = "721554875",
                    Prestige = 0,
                    ValidCode = null,
                };
                db.User.Add(superAdmin);
                db.SaveChanges();
            }
        }
    }
}
