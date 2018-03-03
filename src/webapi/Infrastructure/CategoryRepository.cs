using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFMultiThread.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFMultiThread.Infrastructure
{
    public class CategoryRepository
    {
        private readonly DbContextOptions options;

        public CategoryRepository(DbContextOptions options)
        {
            this.options = options;
        }

        public Task<List<Category>> GetAllAsync(Guid organizationId)
        {
            var context = new EFContext(this.options);
            return context.Set<Category>().Where(c => c.OrganizationId.Equals(organizationId)).ToListAsync();
        }
    }
}