using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("UserImage")]
    public class UserImageEntity : _BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string Guid { get; set; }

        [Required]
        [StringLength(36)]
        public string GuidUser { get; set; }

        [Required]
        public string Img64 { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public int Order { get; set; }

        [ForeignKey(nameof(GuidUser))]
        public virtual UserEntity E_User { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserImageEntity>().HasOne(e => e.E_User).WithMany(e => e.EL_UserImage).HasForeignKey(e => e.GuidUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
