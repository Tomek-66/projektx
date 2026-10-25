using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("UserMessage")]
    public class UserMessageEntity : _BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string Guid { get; set; }

        [Required]
        [StringLength(36)]
        public string GuidUserSend { get; set; }

        [Required]
        [StringLength(36)]
        public string GuidUserReceive { get; set; }

        [StringLength(255)]
        public string? Message { get; set; }

        [Required]
        public long DatetimeTicks { get; set; }

        public string? Img64 { get; set; }

        public virtual UserEntity E_UserSend { get; set; }

        public virtual UserEntity E_UserReceive { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessageEntity>().HasOne(e => e.E_UserSend).WithMany(e => e.EL_UserMessageSend).HasForeignKey(e => e.GuidUserSend).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserMessageEntity>().HasOne(e => e.E_UserReceive).WithMany(e => e.EL_UserMessageReceive).HasForeignKey(e => e.GuidUserReceive).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
