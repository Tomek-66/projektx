using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("UserType")]
    public class UserTypeEntity : _BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        public virtual ICollection<UserEntity> EL_Users { get; set; } = new List<UserEntity>();

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
