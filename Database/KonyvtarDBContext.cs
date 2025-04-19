using Microsoft.EntityFrameworkCore;

namespace KonyvtarAPI
{
    public class KonyvtarDBContext : DbContext
    {
        public KonyvtarDBContext(DbContextOptions<KonyvtarDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Konyvek> Konyvek { get; set; }
        public virtual DbSet<Kolcsonzes> Kolcsonzesek { get; set; }
        public virtual DbSet<Olvasok> Olvasok { get; set; }
    }
}
