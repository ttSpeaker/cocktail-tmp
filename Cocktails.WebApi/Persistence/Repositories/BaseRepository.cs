using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cocktails.WebApi.Persistence.Contexts;

namespace Cocktails.WebApi.Persistence.Repositories
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
