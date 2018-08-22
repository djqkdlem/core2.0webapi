using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class MysqlBoardContext : DbContext
    {
        public MysqlBoardContext(DbContextOptions<MysqlBoardContext> options)
            : base(options)
        {
        }
        public DbSet<Board> Board { get; set; }
    }
}
