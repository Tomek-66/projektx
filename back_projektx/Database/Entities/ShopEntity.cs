using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("Shop")]
    public class ShopEntity : _BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int IdTransactionType { get; set; }

        public virtual TransactionTypeEntity E_TransactionType { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopEntity>().HasOne(e => e.E_TransactionType).WithMany(e => e.EL_Shop).HasForeignKey(e => e.IdTransactionType).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
