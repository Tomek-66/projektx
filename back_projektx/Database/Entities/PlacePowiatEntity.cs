using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("PlacePowiat")]
    public class PlacePowiatEntity : _BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdWojewodztwo { get; set; }

        [Required]
        public int Name { get; set; }
        public virtual PlaceWojewodztwoEntity E_Wojewodztwo { get; set; }

        public virtual ICollection<PlaceGminaEntity> EL_Gmina { get; set; } = new List<PlaceGminaEntity>();

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlacePowiatEntity>().HasOne(e => e.E_Wojewodztwo).WithMany(e => e.EL_Powiat).HasForeignKey(e => e.IdWojewodztwo).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
