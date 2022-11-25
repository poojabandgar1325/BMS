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

        public async Task<User> AddAsync(User user)
        {
            
            await bMSDbContext.AddAsync(user);
            await bMSDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await bMSDbContext.Users.ToListAsync();
        }

        public async Task<User> GetSync(int id)
        {
            return await bMSDbContext.Users.FirstOrDefaultAsync(x => x.AccountNo == id);
            
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            var existinguser = await bMSDbContext.Users.FirstOrDefaultAsync(x => x.AccountNo == id);
            if(existinguser == null)
            {
                return null;
            }

            existinguser.Name = user.Name;
            existinguser.UserName = user.UserName;
            existinguser.Password = user.Password;
            existinguser.Address = user.Address;
            existinguser.Country = user.Country;
            existinguser.State = user.State;
            existinguser.EmailID = user.EmailID;
            existinguser.PAN = user.PAN;
            existinguser.ContactNo = user.ContactNo;
            existinguser.DOB = user.DOB;
            existinguser.AccountType = user.AccountType;

            await bMSDbContext.SaveChangesAsync();

            return existinguser;

        }
    }
}
