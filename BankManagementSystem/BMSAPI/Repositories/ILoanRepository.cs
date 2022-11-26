using BMSAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Repositories
{
    public interface ILoanRepository
    {
        IEnumerable<Loan> GetAll();

        Task<Loan> GetSync(int id);

        Task<Loan> AddAsync(Loan loan);

        Task<Loan> UpdateAsync(int id, Loan loan);
    }
}
