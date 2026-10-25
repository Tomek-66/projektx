using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("PlaceSearch")]
    public class PlaceSearchEntity : _BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string Guid { get; set; }

        [Required]
        [StringLength(36)]
        public string GuidUser { get; set; }

        [Required]
        public int IdPlaceGmina { get; set; }

        public virtual UserEntity E_User { get; set; }
        public virtual PlaceGminaEntity E_Gmina { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaceSearchEntity>().HasOne(e => e.E_User).WithMany(e => e.EL_PlaceSearch).HasForeignKey(e => e.GuidUser).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PlaceSearchEntity>().HasOne(e => e.E_Gmina).WithMany(e => e.EL_PlaceSearch).HasForeignKey(e => e.IdPlaceGmina).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
