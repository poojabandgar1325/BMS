using BMSAPI.Data;
using BMSAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Repositories
{
    public class LoanRepository : ILoanRepository

    {
        private readonly BMSDbContext bMSDbContext;

        public LoanRepository(BMSDbContext bMSDbContext)
        {
            this.bMSDbContext = bMSDbContext;
        }
        public async Task<Loan> AddAsync(Loan loan)
        {
            await bMSDbContext.AddAsync(loan);
            await bMSDbContext.SaveChangesAsync();
            return loan;
        }

        public IEnumerable<Loan> GetAll()
        {
            return bMSDbContext.Loans
                .Include(x=>x.User)
                .ToList();
        }

        public async Task<Loan> GetSync(int id)
        {
            return await bMSDbContext.Loans.FirstOrDefaultAsync(x => x.LoanID == id);
        }

        

        public async Task<Loan> UpdateAsync(int id, Loan loan)
        {
            var existingloan = await bMSDbContext.Loans.FindAsync(id);
            if (existingloan != null)
            {
                //existingloan.LoanType = loan.LoanType;
                //existingloan.LoanAmount = loan.LoanAmount;
                //existingloan.Date = loan.Date;
                //existingloan.RateOfInterest = loan.RateOfInterest;
                //existingloan.Duration = loan.Duration;
                existingloan.Status = loan.Status;
                existingloan.Comment = loan.Comment;
               // existingloan.AccountNo = loan.AccountNo;

                await bMSDbContext.SaveChangesAsync();

                return existingloan;
            }
            return null; 

            
        }
    }
}
