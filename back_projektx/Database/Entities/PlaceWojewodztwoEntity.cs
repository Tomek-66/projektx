using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("PlaceWojewodztwo")]
    public class PlaceWojewodztwoEntity : _BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Name { get; set; }

        public virtual ICollection<PlacePowiatEntity> EL_Powiat { get; set; } = new List<PlacePowiatEntity>();
        public virtual ICollection<PlaceGminaEntity> EL_Gmina { get; set; } = new List<PlaceGminaEntity>();

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
