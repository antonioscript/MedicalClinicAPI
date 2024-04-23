using MedicalClinic.Application.DTOs.Identity;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Interfaces.Shared
{
    public interface IIdentityService
    {
        Task<Result<UserResponse>> Register(RegisterRequest request);
        Task<Result<UserResponse>> SignIn(LoginRequest request);
        Task<TokenResponse> GenerateToken(IdentityUser user);
        Task<Result<UserResponse>> GetTokenByRefresh(string token);
    }
}
