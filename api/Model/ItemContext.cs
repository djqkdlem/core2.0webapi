using Microsoft.EntityFrameworkCore;

namespace api.Model
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
        }

        // 테이블 명과 일치 해야 함
        public DbSet<Item> Item { get; set; }
    }
}