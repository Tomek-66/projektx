using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("Transaction")]
    public class TransactionEntity : _BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string Guid { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int IdType { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public long DatetimeTicks { get; set; }

        [StringLength(36)]
        public string? GuidUserSend { get; set; }

        [StringLength(36)]
        public string? GuidUserReceiver { get; set; }

        public int? Value { get; set; }
        public virtual TransactionTypeEntity E_TransactionType { get; set; }
        public virtual UserEntity E_UserSend { get; set; }
        public virtual UserEntity E_UserReceiver { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>().HasOne(e => e.E_TransactionType).WithMany(e => e.EL_Transaction).HasForeignKey(e => e.IdType).OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<TransactionEntity>().HasOne(e => e.E_UserSend).WithMany(e => e.EL_TransactionUserSend).HasForeignKey(e => e.GuidUserSend).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TransactionEntity>().HasOne(e => e.E_UserReceiver).WithMany(e => e.EL_TransactionUserReceiver).HasForeignKey(e => e.GuidUserReceiver).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
