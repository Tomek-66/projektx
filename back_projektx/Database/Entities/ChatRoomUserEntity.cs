using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("ChatRoomUser")]
    public class ChatRoomUserEntity : _BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string Guid { get; set; }

        [Required]
        public int IdRoom { get; set; }

        [Required]
        [StringLength(36)]
        public string GuidUser { get; set; }

        [Required]
        public long ActiveTicks { get; set; }

        public virtual ChatRoomEntity E_ChatRoom { get; set; }

        public virtual UserEntity E_User { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatRoomUserEntity>().HasOne(e => e.E_ChatRoom).WithMany(e => e.EL_ChatRoomUser).HasForeignKey(e => e.IdRoom).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ChatRoomUserEntity>().HasOne(e => e.E_User).WithMany(e => e.EL_ChatRoomUser).HasForeignKey(e => e.GuidUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
