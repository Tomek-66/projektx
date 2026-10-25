using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace back_projektx.Database.Entities
{
    public abstract class _BaseEntity
    {
        public abstract void OnModelCreating(ModelBuilder modelBuilder);
    }
}
