using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("UserAccess")]
    public class UserAccessEntity : _BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string Guid { get; set; }

        [Required]
        [StringLength(36)]
        public string GuidUser { get; set; }

        [Required]
        [StringLength(36)]
        public string GuidUserFor { get; set; }

        [Required]
        public int Level { get; set; }

        public virtual UserEntity E_User { get; set; }
        public virtual UserEntity E_UserFor { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccessEntity>().HasOne(e => e.E_User).WithMany(e => e.EL_UserAccess).HasForeignKey(e => e.GuidUser).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserAccessEntity>().HasOne(e => e.E_UserFor).WithMany(e => e.EL_UserAccesFor).HasForeignKey(e => e.GuidUserFor).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
