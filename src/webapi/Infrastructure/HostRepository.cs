using System.Collections.Generic;
using System.Threading.Tasks;
using EFMultiThread.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFMultiThread.Infrastructure
{
    public class HostRepository
    {
        private readonly DbContextOptions options;

        public HostRepository(DbContextOptions options)
        {
            this.options = options;
        }

        public Task<List<Host>> GetAllAsync()
        {
            var context = new EFContext(this.options);
            return context.Set<Host>().ToListAsync();
        }
    }
}