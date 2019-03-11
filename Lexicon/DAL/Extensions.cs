using System.Data.Entity;
using System.Linq;
using Ikco.Data;

namespace Lexicon.DAL
{
    public static class Extensions
    {
        public static MyDbContext Reset(this MyDbContext context)
        {
            var entries = context.ChangeTracker
                .Entries()
                .Where(e => e.State != EntityState.Unchanged)
                .ToArray();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
            return context;
        }

    }
}