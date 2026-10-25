using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("PlaceGmina")]
    public class PlaceGminaEntity : _BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdWojewodztwo { get; set; }

        [Required]
        public int IdPowiat { get; set; }

        [Required]
        public int Name { get; set; }

        public virtual PlacePowiatEntity E_Powiat { get; set; }
        public virtual PlaceWojewodztwoEntity E_Wojewodztwo { get; set; }
        public virtual ICollection<PlaceSearchEntity> EL_PlaceSearch { get; set; } = new List<PlaceSearchEntity>();
        public virtual ICollection<PlaceUserEntity> EL_PlaceUser { get; set; } = new List<PlaceUserEntity>();

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaceGminaEntity>().HasOne(e => e.E_Powiat).WithMany(e => e.EL_Gmina).HasForeignKey(e => e.IdPowiat).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PlaceGminaEntity>().HasOne(e => e.E_Wojewodztwo).WithMany(e => e.EL_Gmina).HasForeignKey(e => e.IdWojewodztwo).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
