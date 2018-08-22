using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace api.Model
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options)
            : base(options)
        {
        }

        // 테이블 명과 일치 해야 함
        public DbSet<Board> Board { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}