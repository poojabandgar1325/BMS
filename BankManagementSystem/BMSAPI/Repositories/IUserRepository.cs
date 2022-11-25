﻿using BMSAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Repositories
{
    public interface IUserRepository
    {
        Task< IEnumerable<User>> GetAllAsync();
    }
}
