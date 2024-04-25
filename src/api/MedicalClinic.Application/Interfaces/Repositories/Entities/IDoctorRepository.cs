﻿using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Interfaces.Repositories.Entities
{
    public interface IRefreshTokenRepository : IRepositoryAsync<RefreshToken>
    {
    }
}
