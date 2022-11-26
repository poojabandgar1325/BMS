using AutoMapper;
using BMSAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Controllers
{
    [ApiController]
    [Route("Loans")]
    public class LoansController : Controller
    {
        private readonly ILoanRepository loanRepository;
        private readonly IMapper mapper;

        public LoansController(ILoanRepository loanRepository, IMapper mapper)
        {
            this.loanRepository = loanRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllLoans()
        {
            var loans = loanRepository.GetAll();
            var loanDTO = mapper.Map<List<Models.DTO.Loan>>(loans);
            // return (IActionResult)loanRepository.GetAll();
            return Ok(loanDTO);
        }

        [HttpGet]
        [Route("{loanId:int}")]
        [ActionName("GetLoanAsync")]
        public async Task<IActionResult> GetLoanAsync(int loanId)
        {
            var loan = await loanRepository.GetSync(loanId);

            if (loan == null)
            {
                return NotFound();
            }
            var loanDTO = mapper.Map<Models.DTO.Loan>(loan);

            return Ok(loanDTO);

        }

        [HttpPost]
        public async Task<IActionResult> AddLoanAsync(Models.DTO.AddLoanRequest addLoanRequest)
        {
            var loan = new Models.Domain.Loan()
            {
                LoanType = addLoanRequest.LoanType,
                LoanAmount = addLoanRequest.LoanAmount,
                Date = addLoanRequest.Date,
                RateOfInterest = addLoanRequest.RateOfInterest,
                Duration = addLoanRequest.Duration,
                AccountNo = addLoanRequest.AccountNo
            };
            loan = await loanRepository.AddAsync(loan);

            var loanDTO = new Models.DTO.Loan
            {
                LoanType = loan.LoanType,
                LoanAmount = loan.LoanAmount,
                Date = loan.Date,
                RateOfInterest = loan.RateOfInterest,
                Duration = loan.Duration,
                AccountNo = loan.AccountNo
            };

            return CreatedAtAction(nameof(GetLoanAsync), new { loanId = loanDTO.LoanID }, loanDTO);
            // return Ok(userDTO);
        }

        [HttpPut]
        [Route("{loanId:int}")]
        public async Task<IActionResult> UpdateLoanAsync([FromRoute] int loanId, [FromBody] Models.DTO.UpdateLoanRequest updateLoanRequest)

        {
            var loan = new Models.Domain.Loan
            {
                Status = updateLoanRequest.Status,
                Comment = updateLoanRequest.Comment
            };
                
            loan = await loanRepository.UpdateAsync(loanId, loan);

            if (loan == null)
            {
                return NotFound();
            }

            var loanDTO = new Models.DTO.Loan
            {
                Status = loan.Status,
                Comment = loan.Comment,
            };

            return Ok(loanDTO);

        }

    }
}
