using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_projektx.Database.Entities
{
    [Table("ChatRoom")]
    public class ChatRoomEntity : _BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<ChatRoomUserEntity> EL_ChatRoomUser { get; set; } = new List<ChatRoomUserEntity>();
        public virtual ICollection<ChatMessageEntity> EL_ChatMessage { get; set; } = new List<ChatMessageEntity>();

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
