using back_projektx.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace back_projektx.Database
{
    public class AppDb : DbContext
    {
        #region User

        public DbSet<UserAccessEntity> UserAccess { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserImageEntity> UserImage { get; set; }
        public DbSet<UserMessageEntity> UserMessage { get; set; }
        public DbSet<UserTypeEntity> UserType { get; set; }

        #endregion


        #region Chat

        public DbSet<ChatMessageEntity> ChatMessage { get; set; }
        public DbSet<ChatRoomEntity> ChatRoom { get; set; }
        public DbSet<ChatRoomUserEntity> ChatRoomUser { get; set; }

        #endregion


        #region Place

        public DbSet<PlaceGminaEntity> PlaceGmina { get; set; }
        public DbSet<PlacePowiatEntity> PlacePowiat { get; set; }
        public DbSet<PlaceSearchEntity> PlaceSearch { get; set; }
        public DbSet<PlaceUserEntity> PlaceUser { get; set; }
        public DbSet<PlaceWojewodztwoEntity> PlaceWojewodztwo { get; set; }

        #endregion


        #region Transaction

        public DbSet<ShopEntity> Shop { get; set; }
        public DbSet<TransactionEntity> Transaction { get; set; }
        public DbSet<TransactionTypeEntity> TransactionType { get; set; }

        #endregion



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string conn = DbConfig.createConnectionString();
            optionsBuilder.UseNpgsql(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var properties = GetType().GetProperties();

            foreach (var prop in properties)
            {
                var generics = prop.PropertyType.GenericTypeArguments;

                if (generics.Length == 1)
                {
                    if (generics[0].IsSubclassOf(typeof(_BaseEntity)))
                    {
                        var instance = Activator.CreateInstance(generics[0]) as _BaseEntity;
                        if (instance != null)
                        {
                            instance.OnModelCreating(modelBuilder);
                        }
                    }
                }
            }
        }
    }
}
