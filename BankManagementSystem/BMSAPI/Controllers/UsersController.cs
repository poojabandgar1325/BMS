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
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GeAllUsers()
        {
            var users = await userRepository.GetAllAsync();

            //var usersDTO = new List<Models.DTO.User>();
            //users.ToList().ForEach(user =>
            //{
            //var userDTO = new Models.DTO.User()
            //{

            //};
            //usersDTO.Add(userDTO);

            // });

            var usersDTO= mapper.Map<List<Models.DTO.User>>(users);

            return Ok(usersDTO);

        }
        
    }
}
