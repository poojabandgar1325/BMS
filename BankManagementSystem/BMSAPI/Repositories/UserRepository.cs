using BMSAPI.Data;
using BMSAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(BMSDbContext bMSDbContext)
        {
            this.bMSDbContext = bMSDbContext;
        }

        public BMSDbContext bMSDbContext { get; }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await bMSDbContext.Users.ToListAsync();
        }
    }
}
