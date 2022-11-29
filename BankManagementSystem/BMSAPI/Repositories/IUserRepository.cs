using BMSAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Repositories
{
    public interface IUserRepository
    {
        Task< IEnumerable<User>> GetAllAsync();

        Task<User> GetAsync(int id);

        Task<User> AddAsync(User user);

        Task<User> UpdateAsync(int id, User user);
    }
}
