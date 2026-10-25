using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("TransactionType")]
    public class TransactionTypeEntity : _BaseEntity

    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        public virtual ICollection<ShopEntity> EL_Shop { get; set; } = new List<ShopEntity>();
        public virtual ICollection<TransactionEntity> EL_Transaction { get; set; } = new List<TransactionEntity>();

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
