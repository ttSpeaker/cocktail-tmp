using Cocktails.Persistence.Contexts;

namespace Cocktails.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository (AppDbContext context)
        {
            _context = context;
        }
    }
}
