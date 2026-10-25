using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("User")]
    public class UserEntity : _BaseEntity
    {
        [Key]
        [StringLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Guid { get; set; }

        [Required]
        public int IdType { get; set; }

        [Required]
        [StringLength(20)]
        public string Nick { get; set; }

        [StringLength(9)]
        public string? Phone { get; set; }

        public string? Password { get; set; }

        [StringLength(6)]
        public string? ValidCode { get; set; }

        public string? Img64 { get; set; }

        [StringLength(1)]
        public string? Sex { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public long? BirthdateTicks { get; set; }

        public long? LoginDateTicks { get; set; }

        [StringLength(100)]
        public string? Note { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int Prestige { get; set; }

        [Required]
        public float Money { get; set; }

        [Required]
        public int LevelCount { get; set; }

        [Required]
        public int ImageCount { get; set; }

        public virtual UserTypeEntity E_UserType { get; set; }
        public virtual ICollection<ChatMessageEntity> EL_ChatMessage { get; set; } = new List<ChatMessageEntity>();
        public virtual ICollection<ChatRoomUserEntity> EL_ChatRoomUser { get; set; } = new List<ChatRoomUserEntity>();
        public virtual ICollection<UserImageEntity> EL_UserImage { get; set; } = new List<UserImageEntity>();
        public virtual ICollection<PlaceUserEntity> EL_PlaceUser { get; set; } = new List<PlaceUserEntity>();
        public virtual ICollection<PlaceSearchEntity> EL_PlaceSearch { get; set; } = new List<PlaceSearchEntity>();
        public virtual ICollection<TransactionEntity> EL_TransactionUserSend { get; set; } = new List<TransactionEntity>();
        public virtual ICollection<TransactionEntity> EL_TransactionUserReceiver { get; set; } = new List<TransactionEntity>();
        public virtual ICollection<UserAccessEntity> EL_UserAccess { get; set; } = new List<UserAccessEntity>();
        public virtual ICollection<UserAccessEntity> EL_UserAccesFor { get; set; } = new List<UserAccessEntity>();
        public virtual ICollection<UserMessageEntity> EL_UserMessageSend { get; set; } = new List<UserMessageEntity>();
        public virtual ICollection<UserMessageEntity> EL_UserMessageReceive { get; set; } = new List<UserMessageEntity>();
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasIndex(e => e.Nick).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(e => e.Phone).IsUnique();
            modelBuilder.Entity<UserEntity>().HasOne(e => e.E_UserType).WithMany(e => e.EL_Users).HasForeignKey(e => e.IdType).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
